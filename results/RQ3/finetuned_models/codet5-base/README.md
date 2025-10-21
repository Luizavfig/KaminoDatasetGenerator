---
tags:
- sentence-transformers
- sentence-similarity
- feature-extraction
- dense
- generated_from_trainer
- dataset_size:2287
- loss:CosineSimilarityLoss
base_model: Salesforce/codet5-base
widget:
- source_sentence: "import pandas as pd\n\n\ndef task_func(df):\n    bracket_counts\
    \ = {}\n    for col in df.columns:\n        for val in df[col]:\n            for\
    \ char in val:\n                if char in ['(', ')', '{', '}', '[', ']']:\n \
    \                   bracket_counts[char] = bracket_counts.get(char, 0) + 1\n \
    \   return sum(bracket_counts.values())\n"
  sentences:
  - "import pandas as pd\n\n\ndef task_func(df: pd.DataFrame) ->int:\n    \"\"\"Return\
    \ the total number of bracket characters in the DataFrame.\"\"\"\n    brackets\
    \ = set('(){}[]')\n    flat = (str(v) for v in df.values.ravel())\n    return\
    \ sum(sum(1 for ch in s if ch in brackets) for s in flat)\n"
  - "import os\n\n\ndef task_func(log_file_path: str, keywords: list) ->list:\n  \
    \  \"\"\"Reads log file and formats lines containing specified keywords.\"\"\"\
    \n    if not os.path.isfile(log_file_path):\n        raise FileNotFoundError(f'Log\
    \ file {log_file_path} does not exist.')\n\n    def format_line(line: str, kwds:\
    \ list) ->str:\n        for keyword in kwds:\n            if keyword in line:\n\
    \                parts = line.strip().split(maxsplit=2)\n                if len(parts)\
    \ >= 3:\n                    return (\n                        f'{keyword:>{20}}\
    \ : {parts[1]:>{20}} : {parts[2]:>{20}}'\n                        )\n        return\
    \ f'Line format unexpected: {line.strip()}'\n    with open(log_file_path, 'r')\
    \ as log_file:\n        lines = [format_line(line, keywords) for line in log_file]\n\
    \    return [line for line in lines if any(kw in line for kw in keywords)]\n"
  - "import os\nimport shutil\n\n\ndef task_func(filename, dest_dir):\n    if not\
    \ os.path.exists(dest_dir):\n        os.makedirs(dest_dir)\n    copied_file =\
    \ os.path.join(dest_dir, os.path.basename(filename))\n    shutil.copy2(filename,\
    \ dest_dir)\n    with open(filename, 'w') as f:\n        pass\n    return copied_file\n"
- source_sentence: "import pickle\nimport os\n\n\ndef task_func(df, file_name):\n\
    \    save_file = open(file_name, 'wb')\n    pickle.dump(df, save_file)\n    save_file.close()\n\
    \    load_file = open(file_name, 'rb')\n    loaded_df = pickle.load(load_file)\n\
    \    load_file.close()\n    os.remove(file_name)\n    return loaded_df\n"
  sentences:
  - "import pickle\nfrom tempfile import TemporaryDirectory\n\n\ndef task_func(df,\
    \ file_path):\n    with TemporaryDirectory() as temp_dir:\n        with open(os.path.join(temp_dir,\
    \ 'temp.pkl'), 'wb') as f:\n            pickle.dump(df, f)\n        loaded_df\
    \ = pd.read_pickle(os.path.join(temp_dir, 'temp.pkl'))\n        os.remove(os.path.join(temp_dir,\
    \ 'temp.pkl'))\n    return loaded_df\n"
  - "import math\nimport pandas as pd\n\n\ndef task_func(tuples_list):\n    \"\"\"\
    Converts list of tuples into DataFrame with sin applied to each element.\"\"\"\
    \n    transformed_data = [[math.sin(num) for num in t] for t in tuples_list]\n\
    \    df = pd.DataFrame(transformed_data)\n    return df\n"
  - "import random\nimport string\nimport hashlib\nimport time\nfrom typing import\
    \ Dict\n\n\ndef task_func(data_dict: Dict[str, str], seed=0) ->Dict[str, str]:\n\
    \    random.seed(seed)\n    SALT_LENGTH = 5\n    data_dict['a'] = '1'\n    salt\
    \ = ''.join(random.choice(string.ascii_lowercase) for _ in range(\n        SALT_LENGTH))\n\
    \    hashed_data_dict = {key: hashlib.sha256((str(value) + salt).encode()).\n\
    \        hexdigest() for key, value in data_dict.items()}\n    timestamp = time.time()\n\
    \    result = {**hashed_data_dict, 'timestamp': timestamp}\n    return result\n"
