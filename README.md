# Kamino Clone Dataset Generator Artifact

## Artifact Overview

### Description

Kamino is a fully automated pipeline for generating Type-IV (semantic) code clones using Large Language Models (LLMs) combined with deterministic validation techniques.

The pipeline generates behaviorally equivalent but syntactically diverse implementations while enforcing:

- Semantic correctness through automated test execution;
- Syntactic diversity through CodeBLEU*-based filtering;
- Non-redundancy through clustering and representative selection.

The resulting dataset can be used for:

- Training machine-learning-based clone detectors;
- Benchmark creation;
- Program transformation studies;
- Evaluation of Type-IV clone detection techniques.

### Artifact Contents

This artifact contains:

- The complete Kamino generation pipeline;
- The generated Kamino dataset;
- Scripts used to execute all experiments reported in the paper;
- Jupyter notebooks used to analyze results and generate figures/tables.

---

# Getting Started

The following instructions allow reviewers to install and validate the artifact within approximately 30 minutes.

## System Requirements

### Hardware

Minimum:

- 8 GB RAM
- 4 CPU cores
- 20 GB free disk space

Recommended:

- 16+ GB RAM
- GPU (optional)

### Software

- Python 3.10 or newer
- Ollama
- Hugging Face account and access token
- Microsoft C++ Build Tools (required by CodeBLEU on Windows)

---

## Installation

The artifact is distributed as a ZIP archive named:

```text
KaminoDatasetGenerator.zip
```

Extract the archive and enter the project directory:

```bash
cd KaminoDatasetGenerator
```

### Create a Python Environment

```bash
python -m venv .venv
```

Activate the environment.

Linux/macOS:

```bash
source .venv/bin/activate
```

Windows:

```bash
.venv\Scripts\activate
```

### Install Dependencies

Inside the pipeline directory:

```bash
cd pipeline
pip install -r requirements.txt
```

### Configure Hugging Face Access

Create a file named:

```text
.env
```

in the root directory containing:

```text
HF_TOKEN=<your_token_here>
```

### Configure Ollama

Ensure an Ollama server is running.

By default:

- Local execution uses the default Ollama port;
- Remote execution uses port 3333.

Connection settings can be modified in:

```text
pipeline/src/resources
```

### Windows-Specific Requirement

Install Microsoft C++ Build Tools with:

- Desktop Development with C++;
- Windows SDK;
- CMake Tools.

These components are required by CodeBLEU.

---

## Smoke Test

To verify the installation, execute:

```bash
cd pipeline
python -m src.main
```

Expected outcome:

- Configuration files are loaded;
- The selected LLM connection is established;
- The pipeline starts execution successfully;
- Output directories are created;
- No runtime exceptions occur.

Successful execution confirms a valid installation.

---

# Paper Claims Supported by the Artifact

The artifact supports all experimental claims presented in the paper.

---

## RQ1

### Research Question

To what extent can LLMs be leveraged to generate Type-IV clones considering different contexts, prompt strategies, and refactorings?

### Supported Claim

The Kamino pipeline can generate Type-IV clone candidates across a large configuration space involving:

- Multiple LLMs;
- Multiple prompt contexts;
- Multiple prompting strategies;
- Multiple refactoring combinations.

The experiments evaluate 224 prompt configurations formed from:

- 4 contexts;
- 2 prompting strategies;
- 7 refactoring combinations;
- 4 LLMs.

### Reproduction Files

Pipeline execution:

```text
pipeline/src/main.py
```

Analysis notebook:

```text
pipeline/RQ1.ipynb
```

### How to Reproduce
**Notice that the .zip file already contains all the results reported in the paper, os running the pipeline again will overwrite these results** 
Execute:

```bash
cd pipeline
python -m src.main
```

After execution completes, open:

```text
pipeline/RQ1.ipynb
```

and run all notebook cells sequentially.

The notebook reproduces the tables and figures associated with RQ1.

---

## RQ2

### Research Question

To what extent do test cases and CodeBLEU* effectively retain only Type-IV clones?

### Supported Claim

The generated dataset predominantly contains Type-IV clones after applying:

- CodeBLEU*-based filtering;
- Test-based validation.

The claim is validated using CloneCognition, an external clone classifier.

### Reproduction Files

CloneCognition XML generation:

```text
pipeline/src/rq2.py
```

Analysis notebook:

```text
pipeline/RQ2.ipynb
```

### How to Reproduce

Generate CloneCognition input files:

```bash
python src/rq2.py
```

