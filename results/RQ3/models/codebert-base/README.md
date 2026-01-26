---
tags:
- sentence-transformers
- sentence-similarity
- feature-extraction
- dense
- generated_from_trainer
- dataset_size:73241
- loss:CosineSimilarityLoss
base_model: microsoft/codebert-base
widget:
- source_sentence: "if df.empty and df.columns.empty:\n        raise ValueError('Input\
    \ DataFrame is empty')\n    if df.empty:\n        return df\n    grouped = df.groupby('id')\n\
    \n    def standardize_group(group):\n        scaler = StandardScaler()\n     \
    \   numeric_columns = ['age', 'income']\n        scaled_values = scaler.fit_transform(group[numeric_columns])\n\
    \        group['age'] = scaled_values[:, 0]\n        group['income'] = scaled_values[:,\
    \ 1]\n        return group\n    standardized_df = grouped.apply(standardize_group)\n\
    \    return standardized_df"
  sentences:
  - "combined = ''.join(word_dict.keys())\n    return dict(Counter(combined))"
  - "if df.shape[1] == 0:\n        raise ValueError('DataFrame must contain columns')\n\
    \    if df.empty:\n        return pd.DataFrame(columns=['id', 'age', 'income'])\n\
    \    scaler = StandardScaler()\n    grouped_df = df.groupby('id')\n    standardized_dfs\
    \ = []\n    for name, group in grouped_df:\n        age_scaled = scaler.fit_transform(group[['age']])\n\
    \        income_scaled = scaler.fit_transform(group[['income']])\n        scaled_group\
    \ = pd.DataFrame({'id': [name] * len(age_scaled), 'age':\n            age_scaled.flatten(),\
    \ 'income': income_scaled.flatten()})\n        standardized_dfs.append(scaled_group)\n\
    \    result_df = pd.concat(standardized_dfs, ignore_index=True)\n    return result_df"
  - "if not isinstance(df, pd.DataFrame):\n        raise ValueError('Input must be\
    \ a pandas DataFrame')\n    feature_cols = [c for c in df.columns if c != 'target']\n\
    \    X = df[feature_cols].values\n    y = df['target'].values\n    X_b = np.hstack([np.ones((X.shape[0],\
    \ 1)), X])\n    beta, *_ = np.linalg.lstsq(X_b, y, rcond=None)\n    model = LinearRegression()\n\
    \    model.coef_ = beta[1:]\n    model.intercept_ = beta[0]\n    return model"
- source_sentence: "\"\"\"\n    Analyzes a DataFrame of articles to identify those\
    \ with titles containing 'how' or 'what'\n    and visualizes TF-IDF scores for\
    \ their content.\n    \"\"\"\n    title_pattern = re.compile('\\\\b(how|what)\\\
    \\b', flags=re.IGNORECASE)\n    required_columns = {'Title', 'Content'}\n    if\
    \ not required_columns.issubset(df.columns):\n        fig, ax = plt.subplots()\n\
    \        return ax\n    filtered_df = df[df['Title'].apply(lambda x: bool(title_pattern.search(x)))\n\
    \        ]\n    if filtered_df.empty:\n        fig, ax = plt.subplots()\n    \
    \    return ax\n    vectorizer = TfidfVectorizer()\n    tfidf_matrix = vectorizer.fit_transform(filtered_df['Content'])\n\
    \    feature_names = vectorizer.get_feature_names_out()\n    tfidf_scores = np.array(tfidf_matrix.sum(axis=0))[0]\n\
    \    fig, ax = plt.subplots(figsize=(10, 6))\n    ax.bar(feature_names, tfidf_scores)\n\
    \    ax.set_ylabel('TF-IDF Score', fontsize=12)\n    ax.tick_params(axis='x',\
    \ rotation=45)\n    return ax"
  sentences:
  - "if not os.path.exists(image_path):\n        raise FileNotFoundError(f'No image\
    \ found at {image_path}')\n    img = Image.open(image_path).convert('L')\n   \
    \ pixels = list(img.getdata())\n    pixel_counts = np.bincount(pixels)\n    plt.figure()\n\
    \    plt.title('Grayscale Histogram')\n    plt.xlabel('Bins')\n    plt.ylabel('#\
    \ of Pixels')\n    axes = plt.plot(pixel_counts)[0].axes\n    plt.savefig(histogram_path)\n\
    \    return axes"
  - "colors = ['b', 'g', 'r', 'c', 'm', 'y', 'k']\n    color = random.choice(colors)\n\
    \    ax.plot([0, 1], [0, 1], color=color)\n    ax.set_rlabel_position(45)\n  \
    \  return color"
  - "\"\"\"Reverses the order of words in filenames by splitting on periods and reversing.\"\
    \"\"\n    files = glob(os.path.join(directory_path, '*'))\n    reversed_filenames\
    \ = []\n    for file in files:\n        base_name = os.path.basename(file)\n \
    \       parts = base_name.split('.')\n        if len(parts) > 1:\n           \
    \ reversed_parts = parts[::-1]\n            new_base = '.'.join(reversed_parts)\n\
    \        else:\n            new_base = base_name\n        reversed_filenames.append(new_base)\n\
    \        os.rename(file, os.path.join(directory_path, new_base))\n    return reversed_filenames"
