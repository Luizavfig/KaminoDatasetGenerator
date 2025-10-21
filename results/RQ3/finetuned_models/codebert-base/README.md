---
tags:
- sentence-transformers
- sentence-similarity
- feature-extraction
- dense
- generated_from_trainer
- dataset_size:2287
- loss:CosineSimilarityLoss
base_model: microsoft/codebert-base
widget:
- source_sentence: "import statistics\n\n\ndef task_func(L):\n\n    def flatten(lst):\n\
    \        for el in lst:\n            if isinstance(el, list):\n              \
    \  yield from flatten(el)\n            else:\n                yield el\n    flat_list\
    \ = list(flatten(L))\n    if not flat_list:\n        raise ValueError('List is\
    \ empty')\n    return float(statistics.median(flat_list))\n"
  sentences:
  - "import statistics\nfrom collections import deque\nimport logging\n\n\ndef task_func(L):\n\
    \n    def flatten(lst):\n        q = deque()\n        q.append(lst)\n        while\
    \ q:\n            current = q.popleft()\n            if isinstance(current, list):\n\
    \                for item in current:\n                    q.append(item)\n  \
    \          else:\n                yield current\n    elements = []\n    try:\n\
    \        for elem in flatten(L):\n            elements.append(elem)\n    except\
    \ TypeError:\n        logging.error('Invalid element found in the list')\n   \
    \     raise ValueError('Input contains invalid elements')\n    if not elements:\n\
    \        raise ValueError('List is empty')\n    sorted_elements = sorted(elements)\n\
    \    n = len(sorted_elements)\n    if n % 2 == 1:\n        return float(statistics.median_low(sorted_elements))\n\
    \    else:\n        lower_median = statistics.median_low(sorted_elements)\n  \
    \      upper_median = statistics.median_high(sorted_elements)\n        return\
    \ (lower_median + upper_median) / 2.0\n"
  - "from datetime import datetime, time\n\n\ndef task_func(logs: list):\n    error_times\
    \ = []\n    total_minutes = 0\n    for log in logs:\n        try:\n          \
    \  ts = datetime.strptime(log[:19], '%Y-%m-%d %H:%M:%S')\n        except Exception:\n\
    \            continue\n        if 'ERROR' in log:\n            error_times.append(time(ts.hour,\
    \ ts.minute))\n            total_minutes += ts.hour * 60 + ts.minute\n    if error_times:\n\
    \        avg_min = total_minutes // len(error_times)\n        avg_time = time(avg_min\
    \ // 60, avg_min % 60)\n    else:\n        avg_time = time(0, 0)\n    return error_times,\
    \ avg_time\n"
  - "import random\nimport matplotlib.pyplot as plt\nfrom datetime import datetime,\
    \ timedelta\n\n\ndef task_func(epoch_milliseconds, teams=['Team1', 'Team2', 'Team3',\
    \ 'Team4',\n    'Team5'], random_seed=0):\n    if not isinstance(teams, list)\
    \ or not all(isinstance(t, str) for t in teams\n        ):\n        raise TypeError('Expected\
    \ teams to be list of str')\n    start_time = datetime.fromtimestamp(epoch_milliseconds\
    \ / 1000.0)\n    current_time = datetime.now()\n    days_diff = (current_time\
    \ - start_time).days\n    if days_diff < 0:\n        raise ValueError('Input epoch\
    \ timestamp is in the future!')\n    random.seed(random_seed)\n    performance_data\
    \ = {}\n    for team in teams:\n        performances = [random.uniform(0.1, 1)\
    \ for _ in range(days_diff)]\n        performance_data[team] = performances\n\
    \    fig, ax = plt.subplots()\n    for team, performance in performance_data.items():\n\
    \        ax.plot(range(days_diff), performance, label=team)\n    ax.set_xlabel('Days\
    \ since ' + start_time.strftime('%Y-%m-%d %H:%M:%S'))\n    ax.set_ylabel('Performance')\n\
    \    ax.legend()\n    return performance_data, fig\n"
