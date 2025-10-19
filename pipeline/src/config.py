import os
"""
Global configuration file Kamino settings.
Import this anywhere using:
    from src.config import *
"""
# Paths 
DATASET = "bigcode/bigcodebench"
DATASET_NAME = "bigcodebench"
DATASET_PATH = f"../dataset/{DATASET_NAME}_normalized.json"
FILTERED_DATASET_PATH = f"../dataset/{DATASET_NAME}_normalized_filtered.json"
TESTS_PATH = "../results/original_test_results.json"
SAMPLE_1_PATH = "../dataset/sample1.json"
SAMPLE_2_PATH = "../dataset/sample2.json"
OUT_PATH     = f"../results/RQ1/{DATASET_NAME}_llm_clones.json"
FINAL_DATASET = f"../results/RQ1/{DATASET_NAME}_clone_dataset.json"

# Normalization settings
SAMPLE_SIZE = 50  # number of entries to sample for experiments
SAMPLE_SEED = 0   # random seed for sampling

#  Models 
DeepSeek = "deepseek-r1:14b"
Gemma3   = "gemma3:latest"
Gpt20b   = "gpt-oss:20b"
LLama3   = "llama3.1:latest"
ALL_MODELS = [DeepSeek, Gemma3, LLama3, Gpt20b]

#  Generation settings 
LLM_OPTS = {
    "temperature": 0.1,        # more deterministic
    "top_p": 0.95,             
    "repeat_penalty": 1.1,     # discourages repetition
    "num_predict": 1500,       # max output tokens
}
REMOTE_OLLAMA = True # change to False to use local ollama server
N_ENTRIES = 50 # number of dataset entries to use as inputs for generation
CLONES_PER_ENTRY = 1 # number of clones to generate per dataset entry per prompt configuration
OLLAMA_CONFIG_FILE_REMOTE = os.path.join(os.path.abspath(os.path.join(os.path.dirname(__file__), "..")), "resources", "ollama_config_remote.json")
OLLAMA_CONFIG_FILE_LOCAL = os.path.join(os.path.abspath(os.path.join(os.path.dirname(__file__), "..")), "resources", "ollama_config_local.json")

# Prompt configuration settings
CONTEXTS = ["code", "test", "complete", "ast"]
REFACS = [f"refac_{i}" for i in range(1, 8)]  # refac_1..refac_7
STRATEGIES = ["zero-shot", "cot"]  
COMBINATIONS_PER_SET = 3 # size of the refactoring combinations to use
NUM_COMBINATIONS_TOUSE = 7 # number of refactoring combinations to use per entry
RANDOM_SEED = 42 # seed for random selection of refactoring combinations
FUNCTION_NAME = "task_func"  

# Reprompting settings
MAX_RETRIES = 2
DELAY = 3
MAX_WORKERS = 6  # for parallelism
MIN_TEST_REPROMPT = 0.5  # minimum % of tests that must pass to consider reprompting
REPROMPT_PATH = f"../results/RQ1/{DATASET_NAME}_reprompt.json"
FAILED_REPROMPT_PATH = f"../results/RQ1/{DATASET_NAME}_failed_reprompt.json"

# Filters 
CODEBLEU_THRESHOLD = 0.4 # 0-1 higher = more similar
FILTERED_PATH_CODEBLEU = f"../results/RQ1/{DATASET_NAME}_filtered_codebleu.json"
FILTERED_PATH_TESTS = f"../results/RQ1/{DATASET_NAME}_filtered_tests.json"

# Clustering settings
CLUSTER_DIR="../results/RQ1/clustering" # directory to save clustering scrips for data visualization

# Embedding settings
EPOCHS = 3
BATCH_SIZE = 8