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
- source_sentence: "logging.basicConfig(level=logging.INFO, format=\n        '%(asctime)s\
    \ - %(levelname)s - %(message)s')\n    try:\n        if not Path(input_file).exists():\n\
    \            raise FileNotFoundError(f'The file {input_file} does not exist.')\n\
    \        with open(input_file, 'r') as f:\n            data = json.load(f)\n \
    \       if not isinstance(data, list) or not all(isinstance(item, dict) for\n\
    \            item in data):\n            raise ValueError(\n                'Invalid\
    \ JSON structure. Expected a list of dictionaries.')\n        keys = data[0].keys()\n\
    \        values = [[item[key] for key in keys] for item in data]\n        results\
    \ = {}\n        for key in keys:\n            arr = np.array([item[key] for item\
    \ in data])\n            mean = np.mean(arr)\n            median = np.median(arr)\n\
    \            results[key] = {'mean': mean, 'median': median}\n        df = DataFrame({key:\
    \ [item[key] for item in data] for key in keys})\n        df_long = df.melt(var_name='Key',\
    \ value_name='Value')\n        plt.figure(figsize=(10, 6))\n        ax = sns.boxplot(x='Key',\
    \ y='Value', data=df_long)\n        ax.set_title('Boxplot of Values for Each Key')\n\
    \        ax.set_xlabel('Keys')\n        ax.set_ylabel('Values')\n        return\
    \ results, ax\n    except json.JSONDecodeError as e:\n        logging.error(f'Invalid\
    \ JSON format in file {input_file}: {str(e)}')\n        raise\n    except Exception\
    \ as e:\n        logging.error(\n            f'An error occurred while processing\
    \ the file {input_file}: {str(e)}'\n            )\n        raise"
  sentences:
  - "\"\"\"\n    Reads a CSV file and counts the most common words in the file.\n\n\
    \    Args:\n        csv_file (str): The path to the CSV file.\n        csv_delimiter\
    \ (str): The delimiter used in the CSV file.\n\n    Returns:\n        list: A\
    \ list of tuples, each containing a word and its frequency,\n              sorted\
    \ by frequency in descending order.\n    \"\"\"\n    try:\n        with open(csv_file,\
    \ 'r') as f:\n            content = f.read()\n    except FileNotFoundError:\n\
    \        return []\n    words = re.findall('\\\\b\\\\w+\\\\b', content.lower())\n\
    \    word_counts = defaultdict(int)\n    for word in words:\n        word_counts[word]\
    \ += 1\n    most_common_words = sorted(word_counts.items(), key=lambda x: x[1],\n\
    \        reverse=True)\n    return most_common_words"
  - "files = []\n    dirs = deque([src_dir])\n    while dirs:\n        current_dir\
    \ = dirs.popleft()\n        for item in os.listdir(current_dir):\n           \
    \ path = os.path.join(current_dir, item)\n            if os.path.isdir(path):\n\
    \                dirs.append(path)\n            elif os.path.isfile(path) and\
    \ os.path.splitext(item)[1\n                ] == extension:\n                files.append((path,\
    \ dest_dir))\n    moved_files_count = 0\n    for src, dest in files:\n       \
    \ try:\n            shutil.move(src, dest)\n            moved_files_count += 1\n\
    \        except Exception as e:\n            pass\n    return moved_files_count"
  - "try:\n        with open(input_file, 'r') as f:\n            data = json.load(f)\n\
    \        results = {}\n        for item in data:\n            for key, value in\
    \ item.items():\n                if key not in results:\n                    results[key]\
    \ = {'mean': [], 'median': []}\n                results[key]['mean'].append(value)\n\
    \                results[key]['median'].append(value)\n        for key in results:\n\
    \            mean = np.mean(results[key]['mean'])\n            median = np.median(results[key]['median'])\n\
    \            results[key] = {'mean': mean, 'median': median}\n        df_data\
    \ = []\n        for item in data:\n            for key, value in item.items():\n\
    \                df_data.append({'X': key, 'Y': value})\n        df = DataFrame(df_data)\n\
    \        ax = sns.boxplot(x='X', y='Y', data=df)\n        plt.title('Boxplot of\
    \ Values for Each Key')\n        return results, ax\n    except FileNotFoundError:\n\
    \        raise FileNotFoundError('The specified file does not exist.')\n    except\
    \ json.JSONDecodeError:\n        raise json.JSONDecodeError('Invalid JSON format\
    \ in the file.', '', 0)"