- source_sentence: "import pandas as pd\nfrom sklearn.preprocessing import StandardScaler\n\
    import numpy as np\n\n\ndef task_func(records: np.ndarray, random_seed: int) ->pd.DataFrame:\n\
    \    \"\"\"\n    Processes input records by shuffling features, normalizing values,\n\
    \    and converting to a DataFrame with shuffled column names.\n\n    Args:\n\
    \        records: A 2D numpy array where each row represents a record\n      \
    \      and each column represents a feature.\n        random_seed: Seed for random\
    \ operations to ensure reproducibility.\n\n    Returns:\n        pd.DataFrame:\
    \ A pandas DataFrame containing the preprocessed data,\n            with shuffled\
    \ feature names.\n    \"\"\"\n    if not isinstance(records, np.ndarray) or records.ndim\
    \ != 2:\n        raise ValueError('Invalid input type or shape')\n    np.random.seed(random_seed)\n\
    \    shuffled_features = np.random.permutation(records.T).T\n    scaler = StandardScaler()\n\
    \    normalized_data = scaler.fit_transform(shuffled_features)\n    columns =\
    \ [f'f{i + 1}' for i in range(normalized_data.shape[1])]\n    df = pd.DataFrame(normalized_data,\
    \ columns=columns)\n    return df\n"
  sentences:
  - "import numpy as np\nimport pandas as pd\nfrom sklearn.preprocessing import StandardScaler\n\
    \n\ndef task_func(records: np.ndarray, random_seed: int) ->pd.DataFrame:\n   \
    \ if not isinstance(random_seed, int):\n        raise TypeError('random_seed must\
    \ be an integer.')\n    if records.ndim != 2:\n        raise ValueError('Input\
    \ must be a 2D numpy array.')\n    shuffled_features = records.copy()\n    np.random.seed(random_seed)\n\
    \    np.random.shuffle(shuffled_features.T)\n    scaler = StandardScaler()\n \
    \   normalized_data = scaler.fit_transform(shuffled_features)\n    feature_names\
    \ = [f'f{i + 1}' for i in range(records.shape[1])]\n    np.random.seed(random_seed)\n\
    \    np.random.shuffle(feature_names)\n    df = pd.DataFrame(normalized_data,\
    \ columns=feature_names)\n    return df\n"
  - "import datetime\nfrom dateutil import tz\n\n\ndef task_func(date_str, from_tz,\
    \ to_tz):\n    try:\n        dt = datetime.datetime.strptime(date_str, '%Y-%m-%d\
    \ %H:%M:%S')\n        from_tz_obj = tz.gettz(from_tz)\n        to_tz_obj = tz.gettz(to_tz)\n\
    \        dt = dt.replace(tzinfo=from_tz_obj)\n        dt = dt.astimezone(to_tz_obj)\n\
    \        return dt.strftime('%Y-%m-%d %H:%M:%S')\n    except ValueError:\n   \
    \     raise ValueError('Invalid date format')\n    except Exception as e:\n  \
    \      raise\n"
  - "import numpy as np\nfrom scipy import stats\nimport matplotlib.pyplot as plt\n\
    \n\ndef task_func(data_str, bins=10, separator=','):\n    try:\n        data =\
    \ [float(x) for x in data_str.split(separator)]\n    except ValueError:\n    \
    \    raise ValueError('Invalid data')\n    if not data:\n        raise ValueError('Data\
    \ is empty')\n    series = pd.Series(data)\n    n, bins, patches = plt.hist(series,\
    \ bins=bins, rwidth=0.9, color='#607c8e')\n    return series.astype(np.int64),\
    \ plt.gca()\n"
