---
tags:
- sentence-transformers
- sentence-similarity
- feature-extraction
- dense
- generated_from_trainer
- dataset_size:4259
- loss:CosineSimilarityLoss
base_model: microsoft/codebert-base
widget:
- source_sentence: "total_sales = {}\n    colors = ['red', 'yellow', 'green', 'blue',\
    \ 'purple']\n    for entry in data:\n        if not isinstance(entry, dict):\n\
    \            raise TypeError('Data must be a list of dictionaries')\n        for\
    \ fruit, quantity in entry.items():\n            if not isinstance(fruit, str):\n\
    \                raise TypeError('Fruit names must be strings')\n            if\
    \ quantity < 0:\n                raise ValueError('Sales quantity cannot be negative')\n\
    \            if fruit in total_sales:\n                total_sales[fruit] += quantity\n\
    \            else:\n                total_sales[fruit] = quantity\n    ax = None\n\
    \    if total_sales:\n        fig, ax = plt.subplots()\n        bars = ax.bar(total_sales.keys(),\
    \ total_sales.values())\n        for i, bar in enumerate(bars):\n            color\
    \ = colors[i % len(colors)]\n            bar.set_color(color)\n    return total_sales,\
    \ ax"
  sentences:
  - "result = []\n    with open(log_file_path, 'r') as f:\n        for line in f:\n\
    \            if any(re.search('\\\\b' + keyword + '\\\\b', line) for keyword in\n\
    \                keywords):\n                result.append(line)\n    return result"
  - "if not data:\n        return {}, None\n    total_sales = {}\n    for d in data:\n\
    \        for key, value in d.items():\n            if not isinstance(value, (int,\
    \ float)):\n                raise TypeError('Sales quantities must be numeric')\n\
    \            if value < 0:\n                raise ValueError('Sales quantities\
    \ must be non-negative')\n            if key not in total_sales:\n           \
    \     total_sales[key] = 0\n            total_sales[key] += value\n    labels\
    \ = list(total_sales.keys())\n    values = list(total_sales.values())\n    ax\
    \ = plt.bar(labels, values)\n    plt.xlabel('Fruit')\n    plt.ylabel('Total Sales')\n\
    \    plt.title('Total Fruit Sales')\n    return dict(total_sales), ax"
  - "if not data:\n        return dict(), None\n    all_fruits = set()\n    for d\
    \ in data:\n        for fruit in d.keys():\n            all_fruits.add(fruit)\n\
    \    for d in data:\n        for fruit, qty in d.items():\n            if qty\
    \ < 0:\n                raise ValueError('Sales quantity must not be negative')\n\
    \    total_sales = {}\n    for fruit in all_fruits:\n        total = sum(d.get(fruit,\
    \ 0) for d in data)\n        total_sales[fruit] = total\n    sorted_fruits = sorted(total_sales.keys())\n\
    \    labels = []\n    values = []\n    for fruit in sorted_fruits:\n        labels.append(fruit)\n\
    \        values.append(total_sales[fruit])\n    colors = ['red', 'yellow', 'green',\
    \ 'blue', 'purple']\n    ax = plt.bar(labels, values, color=colors[:len(labels)])\n\
    \    plt.xlabel('Fruit')\n    plt.ylabel('Total Sales')\n    plt.title('Total\
    \ Fruit Sales')\n    return total_sales, ax"
- source_sentence: "os.makedirs(dest_dir, exist_ok=True)\n    dest_path = os.path.join(dest_dir,\
    \ os.path.basename(filename))\n    copyfile(filename, dest_path)\n    with open(filename,\
    \ 'w'):\n        pass\n    return dest_path"
  sentences:
  - "def create_directory(directory_path):\n        try:\n            os.mkdir(directory_path)\n\
    \        except FileExistsError:\n            pass\n\n    def copy_file(source_path,\
    \ destination_path):\n        return shutil.copy2(source_path, destination_path)\n\
    \n    def clear_file_content(file_path):\n        with open(file_path, 'w') as\
    \ file:\n            pass\n    create_directory(dest_dir)\n    copied_file = copy_file(filename,\
    \ os.path.join(dest_dir, os.path.\n        basename(filename)))\n    clear_file_content(filename)\n\
    \    return os.path.abspath(copied_file)"
  - "path = Path(file_path)\n    if not path.is_file():\n        raise FileNotFoundError(f'File\
    \ not found: {file_path}')\n    try:\n        with path.open(newline='', encoding='utf-8')\
    \ as f:\n            reader = csv.DictReader(f)\n            rows = list(reader)\n\
    \    except csv.Error as e:\n        raise ValueError(f'Error reading CSV: {e}')\n\
    \    df = pd.DataFrame(rows)\n    if column_name and column_name in df.columns:\n\
    \        df[column_name] = df[column_name].apply(lambda x: x.replace('\\n',\n\
    \            '<br>') if isinstance(x, str) else x)\n    return df"
  - "data = df[column_name].values\n    stat, p_value = shapiro(data)\n    return\
    \ p_value > alpha"
