---
tags:
- sentence-transformers
- sentence-similarity
- feature-extraction
- dense
- generated_from_trainer
- dataset_size:55745
- loss:CosineSimilarityLoss
base_model: microsoft/codebert-base
widget:
- source_sentence: "\"\"\"Organize files in a directory by their extensions into separate\
    \ directories.\"\"\"\n\n    def get_extension(file_path):\n        return file_path.suffix[1:]\
    \ if file_path.suffix else ''\n    dir_path = Path(directory)\n    files = list(dir_path.glob('*'))\n\
    \    files_by_ext = {}\n    for file in files:\n        ext = get_extension(file)\n\
    \        if ext:\n            if ext not in files_by_ext:\n                files_by_ext[ext]\
    \ = []\n            files_by_ext[ext].append(file)\n    for ext, file_list in\
    \ files_by_ext.items():\n        ext_dir = dir_path / ext\n        ext_dir.mkdir(exist_ok=True)\n\
    \        for file in file_list:\n            shutil.move(str(file), str(ext_dir))"
  sentences:
  - "words = [token.strip(string.punctuation) for token in text.split()]\n    word_count\
    \ = sum(1 for w in words if w)\n    punctuation_count = sum(1 for ch in text if\
    \ ch in string.punctuation)\n    return word_count, punctuation_count"
  - "\"\"\"Return the continuous substring of x with the maximum total weight.\"\"\
    \"\n    weights = [w.get(ch, 0) for ch in x]\n    max_sum = -float('inf')\n  \
    \  current_sum = 0\n    start = end = 0\n    temp_start = 0\n    for i, val in\
    \ enumerate(weights):\n        if current_sum <= 0:\n            current_sum =\
    \ val\n            temp_start = i\n        else:\n            current_sum += val\n\
    \        if current_sum > max_sum:\n            max_sum = current_sum\n      \
    \      start = temp_start\n            end = i + 1\n    return x[start:end]"
  - "try:\n        directory = pathlib.Path(directory)\n        if not directory.is_dir():\n\
    \            raise ValueError('Invalid directory')\n        for file in directory.iterdir():\n\
    \            ext = file.suffix[1:]\n            ext_dir = directory / ext\n  \
    \          ext_dir.mkdir(exist_ok=True)\n            shutil.move(str(file), str(ext_dir))\n\
    \    except Exception as e:\n        logging.error(f'Error processing directory:\
    \ {e}')"
- source_sentence: "\"\"\"\n    Backs up a specified file from a predefined directory\
    \ to a backup directory and executes it as a subprocess.\n\n    Args:\n      \
    \  filename (str): The name of the file to be backed up and executed.\n\n    Returns:\n\
    \        int: The exit code of the subprocess. 0 indicates successful execution,\
    \ -1 otherwise.\n    \"\"\"\n    DIRECTORY = 'c:\\\\Program Files\\\\VMware\\\\\
    VMware Server'\n    BACKUP_DIRECTORY = 'c:\\\\Program Files\\\\VMware\\\\VMware\
    \ Server\\\\Backup'\n    file_path = os.path.join(DIRECTORY, filename)\n    backup_path\
    \ = os.path.join(BACKUP_DIRECTORY, filename)\n    try:\n        shutil.copy(file_path,\
    \ backup_path)\n    except Exception as e:\n        return -1\n    try:\n    \
    \    process = subprocess.Popen([file_path])\n        return process.poll()\n\
    \    except Exception as e:\n        return -1"
  sentences:
  - "\"\"\"\n    Generate a plot showing temperature trends over a specified number\
    \ of days in the past.\n\n    Args:\n        days_in_past (int): Number of days\
    \ to look back. Defaults to 7.\n        random_seed (int): Seed for random number\
    \ generation. Defaults to 0.\n\n    Returns:\n        matplotlib.axes._axes.Axes:\
    \ Plot showing temperature data with date on x-axis and temperature on y-axis.\n\
    \    \"\"\"\n    if days_in_past <= 0:\n        raise ValueError('days_in_past\
    \ must be a positive integer')\n    random.seed(random_seed)\n    today = date.today()\n\
    \    dates = [(today - timedelta(days=i)) for i in range(days_in_past)]\n    temperatures\
    \ = [random.randint(15, 35) for _ in range(days_in_past)]\n    fig, ax = plt.subplots()\n\
    \    ax.plot(dates, temperatures)\n    ax.set_xlabel('Date')\n    ax.set_ylabel('Temperature\
    \ (°C)')\n    ax.set_title('Temperature Trend')\n    return ax"
  - "for file in os.listdir(directory):\n        if '.' in file:\n            extension\
    \ = Path(file).suffix[1:]\n            dir_name = f'{extension}'\n           \
    \ if not os.path.exists(os.path.join(directory, dir_name)):\n                os.mkdir(os.path.join(directory,\
    \ dir_name))\n            shutil.move(os.path.join(directory, file), os.path.join(\n\
    \                directory, dir_name))"
  - "stemmer = PorterStemmer()\n\n    def process_text(text: str) ->str:\n       \
    \ text = re.sub('[^\\\\sa-zA-Z0-9]', '', text).lower().strip()\n        return\
    \ ' '.join([stemmer.stem(word) for word in text.split()])\n    return text_series.apply(process_text)"