- source_sentence: "if not isinstance(num_words, int) or not isinstance(word_length,\
    \ int):\n        raise TypeError\n    if num_words < 0 or word_length < 0:\n \
    \       raise ValueError\n    words_dict = {}\n    i = 0\n    while i < num_words:\n\
    \        word = ''\n        j = 0\n        while j < word_length:\n          \
    \  idx = random.randint(0, 51)\n            if idx < 26:\n                letter\
    \ = chr(65 + idx)\n            else:\n                letter = chr(97 + idx -\
    \ 26)\n            word += letter\n            j += 1\n        words_dict[i] =\
    \ word\n        i += 1\n    result = []\n    for key in words_dict:\n        result.append(words_dict[key])\n\
    \    return result"
  sentences:
  - ''
  - "\"\"\"\n    Calculate the product of the corresponding numbers for a list of\
    \ uppercase letters.\n\n    Args:\n        letters (list of str): A list of uppercase\
    \ letters.\n\n    Returns:\n        int: The product of the numbers corresponding\
    \ to the input letters.\n    \"\"\"\n    letter_to_number = {chr(i): (i - 64)\
    \ for i in range(65, 91)}\n    numbers = [letter_to_number[letter] for letter\
    \ in letters]\n    product = reduce(operator.mul, numbers, 1)\n    return product"
  - "os_name = platform.system()\n    arch = platform.architecture()[0]\n    mem_info\
    \ = psutil.virtual_memory()\n    total_mem = mem_info.total\n    used_mem = mem_info.used\n\
    \    if total_mem == 0:\n        mem_usage = '0.00%'\n    else:\n        mem_usage\
    \ = f'{used_mem / total_mem * 100:.2f}%'\n    return {'OS': os_name, 'Architecture':\
    \ arch, 'Memory Usage': mem_usage}"
