---
tags:
- sentence-transformers
- sentence-similarity
- feature-extraction
- dense
- generated_from_trainer
- dataset_size:4259
- loss:CosineSimilarityLoss
base_model: Salesforce/codet5-base
widget:
- source_sentence: "sales_data = []\n    for product in products_list:\n        monthly_sales\
    \ = [random.randint(100, 500) for _ in range(12)]\n        avg = stats.mean(monthly_sales)\n\
    \        data_row = {'Product': product, **{f'Month {i + 1}': sale for i,\n  \
    \          sale in enumerate(monthly_sales)}, 'Average Sales': avg}\n        sales_data.append(data_row)\n\
    \    df = pd.DataFrame(sales_data)\n    return df"
  sentences:
  - "\"\"\"Reads log file and formats lines containing specified keywords.\"\"\"\n\
    \    if not os.path.isfile(log_file_path):\n        raise FileNotFoundError(f'Log\
    \ file {log_file_path} does not exist.')\n\n    def format_line(line: str, kwds:\
    \ list) ->str:\n        for keyword in kwds:\n            if keyword in line:\n\
    \                parts = line.strip().split(maxsplit=2)\n                if len(parts)\
    \ >= 3:\n                    return (\n                        f'{keyword:>{20}}\
    \ : {parts[1]:>{20}} : {parts[2]:>{20}}'\n                        )\n        return\
    \ f'Line format unexpected: {line.strip()}'\n    with open(log_file_path, 'r')\
    \ as log_file:\n        lines = [format_line(line, keywords) for line in log_file]\n\
    \    return [line for line in lines if any(kw in line for kw in keywords)]"
  - "if not features:\n        return df\n    scaler = StandardScaler()\n    df[features]\
    \ = scaler.fit_transform(df[features])\n    return df"
  - "if hex_key is not None:\n        chosen = round(struct.unpack('>f', bytes.fromhex(hex_key))[0],\
    \ 2)\n    else:\n        floats = [round(struct.unpack('>f', bytes.fromhex(h))[0],\
    \ 2) for h in\n            KEYS]\n        chosen = random.choice(floats)\n   \
    \ return chosen"
- source_sentence: "if len(args) == 0:\n        url = 'https://example.com/data.csv'\n\
    \        out_path = 'data.json'\n    elif len(args) == 2:\n        url, out_path\
    \ = args\n    else:\n        raise TypeError('task_func expects 0 or 2 arguments')\n\
    \    response = requests.get(url)\n    csv_text = response.text\n    reader =\
    \ csv.DictReader(StringIO(csv_text))\n    data = [row for row in reader]\n   \
    \ with open(out_path, 'w', encoding='utf-8') as f:\n        json.dump(data, f)\n\
    \    return out_path"
  sentences:
  - "key = hashlib.sha256(password.encode()).digest()\n    encrypted_bytes = bytes([(b\
    \ ^ key[i % len(key)]) for i, b in enumerate(\n        data.encode())])\n    encrypted_str\
    \ = base64.b64encode(encrypted_bytes).decode()\n    os.makedirs(os.path.dirname(file_path),\
    \ exist_ok=True)\n    with open(file_path, 'w') as f:\n        f.write(encrypted_str)\n\
    \    return encrypted_str"
  - "try:\n        df = pd.read_excel(excel_file_location, sheet_name=sheet_name)\n\
    \        df.to_csv(csv_file_location, index=False)\n        column_sum = df.sum(numeric_only=True)\n\
    \        return column_sum.to_dict()\n    except FileNotFoundError:\n        raise\
    \ FileNotFoundError(\n            f'Excel file not found at {excel_file_location}')\n\
    \    except ValueError as e:\n        raise ValueError(f'Error in processing Excel\
    \ file: {e}')"
  - "if not d:\n        return pd.DataFrame(columns=['x', 'y', 'z'])\n    features\
    \ = ['x', 'y', 'z']\n    data_frame = pd.DataFrame(d)\n    scaler = MinMaxScaler()\n\
    \    scaled_values = scaler.fit_transform(data_frame[features])\n    result =\
    \ pd.DataFrame(scaled_values, columns=features)\n    return result"
- source_sentence: "lines = input_string.splitlines()\n    cleaned_lines = [line.strip()\
    \ for line in lines if line.strip()]\n    processed_lines = [re.sub('\\\\t', '\
    \ ', line) for line in cleaned_lines]\n    df = pd.DataFrame(processed_lines,\
    \ columns=['Text'])\n    return df"
  sentences:
  - "result = {}\n    for _ in range(n_samples):\n        index = random.choices(range(len(values)),\
    \ weights=weights)[0]\n        value = values[index]\n        if value not in\
    \ result:\n            result[value] = 1\n        else:\n            result[value]\
    \ += 1\n    return result"
  - "sales_data = {product: [randint(100, 500) for _ in range(12)] for\n        product\
    \ in products_list}\n\n    def calculate_average_sales(sales):\n        return\
    \ sum(sales) / len(sales)\n    average_sales = {product: calculate_average_sales(sales)\
    \ for product,\n        sales in sales_data.items()}\n    sales_df = pd.DataFrame({'Product':\
    \ list(sales_data.keys()), **{\n        f'Month {i + 1}': [sales[i] for sales\
    \ in sales_data.values()] for i in\n        range(12)}, 'Average Sales': list(average_sales.values())})\n\
    \    return sales_df"
  - "if not isinstance(df, pd.DataFrame):\n        raise TypeError('df should be a\
    \ DataFrame.')\n\n    def count_brackets(x: Union[str, float]) ->int:\n      \
    \  return sum(1 for c in str(x) if c in '(){}[]')\n    result = df.applymap(count_brackets).sum().sum()\n\
    \    return result"