- source_sentence: "import os\nfrom pathlib import Path\nimport shutil\n\n\ndef task_func(filename:\
    \ str, dest_dir: str) ->str:\n    \"\"\"Copy a file to the specified destination\
    \ directory and clear its contents.\n\n    Args:\n        filename (str): Path\
    \ to the source file.\n        dest_dir (str): Path to the destination directory.\n\
    \n    Returns:\n        str: Absolute path of the copied file.\n\n    Raises:\n\
    \        FileNotFoundError: If the source file does not exist.\n        OSError:\
    \ If there's an issue creating the destination directory or copying the file.\n\
    \    \"\"\"\n    if not os.path.isfile(filename):\n        raise FileNotFoundError(f\"\
    Source file '{filename}' does not exist.\")\n    dest_path = Path(dest_dir)\n\
    \    dest_path.mkdir(parents=True, exist_ok=True)\n    copied_file = shutil.copy2(str(filename),\
    \ str(dest_path))\n    with open(filename, 'w', encoding='utf-8') as f:\n    \
    \    pass\n    return os.path.abspath(copied_file)\n"
  sentences:
  - "import re\nimport socket\nfrom urllib.parse import urlparse\n\n\ndef task_func(myString):\n\
    \    \"\"\"\n    Extracts URLs from a string, processes each to get the domain,\n\
    \    and retrieves the IPv4 address for each domain.\n    Returns a dictionary\
    \ with domains as keys and IP addresses as values.\n    Domains that cannot be\
    \ resolved will have None as their IP address.\n    \"\"\"\n    url_pattern =\
    \ 'https?://[^\\\\s,]+'\n    extracted_urls = re.findall(url_pattern, myString)\n\
    \n    def process_url(url):\n        try:\n            parsed = urlparse(url)\n\
    \            domain = parsed.netloc\n            ip = socket.gethostbyname(domain)\n\
    \            return {domain: ip}\n        except (socket.gaierror, ValueError):\n\
    \            return {domain: None} if 'domain' in locals() else {}\n    result\
    \ = {}\n    for url in extracted_urls:\n        processed = process_url(url)\n\
    \        if processed:\n            result.update(processed)\n    return result\n"
  - "import os, shutil\n\n\ndef task_func(filename, dest_dir):\n    if not os.path.isdir(dest_dir):\n\
    \        os.makedirs(dest_dir)\n    mapping = {'src': filename, 'dst': os.path.join(dest_dir,\
    \ os.path.\n        basename(filename))}\n    for key in mapping:\n        if\
    \ key == 'src':\n            src_path = mapping[key]\n        else:\n        \
    \    dst_path = mapping[key]\n    shutil.copy2(src_path, dst_path)\n    with open(src_path,\
    \ 'w') as f:\n        f.write('')\n    paths = [src_path, dst_path]\n\n    def\
    \ inner():\n        return None\n    return os.path.abspath(dst_path)\n"
  - "import os\nimport shutil\n\n\ndef task_func(filename, dest_dir):\n\n    def create_directory(directory_path):\n\
    \        try:\n            os.mkdir(directory_path)\n        except FileExistsError:\n\
    \            pass\n\n    def copy_file(source_path, destination_path):\n     \
    \   return shutil.copy2(source_path, destination_path)\n\n    def clear_file_content(file_path):\n\
    \        with open(file_path, 'w') as file:\n            pass\n    create_directory(dest_dir)\n\
    \    copied_file = copy_file(filename, os.path.join(dest_dir, os.path.\n     \
    \   basename(filename)))\n    clear_file_content(filename)\n    return os.path.abspath(copied_file)\n"