- source_sentence: "\"\"\"\n    Extracts matches from all text files in a specified\
    \ directory based on a regular expression pattern.\n    It captures whatever is\
    \ between parentheses as a single match, and any character outside the parentheses\
    \ as individual matches in the string.\n    \"\"\"\n    result = {}\n    for filename\
    \ in os.listdir(directory_path):\n        if filename.endswith('.txt'):\n    \
    \        filepath = os.path.join(directory_path, filename)\n            with open(filepath,\
    \ 'r') as f:\n                content = f.read()\n                matches = re.findall(regex_pattern,\
    \ content)\n                result[filename] = matches\n    return result"
  sentences:
  - "params = norm.fit(data)\n    mean = params[0]\n    var = params[1] ** 2\n   \
    \ if var == 0:\n        return [], mean, var\n    z_scores = (data - mean) / np.sqrt(var)\n\
    \    outliers = np.where(np.abs(z_scores) > threshold)[0]\n    return outliers.tolist(),\
    \ mean, var"
  - "\"\"\"\n    Save the provided Pandas DataFrame \"df\" in a pickle file with the\
    \ given name,\n    read it back for validation, and delete the intermediate file.\n\
    \n    Args:\n        df (pd.DataFrame): The pandas DataFrame to be saved.\n  \
    \      file_name (str): Name of the file where the DataFrame will be saved.\n\n\
    \    Returns:\n        loaded_df (pd.DataFrame): The loaded DataFrame from the\
    \ specified file.\n    \"\"\"\n    with open(file_name, 'wb') as f:\n        pickle.dump(df,\
    \ f)\n    with open(file_name, 'rb') as f:\n        loaded_df = pickle.load(f)\n\
    \    os.remove(file_name)\n    return loaded_df"
  - "\"\"\"\n    Removes rows from a dataframe based on values of multiple columns,\n\
    \    and then creates n random pairs of two columns against each other\n    to\
    \ generate pairplots.\n    \"\"\"\n    modified_df = df[~df.apply(tuple, axis=1).isin(tuple(map(tuple,\
    \ tuples)))]\n    cols = list(df.columns)\n    plots = []\n    for i in range(min(n_plots,\
    \ len(cols) // 2)):\n        col1 = cols[i]\n        col2 = cols[i + 1]\n    \
    \    plt.figure(figsize=(8, 6))\n        plt.scatter(df[col1], df[col2])\n   \
    \     plt.xlabel(col1)\n        plt.ylabel(col2)\n        plt.title(f'{col1} vs\
    \ {col2}')\n        plt.grid(True)\n        plt.savefig(f'{col1}_{col2}.png')\n\
    \        plt.close()\n        plots.append(plt.gca())\n    return modified_df,\
    \ plots"
