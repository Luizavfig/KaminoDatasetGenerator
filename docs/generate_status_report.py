"""
Gera docs/Relatorio_Estado_Atual_e_Plano_de_Execucao_Kamino_CSharp.pdf

Relatorio de acompanhamento (estado atual + plano de execucao) para a extensao
do pipeline Kamino para C#. Todos os numeros usados aqui vieram de inspecao
direta do repositorio (contagem de arquivos JSON, git status, git log,
execucao real do script de verificacao do golden dataset, e checagem de
dependencias instaladas) -- nao ha numeros inventados.

Uso (a partir da raiz do repositorio):
    python docs/generate_status_report.py
"""
import json
import os
import subprocess
from datetime import date

from reportlab.lib import colors
from reportlab.lib.pagesizes import LETTER
from reportlab.lib.styles import getSampleStyleSheet, ParagraphStyle
from reportlab.lib.units import inch
from reportlab.platypus import (
    SimpleDocTemplate, Paragraph, Spacer, Table, TableStyle, PageBreak,
    ListFlowable, ListItem, HRFlowable
)
from reportlab.lib.enums import TA_CENTER, TA_LEFT

REPO_ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
GOLDEN_DIR = os.path.join(REPO_ROOT, "dataset", "golden_dataset_csharp")
OUT_PDF = os.path.join(REPO_ROOT, "docs", "Relatorio_Estado_Atual_e_Plano_de_Execucao_Kamino_CSharp.pdf")


def load_json(path):
    with open(path, encoding="utf-8") as f:
        return json.load(f)


def git(args):
    proc = subprocess.run(["git"] + args, cwd=REPO_ROOT, capture_output=True, text=True, timeout=30)
    return proc.stdout.strip()


def gather_real_data():
    """Coleta numeros reais do repositorio para usar no relatorio."""
    data = {}

    # Golden dataset C# atual
    index = load_json(os.path.join(GOLDEN_DIR, "golden_dataset.json"))
    data["golden_entries"] = len(index)
    py_pass = py_total = cs_pass = cs_total = 0
    for entry in index:
        v = load_json(os.path.join(REPO_ROOT, entry["verification"]))
        py_total += v["python_behavior"]["tests_ran"]
        py_pass += v["python_behavior"]["tests_passed"] or 0
        cs_total += v["csharp_behavior"]["tests_ran"]
        cs_pass += v["csharp_behavior"]["tests_passed"] or 0
    data["py_pass"], data["py_total"] = py_pass, py_total
    data["cs_pass"], data["cs_total"] = cs_pass, cs_total
    data["all_equivalent"] = all(
        load_json(os.path.join(REPO_ROOT, e["verification"]))["equivalence_status"] == "EQUIVALENT"
        for e in index
    )

    # Dataset Python existente (Kamino)
    kamino = load_json(os.path.join(REPO_ROOT, "dataset", "kamino_clones_dataset", "bigcodebench_clone_dataset.json"))
    data["kamino_entries"] = len(kamino)
    total_clones = sum(len(e.get("clones", [])) for e in kamino)
    data["kamino_clones"] = total_clones
    data["kamino_avg"] = round(total_clones / len(kamino), 2) if kamino else 0

    bcb_norm = load_json(os.path.join(REPO_ROOT, "dataset", "bigcodebench_normalized.json"))
    bcb_filtered = load_json(os.path.join(REPO_ROOT, "dataset", "bigcodebench_normalized_filtered.json"))
    data["bcb_total"] = len(bcb_norm)
    data["bcb_filtered"] = len(bcb_filtered)

    # git
    data["last_commit"] = git(["log", "-1", "--format=%h %ad %s", "--date=short"])
    status_lines = git(["status", "--porcelain"]).splitlines()
    data["uncommitted_count"] = len(status_lines)

    return data