- source_sentence: "import os\nimport shutil\nimport tempfile\n\n\ndef task_func(filename,\
    \ dest_dir):\n    os.makedirs(dest_dir, exist_ok=True)\n    shutil.copy2(filename,\
    \ os.path.join(dest_dir, os.path.basename(filename)))\n    open(filename, 'w').truncate(0)\n\
    \    return os.path.abspath(os.path.join(dest_dir, os.path.basename(filename)))\n"
  sentences:
  - "import dill\nimport tempfile\nimport logging\n\n\ndef task_func(df, file_name):\n\
    \    try:\n        with tempfile.NamedTemporaryFile(mode='wb', delete=False) as\
    \ temp_file:\n            dill.dump(df, temp_file)\n            temp_path = temp_file.name\n\
    \        with open(temp_path, 'rb') as loaded_file:\n            loaded_df = dill.load(loaded_file)\n\
    \        if os.path.exists(temp_path):\n            os.remove(temp_path)\n   \
    \     return loaded_df\n    except Exception as e:\n        logging.error(f'Error\
    \ during DataFrame save/load: {str(e)}')\n        raise\n"
  - "import shutil\nfrom pathlib import Path\n\n\ndef task_func(filename: str, dest_dir:\
    \ str):\n    mapping = {Path(filename): Path(dest_dir) / Path(filename).name}\n\
    \    for src, dst in mapping.items():\n        dst.parent.mkdir(parents=True,\
    \ exist_ok=True)\n        shutil.copy2(src, dst)\n        src.open('wb').close()\n\
    \    return str(mapping[Path(filename)].resolve())\n"
  - "import re\nimport socket\n\n\ndef task_func(myString):\n    url_pattern = re.compile('https?://(?:[-\\\
    \\w.]|(?:%[\\\\da-fA-F]{2}))+')\n    urls = url_pattern.findall(myString)\n  \
    \  domain_ip_dict = {}\n    for url in urls:\n        try:\n            domain\
    \ = url.split('//')[-1].split('/')[0]\n            ip_address = socket.gethostbyname(domain)\n\
    \            domain_ip_dict[domain] = ip_address\n        except socket.gaierror:\n\
    \            domain_ip_dict[domain] = None\n    return domain_ip_dict\n"
- source_sentence: "import pandas as pd\nfrom typing import Iterable, Union\n\n\n\
    def task_func(df: pd.DataFrame) ->int:\n    if not isinstance(df, pd.DataFrame):\n\
    \        raise TypeError('Input must be a DataFrame.')\n\n    def count_brackets(s:\
    \ str) ->int:\n        brackets = {'(', ')', '{', '}', '[', ']'}\n        return\
    \ sum(1 for char in s if char in brackets)\n    total = 0\n    for _, row in df.iterrows():\n\
    \        for value in row.values:\n            if isinstance(value, (str, bytes)):\n\
    \                total += count_brackets(str(value))\n    return total\n"
  sentences:
  - "import numpy as np\nfrom scipy.stats import shapiro\n\n\ndef task_func(df, column_name,\
    \ significance_level):\n    if not isinstance(df, pd.DataFrame) or not isinstance(column_name,\
    \ str\n        ) or not isinstance(significance_level, (int, float)):\n      \
    \  raise ValueError('Invalid input type')\n    try:\n        values = df[column_name]\n\
    \    except KeyError:\n        raise ValueError(\n            f\"Column '{column_name}'\
    \ does not exist in the DataFrame\")\n    if len(values) < 30:\n        return\
    \ False\n    stat, p_value = shapiro(values)\n    return p_value > significance_level\n"
  - "import pandas as pd\nfrom sklearn.preprocessing import MinMaxScaler\nimport matplotlib.pyplot\
    \ as plt\n\n\ndef task_func(data_dict, data_keys):\n    if not data_keys:\n  \
    \      raise ValueError('At least one key must be specified')\n    for key in\
    \ data_keys:\n        if key not in data_dict:\n            raise ValueError(f\"\
    Key '{key}' is not present in the dictionary\")\n    df = pd.DataFrame({key: value\
    \ for key, value in data_dict.items() if \n        key in data_keys})\n    scaler\
    \ = MinMaxScaler()\n    normalized_df = scaler.fit_transform(df)\n    normalized_df\
    \ = pd.DataFrame(normalized_df, columns=data_keys)\n    fig, ax = plt.subplots()\n\
    \    for column in normalized_df.columns:\n        ax.plot(normalized_df[column],\
    \ label=column)\n    ax.legend()\n    return normalized_df, ax\n"
  - "import pandas as pd\nfrom typing import Union\n\n\ndef task_func(df: pd.DataFrame)\
    \ ->int:\n    if not isinstance(df, pd.DataFrame):\n        raise TypeError('df\
    \ should be a DataFrame.')\n\n    def count_brackets(x: Union[str, float]) ->int:\n\
    \        return sum(1 for c in str(x) if c in '(){}[]')\n    result = df.applymap(count_brackets).sum().sum()\n\
    \    return result\n"