- source_sentence: "if pd.isna(cell) or not isinstance(cell, str):\n            return\
    \ np.nan\n        match = re.search(data_pattern, cell)\n        if match:\n \
    \           try:\n                number = float(match.group(0)[1:-1])\n     \
    \           return number\n            except ValueError:\n                return\
    \ np.nan\n        return np.nan\n    result = dataframe.copy()\n    for col in\
    \ result.columns:\n        result[col] = result[col].apply(process_cell)\n   \
    \ return result"
  sentences:
  - "def _convert(o):\n        if isinstance(o, datetime):\n            return o.isoformat()\n\
    \        if isinstance(o, np.ndarray):\n            return o.tolist()\n      \
    \  if isinstance(o, Decimal):\n            return str(o)\n        if isinstance(o,\
    \ dict):\n            new_dict = {}\n            for k, v in o.items():\n    \
    \            new_dict[k] = _convert(v)\n            return new_dict\n        if\
    \ isinstance(o, list):\n            new_list = []\n            for item in o:\n\
    \                new_list.append(_convert(item))\n            return new_list\n\
    \        if isinstance(o, tuple):\n            new_tuple = []\n            for\
    \ item in o:\n                new_tuple.append(_convert(item))\n            return\
    \ tuple(new_tuple)\n        if isinstance(o, set):\n            return list(_convert(item)\
    \ for item in o)\n        return o\n    return json.dumps(_convert(my_obj))"
  - "if not isinstance(df, pd.DataFrame\n        ) or 'Date' not in df.columns or\
    \ 'Sales' not in df.columns:\n        raise ValueError('Invalid input DataFrame')\n\
    \    try:\n        df['Date'] = pd.to_datetime(df['Date'])\n    except:\n    \
    \    pass\n    if len(df) == 0:\n        raise ValueError('Empty DataFrame')\n\
    \    fig, ax = plt.subplots()\n    ax.plot_date(df['Date'], df['Sales'], '-')\n\
    \    ax.set_title('Daily Turnover')\n    ax.set_ylabel('Sales')\n    return ax"
  - "\"\"\"Converts a word into a DataFrame with letters and their positions in the\
    \ alphabet.\"\"\"\n    if not isinstance(word, str) or len(word) == 0:\n     \
    \   return pd.DataFrame({'Letter': [], 'Position': []})\n    if not word.isalpha():\n\
    \        raise ValueError('Input must be alphabetic characters only.')\n    if\
    \ not word.islower():\n        raise ValueError('Input must be lowercase letters\
    \ only.')\n    alphabet = 'abcdefghijklmnopqrstuvwxyz'\n    letter_positions =\
    \ [(alphabet.index(char) + 1) for char in word]\n    data = {'Letter': list(word),\
    \ 'Position': letter_positions}\n    return pd.DataFrame(data)"
- source_sentence: "\"\"\"\n    Perform DBSCAN clustering on the data and add cluster\
    \ assignments to a DataFrame.\n\n    Args:\n        data (list): List of lists\
    \ containing numerical data points.\n        cols (list): List of column names\
    \ for the features.\n\n    Returns:\n        df (DataFrame): DataFrame with original\
    \ data and an additional 'Cluster' column\n                        indicating\
    \ the cluster assignment for each point.\n    \"\"\"\n    df = pd.DataFrame(data,\
    \ columns=cols)\n    db = DBSCAN(eps=3, min_samples=2).fit(df)\n    df['Cluster']\
    \ = db.labels_\n    return df"
  sentences:
  - "\"\"\"\n    Generates all possible combinations of a given length from a tuple\
    \ and returns a random combination.\n\n    Args:\n        t (tuple): The input\
    \ tuple from which combinations are generated.\n        n (int): The desired length\
    \ of the combinations.\n\n    Returns:\n        tuple: A randomly selected combination\
    \ of the specified length, or an empty tuple if no valid combination exists.\n\
    \    \"\"\"\n    if n == 0:\n        return ()\n    combs = list(itertools.combinations(t,\
    \ n))\n    if not combs:\n        return ()\n    return random.choice(combs)"
  - "\"\"\"\n    Checks a log file and formats the lines that contain certain keywords.\n\
    \n    Args:\n        log_file_path (str): The path to the log file to be checked.\n\
    \        keywords (list): A list of keywords to be searched for in the log file.\n\
    \n    Returns:\n        list: Returns a list of formatted strings containing the\
    \ relevant information.\n    \"\"\"\n    try:\n        with open(log_file_path,\
    \ 'r') as log_file:\n            formatted_lines = []\n            for line in\
    \ log_file:\n                for keyword in keywords:\n                    if\
    \ keyword in line:\n                        match = re.search('(\\\\S+)\\\\s+(\\\
    \\S+)\\\\s+(.*)', line.\n                            strip())\n              \
    \          if match:\n                            formatted_line = (\n       \
    \                         f'{keyword:<20} : {match.group(1):<20} : {match.group(2):<20}'\n\
    \                                )\n                            formatted_lines.append(formatted_line)\n\
    \                        else:\n                            formatted_lines.append(\n\
    \                                f'Unexpected line format: {line.strip()}')\n\
    \    except FileNotFoundError:\n        raise FileNotFoundError(f'Log file {log_file_path}\
    \ does not exist.')\n    except Exception as e:\n        logging.error(f'An error\
    \ occurred: {e}')\n        raise\n    return formatted_lines"
  - "class PlotData:\n\n        def __init__(self):\n            self.x = tuple(range(points))\n\
    \            self.y = [random.random() for _ in range(points)]\n    data = PlotData()\n\
    \    fig, ax = plt.subplots(figsize=(8, 6), dpi=100)\n    ax.plot(data.x, data.y,\
    \ marker='o', linestyle='-', color='blue')\n    ax.set_xlabel('Index', fontsize=12)\n\
    \    ax.set_ylabel('Random Value', fontsize=12)\n    ax.grid(True, which='both',\
    \ linestyle='--', alpha=0.7)\n    return data.y.copy(), ax"