- source_sentence: "from collections import defaultdict\nimport matplotlib.pyplot\
    \ as plt\nimport pandas as pd\nimport seaborn as sns\n\n\ndef task_func(list_of_menuitems):\n\
    \    if not list_of_menuitems:\n        return None\n    flat_list = []\n    for\
    \ sublist in list_of_menuitems:\n        if isinstance(sublist, list):\n     \
    \       for item in sublist:\n                flat_list.append(item)\n    if not\
    \ flat_list:\n        return None\n    counter = defaultdict(int)\n    for item\
    \ in flat_list:\n        counter[item] += 1\n    df = pd.DataFrame.from_dict(counter,\
    \ orient='index', columns=['Count']\n        ).reset_index()\n    df.columns =\
    \ ['Item', 'Count']\n    if df.empty:\n        return None\n    sns.set(style='darkgrid')\n\
    \    ax = sns.barplot(y='Item', x='Count', data=df, palette='plasma')\n    plt.tight_layout()\n\
    \    return ax\n"
  sentences:
  - "import pandas as pd\nimport matplotlib.pyplot as plt\n\n\ndef task_func(data_str,\
    \ separator=',', bins=20):\n    if not data_str.strip():\n        raise ValueError('Empty\
    \ data string')\n    try:\n        data = [int(float(x)) for x in data_str.split(separator)]\n\
    \    except ValueError:\n        raise ValueError('Failed to convert data to integers')\n\
    \    series = pd.Series(data)\n    fig, ax = plt.subplots()\n    series.plot.hist(ax=ax,\
    \ grid=True, bins=bins, rwidth=0.9, color='#607c8e')\n    return series, ax\n"
  - "import pandas as pd\n\n\ndef task_func(df):\n    if not isinstance(df, pd.DataFrame):\n\
    \        raise TypeError('Input must be a pandas DataFrame')\n    if df.empty:\n\
    \        return 0\n    brackets = '(){}[]'\n    total = sum(sum(str(val).count(b)\
    \ for b in brackets) for val in df.\n        astype(str).values.ravel())\n   \
    \ return total\n"
  - "import matplotlib.pyplot as plt\nimport seaborn as sns\nfrom collections import\
    \ Counter\n\n\ndef task_func(list_of_menuitems):\n    if not list_of_menuitems:\n\
    \        return None\n    flat_list = [item for sublist in list_of_menuitems for\
    \ item in sublist]\n    counts = Counter(flat_list)\n    fig, ax = plt.subplots()\n\
    \    sns.barplot(x=counts.keys(), y=counts.values(), ax=ax)\n    return ax\n"