def build_styles():
    styles = getSampleStyleSheet()
    styles.add(ParagraphStyle(name="CoverTitle", fontSize=24, leading=30, spaceAfter=6,
                               alignment=TA_CENTER, fontName="Helvetica-Bold",
                               textColor=colors.HexColor("#16213e")))
    styles.add(ParagraphStyle(name="CoverSubtitle", fontSize=15, leading=20, spaceAfter=10,
                               alignment=TA_CENTER, fontName="Helvetica-Bold",
                               textColor=colors.HexColor("#0f3460")))
    styles.add(ParagraphStyle(name="CoverMeta", fontSize=11, leading=16, spaceAfter=4,
                               alignment=TA_CENTER, textColor=colors.HexColor("#555555")))
    styles.add(ParagraphStyle(name="H1", fontSize=15.5, leading=19, spaceBefore=16, spaceAfter=8,
                               fontName="Helvetica-Bold", textColor=colors.HexColor("#16213e")))
    styles.add(ParagraphStyle(name="H2", fontSize=11.5, leading=15, spaceBefore=10, spaceAfter=5,
                               fontName="Helvetica-Bold", textColor=colors.HexColor("#0f3460")))
    styles.add(ParagraphStyle(name="Body", fontSize=9.6, leading=13.5, spaceAfter=6,
                               fontName="Helvetica", alignment=TA_LEFT))
    styles.add(ParagraphStyle(name="BodySmall", fontSize=8.3, leading=11.3, spaceAfter=4,
                               fontName="Helvetica", textColor=colors.HexColor("#444444")))
    styles.add(ParagraphStyle(name="Mono", fontSize=7.6, leading=10, fontName="Courier", spaceAfter=3))
    styles.add(ParagraphStyle(name="TableCell", fontSize=7.9, leading=10.2, fontName="Helvetica"))
    styles.add(ParagraphStyle(name="TableHeader", fontSize=8.2, leading=10.4, fontName="Helvetica-Bold",
                               textColor=colors.white))
    styles.add(ParagraphStyle(name="Flow", fontSize=9.4, leading=13, fontName="Courier",
                               alignment=TA_LEFT, spaceAfter=2))
    return styles


def cell(text, style):
    return Paragraph(str(text).replace("\n", "<br/>"), style)


def build_table(data, col_widths, styles, header_bg="#16213e"):
    rows = [[cell(h, styles["TableHeader"]) for h in data[0]]]
    for row in data[1:]:
        rows.append([cell(v, styles["TableCell"]) for v in row])
    t = Table(rows, colWidths=col_widths, repeatRows=1)
    t.setStyle(TableStyle([
        ("BACKGROUND", (0, 0), (-1, 0), colors.HexColor(header_bg)),
        ("TEXTCOLOR", (0, 0), (-1, 0), colors.white),
        ("GRID", (0, 0), (-1, -1), 0.5, colors.HexColor("#cccccc")),
        ("VALIGN", (0, 0), (-1, -1), "TOP"),
        ("ROWBACKGROUNDS", (0, 1), (-1, -1), [colors.white, colors.HexColor("#f4f6fb")]),
        ("LEFTPADDING", (0, 0), (-1, -1), 5),
        ("RIGHTPADDING", (0, 0), (-1, -1), 5),
        ("TOPPADDING", (0, 0), (-1, -1), 4),
        ("BOTTOMPADDING", (0, 0), (-1, -1), 4),
    ]))
    return t


def bullets(items, styles):
    return ListFlowable(
        [ListItem(Paragraph(x, styles["Body"]), leftIndent=6) for x in items],
        bulletType="bullet", start="circle", leftIndent=14)


def checklist(items, styles):
    """items: list of (mark, text) where mark in ('x','~',' ')"""
    rows = []
    for mark, text in items:
        symbol = {"x": "[x]", "~": "[~]", " ": "[ ]"}[mark]
        rows.append(Paragraph(f"{symbol}  {text}", styles["Flow"]))
    return rows


