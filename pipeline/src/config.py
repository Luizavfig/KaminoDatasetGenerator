import os
"""
Global configuration file for model and dataset settings.
Import this anywhere using:
    from src.config import *
"""
# --- Dataset paths ---
DATASET = "bigcode/bigcodebench"
DATASET_NAME = "bigcodebench"
DATASET_PATH = f"../dataset/{DATASET_NAME}_normalized.json"
FILTERED_DATASET_PATH = f"../dataset/{DATASET_NAME}_normalized_filtered.json"
TESTS_PATH = "../results/original_test_results.json"
SAMPLE_1_PATH = "../dataset/sample1.json"
SAMPLE_2_PATH = "../dataset/sample2.json"
OUT_PATH     = f"../results/{DATASET_NAME}_llm_clones.json"
FINAL_DATASET = f"../results/{DATASET_NAME}_clone_dataset.json"
# --- Models ---
DeepSeek = "deepseek-r1:14b"
Gemma3   = "gemma3:latest"
Gpt20b   = "gpt-oss:20b"
LLama3   = "llama3.1:latest"
ALL_MODELS = [DeepSeek, Gemma3, LLama3, Gpt20b]
# --- Default model assignments --- 
NL_MODEL     = LLama3
CODE_MODEL   = LLama3
# --- Generation settings ---
LLM_OPTS = {
    "temperature": 0.1,        # lower = more deterministic
    "top_p": 0.95,             # nucleus sampling threshold
    "repeat_penalty": 1.1,     # discourages repetition
    "num_predict": 1500,       # max output tokens
}
REMOTE_OLLAMA = True
N_ENTRIES = 12
CLONES_PER_ENTRY = 1
CONTEXTS = ["code", "test", "complete", "ast"]
REFACS = [f"refac_{i}" for i in range(1, 8)]  # refac_1..refac_7
STRATEGIES = ["zero-shot", "cot"]  
COMBINATIONS_PER_SET = 3
NUM_COMBINATIONS_TOUSE = 7
RANDOM_SEED = 42
FUNCTION_NAME = "task_func"  
OLLAMA_CONFIG_FILE_REMOTE = os.path.join(os.path.abspath(os.path.join(os.path.dirname(__file__), "..")), "resources", "ollama_config_remote.json")
OLLAMA_CONFIG_FILE_LOCAL = os.path.join(os.path.abspath(os.path.join(os.path.dirname(__file__), "..")), "resources", "ollama_config_local.json")


# Reprompting settings
MAX_RETRIES= 2
DELAY=3
MAX_WORKERS = 6  # for parallelism
MIN_TEST_REPROMPT = 2  # minimum number of tests that must pass to consider reprompting
REPROMPT_PATH = f"../results/{DATASET_NAME}_reprompt.json"
FAILED_REPROMPT_PATH = f"../results/{DATASET_NAME}_failed_reprompt.json"

# Filters 
CODEBLEU_THRESHOLD = 0.4
FILTERED_PATH_CODEBLEU = f"../results/{DATASET_NAME}_filtered_codebleu.json"
FILTERED_PATH_TESTS = f"../results/{DATASET_NAME}_filtered_tests.json"

# Clustering settings
CLUSTER_DIR="../results/clustering"

# Embedding settings
EPOCHS = 3
BATCH_SIZE = 8