- source_sentence: "import os\n\n\ndef task_func(log_file_path, keywords):\n    log_lines\
    \ = []\n    with open(log_file_path, 'r') as f:\n        for line in f:\n    \
    \        if any(keyword in line for keyword in keywords):\n                parts\
    \ = line.split()\n                timestamp = ' '.join(parts[0:2])\n         \
    \       message = ' '.join(parts[3:])\n                formatted_line = f\"{parts[0]}\
    \ {parts[1]}{' ' * 20}{message}\"\n                log_lines.append(formatted_line)\n\
    \    return log_lines\n"
  sentences:
  - "import random\nimport string\n\n\ndef task_func(text, seed=None):\n    if seed\
    \ is None:\n        seed = 0\n    result = text.translate(str.maketrans('', '',\
    \ string.punctuation)).replace(\n        ' ', '_').replace('\\t', '__').replace('\\\
    n', '___')\n    if seed is not None:\n        random.seed(seed)\n        result\
    \ = ''.join([(c.upper() if random.choice([True, False]) else c\n            )\
    \ for c in result])\n    else:\n        result = result.upper()\n    return result\n"
  - "import random, math\n\n\ndef task_func(n):\n    \"\"\"Generate n random points\
    \ within a circle of radius 5 and return average distance from center.\"\"\"\n\
    \    RADIUS = 5\n    points = {i: (math.sqrt(random.random()) * RADIUS) for i\
    \ in range(n)}\n    total = sum(points.values())\n    return total / n if n else\
    \ 0\n"
  - "import os\n\n\ndef task_func(log_file_path, keywords):\n    if not keywords:\n\
    \        return []\n\n    def _read_file(path):\n        with open(path, 'r')\
    \ as f:\n            return f.readlines()\n\n    def _extract_parts(line):\n \
    \       parts = line.split(' ', 2)\n        if len(parts) < 3:\n            return\
    \ None, None, None\n        return parts[0], parts[1], parts[2].rstrip('\\n')\n\
    \n    def _format_line(kw, ts, msg):\n        return f\"{kw}{' ' * 20}{ts}{' '\
    \ * 20}{msg}\"\n    lines = _read_file(log_file_path)\n    kw_set = set(keywords)\n\
    \    result_dict = {}\n    for kw in kw_set:\n        result_dict[kw] = []\n \
    \   for line in lines:\n        for kw in kw_set:\n            if kw in line:\n\
    \                keyword, timestamp, message = _extract_parts(line)\n        \
    \        if keyword is None:\n                    continue\n                formatted\
    \ = _format_line(keyword, timestamp, message)\n                result_dict[keyword].append(formatted)\n\
    \    for line in lines:\n        for kw in kw_set:\n            if kw in line:\n\
    \                keyword, timestamp, message = _extract_parts(line)\n        \
    \        if keyword is None:\n                    continue\n                formatted\
    \ = _format_line(keyword, timestamp, message)\n                if keyword not\
    \ in result_dict:\n                    result_dict[keyword] = []\n           \
    \     result_dict[keyword].append(formatted)\n    final_list = []\n    for lst\
    \ in result_dict.values():\n        final_list.extend(lst)\n    return final_list\n"
