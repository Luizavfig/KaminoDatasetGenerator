---
tags:
- sentence-transformers
- sentence-similarity
- feature-extraction
- dense
- generated_from_trainer
- dataset_size:55745
- loss:CosineSimilarityLoss
base_model: Salesforce/codet5-base
widget:
- source_sentence: "def extract_matches(row):\n        return re.findall('([a-fA-F\\\
    \\d]{32})', row)\n    matches = df[column].apply(extract_matches)\n    flattened_matches\
    \ = [match for sublist in matches.values for match in\n        sublist]\n    try:\n\
    \        counts = {}\n        for match in flattened_matches:\n            if\
    \ match not in counts:\n                counts[match] = 1\n            else:\n\
    \                counts[match] += 1\n        return pd.Series(counts)\n    except\
    \ Exception as e:\n        print(f'An error occurred: {e}')\n        return pd.Series()"
  sentences:
  - "try:\n        bytes_value = bytes.fromhex(hex_string)\n        float_value =\
    \ struct.unpack('>f', bytes_value)[0]\n        buffer = BytesIO()\n        buffer.write(struct.pack('>f',\
    \ float_value))\n        return buffer.getvalue()\n    except ValueError as e:\n\
    \        raise e"
  - ''
  - "\"\"\"Return Series of counts of each unique 32‑character hex match in df[column].\"\
    \"\"\n    pattern = '([a-fA-F\\\\d]{32})'\n    return df[column].astype(str).str.findall(pattern).explode().value_counts()"
- source_sentence: "\"\"\"Return mean, median, and mode of sums of all subsets of\
    \ given size.\"\"\"\n    sums = []\n\n    def backtrack(start, comb):\n      \
    \  if len(comb) == subset_size:\n            sums.append(sum(comb))\n        \
    \    return\n        for i in range(start, len(elements)):\n            backtrack(i\
    \ + 1, comb + (elements[i],))\n    backtrack(0, ())\n    n = len(sums)\n    mean_val\
    \ = sum(sums) / n if n else 0\n    sorted_sums = sorted(sums)\n    if n % 2:\n\
    \        median_val = sorted_sums[n // 2]\n    else:\n        median_val = (sorted_sums[n\
    \ // 2 - 1] + sorted_sums[n // 2]) / 2\n    freq = {}\n    for s in sums:\n  \
    \      freq[s] = freq.get(s, 0) + 1\n    mode_val = max(freq, key=lambda k: freq[k])\n\
    \    return {'mean': mean_val, 'median': median_val, 'mode': mode_val}"
  sentences:
  - "subsets = list(itertools.combinations(elements, subset_size))\n    sums = [sum(subset)\
    \ for subset in subsets]\n    return {'mean': mean(sums), 'median': median(sorted(sums)),\
    \ 'mode':\n        mode(sums)}"
  - "if not isinstance(df, pd.DataFrame):\n        raise ValueError('Input must be\
    \ a DataFrame')\n    for col in cols:\n        if col not in df.columns:\n   \
    \         raise ValueError(f\"Column '{col}' does not exist in the DataFrame\"\
    )\n    scaler = StandardScaler()\n    standardized_df = df.copy()\n    standardized_df[cols]\
    \ = scaler.fit_transform(df[cols])\n    return standardized_df"
  - "\"\"\"\n    Extract URLs from a JSON string and return a dictionary mapping each\
    \ URL\n    to the number of times it appears. If a second argument is supplied,\n\
    \    it specifies the maximum number of top URLs to return.\n    \"\"\"\n    pattern\
    \ = 'https?://[^\\\\s]+|www\\\\.[^\\\\s]+'\n    data = json.loads(json_str)\n\
    \    urls = []\n    stack = [data]\n    while stack:\n        current = stack.pop()\n\
    \        for value in current.values():\n            if isinstance(value, dict):\n\
    \                stack.append(value)\n            elif isinstance(value, str)\
    \ and re.fullmatch(pattern, value):\n                urls.append(value)\n    if\
    \ not urls:\n        return {}\n    counter = Counter(urls)\n    top_n = args[0]\
    \ if args else None\n    if top_n is None or len(counter) <= top_n:\n        return\
    \ dict(counter)\n    return dict(counter.most_common(top_n))"