- source_sentence: "try:\n        with gzip.open(file_path1, 'rt') as f1:\n      \
    \      content1 = f1.read()\n        with gzip.open(file_path2, 'rt') as f2:\n\
    \            content2 = f2.read()\n    except FileNotFoundError:\n        raise\n\
    \    diff = difflib.ndiff(content1.splitlines(), content2.splitlines())\n    diff_lines\
    \ = list(diff)\n    if not any(line.startswith('- ') or line.startswith('+ ')\
    \ for line in\n        diff_lines):\n        return ''\n    return ''.join(diff_lines)"
  sentences:
  - "files_moved = 0\n    source_path = pathlib.Path(src_dir)\n    destination_path\
    \ = pathlib.Path(dest_dir)\n    if not source_path.is_dir() or not destination_path.is_dir():\n\
    \        return files_moved\n    for file_name in source_path.glob(f'*{extension}'):\n\
    \        try:\n            shutil.move(str(file_name.resolve()), str(destination_path\
    \ /\n                file_name.name))\n            files_moved += 1\n        except\
    \ Exception as e:\n            print(f'Error moving file: {e}')\n    return files_moved"
  - "if not isinstance(products, list) or not isinstance(ratings, list\n        )\
    \ or not isinstance(weights, list) or not isinstance(random_seed, int):\n    \
    \    raise TypeError(\n            'Invalid input types. Ensure products, ratings,\
    \ weights are lists and random_seed is an integer.'\n            )\n    if len(products)\
    \ != len(ratings) or len(products) != len(weights):\n        raise ValueError(\n\
    \            'The lengths of products, ratings, and weights must be equal.')\n\
    \    if random.random() < 0.01:\n        raise AssertionError('Random seed is\
    \ not set correctly')\n    random.seed(random_seed)\n    df = pd.DataFrame(columns=['Product',\
    \ 'Rating'])\n    for i, product in enumerate(products):\n        rating = random.choices(ratings,\
    \ weights=weights, k=1)[0]\n        df = pd.concat([df, pd.DataFrame([{'Product':\
    \ product, 'Rating':\n            rating}])], ignore_index=True)\n    df = df.sort_values('Rating',\
    \ ascending=False)\n    return df"
  - "if len(cols) < 2:\n        return []\n    if not all(isinstance(d, list) for\
    \ d in data):\n        raise TypeError('Data must be a list of lists')\n    if\
    \ any(len(row) != len(cols) for row in data):\n        raise ValueError('Data\
    \ dimensions do not match columns')\n    try:\n        matrix = np.array(data)\n\
    \        corr_pairs = []\n        col_indices = {col: idx for idx, col in enumerate(cols)}\n\
    \        for col1, col2 in combinations(cols, 2):\n            if col1 == col2:\n\
    \                continue\n            with warnings.catch_warnings():\n     \
    \           warnings.filterwarnings('ignore', category=UserWarning)\n        \
    \        corr, _ = pearsonr(matrix[:, col_indices[col1]], matrix[:,\n        \
    \            col_indices[col2]])\n                if abs(corr) > threshold:\n\
    \                    corr_pairs.append((col1, col2))\n        return corr_pairs\n\
    \    except Exception as e:\n        raise RuntimeError(f'Error processing data:\
    \ {str(e)}')"