- source_sentence: "if not os.path.exists(directory):\n        raise FileNotFoundError(f'Directory\
    \ {directory} does not exist')\n    entries = os.listdir(directory)\n    to_remove\
    \ = [f for f in entries if f.endswith('.js') and 'jquery' in f]\n    removed =\
    \ []\n    for f in to_remove:\n        try:\n            os.remove(os.path.join(directory,\
    \ f))\n            removed.append(f)\n            logging.info(f'Removed {f}')\n\
    \        except OSError:\n            return 0, []\n    return len(removed), removed"
  sentences:
  - "if not isinstance(data, pd.DataFrame):\n        raise TypeError('Input must be\
    \ a pandas DataFrame')\n    required_columns = ['Name', 'Date', 'Job']\n    missing_cols\
    \ = [col for col in required_columns if col not in data.columns]\n    if len(missing_cols)\
    \ > 0:\n        raise ValueError(f'Missing columns: {missing_cols}')\n    job_counts\
    \ = data['Job'].value_counts()\n    fig, ax = plt.subplots(figsize=(8, 6))\n \
    \   ax.pie(job_counts.values, labels=job_counts.index, autopct='%1.1f%%',\n  \
    \      startangle=90)\n    ax.set_title('Job Distribution')\n    return fig"
  - "if not data:\n        return np.array([]), 0\n    avg = statistics.mean(data)\n\
    \    greater_avg = [x for x in data if x > avg]\n    sorted_data = sorted(data)\n\
    \    count = sum(1 for x in sorted_data if x > value)\n    plt.hist(sorted_data,\
    \ bins=10)\n    plt.show()\n    return np.array(greater_avg), count"
  - "\"\"\"\n    Reads a CSV file, converts string representations of dictionaries\
    \ in the\n    'dict_column' to actual Python dictionaries, and creates a Seaborn\
    \ PairGrid.\n    Returns a tuple (df, ax) where df is the processed DataFrame\
    \ and ax is the\n    PairGrid object.\n    \"\"\"\n    if not os.path.isfile(csv_file):\n\
    \        logging.error(f'File not found: {csv_file}')\n        raise FileNotFoundError(f'File\
    \ not found: {csv_file}')\n    try:\n        df = pd.read_csv(csv_file)\n    except\
    \ Exception as exc:\n        logging.error(f'Error reading CSV: {exc}')\n    \
    \    raise\n    if 'dict_column' not in df.columns:\n        logging.error(\"\
    Missing 'dict_column' in DataFrame\")\n        raise KeyError(\"Missing 'dict_column'\
    \ in DataFrame\")\n\n    def _convert(val):\n        try:\n            return\
    \ ast.literal_eval(val) if isinstance(val, str) else val\n        except Exception:\n\
    \            logging.warning(f'Failed to convert value: {val}')\n            return\
    \ val\n    df['dict_column'] = [_convert(v) for v in df['dict_column']]\n    try:\n\
    \        ax = sns.pairplot(df)\n    except Exception as exc:\n        logging.error(f'Error\
    \ creating PairGrid: {exc}')\n        raise\n    return df, ax"