- source_sentence: "parsed = datetime.strptime(date_str, '%Y-%m-%d %H:%M:%S')\n  \
    \  now = datetime.now()\n    diff = now - parsed\n    seconds = diff.total_seconds()\n\
    \    leap_count = np.sum(LEAP_SECONDS >= parsed.year)\n    return int(seconds\
    \ + leap_count)"
  sentences:
  - ''
  - "files = os.listdir(directory)\n    file_groups = {}\n    for filename in files:\n\
    \        match = re.search('\\\\.(.*?)$', filename)\n        if match:\n     \
    \       ext = match.group(1)\n            dest_dir = os.path.join(directory, ext)\n\
    \            if not os.path.exists(dest_dir):\n                os.makedirs(dest_dir)\n\
    \            src_path = os.path.join(directory, filename)\n            shutil.move(src_path,\
    \ dest_dir)"
  - "df = df[columns]\n    missing_cols = [col for col in columns if col not in df.columns]\n\
    \    if len(missing_cols) > 0:\n        raise Exception('Columns not found: '\
    \ + ', '.join(missing_cols))\n    try:\n        filtered_df = df[df[columns[1]]\
    \ > larger]\n        filtered_df = filtered_df[filtered_df[columns[2]] == equal]\n\
    \        contingency_table = pd.crosstab(filtered_df[columns[0]],\n          \
    \  filtered_df[columns[1]])\n        chi2, p_value, _, _ = chi2_contingency(contingency_table)\n\
    \        return p_value\n    except Exception as e:\n        raise Exception('Error\
    \ processing DataFrame: ' + str(e))"
- source_sentence: "\"\"\"\n    Generates a normal distribution, plots its histogram\
    \ and PDF, and returns the distribution and the plot.\n\n    Args:\n        length\
    \ (int): The length of the distribution to be generated.\n\n    Returns:\n   \
    \     tuple: A tuple containing: 1. numpy array with the normal distribution.\
    \ 2. matplotlib Axes object representing the plot.\n    \"\"\"\n    distribution\
    \ = np.random.normal(0, 1, length)\n    fig, ax = plt.subplots()\n    ax.hist(distribution,\
    \ density=True, bins=30)\n    x = np.linspace(0, 1, 100)\n    pdf = np.random.normal(0,\
    \ 1, 100)\n    ax.plot(x, pdf, linewidth=2, color='r', label='PDF')\n    ax.legend()\n\
    \    return distribution, ax"
  sentences:
  - "\"\"\"Count frequency of each letter after repeating the list.\"\"\"\n    if\
    \ not letters or repetitions <= 0:\n        return {}\n    freq = {}\n    for\
    \ letter in (letters * repetitions):\n        if letter in freq:\n           \
    \ freq[letter] += 1\n        else:\n            freq[letter] = 1\n    return freq"
  - "try:\n        combined = a + b\n        if items is not None:\n            counter\
    \ = {item: combined.count(item) for item in items}\n        else:\n          \
    \  counter = {}\n        df = pd.DataFrame(list(counter.items()), columns=['Item',\
    \ 'Frequency'])\n        plt.bar(df['Item'], df['Frequency'])\n        plt.xlabel('Items')\n\
    \        plt.ylabel('Frequency')\n        plt.title('Item Frequency in Combined\
    \ List')\n        plt.xticks(rotation=45)\n        plt.tight_layout()\n      \
    \  return plt.gca()\n    except Exception as e:\n        print(f'An error occurred:\
    \ {e}')\n        return None\n\n\na = ['apple', 'banana', 'orange']\nb = ['banana',\
    \ 'orange', 'grape']\nitems = ['apple', 'banana']\nresult = task_func(a, b, items)"
  - "\"\"\"Generate a normal distribution and plot its histogram with PDF.\"\"\"\n\
    \    dist = np.random.standard_normal(length)\n    fig, ax = plt.subplots()\n\
    \    ax.hist(dist, bins=30, density=True, alpha=0.6, color='g')\n    x_vals =\
    \ np.linspace(dist.min() - 1, dist.max() + 1, 200)\n    pdf_vals = 1 / np.sqrt(2\
    \ * np.pi) * np.exp(-x_vals ** 2 / 2)\n    ax.plot(x_vals, pdf_vals, color='r')\n\
    \    return dist, ax"