- source_sentence: "theta = np.linspace(0, 2 * np.pi, 100)\n    amplitude = random.uniform(0.5,\
    \ 1.5)\n    phase = random.uniform(0, 2 * np.pi)\n    y = amplitude * np.sin(phase\
    \ * theta)\n    color = random.choice(['b', 'g', 'r', 'c', 'm', 'y', 'k'])\n \
    \   ax.plot(theta, y, color=color)\n    ax.set_rlabel_position(random.uniform(0,\
    \ 360))\n    return color"
  sentences:
  - "def flatten(lst):\n        dq = deque()\n        for item in lst:\n         \
    \   if isinstance(item, list):\n                dq.extend(flatten(item))\n   \
    \         else:\n                dq.append(item)\n        return list(dq)\n  \
    \  flattened = flatten(L)\n    if not flattened:\n        raise ValueError('List\
    \ is empty')\n    sorted_list = sorted(flattened)\n    n = len(sorted_list)\n\
    \    if n % 2 == 0:\n        median = (sorted_list[n // 2 - 1] + sorted_list[n\
    \ // 2]) / 2\n    else:\n        median = sorted_list[n // 2]\n    return median"
  - "if not isinstance(df, pd.DataFrame) or df.empty:\n        raise ValueError('Input\
    \ must be a non-empty DataFrame')\n    df.iloc[:, -1] = df.iloc[:, -1].fillna(df.iloc[:,\
    \ -1].mean())\n    ax = df.iloc[:, -1].plot(kind='box', title='Boxplot of Last\
    \ Column')\n    ax.set_xlabel('D')\n    return df, ax"
  - ''
- source_sentence: "x = np.linspace(mu - 3 * sigma, mu + 3 * sigma, 100)\n    y =\
    \ np.random.normal(mu, sigma, num_samples)\n    plt.figure(figsize=(8, 6))\n \
    \   plt.hist(y, bins=30, density=True, alpha=0.7, label='Histogram')\n    plt.plot(x,\
    \ np.random.normal(mu, sigma, len(x)), 'r', linewidth=2,\n        label='Normal\
    \ Distribution')\n    plt.title('Normal Distribution')\n    plt.xlabel('Value')\n\
    \    plt.ylabel('Density')\n    plt.legend()\n    plt.grid(True)\n    return plt.gcf()"
  sentences:
  - "n = len(numbers)\n    total = 0.0\n    for mask in range(1, 1 << n):\n      \
    \  prod = 1\n        for i in range(n):\n            if mask >> i & 1:\n     \
    \           prod *= numbers[i]\n        total += math.log(prod)\n    return total"
  - "try:\n        with open(log_file_path, 'r') as log:\n            formatted_lines\
    \ = []\n            for line in log:\n                parts = line.strip().split('\
    \ ', 2)\n                if len(parts) == 3 and any(keyword in parts[0] for keyword\
    \ in\n                    keywords):\n                    timestamp = datetime.strptime(parts[1],\
    \ '%H:%M:%S')\n                    formatted_line = (\n                      \
    \  f\"{parts[0]:>{20}} : {timestamp.strftime('%Y-%m-%d %H:%M:%S')}: {parts[2]:>{20}}\"\
    \n                        )\n                    formatted_lines.append(formatted_line)\n\
    \            return formatted_lines\n    except FileNotFoundError:\n        raise"
  - "if hex_key is not None:\n        chosen = round(struct.unpack('>f', bytes.fromhex(hex_key))[0],\
    \ 2)\n    else:\n        floats = [round(struct.unpack('>f', bytes.fromhex(h))[0],\
    \ 2) for h in\n            KEYS]\n        chosen = random.choice(floats)\n   \
    \ return chosen"