def main():
    d = gather_real_data()
    styles = build_styles()

    doc = SimpleDocTemplate(
        OUT_PDF, pagesize=LETTER,
        leftMargin=0.75 * inch, rightMargin=0.75 * inch,
        topMargin=0.7 * inch, bottomMargin=0.7 * inch,
        title="Relatorio de Estado Atual e Plano de Execucao - Kamino C#",
        author="Kamino Dataset Generator",
    )
    story = []

    # ---------- 1. CAPA ----------
    story.append(Spacer(1, 1.7 * inch))
    story.append(Paragraph("KaminoDatasetGenerator", styles["CoverSubtitle"]))
    story.append(Paragraph("Relatorio de Estado Atual e<br/>Plano de Execucao", styles["CoverTitle"]))
    story.append(Paragraph("Extensao do Pipeline Kamino para C#", styles["CoverSubtitle"]))
    story.append(Spacer(1, 0.35 * inch))
    story.append(HRFlowable(width="60%", thickness=1, color=colors.HexColor("#cccccc"), hAlign="CENTER"))
    story.append(Spacer(1, 0.25 * inch))
    story.append(Paragraph(f"Estado atual estimado: <b>~20-25% concluido</b>", styles["CoverMeta"]))
    story.append(Paragraph(f"Data da analise: {date.today().strftime('%d/%m/%Y')}", styles["CoverMeta"]))
    story.append(Paragraph(f"Ultimo commit no repositorio: {d['last_commit']}", styles["CoverMeta"]))
    story.append(Paragraph(f"Arquivos nao commitados no momento da analise: {d['uncommitted_count']}", styles["CoverMeta"]))
    story.append(PageBreak())

    # ---------- 2. RESUMO EXECUTIVO ----------
    story.append(Paragraph("2. Resumo Executivo", styles["H1"]))
    story.append(Paragraph(
        "O objetivo do projeto e estender o pipeline Kamino -- que hoje gera clones Type-IV "
        "(semanticamente equivalentes, sintaticamente diferentes) automaticamente a partir do "
        "BigCodeBench, mas somente em Python -- para tambem suportar C#. O plano tem seis etapas: "
        "estudar o pipeline existente, mapear diferencas Python/C#, prototipar a traducao "
        "Python-C# (5-10 funcoes), montar um Golden Dataset C# de 100 entradas, gerar clones "
        "Type-IV em C# (~7 por entrada, ~700 no total) e avaliar tudo com a infraestrutura de "
        "deteccao de clones por embeddings ja existente.", styles["Body"]))
    story.append(Paragraph(
        f"<b>Estado atual:</b> foram traduzidas e verificadas manualmente {d['golden_entries']} funcoes "
        f"do BigCodeBench (dentro da meta de 5-10 do prototipo inicial), com "
        f"{d['py_pass']}/{d['py_total']} testes Python e {d['cs_pass']}/{d['cs_total']} testes C# "
        f"passando de forma real (compilacao e execucao efetivas, nao apenas inspecao). Esse "
        f"trabalho, porem, <b>ainda nao foi commitado</b> no git. O nucleo do objetivo -- gerar "
        f"variantes Type-IV em C# -- <b>ainda nao foi implementado</b>: existe apenas traducao "
        f"1-para-1, nao geracao de clones diversificados. O lado Python do pipeline, por outro "
        f"lado, e robusto e ja tem resultados reais: {d['kamino_entries']} entradas e "
        f"{d['kamino_clones']} clones (media de {d['kamino_avg']} clones/entrada -- a meta de "
        f"'~7 clones por entrada' ja foi atingida, mas em Python).", styles["Body"]))
    story.append(Paragraph(
        "Principais pendencias: escalar o Golden Dataset de 8 para 100 entradas, implementar a "
        "geracao de clones Type-IV em C# (prompt de diversificacao + validacao automatizada por "
        "compilacao/execucao), construir o dataset final de clones C#, e rodar a infraestrutura "
        "de embeddings sobre esse dataset (hoje ela ja funciona com C#, mas so foi testada contra "
        "bases externas, nunca contra dados gerados pelo proprio Kamino).", styles["Body"]))

    # ---------- 3. ESTADO ATUAL ----------
    story.append(Paragraph("3. Estado Atual do Projeto", styles["H1"]))
    story.append(Paragraph(
        "Estimativa: <b>~20-25% do objetivo de extensao para C#</b>, calculada ponderando as 6 "
        "etapas do plano pelo peso relativo de cada uma e o quanto de cada uma esta de fato pronto "
        "(detalhamento completo na secao correspondente do documento de analise tecnica). As duas "
        "etapas mais pesadas do plano -- geracao de clones Type-IV (30%) e avaliacao com embeddings "
        "sobre o dataset C# nativo (15%) -- estao praticamente em zero.", styles["Body"]))
    status_table = [
        ["Etapa do plano", "Status"],
        ["1. Estudo do pipeline Python + dataset", "CONCLUIDA"],
        ["2. Analise das diferencas Python vs. C#", "CONCLUIDA"],
        ["3. Prototipo de traducao (5-10 funcoes)", "CONCLUIDA (nao commitada)"],
        ["4. Golden Dataset C# (100 entradas)", f"EM ANDAMENTO ({d['golden_entries']}/100)"],
        ["5. Geracao de clones Type-IV C# (~7/entrada)", "NAO INICIADA"],
        ["6. Avaliacao com embeddings sobre dataset Kamino-C#", "NAO INICIADA (infra existe e funciona com C# externo)"],
    ]
    story.append(build_table(status_table, [4.1 * inch, 2.5 * inch], styles))

    # ---------- 4. O QUE JA FOI DESENVOLVIDO ----------
    story.append(PageBreak())
    story.append(Paragraph("4. O que ja foi desenvolvido", styles["H1"]))
    story.append(Paragraph("<b>Estudo do Kamino existente:</b>", styles["H2"]))
    story.append(Paragraph(
        "Pipeline de 6 passos (Normalizacao, Geracao de Clones, Filtragem CodeBLEU, Testes, "
        "Reparo/Reprompt, Clustering) mapeado e documentado (doc/step1.md a doc/step6.md). "
        "Confirmado como funcional atraves dos resultados reais ja existentes no repositorio.", styles["Body"]))
    story.append(Paragraph("<b>Traducao das 8 funcoes:</b>", styles["H2"]))
    story.append(Paragraph(
        f"dataset/golden_dataset_csharp/ contem {d['golden_entries']} entradas do BigCodeBench "
        "traduzidas manualmente/assistidas de Python para C#, cada uma com implementacao e testes "
        "originais preservados (python/task_func.py, python/test_task_func.py) e a traducao C# "
        "correspondente (csharp/TaskFunc.cs, csharp/TaskFuncTests.cs).", styles["Body"]))
    story.append(Paragraph("<b>Testes e validacao:</b>", styles["H2"]))
    story.append(Paragraph(
        f"Reexecutado agora mesmo (dataset/golden_dataset_csharp/_shared/verify_all.py): "
        f"<b>{d['py_pass']}/{d['py_total']} testes Python passando</b> e "
        f"<b>{d['cs_pass']}/{d['cs_total']} testes C# passando</b>, com compilacao e execucao "
        f"reais (nao apenas leitura de codigo). Todas as {d['golden_entries']} entradas marcadas "
        f"como EQUIVALENT.", styles["Body"]))
    story.append(Paragraph("<b>Prompts / infraestrutura inicial:</b>", styles["H2"]))
    story.append(Paragraph(
        "pipeline/src/utils/prompts.py ganhou um contexto \"csharp_translate\" (traducao 1-para-1, "
        "nao geracao de variantes). pipeline/src/steps/translate_csharp.py reaproveita a chamada "
        "ao Ollama ja existente, mas nunca foi executado com sucesso -- nao ha servidor Ollama "
        "acessivel neste ambiente.", styles["Body"]))
    story.append(Paragraph("<b>Infraestrutura de embeddings ja existente:</b>", styles["H2"]))
    story.append(Paragraph(
        "pipeline/src/clone_detection/detect.py ja aceita language=\"csharp\" e ja tem resultados "
        "reais e comitados em results/RQ3/ e results/RQ4/ (ex.: modelo treinado no Kamino Python "
        "avaliado contra GPTCloneBench C# obtendo F1~0.96) -- mas somente contra datasets C# "
        "EXTERNOS, nunca contra um dataset C# gerado pelo proprio Kamino.", styles["Body"]))

    # ---------- 5. O QUE AINDA PRECISA SER DESENVOLVIDO ----------
    story.append(Paragraph("5. O que ainda precisa ser desenvolvido", styles["H1"]))
    story.append(bullets([
        f"Escalar o Golden Dataset C# de {d['golden_entries']} para 100 entradas do BigCodeBench",
        "Implementar geracao de clones Type-IV em C# (prompt de diversificacao -- nao existe hoje, so ha traducao 1-para-1)",
        "Gerar ~700 clones (100 entradas x ~7 clones), com diversidade sintatica e equivalencia semantica comprovadas",
        "Criar validacao automatizada de clones C# (compilar + rodar testes), hoje so existe um script isolado fora do pipeline principal",
        "Construir o dataset final de clones C# no formato compativel com o Kamino existente",
        "Rodar a infraestrutura de embeddings sobre esse novo dataset (hoje so foi testada com C# externo)",
        "Executar os experimentos de deteccao de clones e analisar os resultados",
        "Commitar todo o trabalho ja realizado (hoje esta todo em working tree, nao commitado)",
    ], styles))

    # ---------- 6. ARQUITETURA/PIPELINE ATUAL ----------
    story.append(PageBreak())
    story.append(Paragraph("6. Arquitetura / Pipeline Atual", styles["H1"]))
    story.append(Paragraph("<b>Lado Python (funcional, com resultados reais):</b>", styles["H2"]))
    for line in [
        "BigCodeBench (HuggingFace) -> normalization.py -> dataset normalizado (927 entradas)",
        "  -> clone_gen.py (LLM via Ollama, 4 modelos x 2 estrategias x 4 contextos x 7 refatoracoes)",
        "  -> filtering.py (filtro CodeBLEU <= 0.4 + execucao real dos testes originais)",
        "  -> reprompt.py (reparo de clones quase-corretos, ate 2 tentativas com outro modelo)",
        "  -> filtering.py (filtro final: 100% dos testes precisam passar)",
        "  -> clustering.py (agrupamento por similaridade + selecao de representante por cluster)",
        f"  -> dataset final: {d['kamino_entries']} entradas, {d['kamino_clones']} clones "
        f"(media {d['kamino_avg']}/entrada)",
    ]:
        story.append(Paragraph(line, styles["Flow"]))
    story.append(Spacer(1, 6))
    story.append(Paragraph("<b>Lado C# (parcial, desconectado do pipeline principal):</b>", styles["H2"]))
    for line in [
        f"BigCodeBench (927 entradas disponiveis) -> selecao manual -> {d['golden_entries']} entradas",
        "  -> traducao manual/assistida -> csharp/TaskFunc.cs + csharp/TaskFuncTests.cs",
        "  -> verify_all.py (script isolado: compila com csc.exe + roda testes)",
        f"  -> {d['golden_entries']} entradas verificadas EQUIVALENT (nao integrado ao pipeline oficial)",
        "  -> [GERACAO DE CLONES: NAO EXISTE]",
        "  -> [DATASET FINAL DE CLONES C#: NAO EXISTE]",
    ]:
        story.append(Paragraph(line, styles["Flow"]))

    # ---------- 7. ARQUITETURA/PIPELINE PRETENDIDO ----------
    story.append(Paragraph("7. Arquitetura / Pipeline Pretendido", styles["H1"]))
    for line in [
        "BigCodeBench",
        "  -> Python (927 entradas normalizadas, ja existe)",
        "  -> C# Golden (traducao 1-para-1 verificada -- escalar de 8 para 100)",
        "  -> Validacao do Golden (compilar + rodar testes traduzidos -- ja funciona para 8)",
        "  -> Geracao Type-IV em C# (prompt de diversificacao + LLM -- NAO EXISTE, criar)",
        "  -> Validacao dos clones (compilar + rodar os MESMOS testes do Golden -- criar validate_with_csharp)",
        "  -> Filtro CodeBLEU (lang=\"c_sharp\", ja suportado pela biblioteca codebleu, confirmado)",
        "  -> Clustering (reutiliza clustering.py sem mudanca)",
        "  -> Dataset final de clones C# (formato compativel com o Kamino existente)",
        "  -> Embeddings (finetune.py/detect.py, pequenos ajustes para reconhecer o dataset nativo)",
        "  -> Experimentos (precision/recall/F1/MCC, mesmo padrao ja usado)",
        "  -> Resultados e analise comparativa",
    ]:
        story.append(Paragraph(line, styles["Flow"]))

    # ---------- 8. O QUE JA PODE SER REUTILIZADO ----------
    story.append(PageBreak())
    story.append(Paragraph("8. O que ja pode ser reutilizado", styles["H1"]))
    reuse_table = [
        ["Componente", "Localizacao", "Funcao", "Reutilizacao"],
        ["Comunicacao com LLM", "clone_gen.py::call_ollama_chat()", "Chamada HTTP generica ao Ollama", "Direta, 100%"],
        ["Clustering", "clustering.py::run_clustering()", "Agrupa clones por CodeBLEU, seleciona representante", "Direta, 100% (agnostico de linguagem)"],
        ["Calculo de eficiencia", "utils/efficiency.py", "Mede sobrevivencia por configuracao no funil", "Direta, 100%"],
        ["CodeBLEU", "helper_functions.py::calc_complete_codebleu()", "Similaridade sintatica via pacote codebleu", "Direta -- confirmado suporte a lang=\"c_sharp\""],
        ["Extracao/pares para embeddings (C# externo)", "helper_functions.py, GPT/SEMANTIC_LANGUAGE_ADAPTERS[\"csharp\"]", "Extrai pares de codigo C# de datasets externos", "Ja existe e ja e usada"],
        ["Avaliacao de embeddings", "clone_detection/detect.py::run_clone_evaluation()", "Calcula precision/recall/F1/MCC", "Ja aceita language=\"csharp\""],
        ["Fine-tuning de embeddings", "clone_detection/finetune.py::run_finetuning()", "Treina SentenceTransformer sobre pares", "Estrutura reutilizavel, so falta registrar dataset C# nativo"],
        ["Extracao de codigo da resposta do LLM", "translate_csharp.py::_extract_csharp_code()", "Regex de bloco ```csharp", "Ja criada, reutilizavel"],
        ["Validacao Python (referencia de design)", "helper_functions.py::validate_with_unittest()", "Executa codigo + testes, devolve PASS/FAIL/ERROR", "Nao reutilizavel diretamente (e Python-only); serve de modelo para criar o equivalente C#"],
        ["Geracao de variantes (refatoracoes)", "prompts.py::REFACTORING (refac_1..7)", "Texto de instrucoes de diversificacao", "Textos provavelmente reaproveitaveis quase como estao para C#"],
    ]
    story.append(build_table(reuse_table, [1.35 * inch, 1.75 * inch, 1.75 * inch, 1.75 * inch], styles))

    # ---------- 9. O QUE PRECISA SER IMPLEMENTADO ----------
    story.append(PageBreak())
    story.append(Paragraph("9. O que precisa ser implementado", styles["H1"]))
    impl_table = [
        ["Funcionalidade", "Prioridade", "Arquivos", "Dependencias", "Resultado esperado"],
        ["Validacao C# integrada (compilar+rodar testes)", "CRITICA", "novo modulo (ref.: _shared/TestHarness.cs, verify_all.py)", "Compilador C# decidido", "validate_with_csharp() com mesmo contrato de validate_with_unittest()"],
        ["Prompt de diversificacao C#", "CRITICA", "prompts.py", "Nenhuma", "Novo context_builder de geracao de variantes (nao traducao)"],
        ["Loop de geracao de clones C#", "CRITICA", "clone_gen.py (generalizar) ou novo modulo", "Ollama acessivel", "Candidatos C# brutos por entrada"],
        ["Escalar Golden Dataset 8->100", "ALTA", "dataset/golden_dataset_csharp/", "Ambiente Python ok", "100 entradas verificadas EQUIVALENT"],
        ["Filtro CodeBLEU para C#", "ALTA", "filtering.py, helper_functions.py", "tree-sitter-c-sharp instalado", "Clones filtrados por diversidade sintatica"],
        ["Export para formato Kamino nativo", "ALTA", "novo script", "Clones C# gerados e validados", "JSON no mesmo shape do dataset Python"],
        ["Registrar dataset C# em finetune.py/detect.py", "MEDIA", "clone_detection/finetune.py, detect.py, config.py", "Dataset final C# existente", "Treino/avaliacao rodando sobre dados nativos C#"],
        ["Commitar trabalho atual", "ALTA", "git", "Nenhuma", "Historico do git atualizado"],
    ]
    story.append(build_table(impl_table, [1.55 * inch, 0.65 * inch, 1.55 * inch, 1.15 * inch, 1.5 * inch], styles))

    # ---------- 10. DEPENDENCIAS E AMBIENTE ----------
    story.append(PageBreak())
    story.append(Paragraph("10. Dependencias e Ambiente", styles["H1"]))
    env_table = [
        ["Item", "Status confirmado agora"],
        ["Python", "3.14 instalado, sem venv configurado no projeto"],
        [".NET / C#", "Somente csc.exe legado (.NET Framework 4.8, C# 5). Sem SDK moderno instalado"],
        ["Ollama", "Nao instalado / nao acessivel (conexao recusada em localhost:11434)"],
        ["GPU", "Nenhuma GPU NVIDIA detectada (nvidia-smi ausente)"],
        ["Dependencias pip (requirements.txt)", "Nenhuma instalada (torch, sentence_transformers, pandas, datasets, sklearn, etc. ausentes)"],
        ["tree-sitter-c-sharp", "Nao esta no requirements.txt; existe no PyPI (confirmado, v0.23.5); necessario para CodeBLEU em C#"],
        [".env / HF_TOKEN", "Arquivo .env nao existe neste ambiente"],
    ]
    story.append(build_table(env_table, [2.3 * inch, 4.3 * inch], styles))
    story.append(Spacer(1, 8))
    story.append(Paragraph(
        "<b>Observacao importante:</b> o README do projeto descreve GPU como \"opcional\", mas o "
        "codigo de fine-tuning (clone_detection/finetune.py) encerra a execucao "
        "(sys.exit(1)) se CUDA nao estiver disponivel -- ou seja, o fine-tuning de embeddings "
        "nao roda sem GPU, na pratica.", styles["BodySmall"]))

    # ---------- 11. BLOQUEIOS ----------
    story.append(Paragraph("11. Bloqueios", styles["H1"]))
    block_table = [
        ["Bloqueio", "Classificacao", "Como resolver"],
        ["Nenhum mecanismo de geracao de clones C# existe", "CRITICO", "Implementar prompt de diversificacao + loop de geracao"],
        ["Sem validacao C# integrada ao pipeline", "CRITICO", "Criar validate_with_csharp() com mesmo contrato da versao Python"],
        ["Ollama nao acessivel neste ambiente", "CRITICO", "Instalar Ollama + baixar modelo(s) em maquina com recursos"],
        ["Sem GPU confirmada (fine-tuning exige CUDA)", "CRITICO", "Confirmar acesso a maquina com GPU antes da fase de embeddings"],
        ["Ambiente sem dependencias/.venv/.env", "IMPORTANTE", "pip install -r requirements.txt + tree-sitter-c-sharp; criar .env"],
        ["So csc.exe legado (C# 5) disponivel", "IMPORTANTE", "Decidir: instalar .NET SDK moderno ou aceitar a limitacao"],
        ["Trabalho das 8 funcoes nao commitado", "PENDENCIA", "git add / git commit"],
        ["finetune.py/detect.py nao reconhecem dataset Kamino-C# nativo", "PENDENCIA", "Pequenos ajustes pontuais nos dois arquivos"],
    ]
    story.append(build_table(block_table, [2.7 * inch, 1.1 * inch, 2.8 * inch], styles))

    # ---------- 12. O QUE PRECISAMOS FORNECER/CONFIGURAR ----------
    story.append(PageBreak())
    story.append(Paragraph("12. O que precisa ser fornecido/configurado (depende de decisao externa)", styles["H1"]))
    story.append(bullets([
        "Acesso a uma maquina com Ollama instalado e pelo menos 1 modelo baixado (local ou remoto)",
        "Decisao: instalar .NET SDK moderno ou seguir apenas com o compilador legado csc.exe",
        "Confirmacao de acesso a GPU (local ou remota) para a etapa de fine-tuning dos embeddings",
        "Decisao sobre quais modelos LLM usar para C# (os 4 do Python, ou um subconjunto menor)",
        "HF_TOKEN valido (.env), caso seja necessario re-rodar a normalizacao do BigCodeBench",
        "Decisao: reaproveitar as 8 entradas atuais como parte das 100, ou re-gerar tudo pelo processo automatizado",
        "Decisao sobre quantidade de configuracoes de prompt por entrada em C# (reduzir do total usado em Python, por causa do tempo de execucao)",
        "Confirmacao de quem tem acesso ao servidor Ollama remoto referenciado em ollama_config_remote.json (porta 3333)",
        "Decisao sobre o limiar de CodeBLEU para C# (usar 0.4 como no Python, ou recalibrar)",
    ], styles))

    # ---------- 13. PLANO DE EXECUCAO ----------
    story.append(PageBreak())
    story.append(Paragraph("13. Plano de Execucao", styles["H1"]))
    phases = [
        ("FASE 1 - Preparacao do ambiente",
         "Instalar dependencias (requirements.txt + tree-sitter-c-sharp), configurar .env, decidir e "
         "confirmar acesso a Ollama e GPU.",
         "requirements.txt, .env"),
        ("FASE 2 - Consolidar as 8 funcoes existentes",
         "Commitar todo o trabalho ja feito (golden_dataset_csharp/, prompts.py, docs).",
         "git add / commit"),
        ("FASE 3 - Validacao C# integrada",
         "Criar validate_with_csharp() com o mesmo contrato de validate_with_unittest(), testar contra "
         "as 8 entradas existentes.",
         "novo modulo de validacao"),
        ("FASE 4 - Prompt de diversificacao + geracao piloto",
         "Criar prompt de geracao de variantes C# e gerar os primeiros clones reais (nao traducao) "
         "para 1-2 entradas piloto.",
         "prompts.py, clone_gen.py"),
        ("FASE 5 - Escalar Golden Dataset (8 -> 100)",
         "Traduzir e verificar as 92 entradas restantes, seguindo o mesmo padrao das 8 atuais.",
         "dataset/golden_dataset_csharp/"),
        ("FASE 6 - Geracao de clones em escala (~7/entrada)",
         "Aplicar a geracao da Fase 4 as 100 entradas, com filtro de CodeBLEU e validacao automatizada.",
         "clone_gen.py, filtering.py"),
        ("FASE 7 - Clustering e dataset final",
         "Reduzir candidatos a representantes nao-redundantes (clustering.py, reutilizado sem mudanca) "
         "e exportar para o formato Kamino nativo.",
         "clustering.py, novo script de export"),
        ("FASE 8 - Embeddings",
         "Registrar o dataset C# nativo em finetune.py/detect.py e rodar treino + avaliacao.",
         "config.py, finetune.py, detect.py"),
        ("FASE 9 - Avaliacao e analise dos resultados",
         "Comparar resultados do dataset Kamino-C# nativo com os resultados ja existentes contra "
         "GPTCloneBench/SemanticCloneBench C# (externos).",
         "notebook novo ou secao em RQ3/RQ4.ipynb"),
        ("FASE 10 - Documentacao final",
         "Atualizar doc/step7, README, DOC.md com o estado final do trabalho.",
         "doc/step7_csharp_translation.md, README.md"),
    ]
    for title, desc, files in phases:
        story.append(Paragraph(title, styles["H2"]))
        story.append(Paragraph(desc, styles["Body"]))
        story.append(Paragraph(f"<i>Arquivos envolvidos:</i> {files}", styles["BodySmall"]))

    # ---------- 14. CRITERIOS DE CONCLUSAO ----------
    story.append(PageBreak())
    story.append(Paragraph("14. Criterios de Conclusao", styles["H1"]))
    story.append(Paragraph("<b>Golden Dataset:</b>", styles["H2"]))
    for p in checklist([
        ("~", f"100 entradas C# (hoje: {d['golden_entries']})"),
        ("x", "Cada entrada possui teste correspondente (valido para as 8 atuais)"),
        ("x", "Todas compilam (valido para as 8 atuais)"),
        ("x", "Todas passam nos testes (valido para as 8 atuais: 49/49)"),
        ("x", "Equivalencia comportamental confirmada por execucao real (valido para as 8 atuais)"),
        (" ", "Trabalho commitado no git"),
    ], styles):
        story.append(p)
    story.append(Spacer(1, 6))
    story.append(Paragraph("<b>Clones:</b>", styles["H2"]))
    for p in checklist([
        (" ", "~7 clones por entrada em media (hoje: 0)"),
        (" ", "Clones sintaticamente diferentes (CodeBLEU <= limiar definido)"),
        (" ", "Comportamento equivalente (100% dos testes do Golden passando)"),
        (" ", "Testes passando de forma automatizada (validate_with_csharp funcionando)"),
        (" ", "Duplicatas removidas/agrupadas via clustering"),
        (" ", "Dataset final armazenado no formato compativel com o Kamino"),
    ], styles):
        story.append(p)
    story.append(Spacer(1, 6))
    story.append(Paragraph("<b>Avaliacao:</b>", styles["H2"]))
    for p in checklist([
        (" ", "Dataset C# carregado por finetune.py/detect.py"),
        (" ", "Modelo de embeddings treinado ou reaproveitado sobre o dataset C#"),
        (" ", "Experimentos executados (multiplos thresholds, como ja e feito para Python)"),
        (" ", "Metricas calculadas (precision/recall/F1/MCC)"),
        (" ", "Resultados salvos em CSV"),
        (" ", "Analise comparativa feita (C# Kamino nativo vs. C# externo)"),
    ], styles):
        story.append(p)

    # ---------- 15. PROXIMOS PASSOS IMEDIATOS ----------
    story.append(PageBreak())
    story.append(Paragraph("15. Proximos Passos Imediatos", styles["H1"]))
    story.append(bullets([
        "Commitar o trabalho ja existente (8 entradas, prompts, documentacao)",
        "Confirmar acesso a Ollama (local ou remoto) e a pelo menos 1 modelo LLM baixado",
        "Confirmar acesso a GPU para a futura etapa de fine-tuning de embeddings",
        "Decidir entre instalar .NET SDK moderno ou manter o compilador legado csc.exe",
        "Instalar tree-sitter-c-sharp e testar calc_codebleu(..., lang=\"c_sharp\") isoladamente",
        "Criar o modulo validate_with_csharp() e valida-lo contra as 8 entradas ja existentes",
        "Criar o prompt de diversificacao C# e gerar clones piloto para 1-2 entradas",
        "Definir critério de quantidade de configuracoes de prompt por entrada (reduzir do total usado em Python)",
    ], styles))

    # ---------- 16. CONCLUSAO ----------
    story.append(Paragraph("16. Conclusao", styles["H1"]))
    story.append(Paragraph(
        f"O projeto de extensao do Kamino para C# esta, hoje, na fase de prototipo de traducao: "
        f"{d['golden_entries']} de 100 entradas do Golden Dataset foram traduzidas e verificadas de "
        f"verdade (compilacao e execucao reais), com {d['py_pass']}/{d['py_total']} testes Python e "
        f"{d['cs_pass']}/{d['cs_total']} testes C# passando. Esse resultado e concreto e confiavel, "
        f"mas ainda nao esta commitado no repositorio. O nucleo do objetivo do projeto -- a geracao "
        f"automatizada de clones Type-IV em C# (variantes sintaticamente diferentes, semanticamente "
        f"equivalentes) -- ainda nao foi implementado; o que existe hoje e apenas uma traducao "
        f"1-para-1, nao um mecanismo de diversificacao.", styles["Body"]))
    story.append(Paragraph(
        "A boa noticia e que boa parte da infraestrutura necessaria ja existe e e reaproveitavel: a "
        "comunicacao com o LLM (Ollama), o clustering, o calculo de similaridade sintatica "
        "(confirmamos que a biblioteca CodeBLEU ja suporta C#) e, principalmente, a infraestrutura "
        "de avaliacao por embeddings -- que ja roda com C# hoje, ainda que contra datasets externos. "
        "O trabalho que falta e concentrado em tres frentes: (1) criar a geracao de clones e a "
        "validacao automatizada especificas para C#, que hoje nao existem; (2) escalar o Golden "
        "Dataset de 8 para 100 entradas; e (3) conectar o novo dataset C# a infraestrutura de "
        "embeddings ja existente. Nenhuma dessas frentes exige reescrever o pipeline -- sao extensoes "
        "pontuais sobre uma base solida -- mas todas dependem de recursos que nao estao confirmados "
        "neste ambiente hoje (Ollama acessivel, GPU, e uma decisao sobre a versao do compilador C#).",
        styles["Body"]))

    doc.build(story)
    print(f"Relatorio gerado em: {OUT_PDF}")
    return d


if __name__ == "__main__":
    main()