- source_sentence: "import logging\nfrom statistics import median\nlogging.basicConfig(level=logging.INFO)\n\
    \n\ndef task_func(L):\n    \"\"\"Return the median of all numeric elements in\
    \ a nested list L.\"\"\"\n    if not isinstance(L, list):\n        raise TypeError('Input\
    \ must be a list')\n\n    def _flatten(lst):\n        flat = []\n        for elem\
    \ in lst:\n            if isinstance(elem, list):\n                flat.extend(_flatten(elem))\n\
    \            else:\n                flat.append(elem)\n        return flat\n \
    \   flat_list = _flatten(L)\n    if not flat_list:\n        raise ValueError('Nested\
    \ list contains no elements')\n    try:\n        return median(flat_list)\n  \
    \  except TypeError as e:\n        raise TypeError('All elements must be comparable\
    \ numbers') from e\n"
  sentences:
  - "import pytz\nfrom dateutil import parser\n\n\ndef task_func(date_str, from_tz,\
    \ to_tz):\n    \"\"\"Converts a given datetime string from one timezone to another.\"\
    \"\"\n    from_timezone = pytz.timezone(from_tz)\n    to_timezone = pytz.timezone(to_tz)\n\
    \    parsed_date = parser.parse(date_str)\n    localized_date = parsed_date.replace(tzinfo=from_timezone)\n\
    \    converted_date = localized_date.astimezone(to_timezone)\n    return converted_date.strftime('%Y-%m-%d\
    \ %H:%M:%S')\n"
  - "def task_func(dt_str, from_tz, to_tz):\n    import datetime\n    from zoneinfo\
    \ import ZoneInfo\n    dt_obj = datetime.datetime.strptime(dt_str, '%Y-%m-%d %H:%M:%S')\n\
    \    if from_tz == to_tz:\n        return dt_str\n    if from_tz == 'UTC' and\
    \ to_tz == 'America/New_York':\n        new_dt = dt_obj.replace(tzinfo=ZoneInfo('UTC')).astimezone(ZoneInfo\n\
    \            ('America/New_York'))\n        return new_dt.strftime('%Y-%m-%d %H:%M:%S')\n\
    \    elif from_tz == 'UTC' and to_tz == 'America/Los_Angeles':\n        new_dt\
    \ = dt_obj.replace(tzinfo=ZoneInfo('UTC')).astimezone(ZoneInfo\n            ('America/Los_Angeles'))\n\
    \        return new_dt.strftime('%Y-%m-%d %H:%M:%S')\n    elif from_tz == 'UTC'\
    \ and to_tz == 'Europe/London':\n        new_dt = dt_obj.replace(tzinfo=ZoneInfo('UTC')).astimezone(ZoneInfo\n\
    \            ('Europe/London'))\n        return new_dt.strftime('%Y-%m-%d %H:%M:%S')\n\
    \    else:\n        raise ValueError('Unsupported timezone conversion')\n"
  - "import numpy as np\nflattened = []\n\n\ndef task_func(L):\n    global flattened\n\
    \    flattened = []\n\n    def recurse(item):\n        if isinstance(item, (list,\
    \ tuple)):\n            for x in item:\n                recurse(x)\n        else:\n\
    \            flattened.append(item)\n    recurse(L)\n    if not flattened:\n \
    \       raise ValueError\n    sorted_list = sorted(flattened)\n    manual = sorted_list[:]\n\
    \    for i in range(len(manual)):\n        for j in range(i + 1, len(manual)):\n\
    \            if manual[j] < manual[i]:\n                manual[i], manual[j] =\
    \ manual[j], manual[i]\n    n = len(manual)\n    mid = n // 2\n    if n % 2 ==\
    \ 1:\n        return float(manual[mid])\n    else:\n        return (manual[mid\
    \ - 1] + manual[mid]) / 2.0\n"
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
      value: 0.8855765121989123
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.16703070653803245
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
    'import logging\nfrom statistics import median\nlogging.basicConfig(level=logging.INFO)\n\n\ndef task_func(L):\n    """Return the median of all numeric elements in a nested list L."""\n    if not isinstance(L, list):\n        raise TypeError(\'Input must be a list\')\n\n    def _flatten(lst):\n        flat = []\n        for elem in lst:\n            if isinstance(elem, list):\n                flat.extend(_flatten(elem))\n            else:\n                flat.append(elem)\n        return flat\n    flat_list = _flatten(L)\n    if not flat_list:\n        raise ValueError(\'Nested list contains no elements\')\n    try:\n        return median(flat_list)\n    except TypeError as e:\n        raise TypeError(\'All elements must be comparable numbers\') from e\n',
    'import numpy as np\nflattened = []\n\n\ndef task_func(L):\n    global flattened\n    flattened = []\n\n    def recurse(item):\n        if isinstance(item, (list, tuple)):\n            for x in item:\n                recurse(x)\n        else:\n            flattened.append(item)\n    recurse(L)\n    if not flattened:\n        raise ValueError\n    sorted_list = sorted(flattened)\n    manual = sorted_list[:]\n    for i in range(len(manual)):\n        for j in range(i + 1, len(manual)):\n            if manual[j] < manual[i]:\n                manual[i], manual[j] = manual[j], manual[i]\n    n = len(manual)\n    mid = n // 2\n    if n % 2 == 1:\n        return float(manual[mid])\n    else:\n        return (manual[mid - 1] + manual[mid]) / 2.0\n',
    'import pytz\nfrom dateutil import parser\n\n\ndef task_func(date_str, from_tz, to_tz):\n    """Converts a given datetime string from one timezone to another."""\n    from_timezone = pytz.timezone(from_tz)\n    to_timezone = pytz.timezone(to_tz)\n    parsed_date = parser.parse(date_str)\n    localized_date = parsed_date.replace(tzinfo=from_timezone)\n    converted_date = localized_date.astimezone(to_timezone)\n    return converted_date.strftime(\'%Y-%m-%d %H:%M:%S\')\n',
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[1.0000, 0.9874, 0.0347],
#         [0.9874, 1.0000, 0.0229],
#         [0.0347, 0.0229, 1.0000]])
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