- source_sentence: "if not isinstance(n, int) or n <= 0:\n        raise ValueError('n\
    \ must be a positive integer')\n    letters = [chr(i) for i in range(ord('a'),\
    \ ord('z') + 1)]\n    if seed is not None:\n        random.seed(seed)\n    counts\
    \ = Counter()\n    for _ in range(n):\n        counts[random.choice(letters)]\
    \ += 1\n    return counts"
  sentences:
  - "counts = collections.defaultdict(int)\n    for key in d:\n        for num in\
    \ d[key]:\n            counts[num] += 1\n    return dict(counts)"
  - "if not os.path.exists(test_directory):\n        return 0\n    word_counts = []\n\
    \    for file_path in os.listdir(test_directory):\n        if file_path.endswith('.txt'):\n\
    \            file_path = os.path.join(test_directory, file_path)\n           \
    \ with open(file_path, 'r') as f:\n                words = f.read().split()\n\
    \                word_counts.extend(words)\n    if not word_counts:\n        return\
    \ 0\n    total_words = len(word_counts)\n    with open(filename, 'w', newline='')\
    \ as csvfile:\n        writer = csv.writer(csvfile)\n        writer.writerow(['Total\
    \ Words'])\n        writer.writerow([total_words])\n    return total_words"
  - "if not isinstance(data_dict, dict):\n        raise TypeError('data_dict must\
    \ be a dictionary')\n    for key, value in data_dict.items():\n        if not\
    \ isinstance(key, str):\n            raise TypeError('All keys must be strings')\n\
    \        if not isinstance(value, list):\n            raise TypeError('All values\
    \ must be lists')\n    df = pd.DataFrame(data_dict)\n    df_clean = df.dropna()\n\
    \    if df_clean.empty:\n        fig, ax = plt.subplots()\n        return pd.DataFrame(),\
    \ ax\n    try:\n        df_scaled = pd.DataFrame()\n        for col in df_clean.columns:\n\
    \            col_min = df_clean[col].min()\n            col_max = df_clean[col].max()\n\
    \            if col_max == col_min:\n                scaled = np.zeros(len(df_clean))\n\
    \            else:\n                scaled = (df_clean[col] - col_min) / (col_max\
    \ - col_min)\n            df_scaled[col] = scaled\n        fig, ax = plt.subplots()\n\
    \        for col in df_scaled.columns:\n            ax.plot(df_scaled.index, df_scaled[col])\n\
    \        ax.set_title('Scaled Values')\n        return df_scaled, ax\n    except\
    \ Exception as e:\n        logging.exception('Error during scaling or plotting')\n\
    \        raise e"