Run CloneCognition following its documentation.

Then open:

```text
pipeline/RQ2.ipynb
```

and execute all notebook cells.

The notebook reproduces the analyses reported for RQ2.

---

## RQ3

### Research Question

To what extent does fine-tuning embedding models on the generated dataset improve Type-IV clone detection performance and cross-dataset generalization?

### Supported Claim

The Kamino dataset can be used to fine-tune embedding models that generalize to unseen Type-IV clones originating from independent datasets and programming languages.

The paper evaluates:

- CodeBERT;
- CodeT5.

The models are trained on Kamino and evaluated on:

- SemanticCloneBench;
- GPTCloneBench.

### Reproduction Files

Training pipeline:

```text
pipeline/src/rq3.py
```

Analysis notebook:

```text
pipeline/RQ3.ipynb
```

### How to Reproduce

Execute:

```bash
python src/rq3.py
```

This script:

- Creates positive clone pairs;
- Creates negative pairs;
- Fine-tunes embedding models;
- Generates evaluation results.

After completion, open:

```text
pipeline/RQ3.ipynb
```

and execute all notebook cells.

The notebook reproduces all analyses reported for RQ3.

---

## RQ4

### Research Question

To what extent does syntactic diversity impact the usefulness of the generated dataset for downstream Type-IV clone detection?

### Supported Claim

Datasets containing different levels of syntactic diversity lead to different downstream clone-detection performance.

The paper evaluates three variants:

- Kamino-LD (low diversity);
- Kamino-MD (medium diversity);
- Kamino-HD (high diversity).

These variants are generated using different CodeBLEU* similarity ranges.

### Reproduction Files

Dataset construction and training:

```text
pipeline/src/rq4.py
```

Analysis notebook:

```text
pipeline/RQ4.ipynb
```

### How to Reproduce

Execute:

```bash
python src/rq4.py
```

This script:

- Creates the Kamino-LD dataset;
- Creates the Kamino-MD dataset;
- Creates the Kamino-HD dataset;
- Fine-tunes CodeBERT;
- Fine-tunes CodeT5;
- Evaluates all resulting models.

After completion, open:

```text
pipeline/RQ4.ipynb
```

and execute all notebook cells.

The notebook reproduces all analyses reported for RQ4.

---

# Claims Not Supported by the Artifacts

The artifact does not directly support:

- Literature review findings;
- Related work comparisons not based on executable experiments;
- Discussion and interpretation sections;
- Threats-to-validity discussions;
- Future work suggestions.

These claims are conceptual and therefore cannot be reproduced through artifact execution.

---

# Dataset Description

The generated dataset is available at:

```text
dataset/kamino_clones_dataset
```

## Dataset Contents

Each entry contains:

- Original implementation;
- Generated clone implementations;
- Metadata;
- Validation results;
- Testing outcomes;
- Similarity measurements.

## Data Provenance

The dataset was generated entirely through the Kamino pipeline described in the paper.

Generated clones were produced using LLM-based transformations and validated through deterministic testing and filtering stages.

## Ethical Considerations

The artifact contains source-code transformations only.

No personal or sensitive information is collected, processed, or distributed.

Users remain responsible for complying with the licenses of any external datasets used as inputs.

## Storage Requirements

The exact storage requirements depend on generated intermediate files and selected configurations.

The generated Kamino dataset is already included in the artifact package.

# Additional Experiments

Beyond reproducing the paper results, reviewers may:

- Change the LLM model;
- Modify prompt strategies;
- Change refactoring combinations;
- Adjust CodeBLEU* thresholds;
- Change clustering parameters;
- Generate new clone datasets;
- Train other pre-trained models for clone detection.

---

# Documentation

The full documentation is available [here](./DOC.md).

# Repository Structure

```text
KaminoDatasetGenerator
│
├── dataset/
│   └── kamino_clones_dataset/
│
├── doc/
│   ├── step1.md
│   ├── step2.md
│   ├── step3.md
│   ├── step4.md
│   ├── step5.md
│   └── step6.md
│
├── pipeline/
│   ├── src/
│   │   ├── main.py
│   │   ├── rq2.py
│   │   ├── rq3.py
│   │   └── rq4.py
│   │
│   ├── RQ1.ipynb
│   ├── RQ2.ipynb
│   ├── RQ3.ipynb
│   └── RQ4.ipynb
│
│── DOC.md
└── README.md

```

---

# Contact

For questions regarding the artifact, please contact the paper authors.