pipeline_tag: sentence-similarity
library_name: sentence-transformers
metrics:
- pearson_cosine
- spearman_cosine
model-index:
- name: SentenceTransformer based on Salesforce/codet5-base
  results:
  - task:
      type: semantic-similarity
      name: Semantic Similarity
    dataset:
      name: val sim
      type: val-sim
    metrics:
    - type: pearson_cosine
      value: 0.8926446076963541
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.18012737767621198
      name: Spearman Cosine
---

# SentenceTransformer based on Salesforce/codet5-base

This is a [sentence-transformers](https://www.SBERT.net) model finetuned from [Salesforce/codet5-base](https://huggingface.co/Salesforce/codet5-base). It maps sentences & paragraphs to a 768-dimensional dense vector space and can be used for semantic textual similarity, semantic search, paraphrase mining, text classification, clustering, and more.

## Model Details

### Model Description
- **Model Type:** Sentence Transformer
- **Base model:** [Salesforce/codet5-base](https://huggingface.co/Salesforce/codet5-base) <!-- at revision 02cd2d31bb7c6d0e4d91156167b2de044989c733 -->
- **Maximum Sequence Length:** 256 tokens
- **Output Dimensionality:** 768 dimensions
- **Similarity Function:** Cosine Similarity
<!-- - **Training Dataset:** Unknown -->
<!-- - **Language:** Unknown -->
<!-- - **License:** Unknown -->

### Model Sources

- **Documentation:** [Sentence Transformers Documentation](https://sbert.net)
- **Repository:** [Sentence Transformers on GitHub](https://github.com/UKPLab/sentence-transformers)
- **Hugging Face:** [Sentence Transformers on Hugging Face](https://huggingface.co/models?library=sentence-transformers)

### Full Model Architecture

```
SentenceTransformer(
  (0): Transformer({'max_seq_length': 256, 'do_lower_case': False, 'architecture': 'T5EncoderModel'})
  (1): Pooling({'word_embedding_dimension': 768, 'pooling_mode_cls_token': False, 'pooling_mode_mean_tokens': True, 'pooling_mode_max_tokens': False, 'pooling_mode_mean_sqrt_len_tokens': False, 'pooling_mode_weightedmean_tokens': False, 'pooling_mode_lasttoken': False, 'include_prompt': True})
)
```

## Usage

### Direct Usage (Sentence Transformers)

First install the Sentence Transformers library:

```bash
pip install -U sentence-transformers
```

Then you can load this model and run inference.
```python
from sentence_transformers import SentenceTransformer

# Download from the 🤗 Hub
model = SentenceTransformer("sentence_transformers_model_id")
# Run inference
sentences = [
    'import os\n\n\ndef task_func(log_file_path, keywords):\n    log_lines = []\n    with open(log_file_path, \'r\') as f:\n        for line in f:\n            if any(keyword in line for keyword in keywords):\n                parts = line.split()\n                timestamp = \' \'.join(parts[0:2])\n                message = \' \'.join(parts[3:])\n                formatted_line = f"{parts[0]} {parts[1]}{\' \' * 20}{message}"\n                log_lines.append(formatted_line)\n    return log_lines\n',
    'import os\n\n\ndef task_func(log_file_path, keywords):\n    if not keywords:\n        return []\n\n    def _read_file(path):\n        with open(path, \'r\') as f:\n            return f.readlines()\n\n    def _extract_parts(line):\n        parts = line.split(\' \', 2)\n        if len(parts) < 3:\n            return None, None, None\n        return parts[0], parts[1], parts[2].rstrip(\'\\n\')\n\n    def _format_line(kw, ts, msg):\n        return f"{kw}{\' \' * 20}{ts}{\' \' * 20}{msg}"\n    lines = _read_file(log_file_path)\n    kw_set = set(keywords)\n    result_dict = {}\n    for kw in kw_set:\n        result_dict[kw] = []\n    for line in lines:\n        for kw in kw_set:\n            if kw in line:\n                keyword, timestamp, message = _extract_parts(line)\n                if keyword is None:\n                    continue\n                formatted = _format_line(keyword, timestamp, message)\n                result_dict[keyword].append(formatted)\n    for line in lines:\n        for kw in kw_set:\n            if kw in line:\n                keyword, timestamp, message = _extract_parts(line)\n                if keyword is None:\n                    continue\n                formatted = _format_line(keyword, timestamp, message)\n                if keyword not in result_dict:\n                    result_dict[keyword] = []\n                result_dict[keyword].append(formatted)\n    final_list = []\n    for lst in result_dict.values():\n        final_list.extend(lst)\n    return final_list\n',
    "import random\nimport string\n\n\ndef task_func(text, seed=None):\n    if seed is None:\n        seed = 0\n    result = text.translate(str.maketrans('', '', string.punctuation)).replace(\n        ' ', '_').replace('\\t', '__').replace('\\n', '___')\n    if seed is not None:\n        random.seed(seed)\n        result = ''.join([(c.upper() if random.choice([True, False]) else c\n            ) for c in result])\n    else:\n        result = result.upper()\n    return result\n",
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[1.0000, 0.9828, 0.5042],
#         [0.9828, 1.0000, 0.5399],
#         [0.5042, 0.5399, 1.0000]])
```

<!--
### Direct Usage (Transformers)

<details><summary>Click to see the direct usage in Transformers</summary>

</details>
-->

<!--
### Downstream Usage (Sentence Transformers)

You can finetune this model on your own dataset.

<details><summary>Click to expand</summary>

</details>
-->

<!--
### Out-of-Scope Use

*List how the model may foreseeably be misused and address what users ought not to do with the model.*
-->

## Evaluation

### Metrics

#### Semantic Similarity

* Dataset: `val-sim`
* Evaluated with [<code>EmbeddingSimilarityEvaluator</code>](https://sbert.net/docs/package_reference/sentence_transformer/evaluation.html#sentence_transformers.evaluation.EmbeddingSimilarityEvaluator)

| Metric              | Value      |
|:--------------------|:-----------|
| pearson_cosine      | 0.8926     |
| **spearman_cosine** | **0.1801** |

<!--
## Bias, Risks and Limitations

*What are the known or foreseeable issues stemming from this model? You could also flag here known failure cases or weaknesses of the model.*
-->

<!--
### Recommendations

*What are recommendations with respect to the foreseeable issues? For example, filtering explicit content.*
-->

## Training Details

### Training Dataset

#### Unnamed Dataset

* Size: 2,287 training samples
* Columns: <code>sentence_0</code>, <code>sentence_1</code>, and <code>label</code>
* Approximate statistics based on the first 1000 samples:
  |         | sentence_0                                                                           | sentence_1                                                                           | label                                                          |
  |:--------|:-------------------------------------------------------------------------------------|:-------------------------------------------------------------------------------------|:---------------------------------------------------------------|
  | type    | string                                                                               | string                                                                               | float                                                          |
  | details | <ul><li>min: 42 tokens</li><li>mean: 166.95 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 15 tokens</li><li>mean: 166.55 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.98</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     | sentence_1                                                                                                                                                                                                                                                                                                                                               | label            |
  |:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code>import pickle<br>import logging<br>import pathlib<br><br><br>def task_func(df, file_path):<br>    logger = logging.getLogger(__name__)<br>    if not hasattr(df, 'equals'):<br>        raise TypeError('df must be a pandas DataFrame')<br>    if not isinstance(file_path, (str, pathlib.Path)):<br>        raise TypeError('file_path must be a string or Path')<br>    path = pathlib.Path(file_path)<br>    try:<br>        with path.open('wb') as f:<br>            pickle.dump(df, f)<br>        with path.open('rb') as f:<br>            loaded = pickle.load(f)<br>    except Exception:<br>        logger.exception('Error during pickle operation')<br>        raise<br>    finally:<br>        try:<br>            if path.exists():<br>                path.unlink()<br>        except Exception:<br>            logger.exception('Failed to delete file')<br>    return loaded<br></code> | <code>import pickle<br>import os<br><br><br>def task_func(df, file_name):<br>    save_file = open(file_name, 'wb')<br>    pickle.dump(df, save_file)<br>    save_file.close()<br>    load_file = open(file_name, 'rb')<br>    loaded_df = pickle.load(load_file)<br>    load_file.close()<br>    os.remove(file_name)<br>    return loaded_df<br></code> | <code>1.0</code> |
  | <code>import os<br>import shutil<br><br><br>def task_func(filename: str, dest_dir: str) ->str:<br>    """<br>    Copy a file to a specified destination directory and clear its contents.<br><br>    Args:<br>        filename (str): The path to the source file.<br>        dest_dir (str): The path to the destination directory.<br><br>    Returns:<br>        str: The absolute path to the copied file within the destination directory.<br><br>    Raises:<br>        FileNotFoundError: If the source file does not exist.<br>        OSError: If the destination directory is the same as the source file's directory.<br>    """<br>    os.makedirs(dest_dir, exist_ok=True)<br>    copied_file = shutil.copy2(filename, dest_dir)<br>    with open(filename, 'w') as f:<br>        pass<br>    return copied_file<br></code>                                                                       | <code>import os<br>from shutil import copyfile<br><br><br>def task_func(filename: str, dest_dir: str) ->str:<br>    os.makedirs(dest_dir, exist_ok=True)<br>    dest_path = os.path.join(dest_dir, os.path.basename(filename))<br>    copyfile(filename, dest_path)<br>    with open(filename, 'w'):<br>        pass<br>    return dest_path<br></code>  | <code>1.0</code> |
  | <code>import math<br>import pandas as pd<br><br><br>def task_func(tuples_list):<br>    """<br>    Convert a list of tuples into a Pandas DataFrame with math.sin applied to each number.<br><br>    Args:<br>        tuples_list: A list where each element is a tuple of numbers.<br><br>    Returns:<br>        A DataFrame where each element is the sine of the corresponding number in the input tuples.<br>    """<br>    return pd.DataFrame(data=[tuple(math.sin(num) for num in t) for t in<br>        tuples_list], columns=[f'sin_{i + 1}' for i in range(len(<br>        tuples_list[0]))] if tuples_list else [])<br></code>                                                                                                                                                                                                                                                                      | <code>import math<br>import pandas as pd<br><br><br>def task_func(tuples_list):<br>    result = []<br>    for t in tuples_list:<br>        row = []<br>        for n in t:<br>            row.append(math.sin(n))<br>        result.append(row)<br>    df = pd.DataFrame(result)<br>    return df<br></code>                                             | <code>1.0</code> |
* Loss: [<code>CosineSimilarityLoss</code>](https://sbert.net/docs/package_reference/sentence_transformer/losses.html#cosinesimilarityloss) with these parameters:
  ```json
  {
      "loss_fct": "torch.nn.modules.loss.MSELoss"
  }
  ```

### Training Hyperparameters
#### Non-Default Hyperparameters

- `fp16`: True
- `multi_dataset_batch_sampler`: round_robin

#### All Hyperparameters
<details><summary>Click to expand</summary>

- `overwrite_output_dir`: False
- `do_predict`: False
- `eval_strategy`: no
- `prediction_loss_only`: True
- `per_device_train_batch_size`: 8
- `per_device_eval_batch_size`: 8
- `per_gpu_train_batch_size`: None
- `per_gpu_eval_batch_size`: None
- `gradient_accumulation_steps`: 1
- `eval_accumulation_steps`: None
- `torch_empty_cache_steps`: None
- `learning_rate`: 5e-05
- `weight_decay`: 0.0
- `adam_beta1`: 0.9
- `adam_beta2`: 0.999
- `adam_epsilon`: 1e-08
- `max_grad_norm`: 1
- `num_train_epochs`: 3
- `max_steps`: -1
- `lr_scheduler_type`: linear
- `lr_scheduler_kwargs`: {}
- `warmup_ratio`: 0.0
- `warmup_steps`: 0
- `log_level`: passive
- `log_level_replica`: warning
- `log_on_each_node`: True
- `logging_nan_inf_filter`: True
- `save_safetensors`: True
- `save_on_each_node`: False
- `save_only_model`: False
- `restore_callback_states_from_checkpoint`: False
- `no_cuda`: False
- `use_cpu`: False
- `use_mps_device`: False
- `seed`: 42
- `data_seed`: None
- `jit_mode_eval`: False
- `bf16`: False
- `fp16`: True
- `fp16_opt_level`: O1
- `half_precision_backend`: auto
- `bf16_full_eval`: False
- `fp16_full_eval`: False
- `tf32`: None
- `local_rank`: 0
- `ddp_backend`: None
- `tpu_num_cores`: None
- `tpu_metrics_debug`: False
- `debug`: []
- `dataloader_drop_last`: False
- `dataloader_num_workers`: 0
- `dataloader_prefetch_factor`: None
- `past_index`: -1
- `disable_tqdm`: False
- `remove_unused_columns`: True
- `label_names`: None
- `load_best_model_at_end`: False
- `ignore_data_skip`: False
- `fsdp`: []
- `fsdp_min_num_params`: 0
- `fsdp_config`: {'min_num_params': 0, 'xla': False, 'xla_fsdp_v2': False, 'xla_fsdp_grad_ckpt': False}
- `fsdp_transformer_layer_cls_to_wrap`: None
- `accelerator_config`: {'split_batches': False, 'dispatch_batches': None, 'even_batches': True, 'use_seedable_sampler': True, 'non_blocking': False, 'gradient_accumulation_kwargs': None}
- `parallelism_config`: None
- `deepspeed`: None
- `label_smoothing_factor`: 0.0
- `optim`: adamw_torch_fused
- `optim_args`: None
- `adafactor`: False
- `group_by_length`: False
- `length_column_name`: length
- `project`: huggingface
- `trackio_space_id`: trackio
- `ddp_find_unused_parameters`: None
- `ddp_bucket_cap_mb`: None
- `ddp_broadcast_buffers`: False
- `dataloader_pin_memory`: True
- `dataloader_persistent_workers`: False
- `skip_memory_metrics`: True
- `use_legacy_prediction_loop`: False
- `push_to_hub`: False
- `resume_from_checkpoint`: None
- `hub_model_id`: None
- `hub_strategy`: every_save
- `hub_private_repo`: None
- `hub_always_push`: False
- `hub_revision`: None
- `gradient_checkpointing`: False
- `gradient_checkpointing_kwargs`: None
- `include_inputs_for_metrics`: False
- `include_for_metrics`: []
- `eval_do_concat_batches`: True
- `fp16_backend`: auto
- `push_to_hub_model_id`: None
- `push_to_hub_organization`: None
- `mp_parameters`: 
- `auto_find_batch_size`: False
- `full_determinism`: False
- `torchdynamo`: None
- `ray_scope`: last
- `ddp_timeout`: 1800
- `torch_compile`: False
- `torch_compile_backend`: None
- `torch_compile_mode`: None
- `include_tokens_per_second`: False
- `include_num_input_tokens_seen`: no
- `neftune_noise_alpha`: None
- `optim_target_modules`: None
- `batch_eval_metrics`: False
- `eval_on_start`: False
- `use_liger_kernel`: False
- `liger_kernel_config`: None
- `eval_use_gather_object`: False
- `average_tokens_across_devices`: True
- `prompts`: None
- `batch_sampler`: batch_sampler
- `multi_dataset_batch_sampler`: round_robin
- `router_mapping`: {}
- `learning_rate_mapping`: {}

</details>

### Training Logs
| Epoch  | Step | Training Loss | val-sim_spearman_cosine |
|:------:|:----:|:-------------:|:-----------------------:|
| 1.0    | 286  | -             | 0.1837                  |
| 1.7483 | 500  | 0.0233        | -                       |
| 2.0    | 572  | -             | 0.1775                  |
| 3.0    | 858  | -             | 0.1801                  |


### Framework Versions
- Python: 3.13.5
- Sentence Transformers: 5.1.1
- Transformers: 4.57.0
- PyTorch: 2.9.0+cu130
- Accelerate: 1.10.1
- Datasets: 4.2.0
- Tokenizers: 0.22.1

## Citation

### BibTeX

#### Sentence Transformers
```bibtex
@inproceedings{reimers-2019-sentence-bert,
    title = "Sentence-BERT: Sentence Embeddings using Siamese BERT-Networks",
    author = "Reimers, Nils and Gurevych, Iryna",
    booktitle = "Proceedings of the 2019 Conference on Empirical Methods in Natural Language Processing",
    month = "11",
    year = "2019",
    publisher = "Association for Computational Linguistics",
    url = "https://arxiv.org/abs/1908.10084",
}
```

<!--
## Glossary

*Clearly define terms in order to be accessible across audiences.*
-->

<!--
## Model Card Authors

*Lists the people who create the model card, providing recognition and accountability for the detailed work that goes into its construction.*
-->

<!--
## Model Card Contact

*Provides a way for people who have updates to the Model Card, suggestions, or questions, to contact the Model Card authors.*
-->