- source_sentence: "X = df[['X']]\n    y = df['Y']\n    model = LinearRegression()\n\
    \    model.fit(X, y)\n    return model"
  sentences:
  - "\"\"\"\n    Fetches a web page from a given URL, decodes its content from a specified\
    \ encoding,\n    and returns the parsed HTML using BeautifulSoup. If specified,\
    \ 'lxml' is used as \n    the parser for improved performance. In case of any\
    \ failure (like network issues, \n    invalid URL, or decoding errors), the function\
    \ returns None.\n\n    Args:\n        url (str): The URL to fetch.\n        from_encoding\
    \ (str): The encoding of the webpage content.\n        use_lxml (bool): Whether\
    \ to use lxml parser for improved performance. Defaults to False.\n\n    Returns:\n\
    \        BeautifulSoup: The parsed HTML, or None if an error occurred.\n    \"\
    \"\"\n    try:\n        response = requests.get(url)\n        response.raise_for_status()\n\
    \        if response.status_code == 200:\n            decoded_content = response.content.decode(from_encoding)\n\
    \            parser = 'lxml' if use_lxml else 'html.parser'\n            return\
    \ BeautifulSoup(decoded_content, parser)\n        else:\n            return None\n\
    \    except Exception as e:\n        return None"
  - "letter_counts = defaultdict(int)\n    for animal in animal_dict:\n        if\
    \ animal in ['cat', 'camel', 'cow', 'dog', 'elephant', 'fox',\n            'giraffe',\
    \ 'hippo', 'iguana', 'jaguar']:\n            for letter in animal:\n         \
    \       letter_counts[letter] += 1\n    sorted_letter_counts = dict(sorted(letter_counts.items(),\
    \ key=\n        itemgetter(1), reverse=True))\n    return sorted_letter_counts"
  - "if not os.path.exists(json_dir_path):\n        raise FileNotFoundError('Directory\
    \ does not exist')\n    texts = []\n    for filename in os.listdir(json_dir_path):\n\
    \        filepath = os.path.join(json_dir_path, filename)\n        if filename.endswith('.json'):\n\
    \            with open(filepath, 'r') as f:\n                data = json.load(f)\n\
    \                texts.append(data['text'])\n    combined_text = ' '.join(texts)\n\
    \    word_counts = Counter(combined_text.split())\n    most_common_words = word_counts.most_common(word_count)\n\
    \    return most_common_words"
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
      value: 0.9723861169890254
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.857482765353391
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
    "X = df[['X']]\n    y = df['Y']\n    model = LinearRegression()\n    model.fit(X, y)\n    return model",
    "if not os.path.exists(json_dir_path):\n        raise FileNotFoundError('Directory does not exist')\n    texts = []\n    for filename in os.listdir(json_dir_path):\n        filepath = os.path.join(json_dir_path, filename)\n        if filename.endswith('.json'):\n            with open(filepath, 'r') as f:\n                data = json.load(f)\n                texts.append(data['text'])\n    combined_text = ' '.join(texts)\n    word_counts = Counter(combined_text.split())\n    most_common_words = word_counts.most_common(word_count)\n    return most_common_words",
    "letter_counts = defaultdict(int)\n    for animal in animal_dict:\n        if animal in ['cat', 'camel', 'cow', 'dog', 'elephant', 'fox',\n            'giraffe', 'hippo', 'iguana', 'jaguar']:\n            for letter in animal:\n                letter_counts[letter] += 1\n    sorted_letter_counts = dict(sorted(letter_counts.items(), key=\n        itemgetter(1), reverse=True))\n    return sorted_letter_counts",
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[ 1.0000, -0.0388,  0.0169],
#         [-0.0388,  1.0000,  0.1465],
#         [ 0.0169,  0.1465,  1.0000]])
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
| pearson_cosine      | 0.9724     |
| **spearman_cosine** | **0.8575** |

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
  | details | <ul><li>min: 2 tokens</li><li>mean: 188.67 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 2 tokens</li><li>mean: 188.13 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.51</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   | sentence_1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       | label            |
  |:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code></code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                | <code>filtered = df.query('Age > @age and Height < @height').copy()<br>    if len(filtered) < 3:<br>        filtered = filtered.assign(Cluster=0)<br>        return filtered, None<br>    clusters = KMeans(n_clusters=3, random_state=0).fit_predict(filtered[[<br>        'Age', 'Height']])<br>    filtered = filtered.assign(Cluster=clusters)<br>    fig, ax = plt.subplots()<br>    ax.scatter(filtered['Age'], filtered['Height'], c=filtered['Cluster'],<br>        cmap='viridis')<br>    ax.set_xlabel('Age')<br>    ax.set_ylabel('Height')<br>    ax.set_title('KMeans Clustering based on Age and Height')<br>    return filtered, ax</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | <code>0.0</code> |
  | <code>"""Decodes Unicode escape strings in the 'UnicodeString' column of a DataFrame."""<br>    decoded_strings = [bytes(s, 'utf-8').decode('utf-8') for s in dataframe<br>        ['UnicodeString']]<br>    result_df = dataframe.copy()<br>    result_df['UnicodeString'] = decoded_strings<br>    return result_df</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 | <code>matched = []<br>    for root, _, files in os.walk(directory):<br>        for name in files:<br>            if any(fnmatch.fnmatch(name, ext) for ext in extensions):<br>                path = os.path.join(root, name)<br>                try:<br>                    with open(path, 'r', encoding='utf-8') as f:<br>                        content = f.read()<br>                    if re.search(pattern, content, re.IGNORECASE):<br>                        matched.append(os.path.abspath(path))<br>                except Exception:<br>                    pass<br>    return matched<br><br><br>def task_func_set(pattern: str, directory: str, extensions: list):<br>    result = set()<br>    for root, _, files in os.walk(directory):<br>        for name in files:<br>            if any(fnmatch.fnmatch(name, ext) for ext in extensions):<br>                path = os.path.join(root, name)<br>                try:<br>                    with open(path, 'r', encoding='utf-8') as f:<br>                        content = f.read()<br>                    if re.search(pattern, content, r...</code> | <code>0.0</code> |
  | <code>if not isinstance(df, pd.DataFrame):<br>        raise TypeError('df must be a pandas DataFrame')<br>    if not isinstance(tuples, list):<br>        raise TypeError('tuples must be a list')<br>    if not isinstance(n_plots, int):<br>        raise TypeError('n_plots must be an integer')<br>    set_tuples = set(tuples)<br>    mask = ~df.apply(tuple, axis=1).isin(set_tuples)<br>    modified_df = df[mask].copy()<br>    logger.info(f'Removed {len(df) - len(modified_df)} rows')<br>    cols = list(modified_df.columns)<br>    all_pairs = list(itertools.combinations(cols, 2))<br>    random.shuffle(all_pairs)<br>    selected_pairs = all_pairs[:n_plots]<br>    plots = []<br>    for col1, col2 in selected_pairs:<br>        fig = px.scatter(modified_df, x=col1, y=col2)<br>        plots.append(((col1, col2), fig))<br>    logger.info(f'Generated {len(plots)} plots')<br>    return modified_df, plots</code> | <code>df_copy = df.copy()<br>    for tup in tuples:<br>        try:<br>            df_copy.drop(df_copy[df_copy[tup[0]] == tup[1]].index, inplace=True<br>                )<br>        except KeyError:<br>            pass<br>    plots = []<br>    remaining_cols = df_copy.columns.tolist()<br>    for i in range(min(n_plots, len(remaining_cols) * (len(remaining_cols) -<br>        1) // 2)):<br>        col1 = remaining_cols[i % len(remaining_cols)]<br>        if i < len(remaining_cols) - 1:<br>            col2 = remaining_cols[(i + 1) % len(remaining_cols)]<br>            plt.figure()<br>            df_copy.plot(x=col1, y=col2, kind='scatter')<br>            plt.xlabel(col1)<br>            plt.ylabel(col2)<br>            plt.title(f'{col1} vs {col2}')<br>            plt.savefig(f'{col1}_{col2}.png')<br>            plt.close()<br>            plots.append((col1, col2, f'{col1}_{col2}.png'))<br>    return df_copy, plots</code>                                                                                                                                                              | <code>1.0</code> |
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
| 0.0717 | 500   | 0.3773        | -                       |
| 0.1435 | 1000  | 0.1474        | -                       |
| 0.2152 | 1500  | 0.0585        | -                       |
| 0.2870 | 2000  | 0.0436        | -                       |
| 0.3587 | 2500  | 0.0383        | -                       |
| 0.4305 | 3000  | 0.0328        | -                       |
| 0.5022 | 3500  | 0.0276        | -                       |
| 0.5740 | 4000  | 0.0277        | -                       |
| 0.6457 | 4500  | 0.0259        | -                       |
| 0.7175 | 5000  | 0.0265        | -                       |
| 0.7892 | 5500  | 0.0224        | -                       |
| 0.8610 | 6000  | 0.0233        | -                       |
| 0.9327 | 6500  | 0.0229        | -                       |
| 1.0    | 6969  | -             | 0.8515                  |
| 1.0044 | 7000  | 0.0211        | -                       |
| 1.0762 | 7500  | 0.0189        | -                       |
| 1.1479 | 8000  | 0.018         | -                       |
| 1.2197 | 8500  | 0.021         | -                       |
| 1.2914 | 9000  | 0.0165        | -                       |
| 1.3632 | 9500  | 0.0134        | -                       |
| 1.4349 | 10000 | 0.0153        | -                       |
| 1.5067 | 10500 | 0.0147        | -                       |
| 1.5784 | 11000 | 0.0145        | -                       |
| 1.6502 | 11500 | 0.0147        | -                       |
| 1.7219 | 12000 | 0.0148        | -                       |
| 1.7937 | 12500 | 0.0133        | -                       |
| 1.8654 | 13000 | 0.0151        | -                       |
| 1.9372 | 13500 | 0.0135        | -                       |
| 2.0    | 13938 | -             | 0.8573                  |
| 2.0089 | 14000 | 0.0126        | -                       |
| 2.0806 | 14500 | 0.0097        | -                       |
| 2.1524 | 15000 | 0.0116        | -                       |
| 2.2241 | 15500 | 0.012         | -                       |
| 2.2959 | 16000 | 0.0095        | -                       |
| 2.3676 | 16500 | 0.011         | -                       |
| 2.4394 | 17000 | 0.0088        | -                       |
| 2.5111 | 17500 | 0.0105        | -                       |
| 2.5829 | 18000 | 0.0102        | -                       |
| 2.6546 | 18500 | 0.0092        | -                       |
| 2.7264 | 19000 | 0.0102        | -                       |
| 2.7981 | 19500 | 0.0121        | -                       |
| 2.8699 | 20000 | 0.009         | -                       |
| 2.9416 | 20500 | 0.0098        | -                       |
| 3.0    | 20907 | -             | 0.8575                  |


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