- source_sentence: ''
  sentences:
  - "try:\n        data = [float(x) for x in data_str.split(separator)]\n    except\
    \ ValueError:\n        raise ValueError('Invalid data')\n    if not data:\n  \
    \      raise ValueError('Data is empty')\n    series = pd.Series(data)\n    n,\
    \ bins, patches = plt.hist(series, bins=bins, rwidth=0.9, color='#607c8e')\n \
    \   return series.astype(np.int64), plt.gca()"
  - "if subset_size > len(elements):\n        return Counter()\n    subsets = list(combinations(elements,\
    \ subset_size))\n    sums = [sum(subset) for subset in subsets]\n    return Counter(sums)"
  - "def flatten(nested_list):\n        for item in nested_list:\n            if isinstance(item,\
    \ (list, tuple)):\n                yield from flatten(item)\n            else:\n\
    \                yield item\n    elements = list(flatten(L))\n    if not elements:\n\
    \        raise ValueError('List is empty')\n    sorted_elements = np.sort(elements)\n\
    \    length = len(sorted_elements)\n    middle = length // 2\n    if length %\
    \ 2 == 1:\n        return float(sorted_elements[middle])\n    else:\n        return\
    \ float((sorted_elements[middle - 1] + sorted_elements[middle]\n            )\
    \ / 2)"