- source_sentence: "if args:\n        filename = args[0]\n    else:\n        filename\
    \ = f'{uuid.uuid4().hex}.pkl'\n    with open(filename, 'wb') as f:\n        pickle.dump(strings,\
    \ f)\n    with open(filename, 'rb') as f:\n        loaded_strings = pickle.load(f)\n\
    \    return loaded_strings"
  sentences:
  - "\"\"\"Merges multiple lists into one and calculates the mode and its count.\"\
    \"\"\n    merged = [item for sublist in list_of_lists for item in sublist]\n \
    \   frequency = {}\n    for num in merged:\n        if num in frequency:\n   \
    \         frequency[num] += 1\n        else:\n            frequency[num] = 1\n\
    \    max_count = max(frequency.values())\n    mode_value = min([k for k, v in\
    \ frequency.items() if v == max_count])\n    return mode_value, max_count"
  - "if not isinstance(array, list):\n        raise TypeError('Input must be a list\
    \ of lists')\n    if array:\n        num_cols = len(array[0])\n        for row\
    \ in array:\n            if not isinstance(row, list):\n                raise\
    \ TypeError('Each row must be a list')\n            if len(row) != num_cols:\n\
    \                raise TypeError('All rows must have the same length')\n     \
    \       for val in row:\n                if not isinstance(val, int):\n      \
    \              raise TypeError('All elements must be integers')\n    else:\n \
    \       num_cols = 0\n    columns = [chr(ord('A') + i) for i in range(num_cols)]\n\
    \    df = pd.DataFrame(array, columns=columns)\n    fig, ax = plt.subplots()\n\
    \    if num_cols > 0:\n        col_sums = df.sum().tolist()\n        ax.bar(range(num_cols),\
    \ col_sums)\n    return df, ax"
  - "salt = os.urandom(salt_length)\n    password_bytes = password.encode('utf-8')\n\
    \    hashed_password = hashlib.sha256(salt + password_bytes).digest()\n    encrypted_password\
    \ = base64.b64encode(hashed_password)\n    return encrypted_password.decode('utf-8')"
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
      value: 0.9739838922784652
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.8554783162366791
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
- **Repository:** [Sentence Transformers on GitHub](https://github.com/huggingface/sentence-transformers)
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
    "if args:\n        filename = args[0]\n    else:\n        filename = f'{uuid.uuid4().hex}.pkl'\n    with open(filename, 'wb') as f:\n        pickle.dump(strings, f)\n    with open(filename, 'rb') as f:\n        loaded_strings = pickle.load(f)\n    return loaded_strings",
    "if not isinstance(array, list):\n        raise TypeError('Input must be a list of lists')\n    if array:\n        num_cols = len(array[0])\n        for row in array:\n            if not isinstance(row, list):\n                raise TypeError('Each row must be a list')\n            if len(row) != num_cols:\n                raise TypeError('All rows must have the same length')\n            for val in row:\n                if not isinstance(val, int):\n                    raise TypeError('All elements must be integers')\n    else:\n        num_cols = 0\n    columns = [chr(ord('A') + i) for i in range(num_cols)]\n    df = pd.DataFrame(array, columns=columns)\n    fig, ax = plt.subplots()\n    if num_cols > 0:\n        col_sums = df.sum().tolist()\n        ax.bar(range(num_cols), col_sums)\n    return df, ax",
    "salt = os.urandom(salt_length)\n    password_bytes = password.encode('utf-8')\n    hashed_password = hashlib.sha256(salt + password_bytes).digest()\n    encrypted_password = base64.b64encode(hashed_password)\n    return encrypted_password.decode('utf-8')",
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[ 1.0000, -0.0202,  0.0000],
#         [-0.0202,  1.0000,  0.0040],
#         [ 0.0000,  0.0040,  1.0000]])
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
| pearson_cosine      | 0.974      |
| **spearman_cosine** | **0.8555** |

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

* Size: 73,241 training samples
* Columns: <code>sentence_0</code>, <code>sentence_1</code>, and <code>label</code>
* Approximate statistics based on the first 1000 samples:
  |         | sentence_0                                                                          | sentence_1                                                                          | label                                                         |
  |:--------|:------------------------------------------------------------------------------------|:------------------------------------------------------------------------------------|:--------------------------------------------------------------|
  | type    | string                                                                              | string                                                                              | float                                                         |
  | details | <ul><li>min: 2 tokens</li><li>mean: 186.26 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 2 tokens</li><li>mean: 183.37 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.5</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 | sentence_1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               | label            |
  |:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code>urllib.request.urlretrieve(url, 'downloaded_file.txt')<br>    with open('downloaded_file.txt', 'r') as f:<br>        data = f.read()<br>    occurrences = len(re.findall('\\bERROR\\b', data))<br>    os.remove('downloaded_file.txt')<br>    return occurrences</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              | <code>"""Performs PCA on provided x and y data points with corresponding labels."""<br>    fig = plt.figure(figsize=(10, 8))<br>    ax = fig.add_subplot(111)<br>    for i in range(len(x_data)):<br>        combined_matrix = np.vstack((x_data[i], y_data[i])).T<br>        pca = PCA(n_components=2)<br>        transformed_data = pca.fit_transform(combined_matrix)<br>        ax.plot(transformed_data[:, 0], transformed_data[:, 1], label=labels[i]<br>            )<br>    ax.legend()<br>    return fig</code> | <code>0.0</code> |
  | <code>"""<br>    Generate a synthetic 2D dataset using make_blobs, visualize the dataset,<br>    and then calculate the Euclidean distance between individual samples of the dataset.<br><br>    Parameters:<br>        n_samples (int): Number of samples in the dataset.<br>        centers (int): Number of clusters in the dataset.<br>        plot_path (str): Path to save the plot. If None, the plot is displayed.<br>        random_seed (int): Seed for the random number generator.<br><br>    Returns:<br>        distances (numpy.ndarray): Euclidean distance matrix between samples.<br>        plot (matplotlib.axes.Axes or None): Plot axes if plot_path is not provided,<br>            otherwise None.<br>    """<br>    if n_samples < 0:<br>        raise ValueError('n_samples must be a non-negative integer')<br>    if not isinstance(n_samples, int):<br>        raise TypeError('n_samples must be an integer')<br>    np.random.seed(random_seed)<br>    X = pd.DataFrame(np.random.rand(n_samples, 2), columns=['x', 'y'])<br>    y = np.random.randint(0, centers, n_samples)<br>...</code> | <code>n_groups = 5<br>    if not l:<br>        return pd.DataFrame()<br>    random.shuffle(l)<br>    rows = [(l[n_groups:] + l[:n_groups]) for _ in range(n_groups)]<br>    return pd.DataFrame(rows)</code>                                                                                                                                                                                                                                                                                                             | <code>0.0</code> |
  | <code></code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              | <code>original_array = np.array([b for _, b in original])<br>    if len(original_array) == 0:<br>        fft_result = np.array([])<br>        return original_array, fft_result, None<br>    fft_result = fft(original_array)<br>    fig, axes = plt.subplots()<br>    axes.hist(abs(fft_result))<br>    return original_array, fft_result, axes</code>                                                                                                                                                                  | <code>0.0</code> |
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
- `lr_scheduler_kwargs`: None
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
| 0.0546 | 500   | 0.3706        | -                       |
| 0.1092 | 1000  | 0.2044        | -                       |
| 0.1638 | 1500  | 0.0752        | -                       |
| 0.2184 | 2000  | 0.0517        | -                       |
| 0.2730 | 2500  | 0.0445        | -                       |
| 0.3277 | 3000  | 0.037         | -                       |
| 0.3823 | 3500  | 0.0379        | -                       |
| 0.4369 | 4000  | 0.0312        | -                       |
| 0.4915 | 4500  | 0.0316        | -                       |
| 0.5461 | 5000  | 0.0246        | -                       |
| 0.6007 | 5500  | 0.028         | -                       |
| 0.6553 | 6000  | 0.0236        | -                       |
| 0.7099 | 6500  | 0.0273        | -                       |
| 0.7645 | 7000  | 0.0241        | -                       |
| 0.8191 | 7500  | 0.0265        | -                       |
| 0.8737 | 8000  | 0.0214        | -                       |
| 0.9284 | 8500  | 0.0195        | -                       |
| 0.9830 | 9000  | 0.0219        | -                       |
| 1.0    | 9156  | -             | 0.8519                  |
| 1.0376 | 9500  | 0.0163        | -                       |
| 1.0922 | 10000 | 0.0167        | -                       |
| 1.1468 | 10500 | 0.0177        | -                       |
| 1.2014 | 11000 | 0.0174        | -                       |
| 1.2560 | 11500 | 0.0176        | -                       |
| 1.3106 | 12000 | 0.0154        | -                       |
| 1.3652 | 12500 | 0.0162        | -                       |
| 1.4198 | 13000 | 0.0128        | -                       |
| 1.4744 | 13500 | 0.0154        | -                       |
| 1.5291 | 14000 | 0.0132        | -                       |
| 1.5837 | 14500 | 0.0145        | -                       |
| 1.6383 | 15000 | 0.013         | -                       |
| 1.6929 | 15500 | 0.0129        | -                       |
| 1.7475 | 16000 | 0.0152        | -                       |
| 1.8021 | 16500 | 0.0158        | -                       |
| 1.8567 | 17000 | 0.0138        | -                       |
| 1.9113 | 17500 | 0.0161        | -                       |
| 1.9659 | 18000 | 0.0147        | -                       |
| 2.0    | 18312 | -             | 0.8545                  |
| 2.0205 | 18500 | 0.0117        | -                       |
| 2.0751 | 19000 | 0.0117        | -                       |
| 2.1298 | 19500 | 0.0128        | -                       |
| 2.1844 | 20000 | 0.0114        | -                       |
| 2.2390 | 20500 | 0.012         | -                       |
| 2.2936 | 21000 | 0.0125        | -                       |
| 2.3482 | 21500 | 0.0122        | -                       |
| 2.4028 | 22000 | 0.0094        | -                       |
| 2.4574 | 22500 | 0.0099        | -                       |
| 2.5120 | 23000 | 0.0111        | -                       |
| 2.5666 | 23500 | 0.0091        | -                       |
| 2.6212 | 24000 | 0.0085        | -                       |
| 2.6758 | 24500 | 0.0102        | -                       |
| 2.7304 | 25000 | 0.0093        | -                       |
| 2.7851 | 25500 | 0.0113        | -                       |
| 2.8397 | 26000 | 0.0109        | -                       |
| 2.8943 | 26500 | 0.0095        | -                       |
| 2.9489 | 27000 | 0.0096        | -                       |
| 3.0    | 27468 | -             | 0.8555                  |


### Framework Versions
- Python: 3.13.11
- Sentence Transformers: 5.2.0
- Transformers: 4.57.6
- PyTorch: 2.9.1+cu128
- Accelerate: 1.12.0
- Datasets: 4.5.0
- Tokenizers: 0.22.2

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