| Metric              | Value     |
|:--------------------|:----------|
| pearson_cosine      | 0.8856    |
| **spearman_cosine** | **0.167** |

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
  | details | <ul><li>min: 17 tokens</li><li>mean: 212.21 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 17 tokens</li><li>mean: 203.95 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.97</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          | sentence_1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              | label            |
  |:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code>import numpy as np<br>flattened = []<br><br><br>def task_func(L):<br>    global flattened<br>    flattened = []<br><br>    def recurse(item):<br>        if isinstance(item, (list, tuple)):<br>            for x in item:<br>                recurse(x)<br>        else:<br>            flattened.append(item)<br>    recurse(L)<br>    if not flattened:<br>        raise ValueError<br>    sorted_list = sorted(flattened)<br>    manual = sorted_list[:]<br>    for i in range(len(manual)):<br>        for j in range(i + 1, len(manual)):<br>            if manual[j] < manual[i]:<br>                manual[i], manual[j] = manual[j], manual[i]<br>    n = len(manual)<br>    mid = n // 2<br>    if n % 2 == 1:<br>        return float(manual[mid])<br>    else:<br>        return (manual[mid - 1] + manual[mid]) / 2.0<br></code> | <code>import numpy as np<br><br><br>def task_func(L):<br>    """<br>    Calculate the median of all elements in a nested list 'L'.<br><br>    Args:<br>        L (list): A nested list containing integers.<br><br>    Returns:<br>        float: The median of all elements in the list.<br><br>    Raises:<br>        ValueError: If the input list is empty.<br>    """<br><br>    def flatten(lst):<br>        return [item for sublist in lst for item in (flatten(sublist) if<br>            isinstance(sublist, list) else [sublist])]<br>    flattened = flatten(L)<br>    if not flattened:<br>        raise ValueError('List is empty')<br>    sorted_flattened = np.sort(flattened)<br>    n = len(sorted_flattened)<br>    if n % 2 == 0:<br>        median_index1 = n // 2 - 1<br>        median_index2 = median_index1 + 1<br>        return (sorted_flattened[median_index1] + sorted_flattened[<br>            median_index2]) / 2.0<br>    else:<br>        return sorted_flattened[n // 2]<br></code> | <code>1.0</code> |
  | <code>import pickle<br>import os<br>import pandas as pd<br><br><br>def task_func(df, file_name):<br>    try:<br>        with open(file_name + '.pkl', 'wb') as f:<br>            pickle.dump(df, f)<br>    except Exception as e:<br>        print(f'Error during pickling: {e}')<br>        return None<br>    try:<br>        loaded_df = pd.read_pickle(file_name + '.pkl')<br>    except Exception as e:<br>        print(f'Error during unpickling: {e}')<br>        return None<br>    try:<br>        os.remove(file_name + '.pkl')<br>    except Exception as e:<br>        print(f'Error during file removal: {e}')<br>        return None<br>    return loaded_df<br></code>                                                                                                                                                              | <code>import pickle<br>import os<br><br><br>def task_func(df, file_name):<br>    save_file = open(file_name, 'wb')<br>    pickle.dump(df, save_file)<br>    save_file.close()<br>    load_file = open(file_name, 'rb')<br>    loaded_df = pickle.load(load_file)<br>    load_file.close()<br>    os.remove(file_name)<br>    return loaded_df<br></code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                | <code>1.0</code> |
  | <code>import numpy as np<br>from scipy import stats<br><br><br>def task_func(df, column, alpha):<br>    if column not in df.columns:<br>        raise ValueError('Column does not exist in DataFrame')<br>    data = df[column].values<br>    stat, p = stats.shapiro(data)<br>    return p > alpha<br></code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      | <code>import pandas as pd<br>import numpy as np<br>import scipy.stats as stats<br><br><br>def task_func(df, column, alpha):<br>    try:<br>        data = df[column].dropna()<br>        if len(data) == 0:<br>            return False<br>        stat_result = stats.shapiro(data)<br>        p_value = stat_result[1]<br>        return p_value > alpha<br>    except KeyError:<br>        raise ValueError('Column does not exist in DataFrame')<br>    except Exception as e:<br>        raise ValueError(f'An error occurred during normality test: {e}')<br></code>                                                                                                                                                                                                                                                                                                                                                                                                                                              | <code>1.0</code> |
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
| 1.0    | 286  | -             | 0.1795                  |
| 1.7483 | 500  | 0.0182        | -                       |
| 2.0    | 572  | -             | 0.1758                  |
| 3.0    | 858  | -             | 0.1670                  |


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