- source_sentence: "df = pd.read_csv(file_name)\n    if df.empty:\n        raise ValueError('DataFrame\
    \ is empty')\n    numeric_cols = df.select_dtypes(include=[np.number]).columns.tolist()\n\
    \    if not numeric_cols:\n        raise ValueError('No numeric columns to normalize')\n\
    \    for col in numeric_cols:\n        col_min = df[col].min()\n        col_max\
    \ = df[col].max()\n        if col_max == col_min:\n            df[col] = 0.0\n\
    \        else:\n            df[col] = (df[col] - col_min) / (col_max - col_min)\n\
    \    for col in numeric_cols:\n        pass\n    return df"
  sentences:
  - "\"\"\"\n    Reads CSV file and processes date column to generate year histogram.\n\
    \n    Args:\n        csv_path (str): Path to the CSV file\n        date_column\
    \ (str): Name of the date column in the CSV\n\n    Returns:\n        matplotlib\
    \ axes object containing the histogram plot\n\n    Raises:\n        FileNotFoundError:\
    \ If the CSV file does not exist\n        ValueError: If the CSV is empty or contains\
    \ invalid dates\n    \"\"\"\n    if not os.path.exists(csv_path):\n        raise\
    \ FileNotFoundError(f'CSV file at {csv_path} does not exist')\n    try:\n    \
    \    df = pd.read_csv(csv_path)\n        if date_column not in df.columns:\n \
    \           raise ValueError(f'Date column {date_column} not found in CSV')\n\
    \        years = []\n        for date_str in df[date_column]:\n            try:\n\
    \                parsed_date = parse(date_str)\n                years.append(parsed_date.year)\n\
    \            except ValueError:\n                raise ValueError(f'Invalid date\
    \ format in column: {date_str}')\n        plt.figure()\n        plt.hist(years,\
    \ bins=range(1900, 2030), edgecolor='black')\n        plt.title('Year Distribution')\n\
    \        plt.xlabel('Year')\n        plt.ylabel('Count')\n        return plt.gca()\n\
    \    except pd.errors.EmptyDataError:\n        raise ValueError('CSV file is empty')"
  - "item_lengths = [len(row) for row in df.values]\n    if len(set(item_lengths))\
    \ != 1:\n        raise ValueError('All rows must have the same number of items')\n\
    \    all_combinations = set()\n    for row in df.values:\n        all_combinations.update(combinations(row,\
    \ len(row)))\n    freq_dict = defaultdict(int)\n    for row in df.values:\n  \
    \      combination = tuple(sorted(row))\n        freq_dict[combination] += 1\n\
    \    return dict(freq_dict)"
  - "\"\"\"Perform DBSCAN clustering on the data and add cluster labels to DataFrame.\"\
    \"\"\n    df = pd.DataFrame([dict(zip(cols, row)) for row in data])\n    dbscan_model\
    \ = DBSCAN(eps=3, min_samples=2)\n    cluster_labels = dbscan_model.fit_predict(df)\n\
    \    df['Cluster'] = cluster_labels\n    return df"
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
      value: 0.9709622651157053
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.8583390571191828
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
- **Repository:** [Sentence Transformers on GitHub](https://github.com/huggingface/sentence-transformers)
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
    "df = pd.read_csv(file_name)\n    if df.empty:\n        raise ValueError('DataFrame is empty')\n    numeric_cols = df.select_dtypes(include=[np.number]).columns.tolist()\n    if not numeric_cols:\n        raise ValueError('No numeric columns to normalize')\n    for col in numeric_cols:\n        col_min = df[col].min()\n        col_max = df[col].max()\n        if col_max == col_min:\n            df[col] = 0.0\n        else:\n            df[col] = (df[col] - col_min) / (col_max - col_min)\n    for col in numeric_cols:\n        pass\n    return df",
    '"""Perform DBSCAN clustering on the data and add cluster labels to DataFrame."""\n    df = pd.DataFrame([dict(zip(cols, row)) for row in data])\n    dbscan_model = DBSCAN(eps=3, min_samples=2)\n    cluster_labels = dbscan_model.fit_predict(df)\n    df[\'Cluster\'] = cluster_labels\n    return df',
    "item_lengths = [len(row) for row in df.values]\n    if len(set(item_lengths)) != 1:\n        raise ValueError('All rows must have the same number of items')\n    all_combinations = set()\n    for row in df.values:\n        all_combinations.update(combinations(row, len(row)))\n    freq_dict = defaultdict(int)\n    for row in df.values:\n        combination = tuple(sorted(row))\n        freq_dict[combination] += 1\n    return dict(freq_dict)",
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[ 1.0000, -0.0192,  0.0453],
#         [-0.0192,  1.0000, -0.0322],
#         [ 0.0453, -0.0322,  1.0000]])
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
| pearson_cosine      | 0.971      |
| **spearman_cosine** | **0.8583** |

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

* Size: 55,745 training samples
* Columns: <code>sentence_0</code>, <code>sentence_1</code>, and <code>label</code>
* Approximate statistics based on the first 1000 samples:
  |         | sentence_0                                                                          | sentence_1                                                                          | label                                                         |
  |:--------|:------------------------------------------------------------------------------------|:------------------------------------------------------------------------------------|:--------------------------------------------------------------|
  | type    | string                                                                              | string                                                                              | float                                                         |
  | details | <ul><li>min: 2 tokens</li><li>mean: 153.68 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 2 tokens</li><li>mean: 152.26 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.5</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            | sentence_1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          | label            |
  |:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code>with open(csv_file, 'r') as f:<br>        content = f.read()<br>    content = content.replace(csv_delimiter, '\n')<br>    words = content.splitlines()<br>    freq = {}<br>    for w in words:<br>        if w in freq:<br>            freq[w] += 1<br>        else:<br>            freq[w] = 1<br>    dummy = {}<br>    for w in words:<br>        dummy[w] = dummy.get(w, 0) + 1<br><br>    def unused_helper():<br>        return None<br>    result = []<br>    for k, v in freq.items():<br>        result.append((k, v))<br>    result.sort(key=lambda x: x[1], reverse=True)<br>    return result</code> | <code>"""<br>    Reads a CSV file and counts the most common words in the file.<br><br>    Args:<br>        csv_file (str): The path to the CSV file.<br>        csv_delimiter (str): The delimiter used in the CSV file.<br><br>    Returns:<br>        list: A list of tuples, each containing a word and its frequency,<br>              sorted by frequency in descending order.<br>    """<br>    try:<br>        with open(csv_file, 'r') as f:<br>            content = f.read()<br>    except FileNotFoundError:<br>        return []<br>    words = re.findall('\\b\\w+\\b', content.lower())<br>    word_counts = defaultdict(int)<br>    for word in words:<br>        word_counts[word] += 1<br>    most_common_words = sorted(word_counts.items(), key=lambda x: x[1],<br>        reverse=True)<br>    return most_common_words</code> | <code>1.0</code> |
  | <code>if not isinstance(t, tuple) or not all(isinstance(x, int) for x in t):<br>        raise ValueError('Input must be a tuple of integers')<br>    if n < 0:<br>        raise ValueError('n cannot be negative')<br>    if n == 0:<br>        return ()<br>    valid_combinations = list(it_combinations(t, n))<br>    if not valid_combinations:<br>        return ()<br>    return random.choice(valid_combinations)</code>                                                                                                                                                                                       | <code>"""<br>    Generates a random combination of length n from a tuple.<br>    """<br>    import random<br>    combinations = random.sample(t, n)<br>    return combinations</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               | <code>1.0</code> |
  | <code>merged = [elem for sub in list_of_lists for elem in sub]<br>    if not merged:<br>        return np.array([]), 0<br>    freq = Counter(merged)<br>    mode_val, mode_cnt = freq.most_common(1)[0]<br>    return np.array(mode_val), mode_cnt</code>                                                                                                                                                                                                                                                                                                                                                             | <code>merged = []<br>    for lst in list_of_lists:<br>        merged.extend(lst)<br>    counts = defaultdict(int)<br>    for num in merged:<br>        counts[num] += 1<br>    max_count = -1<br>    mode = None<br>    for num, cnt in counts.items():<br>        if cnt > max_count or cnt == max_count and num < mode:<br>            max_count = cnt<br>            mode = num<br>    return mode, max_count</code>                                                                                                                                                                                                                                                                                                                                                                                                                             | <code>1.0</code> |
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
| Epoch  | Step  | Training Loss | val-sim_spearman_cosine |
|:------:|:-----:|:-------------:|:-----------------------:|
| 0.0717 | 500   | 0.2342        | -                       |
| 0.1435 | 1000  | 0.105         | -                       |
| 0.2152 | 1500  | 0.0653        | -                       |
| 0.2870 | 2000  | 0.0557        | -                       |
| 0.3587 | 2500  | 0.0472        | -                       |
| 0.4305 | 3000  | 0.0433        | -                       |
| 0.5022 | 3500  | 0.0369        | -                       |
| 0.5740 | 4000  | 0.0325        | -                       |
| 0.6457 | 4500  | 0.0314        | -                       |
| 0.7175 | 5000  | 0.0281        | -                       |
| 0.7892 | 5500  | 0.0264        | -                       |
| 0.8610 | 6000  | 0.0267        | -                       |
| 0.9327 | 6500  | 0.0255        | -                       |
| 1.0    | 6969  | -             | 0.8542                  |
| 1.0044 | 7000  | 0.0223        | -                       |
| 1.0762 | 7500  | 0.0179        | -                       |
| 1.1479 | 8000  | 0.0182        | -                       |
| 1.2197 | 8500  | 0.0198        | -                       |
| 1.2914 | 9000  | 0.0188        | -                       |
| 1.3632 | 9500  | 0.0156        | -                       |
| 1.4349 | 10000 | 0.0167        | -                       |
| 1.5067 | 10500 | 0.0177        | -                       |
| 1.5784 | 11000 | 0.0167        | -                       |
| 1.6502 | 11500 | 0.0146        | -                       |
| 1.7219 | 12000 | 0.0161        | -                       |
| 1.7937 | 12500 | 0.0146        | -                       |
| 1.8654 | 13000 | 0.0145        | -                       |
| 1.9372 | 13500 | 0.0144        | -                       |
| 2.0    | 13938 | -             | 0.8571                  |
| 2.0089 | 14000 | 0.0144        | -                       |
| 2.0806 | 14500 | 0.0125        | -                       |
| 2.1524 | 15000 | 0.0101        | -                       |
| 2.2241 | 15500 | 0.0123        | -                       |
| 2.2959 | 16000 | 0.0127        | -                       |
| 2.3676 | 16500 | 0.0109        | -                       |
| 2.4394 | 17000 | 0.0116        | -                       |
| 2.5111 | 17500 | 0.0112        | -                       |
| 2.5829 | 18000 | 0.0103        | -                       |
| 2.6546 | 18500 | 0.0105        | -                       |
| 2.7264 | 19000 | 0.0099        | -                       |
| 2.7981 | 19500 | 0.0096        | -                       |
| 2.8699 | 20000 | 0.0111        | -                       |
| 2.9416 | 20500 | 0.01          | -                       |
| 3.0    | 20907 | -             | 0.8583                  |


### Framework Versions
- Python: 3.13.9
- Sentence Transformers: 5.2.0
- Transformers: 4.57.3
- PyTorch: 2.9.1+cu128
- Accelerate: 1.12.0
- Datasets: 4.4.1
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