- source_sentence: "invalid_keys = [key for key in data_keys if key not in data_dict]\n\
    \    if len(invalid_keys) > 0:\n        raise ValueError(f'Invalid keys: {invalid_keys}')\n\
    \    if not data_keys:\n        raise ValueError('No keys specified')\n    normalized_data\
    \ = {}\n    for key in data_keys:\n        data = data_dict[key]\n        min_val\
    \ = min(data)\n        max_val = max(data)\n        normalized = [((x - min_val)\
    \ / (max_val - min_val) if max_val !=\n            min_val else 0.5) for x in\
    \ data]\n        normalized_data[key] = normalized\n    df = pd.DataFrame(normalized_data)\n\
    \    fig, ax = plt.subplots()\n    df.plot(ax=ax)\n    return df, ax"
  sentences:
  - "\"\"\"\n    Test the normality of a DataFrame column using Shapiro-Wilk test.\n\
    \    Implements an artificial step to demonstrate use of numpy functions.\n\n\
    \    Args:\n        df: pandas DataFrame containing data\n        column: str,\
    \ name of the column to test\n        alpha: float, significance level\n\n   \
    \ Returns:\n        bool indicating whether p-value is greater than alpha\n  \
    \  \"\"\"\n    data = np.array(df[column])\n    centered_data = data - np.mean(data)\n\
    \    stat, p = shapiro(centered_data)\n    return p > alpha"
  - "if seed is not None:\n        random.seed(seed)\n    punctuation_re = re.compile('[%s]'\
    \ % re.escape(string.punctuation))\n    text = punctuation_re.sub('', text)\n\
    \    whitespace_map = {' ': '_', '\\t': '__', '\\n': '___'}\n    text = ''.join(whitespace_map.get(c,\
    \ c) for c in text)\n    text_list = list(text)\n    for i, char in enumerate(text_list):\n\
    \        if random.random() < 0.5:\n            text_list[i] = char.upper()\n\
    \    return ''.join(text_list)"
  - "words = re.findall('\\\\b\\\\w+\\\\b', text)\n    punctuation_marks = [c for\
    \ c in text if c in string.punctuation]\n    return len(words), len(punctuation_marks)"
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
      value: 0.9703892888746217
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.8584694065284882
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
    "invalid_keys = [key for key in data_keys if key not in data_dict]\n    if len(invalid_keys) > 0:\n        raise ValueError(f'Invalid keys: {invalid_keys}')\n    if not data_keys:\n        raise ValueError('No keys specified')\n    normalized_data = {}\n    for key in data_keys:\n        data = data_dict[key]\n        min_val = min(data)\n        max_val = max(data)\n        normalized = [((x - min_val) / (max_val - min_val) if max_val !=\n            min_val else 0.5) for x in data]\n        normalized_data[key] = normalized\n    df = pd.DataFrame(normalized_data)\n    fig, ax = plt.subplots()\n    df.plot(ax=ax)\n    return df, ax",
    "if seed is not None:\n        random.seed(seed)\n    punctuation_re = re.compile('[%s]' % re.escape(string.punctuation))\n    text = punctuation_re.sub('', text)\n    whitespace_map = {' ': '_', '\\t': '__', '\\n': '___'}\n    text = ''.join(whitespace_map.get(c, c) for c in text)\n    text_list = list(text)\n    for i, char in enumerate(text_list):\n        if random.random() < 0.5:\n            text_list[i] = char.upper()\n    return ''.join(text_list)",
    '"""\n    Test the normality of a DataFrame column using Shapiro-Wilk test.\n    Implements an artificial step to demonstrate use of numpy functions.\n\n    Args:\n        df: pandas DataFrame containing data\n        column: str, name of the column to test\n        alpha: float, significance level\n\n    Returns:\n        bool indicating whether p-value is greater than alpha\n    """\n    data = np.array(df[column])\n    centered_data = data - np.mean(data)\n    stat, p = shapiro(centered_data)\n    return p > alpha',
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[ 1.0000,  0.0714,  0.2361],
#         [ 0.0714,  1.0000, -0.0179],
#         [ 0.2361, -0.0179,  1.0000]])
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
| pearson_cosine      | 0.9704     |
| **spearman_cosine** | **0.8585** |

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
  |         | sentence_0                                                                         | sentence_1                                                                          | label                                                          |
  |:--------|:-----------------------------------------------------------------------------------|:------------------------------------------------------------------------------------|:---------------------------------------------------------------|
  | type    | string                                                                             | string                                                                              | float                                                          |
  | details | <ul><li>min: 2 tokens</li><li>mean: 147.2 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 2 tokens</li><li>mean: 149.66 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.49</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           | sentence_1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | label            |
  |:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code>X = np.vstack([x_data ** 2, np.ones(len(x_data))]).T<br>    params, residuals, rank, singular_values = np.linalg.lstsq(X, l, rcond=None<br>        )<br>    fitted_values = np.dot(X, params)<br>    if plot:<br>        plt.figure()<br>        ax = plt.gca()<br>        ax.plot(x_data, l, 'bo', label='Original data')<br>        ax.plot(x_data, fitted_values, 'r-', label='Fitted quadratic curve')<br>        ax.set_xlabel('x')<br>        ax.set_ylabel('y')<br>        ax.legend()<br>        return params, fitted_values, ax<br>    else:<br>        return params, fitted_values</code>                                                                                                                                                                                                                                                                          | <code>RANGE = args[0] if args else 100<br>    total = sum(int(num) for tup in T1 for num in tup)<br>    numbers = [random.randint(0, RANGE) for _ in range(total)]<br>    return Counter(numbers)</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         | <code>0.0</code> |
  | <code></code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | <code>words = re.findall('\\b\\w+\\b', text)<br>    stop_words = set(stopwords.words('english'))<br>    word_counts = defaultdict(int)<br>    for word in words:<br>        if word.lower() not in stop_words:<br>            word_counts[word] += 1<br>    return dict(word_counts)</code>                                                                                                                                                                                                                                                                                                                                                                                                                                      | <code>0.0</code> |
  | <code>error_times = []<br>    for log in logs:<br>        parts = log.split()<br>        if len(parts) < 3:<br>            continue<br>        level_part = parts[2]<br>        if not level_part.endswith(':'):<br>            continue<br>        level = level_part.rstrip(':')<br>        if level != 'ERROR':<br>            continue<br>        time_str = parts[1]<br>        try:<br>            h, m, _ = time_str.split(':')<br>            error_times.append(time(int(h), int(m)))<br>        except Exception:<br>            continue<br>    if not error_times:<br>        return [], time(0, 0)<br>    total_minutes = sum(t.hour * 60 + t.minute for t in error_times)<br>    avg_minutes = total_minutes // len(error_times)<br>    avg_hour = avg_minutes // 60<br>    avg_minute = avg_minutes % 60<br>    return error_times, time(avg_hour, avg_minute)</code> | <code>error_times = []<br>    total_time = 0<br>    count = 0<br>    for log in logs:<br>        match = re.search('(\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2}:\\d{2}) ERROR:',<br>            log)<br>        if match:<br>            dt = datetime.strptime(match.group(1), '%Y-%m-%d %H:%M:%S')<br>            hour = dt.hour<br>            minute = dt.minute<br>            error_times.append(time(hour, minute))<br>            total_time += hour + minute / 60<br>            count += 1<br>    if count > 0:<br>        average_time = time(int(total_time // count), int(total_time %<br>            count * 60 / count))<br>    else:<br>        average_time = time(0, 0)<br>    return error_times, average_time</code> | <code>1.0</code> |
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
| 0.9381 | 500  | 0.1092        | -                       |
| 1.0    | 533  | -             | 0.8558                  |
| 1.8762 | 1000 | 0.0218        | -                       |
| 2.0    | 1066 | -             | 0.8584                  |
| 2.8143 | 1500 | 0.0109        | -                       |
| 3.0    | 1599 | -             | 0.8585                  |


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