- source_sentence: "df = pd.DataFrame(df)\n    if column_to_remove in df.columns:\n\
    \        df = df.drop(columns=[column_to_remove])\n    X = df.drop(columns=[target_column])\n\
    \    y = df[target_column]\n    X_train, X_test, y_train, y_test = train_test_split(X,\
    \ y, test_size=\n        test_size)\n    return X_train, X_test, y_train, y_test"
  sentences:
  - "weekdays = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday',\n       \
    \ 'Saturday', 'Sunday']\n    counts = {day: (0) for day in weekdays}\n    if not\
    \ dates_str_list:\n        return pd.Series([0] * 7, index=weekdays)\n    for\
    \ date_str in dates_str_list:\n        try:\n            date_obj = datetime.strptime(date_str,\
    \ '%Y-%m-%d')\n            weekday = date_obj.weekday()\n            counts[weekdays[weekday]]\
    \ += 1\n        except ValueError:\n            pass\n    return pd.Series([counts[day]\
    \ for day in weekdays], index=weekdays)"
  - "wb = xlwt.Workbook()\n    ws = wb.add_sheet('Sheet1')\n    rows = [tuple(r) for\
    \ r in csv.reader(io.StringIO(csv_content))]\n    row_map = {idx: rows[idx] for\
    \ idx in range(len(rows))}\n    idx = 0\n    while idx in row_map:\n        row\
    \ = row_map[idx]\n        col = 0\n        while col < len(row):\n           \
    \ ws.write(idx, col, row[col])\n            col += 1\n        idx += 1\n    wb.save(filename)\n\
    \    return os.path.abspath(filename)"
  - "samples = np.random.normal(mu, sigma, 1000)\n    fig, axes = plt.subplots(1,\
    \ 2, figsize=(12, 6))\n    axes[0].hist(samples, bins=30, color='g')\n    stats.probplot(samples,\
    \ dist='norm', plot=axes[1])\n    return fig"
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
      value: 0.9711698294269815
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.8573235415214066
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
    'df = pd.DataFrame(df)\n    if column_to_remove in df.columns:\n        df = df.drop(columns=[column_to_remove])\n    X = df.drop(columns=[target_column])\n    y = df[target_column]\n    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=\n        test_size)\n    return X_train, X_test, y_train, y_test',
    "samples = np.random.normal(mu, sigma, 1000)\n    fig, axes = plt.subplots(1, 2, figsize=(12, 6))\n    axes[0].hist(samples, bins=30, color='g')\n    stats.probplot(samples, dist='norm', plot=axes[1])\n    return fig",
    "wb = xlwt.Workbook()\n    ws = wb.add_sheet('Sheet1')\n    rows = [tuple(r) for r in csv.reader(io.StringIO(csv_content))]\n    row_map = {idx: rows[idx] for idx in range(len(rows))}\n    idx = 0\n    while idx in row_map:\n        row = row_map[idx]\n        col = 0\n        while col < len(row):\n            ws.write(idx, col, row[col])\n            col += 1\n        idx += 1\n    wb.save(filename)\n    return os.path.abspath(filename)",
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[1.0000, 0.0056, 0.0438],
#         [0.0056, 1.0000, 0.0276],
#         [0.0438, 0.0276, 1.0000]])
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
| pearson_cosine      | 0.9712     |
| **spearman_cosine** | **0.8573** |

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
  |         | sentence_0                                                                          | sentence_1                                                                          | label                                                          |
  |:--------|:------------------------------------------------------------------------------------|:------------------------------------------------------------------------------------|:---------------------------------------------------------------|
  | type    | string                                                                              | string                                                                              | float                                                          |
  | details | <ul><li>min: 2 tokens</li><li>mean: 191.04 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 2 tokens</li><li>mean: 188.12 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.53</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | sentence_1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   | label            |
  |:------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code>"""Return formatted log lines containing any of the specified keywords.<br><br>    Parameters<br>    ----------<br>    log_file_path : str<br>        Path to the log file to be examined.<br>    keywords : list<br>        List of keyword strings to search for in the log file.<br><br>    Returns<br>    -------<br>    list<br>        Formatted strings for each matching line, with keyword, timestamp,<br>        and message separated by 20 spaces.<br>    """<br>    if not isinstance(log_file_path, str):<br>        raise TypeError('log_file_path must be a string')<br>    if not isinstance(keywords, list):<br>        raise TypeError('keywords must be a list')<br>    if not keywords:<br>        return []<br>    pattern = re.compile(<br>        '^(?P<keyword>\\w+)\\s+(?P<timestamp>\\d{2}:\\d{2}:\\d{2})\\s+(?P<message>.+)$'<br>        )<br>    formatted_lines = []<br>    try:<br>        with Path(log_file_path).open('r', encoding='utf-8') as file_obj:<br>            for raw_line in file_obj:<br>                line = raw_line.rstrip('\n')<br>                match = pattern.match(l...</code> | <code>if not os.path.exists(log_file_path):<br>        raise FileNotFoundError(f'Log file {log_file_path} does not exist.')<br>    formatted_lines = []<br>    with open(log_file_path, 'r') as log_file:<br>        for line in log_file:<br>            parts = re.split('\\s+', line.strip())<br>            if any(keyword in parts[0] for keyword in keywords):<br>                formatted_line = (<br>                    f'{parts[0]:>20} : {parts[1]:>20} : {parts[2]:>20}')<br>                formatted_lines.append(formatted_line)<br>    return formatted_lines</code>                                                                                                                                                        | <code>1.0</code> |
  | <code>"""<br>    Split a multi-line string into separate strings, remove special characters,<br>    and save each string as a separate text file.<br><br>    Args:<br>        input_string (str): The multi-line string to be split and saved.<br>        directory (str): The directory where the text files will be saved.<br><br>    Returns:<br>        list: A list of file paths where the text is saved.<br>    """<br>    lines = input_string.split('\n')<br>    cleaned_lines = [line.translate(str.maketrans('', '', string.<br>        punctuation)) for line in lines]<br>    file_paths = []<br>    for line in cleaned_lines:<br>        filename = ''.join(random.choices(string.ascii_letters + string.<br>            digits, k=8))<br>        file_path = os.path.join(directory, f'{filename}.txt')<br>        with open(file_path, 'w') as f:<br>            f.write(line)<br>        file_paths.append(file_path)<br>    return file_paths</code>                                                                                                                                                                         | <code>warnings.simplefilter('always')<br>    data = ds.load_iris()<br>    X, y = data.data, data.target<br>    Xtr, Xte, ytr, yte = sm.train_test_split(X, y, test_size=0.33,<br>        random_state=0)<br>    clf = svm.SVC(kernel='rbf', C=1.0, random_state=0)<br>    clf.fit(Xtr, ytr)<br>    pred_dict = {idx: clf.predict([sample])[0] for idx, sample in enumerate<br>        (Xte)}<br>    preds = [pred_dict[i] for i in range(len(Xte))]<br>    acc = mt.accuracy_score(yte, preds)<br>    acc_dup = mt.accuracy_score(yte, preds)<br>    warn_msg = None<br>    if acc < 0.9:<br>        warn_msg = 'The accuracy of the SVM classification is below 0.9.'<br>        warnings.warn(warn_msg)<br>    return acc, warn_msg</code> | <code>0.0</code> |
  | <code>"""Reverse dot-separated words in each string of a numpy array."""<br>    out = []<br>    for s in arr:<br>        if '.' in s:<br>            out.append('.'.join(reversed(s.split('.'))))<br>        else:<br>            out.append(s)<br>    return np.array(out)</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              | <code>def reverse_words(s):<br>        if '.' not in s:<br>            return s<br>        parts = s.split('.')<br>        return '.'.join(parts[::-1])<br>    vectorized_reverse = np.vectorize(reverse_words)<br>    return vectorized_reverse(arr)</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 | <code>1.0</code> |
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
| 0.0717 | 500   | 0.3721        | -                       |
| 0.1435 | 1000  | 0.1564        | -                       |
| 0.2152 | 1500  | 0.0628        | -                       |
| 0.2870 | 2000  | 0.0418        | -                       |
| 0.3587 | 2500  | 0.039         | -                       |
| 0.4305 | 3000  | 0.0338        | -                       |
| 0.5022 | 3500  | 0.0316        | -                       |
| 0.5740 | 4000  | 0.0268        | -                       |
| 0.6457 | 4500  | 0.0261        | -                       |
| 0.7175 | 5000  | 0.0252        | -                       |
| 0.7892 | 5500  | 0.0224        | -                       |
| 0.8610 | 6000  | 0.0226        | -                       |
| 0.9327 | 6500  | 0.0216        | -                       |
| 1.0    | 6969  | -             | 0.8543                  |
| 1.0044 | 7000  | 0.0223        | -                       |
| 1.0762 | 7500  | 0.0179        | -                       |
| 1.1479 | 8000  | 0.0182        | -                       |
| 1.2197 | 8500  | 0.017         | -                       |
| 1.2914 | 9000  | 0.0184        | -                       |
| 1.3632 | 9500  | 0.0158        | -                       |
| 1.4349 | 10000 | 0.0152        | -                       |
| 1.5067 | 10500 | 0.014         | -                       |
| 1.5784 | 11000 | 0.0133        | -                       |
| 1.6502 | 11500 | 0.0144        | -                       |
| 1.7219 | 12000 | 0.0155        | -                       |
| 1.7937 | 12500 | 0.0116        | -                       |
| 1.8654 | 13000 | 0.0138        | -                       |
| 1.9372 | 13500 | 0.0129        | -                       |
| 2.0    | 13938 | -             | 0.8564                  |
| 2.0089 | 14000 | 0.0131        | -                       |
| 2.0806 | 14500 | 0.0088        | -                       |
| 2.1524 | 15000 | 0.0117        | -                       |
| 2.2241 | 15500 | 0.0091        | -                       |
| 2.2959 | 16000 | 0.0101        | -                       |
| 2.3676 | 16500 | 0.013         | -                       |
| 2.4394 | 17000 | 0.0087        | -                       |
| 2.5111 | 17500 | 0.0088        | -                       |
| 2.5829 | 18000 | 0.0093        | -                       |
| 2.6546 | 18500 | 0.0104        | -                       |
| 2.7264 | 19000 | 0.0103        | -                       |
| 2.7981 | 19500 | 0.0102        | -                       |
| 2.8699 | 20000 | 0.0094        | -                       |
| 2.9416 | 20500 | 0.0099        | -                       |
| 3.0    | 20907 | -             | 0.8573                  |


### Framework Versions
- Python: 3.13.9
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