- source_sentence: "with open(file_path, 'r') as file:\n        reader = csv.reader(file)\n\
    \        data = list(reader)\n    df = pd.DataFrame(data[1:], columns=data[0])\n\
    \    if column_name in df.columns:\n        df[column_name] = df[column_name].str.replace('\\\
    n', '<br>')\n    return df"
  sentences:
  - "if not os.path.isfile(log_file_path):\n        raise FileNotFoundError(f'Log\
    \ file {log_file_path} does not exist.')\n    formatted_lines = []\n    try:\n\
    \        with open(log_file_path, 'r') as log_file:\n            for line in log_file:\n\
    \                for keyword in keywords:\n                    if keyword.lower()\
    \ in line.lower():\n                        parts = line.strip().split()\n   \
    \                     if len(parts) >= 3:\n                            timestamp\
    \ = parts[1]\n                            message = ' '.join(parts[2:])\n    \
    \                        formatted_line = (\n                                f'{keyword:20}\
    \ : {timestamp:20} : {message:20}'\n                                )\n      \
    \                      formatted_lines.append(formatted_line)\n              \
    \          else:\n                            formatted_lines.append(\n      \
    \                          f'Line format unexpected: {line.strip()}')\n      \
    \  return formatted_lines\n    except Exception as e:\n        raise RuntimeError(f'Error\
    \ processing log file: {e}')"
  - "path = Path(file_path)\n    if not path.is_file():\n        raise FileNotFoundError(f'File\
    \ not found: {file_path}')\n    try:\n        with path.open(newline='', encoding='utf-8')\
    \ as f:\n            reader = csv.DictReader(f)\n            rows = list(reader)\n\
    \    except csv.Error as e:\n        raise ValueError(f'Error reading CSV: {e}')\n\
    \    df = pd.DataFrame(rows)\n    if column_name and column_name in df.columns:\n\
    \        df[column_name] = df[column_name].apply(lambda x: x.replace('\\n',\n\
    \            '<br>') if isinstance(x, str) else x)\n    return df"
  - "if not isinstance(df, pd.DataFrame):\n        raise Exception('Input must be\
    \ a pandas DataFrame')\n    total_brackets = 0\n    for col in df.columns:\n \
    \       for value in df[col]:\n            total_brackets += len(re.findall('[\\\
    \\(\\\\)\\\\{\\\\}\\\\[\\\\]]', str(\n                value)))\n    return total_brackets"
pipeline_tag: sentence-similarity
library_name: sentence-transformers
metrics:
- pearson_cosine
- spearman_cosine
model-index:
- name: SentenceTransformer based on microsoft/codebert-base
  results:
  - task:
      type: semantic-similarity
      name: Semantic Similarity
    dataset:
      name: val sim
      type: val-sim
    metrics:
    - type: pearson_cosine
      value: 0.9761237425180157
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.8590985763988691
      name: Spearman Cosine
---

# SentenceTransformer based on microsoft/codebert-base

This is a [sentence-transformers](https://www.SBERT.net) model finetuned from [microsoft/codebert-base](https://huggingface.co/microsoft/codebert-base). It maps sentences & paragraphs to a 768-dimensional dense vector space and can be used for semantic textual similarity, semantic search, paraphrase mining, text classification, clustering, and more.

## Model Details

### Model Description
- **Model Type:** Sentence Transformer
- **Base model:** [microsoft/codebert-base](https://huggingface.co/microsoft/codebert-base) <!-- at revision 3b0952feddeffad0063f274080e3c23d75e7eb39 -->
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
  (0): Transformer({'max_seq_length': 256, 'do_lower_case': False, 'architecture': 'RobertaModel'})
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
    "with open(file_path, 'r') as file:\n        reader = csv.reader(file)\n        data = list(reader)\n    df = pd.DataFrame(data[1:], columns=data[0])\n    if column_name in df.columns:\n        df[column_name] = df[column_name].str.replace('\\n', '<br>')\n    return df",
    "path = Path(file_path)\n    if not path.is_file():\n        raise FileNotFoundError(f'File not found: {file_path}')\n    try:\n        with path.open(newline='', encoding='utf-8') as f:\n            reader = csv.DictReader(f)\n            rows = list(reader)\n    except csv.Error as e:\n        raise ValueError(f'Error reading CSV: {e}')\n    df = pd.DataFrame(rows)\n    if column_name and column_name in df.columns:\n        df[column_name] = df[column_name].apply(lambda x: x.replace('\\n',\n            '<br>') if isinstance(x, str) else x)\n    return df",
    "if not os.path.isfile(log_file_path):\n        raise FileNotFoundError(f'Log file {log_file_path} does not exist.')\n    formatted_lines = []\n    try:\n        with open(log_file_path, 'r') as log_file:\n            for line in log_file:\n                for keyword in keywords:\n                    if keyword.lower() in line.lower():\n                        parts = line.strip().split()\n                        if len(parts) >= 3:\n                            timestamp = parts[1]\n                            message = ' '.join(parts[2:])\n                            formatted_line = (\n                                f'{keyword:20} : {timestamp:20} : {message:20}'\n                                )\n                            formatted_lines.append(formatted_line)\n                        else:\n                            formatted_lines.append(\n                                f'Line format unexpected: {line.strip()}')\n        return formatted_lines\n    except Exception as e:\n        raise RuntimeError(f'Error processing log file: {e}')",
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[1.0000, 0.9811, 0.1692],
#         [0.9811, 1.0000, 0.1702],
#         [0.1692, 0.1702, 1.0000]])
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
| pearson_cosine      | 0.9761     |
| **spearman_cosine** | **0.8591** |

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

* Size: 4,259 training samples
* Columns: <code>sentence_0</code>, <code>sentence_1</code>, and <code>label</code>
* Approximate statistics based on the first 1000 samples:
  |         | sentence_0                                                                          | sentence_1                                                                          | label                                                         |
  |:--------|:------------------------------------------------------------------------------------|:------------------------------------------------------------------------------------|:--------------------------------------------------------------|
  | type    | string                                                                              | string                                                                              | float                                                         |
  | details | <ul><li>min: 2 tokens</li><li>mean: 190.54 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 2 tokens</li><li>mean: 195.06 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.5</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 | sentence_1                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | label            |
  |:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code>timezones = [pytz.timezone('UTC'), pytz.timezone('America/Los_Angeles'),<br>        pytz.timezone('Europe/Paris'), pytz.timezone('Asia/Kolkata'), pytz.<br>        timezone('Australia/Sydney')]<br>    colors = ['b', 'g', 'r', 'c', 'm']<br>    start_date = datetime.strptime(start_time, '%Y-%m-%d').date()<br>    end_date = datetime.strptime(end_time, '%Y-%m-%d').date()<br>    dates = []<br>    current_date = start_date<br>    while current_date <= end_date:<br>        dates.append(current_date)<br>        current_date += timedelta(days=1)<br>    fig, ax = plt.subplots(figsize=(10, 6))<br>    for i, tz in enumerate(timezones):<br>        times_diff = []<br>        for date in dates:<br>            dt = datetime.combine(date, datetime.max.time(), tzinfo=tz)<br>            utc_dt = dt.astimezone(pytz.utc)<br>            diff = utc_dt.hour + utc_dt.minute / 60.0<br>            times_diff.append(diff)<br>        ax.plot(dates, times_diff, color=colors[i], label=tz.zone)<br>    ax.set_xlabel('Date')<br>    ax.set_ylabel('Time Difference (Hours)')<br>    ax.le...</code> | <code>words = len(re.findall('\\b\\w+\\b', text))<br>    punctuation = len(re.findall('[^\\w\\s]', text))<br>    return words, punctuation</code>                                                                                                                                                                                                                                                                                                                               | <code>0.0</code> |
  | <code>txt_files = glob(os.path.join(directory, '*.txt'))<br>    results = []<br>    for file_path in txt_files:<br>        with open(file_path, 'r') as f:<br>            lines = f.readlines()<br>            for line in lines:<br>                stripped_line = line.strip()<br>                if stripped_line:<br>                    try:<br>                        result = ast.literal_eval(stripped_line)<br>                        results.append(result)<br>                    except (ValueError, SyntaxError):<br>                        raise ValueError(<br>                            f'Invalid dictionary in file: {file_path}')<br>    return results</code>                                                                                                                                                                                                                                                                                                                                                                                                                                     | <code>words = re.findall('\\b\\w+\\b', input_string)<br>    stop_words = {'is', 'a', 'only', 'this'}<br>    filtered = [w for w in words if w not in stop_words]<br>    return dict(Counter(filtered))</code>                                                                                                                                                                                                                                                                   | <code>0.0</code> |
  | <code>try:<br>        os.makedirs(dest_dir, exist_ok=True)<br>    except OSError as e:<br>        if e.errno != errno.EEXIST:<br>            raise<br>    shutil.copy2(filename, os.path.join(dest_dir, os.path.basename(filename)))<br>    with open(filename, 'w') as f:<br>        f.truncate(0)<br>    return os.path.abspath(os.path.join(dest_dir, os.path.basename(filename)))</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               | <code>def copy_file(src: str, dst: str) ->None:<br>        shutil.copy2(src, dst)<br><br>    def clear_file(file_path: str) ->None:<br>        with open(file_path, 'w') as f:<br>            pass<br>    if not os.path.exists(dest_dir):<br>        os.makedirs(dest_dir)<br>    file_name = os.path.basename(filename)<br>    dest_path = os.path.join(dest_dir, file_name)<br>    copy_file(filename, dest_path)<br>    clear_file(filename)<br>    return dest_path</code> | <code>1.0</code> |
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
| 0.9381 | 500  | 0.1728        | -                       |
| 1.0    | 533  | -             | 0.8548                  |
| 1.8762 | 1000 | 0.0176        | -                       |
| 2.0    | 1066 | -             | 0.8587                  |
| 2.8143 | 1500 | 0.0096        | -                       |
| 3.0    | 1599 | -             | 0.8591                  |


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