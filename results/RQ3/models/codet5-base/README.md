---
tags:
- sentence-transformers
- sentence-similarity
- feature-extraction
- dense
- generated_from_trainer
- dataset_size:73241
- loss:CosineSimilarityLoss
base_model: Salesforce/codet5-base
widget:
- source_sentence: "salt = os.urandom(salt_size)\n    b64_salt = base64.b64encode(salt).decode('utf-8')\n\
    \    sha256_hash = hashlib.sha256()\n    sha256_hash.update(hex_str.encode('utf-8'))\n\
    \    hash_value = sha256_hash.hexdigest()\n    return b64_salt, hash_value"
  sentences:
  - ''
  - "salt = os.urandom(salt_size)\n    hash_value = hashlib.sha256((hex_str + str(salt)).encode()).hexdigest()\n\
    \    return base64.b64encode(salt).decode(), hash_value"
  - "scale_factors = [0.5, 0.75, 1.5, 2.0]\n    if not os.path.exists(img_path):\n\
    \        raise FileNotFoundError(f'No file found at {img_path}')\n    images =\
    \ []\n    figs = []\n    try:\n        img = Image.open(img_path)\n        original_arr\
    \ = np.array(img)\n        for scale in scale_factors:\n            new_height\
    \ = int(img.height * scale)\n            new_width = int(img.width * scale)\n\
    \            scaled_arr = np.zeros((new_height, new_width, 3), dtype=np.uint8)\n\
    \            if scale < 1:\n                step_x = img.width // new_width\n\
    \                step_y = img.height // new_height\n                for i in range(new_height):\n\
    \                    for j in range(new_width):\n                        x = i\
    \ * step_y\n                        y = j * step_x\n                        scaled_arr[i,\
    \ j] = original_arr[x, y]\n            else:\n                for i in range(img.height):\n\
    \                    for j in range(img.width):\n                        step_x\
    \ = int(i * (new_width / img.width))\n                        step_y = int(j *\
    \ (new_height / img.height))\n                        scaled_arr[step_y, step_x]\
    \ = original_arr[i, j]\n            fig, ax = plt.subplots()\n            ax.imshow(scaled_arr)\n\
    \            ax.set_title(f'Scale factor: {scale}')\n            images.append((ax,\
    \ scaled_arr))\n            figs.append(fig)\n        return images\n    finally:\n\
    \        for fig in figs:\n            plt.close(fig)"
- source_sentence: "max_weight = -10 ** 9\n    max_substr = ''\n    substr_set = {x[i:j]\
    \ for i in range(len(x)) for j in range(i + 1, len(x\n        ) + 1)}\n\n    def\
    \ compute_weight(sub):\n        total = 0\n        for ch in sub:\n          \
    \  total += w.get(ch, 0)\n        return total\n    for sub in substr_set:\n \
    \       weight = 0\n        for ch in sub:\n            weight += w.get(ch, 0)\n\
    \        if weight > max_weight:\n            max_weight = weight\n          \
    \  max_substr = sub\n    return max_substr"
  sentences:
  - "cleaned = []\n    for text in texts:\n        temp = re.sub('[\\\\W_]', ' ',\
    \ text)\n        temp = temp.lower()\n        tokens = temp.split()\n        filtered_tokens\
    \ = [word for word in tokens if word not in nltk.\n            corpus.stopwords.words('english')]\n\
    \        cleaned.append(' '.join(filtered_tokens))\n    vectorizer = CountVectorizer()\n\
    \    dtm = vectorizer.fit_transform(cleaned)\n    feature_names = vectorizer.get_feature_names_out()\
    \ if hasattr(vectorizer,\n        'get_feature_names_out') else vectorizer.get_feature_names()\n\
    \    dtm_df = pd.DataFrame(dtm.toarray(), index=list(range(len(texts))),\n   \
    \     columns=feature_names)\n    return dtm_df"
  - "max_weight = -float('inf')\n    max_substr = ''\n    for i in range(len(x)):\n\
    \        current_weight = 0\n        for j in range(i, len(x)):\n            char\
    \ = x[j]\n            if char not in w:\n                continue\n          \
    \  current_weight += w[char]\n            if (current_weight > max_weight or current_weight\
    \ == max_weight and\n                x[i:j + 1] < max_substr):\n             \
    \   max_weight = current_weight\n                max_substr = x[i:j + 1]\n   \
    \ return max_substr\n\n\ndef task_func(x, w):\n    max_substring = ''\n    max_sum\
    \ = -float('inf')\n    for i in range(len(x)):\n        current_sum = 0\n    \
    \    for j in range(i, len(x)):\n            char = x[j]\n            if char\
    \ not in w:\n                continue\n            current_sum += w[char]\n  \
    \          if current_sum > max_sum or current_sum == max_sum and x[i:j + 1\n\
    \                ] < max_substring:\n                max_sum = current_sum\n \
    \               max_substring = x[i:j + 1]\n    return max_substring\n\n\ndef\
    \ task_func(x, w):\n    if not isinstance(x, str) or not isinstance(w, dict):\n\
    \        raise TypeError('Invalid input types')\n    max_weight = -float('inf')\n\
    \    max_substr = ''\n    for i in range(len(x)):\n        current_weight = 0\n\
    \        for j in range(i, len(x)):\n            char = x[j]\n            if char\
    \ not in w:\n                continue\n            current_weight += w[char]\n\
    \            if (current_weight > max_weight or current_weight == max_weight and\n\
    \                x[i:j + 1] < max_substr):\n                max_weight = current_weight\n\
    \                max_substr = x[i:j + 1]\n    return max_substr"
  - "if not isinstance(s1, pd.Series) or not isinstance(s2, pd.Series):\n        raise\
    \ TypeError('Both arguments must be pandas Series objects')\n    missing_categories\
    \ = set(CATEGORIES).difference(set(s1.index).union(set\n        (s2.index)))\n\
    \    if len(missing_categories) > 0:\n        print(\n            f'Warning: Some\
    \ categories are not present in the input data: {missing_categories}'\n      \
    \      )\n    try:\n        mask_s1 = s1 > 200\n        mask_s2 = s2 > 200\n \
    \       high_sales_categories = s1.index[mask_s1 & mask_s2]\n        if len(high_sales_categories)\
    \ == 0:\n            return None, 0.0\n        df_data = {'Store 1': s1[high_sales_categories],\
    \ 'Store 2': s2[\n            high_sales_categories]}\n        df = pd.DataFrame(df_data)\n\
    \        edit_distance = np.linalg.norm(df['Store 1'].values - df['Store 2']\n\
    \            .values)\n        fig, ax = plt.subplots()\n        df.plot(kind='bar',\
    \ title=\n            'Sales Comparison Above Threshold in Categories', ax=ax)\n\
    \        plt.xticks(rotation=45)\n        plt.tight_layout()\n        return ax,\
    \ edit_distance\n    except Exception as e:\n        print(f'Error occurred: {e}')\n\
    \        return None, 0.0"
- source_sentence: "random_state = 42\n    length = 10\n    lower_bound = 0\n    upper_bound\
    \ = 10\n    arr = np.random.RandomState(random_state).randint(lower_bound,\n \
    \       upper_bound, (length,))\n    arr_reshaped = arr.reshape(-1, 1)\n    scaler\
    \ = MinMaxScaler()\n    normalized_data = scaler.fit_transform(arr_reshaped)\n\
    \    return normalized_data"
  sentences:
  - "\"\"\"Generate random array and apply min-max normalization.\"\"\"\n    np.random.seed(42)\n\
    \    array = np.array([np.random.randint(0, 10) for _ in range(10)])\n    reshaped_array\
    \ = array.reshape(-1, 1)\n    min_val = reshaped_array.min()\n    max_val = reshaped_array.max()\n\
    \    scaled_array = (reshaped_array - min_val) / (max_val - min_val)\n    return\
    \ scaled_array"
  - "if df.empty:\n        raise ValueError('Input DataFrame cannot be empty')\n \
    \   cumsum_df = df.cumsum()\n    fig, ax = plt.subplots(figsize=(10, 6))\n   \
    \ cumsum_df.plot(kind='bar', ax=ax, color=['#2ecc71', '#e74c3c'])\n    ax.set_title('Cumulative\
    \ Sum per Column', fontsize=14, fontweight='bold')\n    ax.set_xlabel('Index',\
    \ fontsize=12)\n    ax.set_ylabel('Cumulative Sum', fontsize=12)\n    ax.grid(True,\
    \ linestyle='--', alpha=0.7)\n    ax.legend(title='Columns', bbox_to_anchor=(1.05,\
    \ 1), borderaxespad=0)\n    return cumsum_df, fig"
  - "with open(file_path, 'r') as file:\n        reader = csv.reader(file)\n     \
    \   data = [row[0] for row in reader]\n    if not data:\n        return float('nan'),\
    \ float('nan'), plot_path\n    cleaned_data = []\n    for value in data:\n   \
    \     try:\n            cleaned_data.append(float(value))\n        except ValueError:\n\
    \            pass\n    mean_value = median_value = float('nan')\n    if cleaned_data:\n\
    \        mean_value = mean(cleaned_data)\n        median_value = median(cleaned_data)\n\
    \    plt.figure(figsize=(10, 6))\n    plt.plot(cleaned_data)\n    plt.title('Data\
    \ Visualization')\n    plt.xlabel('Index')\n    plt.ylabel('Value')\n    plt.savefig(plot_path)\n\
    \    plt.close()\n    return mean_value, median_value, plot_path"
- source_sentence: "try:\n        float_bytes = secrets.token_bytes(4)\n        hex_str\
    \ = binascii.hexlify(float_bytes).decode('utf-8')\n        b64_bytes = base64.b64encode(hex_str.encode('utf-8'))\n\
    \        return b64_bytes.decode('utf-8')\n    except Exception as e:\n      \
    \  raise RuntimeError(f'Error encoding float to hex and base64: {e}')"
  sentences:
  - "df = df.drop(tuples, errors='ignore')\n    if not tuples and n_plots > 0:\n \
    \       columns = list(df.columns)\n        plots = []\n        used_pairs = set()\n\
    \        for _ in range(n_plots):\n            if len(columns) < 2:\n        \
    \        break\n            col1 = sample(columns, 1)[0]\n            remaining_columns\
    \ = [x for x in columns if x != col1]\n            if not remaining_columns:\n\
    \                break\n            col2 = sample(remaining_columns, 1)[0]\n \
    \           pair = col1, col2\n            if pair not in used_pairs:\n      \
    \          fig, ax = plt.subplots()\n                ax.scatter(df[col1], df[col2])\n\
    \                ax.set_xlabel(col1)\n                ax.set_ylabel(col2)\n  \
    \              plt.title(f'Scatter Plot: {col1} vs {col2}')\n                plots.append((col1,\
    \ col2, fig))\n                used_pairs.add(pair)\n        return df, plots\n\
    \    else:\n        return df, []"
  - "\"\"\"Generates a random float, converts to hex, and encodes in base64.\"\"\"\
    \n    random_float = os.urandom(4)\n    hex_str = random_float.hex()\n    b64_bytes\
    \ = base64.b64encode(hex_str.encode('utf-8'))\n    return b64_bytes.decode('utf-8')"
  - ''
- source_sentence: "def calculate_weight(substring: str) ->int:\n        return sum(w.get(c,\
    \ 0) for c in substring)\n    max_info = {'weight': -float('inf'), 'substring':\
    \ ''}\n    current_sum = 0\n    start_index = 0\n    for i, char in enumerate(x):\n\
    \        current_sum += w.get(char, 0)\n        if current_sum > max_info['weight']:\n\
    \            max_info['weight'] = current_sum\n            max_info['substring']\
    \ = x[start_index:i + 1]\n        elif current_sum < 0:\n            start_index\
    \ = i + 1\n            current_sum = 0\n    return max_info['substring']"
  sentences:
  - "result = {}\n    os_name = platform.system()\n    result['OS'] = os_name\n  \
    \  result['OS'] = platform.system()\n    arch = platform.architecture()[0]\n \
    \   result['Architecture'] = arch\n    result['Architecture'] = platform.architecture()[0]\n\
    \    try:\n        if psutil:\n            mem = psutil.virtual_memory()\n   \
    \         used = mem.used\n            total = mem.total\n        else:\n    \
    \        raise Exception\n    except Exception:\n        if os.name == 'posix':\n\
    \            with open('/proc/meminfo') as f:\n                lines = f.readlines()\n\
    \            meminfo = {}\n            for line in lines:\n                key,\
    \ val = line.split(':')\n                meminfo[key.strip()] = int(val.split()[0])\n\
    \            total = meminfo['MemTotal'] * 1024\n            used = (meminfo['MemTotal']\
    \ - meminfo['MemFree'] - meminfo.get(\n                'Buffers', 0) - meminfo.get('Cached',\
    \ 0)) * 1024\n        else:\n            total = 1\n            used = 0\n   \
    \ percent = used / total * 100 if total else 0\n    mem_str = f'{percent:.2f}%'\n\
    \    result['Memory Usage'] = mem_str\n    result['Memory Usage'] = f'{percent:.2f}%'\n\
    \    return result"
  - "delay_time = args[0] if len(args) > 0 else kwargs.get('delay_time', 1)\n    num_threads\
    \ = args[1] if len(args) > 1 else kwargs.get('num_threads', 5)\n    if num_threads\
    \ <= 0:\n        return []\n    results = []\n\n    def worker(idx, out):\n  \
    \      time.sleep(delay_time)\n        out.append(f'Delay in thread {idx} completed')\n\
    \    for i in range(num_threads):\n        out = []\n        t = threading.Thread(target=worker,\
    \ args=(i, out))\n        t.start()\n        t.join()\n        results.extend(out)\n\
    \    return results"
  - "\"\"\"\n    Parses XML content from a string and converts it into CSV format.\n\
    \n    Args:\n        xml_content (str): A well-formed XML string to be parsed.\n\
    \        output_csv_path (str): The file path where the resulting CSV will be\
    \ saved.\n\n    Notes:\n        - This function does not return any value. It\
    \ writes directly to the specified CSV file.\n        - Handles various edge cases\
    \ including nested elements, attributes, and empty XML structures.\n    \"\"\"\
    \n    try:\n        root = ET.fromstring(xml_content)\n        csv_data = []\n\
    \        for elem in root.iter():\n            row = [elem.tag]\n            if\
    \ elem.text is not None:\n                row.append(elem.text.strip())\n    \
    \        else:\n                row.append('')\n            csv_data.append(row)\n\
    \        with open(output_csv_path, 'w', newline='', encoding='utf-8'\n      \
    \      ) as csvfile:\n            writer = csv.writer(csvfile)\n            writer.writerows(csv_data)\n\
    \    except ET.ParseError as e:\n        raise ET.ParseError(f'Invalid XML content:\
    \ {str(e)}')\n    except IOError as e:\n        raise IOError(\n            f'Failed\
    \ to write CSV file at path: {output_csv_path}. Error: {str(e)}'\n           \
    \ )"
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
      value: 0.9714369594217919
      name: Pearson Cosine
    - type: spearman_cosine
      value: 0.855810095403785
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
    "def calculate_weight(substring: str) ->int:\n        return sum(w.get(c, 0) for c in substring)\n    max_info = {'weight': -float('inf'), 'substring': ''}\n    current_sum = 0\n    start_index = 0\n    for i, char in enumerate(x):\n        current_sum += w.get(char, 0)\n        if current_sum > max_info['weight']:\n            max_info['weight'] = current_sum\n            max_info['substring'] = x[start_index:i + 1]\n        elif current_sum < 0:\n            start_index = i + 1\n            current_sum = 0\n    return max_info['substring']",
    "delay_time = args[0] if len(args) > 0 else kwargs.get('delay_time', 1)\n    num_threads = args[1] if len(args) > 1 else kwargs.get('num_threads', 5)\n    if num_threads <= 0:\n        return []\n    results = []\n\n    def worker(idx, out):\n        time.sleep(delay_time)\n        out.append(f'Delay in thread {idx} completed')\n    for i in range(num_threads):\n        out = []\n        t = threading.Thread(target=worker, args=(i, out))\n        t.start()\n        t.join()\n        results.extend(out)\n    return results",
    '"""\n    Parses XML content from a string and converts it into CSV format.\n\n    Args:\n        xml_content (str): A well-formed XML string to be parsed.\n        output_csv_path (str): The file path where the resulting CSV will be saved.\n\n    Notes:\n        - This function does not return any value. It writes directly to the specified CSV file.\n        - Handles various edge cases including nested elements, attributes, and empty XML structures.\n    """\n    try:\n        root = ET.fromstring(xml_content)\n        csv_data = []\n        for elem in root.iter():\n            row = [elem.tag]\n            if elem.text is not None:\n                row.append(elem.text.strip())\n            else:\n                row.append(\'\')\n            csv_data.append(row)\n        with open(output_csv_path, \'w\', newline=\'\', encoding=\'utf-8\'\n            ) as csvfile:\n            writer = csv.writer(csvfile)\n            writer.writerows(csv_data)\n    except ET.ParseError as e:\n        raise ET.ParseError(f\'Invalid XML content: {str(e)}\')\n    except IOError as e:\n        raise IOError(\n            f\'Failed to write CSV file at path: {output_csv_path}. Error: {str(e)}\'\n            )',
]
embeddings = model.encode(sentences)
print(embeddings.shape)
# [3, 768]

# Get the similarity scores for the embeddings
similarities = model.similarity(embeddings, embeddings)
print(similarities)
# tensor([[ 1.0000,  0.0083, -0.0168],
#         [ 0.0083,  1.0000,  0.0169],
#         [-0.0168,  0.0169,  1.0000]])
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
| pearson_cosine      | 0.9714     |
| **spearman_cosine** | **0.8558** |

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
  |         | sentence_0                                                                          | sentence_1                                                                          | label                                                          |
  |:--------|:------------------------------------------------------------------------------------|:------------------------------------------------------------------------------------|:---------------------------------------------------------------|
  | type    | string                                                                              | string                                                                              | float                                                          |
  | details | <ul><li>min: 2 tokens</li><li>mean: 151.99 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 2 tokens</li><li>mean: 150.28 tokens</li><li>max: 256 tokens</li></ul> | <ul><li>min: 0.0</li><li>mean: 0.49</li><li>max: 1.0</li></ul> |
* Samples:
  | sentence_0                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     | sentence_1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    | label            |
  |:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------|
  | <code>merged_list = []<br>    for sublist in list_of_lists:<br>        merged_list.extend(sublist)<br>    if not merged_list:<br>        return np.array([]), 0<br>    mode_value, mode_count = stats.mode(np.array(merged_list))<br>    return mode_value, mode_count</code>                                                                                                                                                                                                                                                  | <code>df_copy = df.copy()<br>    mask = df_copy.apply(tuple, axis=1).isin(tuples)<br>    df_filtered = df_copy[~mask]<br>    plot_details = []<br>    max_plots = min(n_plots, len(df_filtered))<br>    for _ in range(max_plots):<br>        cols = random.sample(COLUMNS, 2)<br>        plot_details.append((cols[0], cols[1]))<br>    return df_filtered, plot_details</code>                                                                                                                                                                                                                                                                                                                                                              | <code>0.0</code> |
  | <code>if directory is None or not os.path.isdir(directory):<br>        raise OSError('Invalid directory path')<br>    counts = Counter()<br>    for ext in (extensions or ['.txt', '.docx', '.xlsx', '.csv']):<br>        for root, _, files in os.walk(directory):<br>            for file in files:<br>                if file.endswith(ext):<br>                    counts[ext] += 1<br>    if not keep_zero:<br>        counts = counts - Counter([ext for ext in counts if counts[ext] == 0])<br>    return counts</code> | <code>target_value = args[0] if args else '332'<br>    mask = dataframe.eq(target_value)<br>    fig, ax = plt.subplots()<br>    sns.heatmap(mask, ax=ax, cbar=False, cmap='viridis', linewidths=0.5)<br>    return mask, ax</code>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            | <code>0.0</code> |
  | <code>text = re.sub('[^\\w\\s]', '', text)<br>    text = re.sub('\\s+', ' ', text).strip()<br>    words = [word.lower() for word in text.split()]<br>    filtered_words = [word for word in words if word not in stopwords.words<br>        ('english')]<br>    bigrams = []<br>    for i in range(len(filtered_words) - 1):<br>        bigrams.append((filtered_words[i], filtered_words[i + 1]))<br>    return Counter(bigrams)</code>                                                                                       | <code>try:<br>        df = pd.read_csv(csv_path)<br>        df[date_column] = pd.to_datetime(df[date_column])<br>        years = df[date_column].dt.year.value_counts()<br>        plt.figure(figsize=(10, 6))<br>        years.hist(bins=10)<br>        plt.xlabel('Year')<br>        plt.ylabel('Frequency')<br>        plt.title('Year Distribution')<br>        plt.grid(True)<br>        plt.show()<br>        return plt.gca()<br>    except FileNotFoundError:<br>        raise FileNotFoundError(f'{csv_path} does not exist')<br>    except ValueError as e:<br>        raise ValueError(f'Error processing date column: {e}')<br>    except Exception as e:<br>        raise Exception(f'An unexpected error occurred: {e}')</code> | <code>0.0</code> |
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
| 0.0546 | 500   | 0.2435        | -                       |
| 0.1092 | 1000  | 0.1218        | -                       |
| 0.1638 | 1500  | 0.0758        | -                       |
| 0.2184 | 2000  | 0.0636        | -                       |
| 0.2730 | 2500  | 0.053         | -                       |
| 0.3277 | 3000  | 0.0459        | -                       |
| 0.3823 | 3500  | 0.0415        | -                       |
| 0.4369 | 4000  | 0.0412        | -                       |
| 0.4915 | 4500  | 0.0391        | -                       |
| 0.5461 | 5000  | 0.0338        | -                       |
| 0.6007 | 5500  | 0.0333        | -                       |
| 0.6553 | 6000  | 0.0285        | -                       |
| 0.7099 | 6500  | 0.0279        | -                       |
| 0.7645 | 7000  | 0.0249        | -                       |
| 0.8191 | 7500  | 0.028         | -                       |
| 0.8737 | 8000  | 0.0239        | -                       |
| 0.9284 | 8500  | 0.026         | -                       |
| 0.9830 | 9000  | 0.0241        | -                       |
| 1.0    | 9156  | -             | 0.8532                  |
| 1.0376 | 9500  | 0.0194        | -                       |
| 1.0922 | 10000 | 0.0195        | -                       |
| 1.1468 | 10500 | 0.0181        | -                       |
| 1.2014 | 11000 | 0.0179        | -                       |
| 1.2560 | 11500 | 0.019         | -                       |
| 1.3106 | 12000 | 0.0167        | -                       |
| 1.3652 | 12500 | 0.0185        | -                       |
| 1.4198 | 13000 | 0.019         | -                       |
| 1.4744 | 13500 | 0.0174        | -                       |
| 1.5291 | 14000 | 0.0177        | -                       |
| 1.5837 | 14500 | 0.0166        | -                       |
| 1.6383 | 15000 | 0.0148        | -                       |
| 1.6929 | 15500 | 0.0166        | -                       |
| 1.7475 | 16000 | 0.0119        | -                       |
| 1.8021 | 16500 | 0.0151        | -                       |
| 1.8567 | 17000 | 0.012         | -                       |
| 1.9113 | 17500 | 0.0152        | -                       |
| 1.9659 | 18000 | 0.0146        | -                       |
| 2.0    | 18312 | -             | 0.8552                  |
| 2.0205 | 18500 | 0.0126        | -                       |
| 2.0751 | 19000 | 0.0113        | -                       |
| 2.1298 | 19500 | 0.012         | -                       |
| 2.1844 | 20000 | 0.0128        | -                       |
| 2.2390 | 20500 | 0.0133        | -                       |
| 2.2936 | 21000 | 0.0119        | -                       |
| 2.3482 | 21500 | 0.0129        | -                       |
| 2.4028 | 22000 | 0.0102        | -                       |
| 2.4574 | 22500 | 0.0119        | -                       |
| 2.5120 | 23000 | 0.0108        | -                       |
| 2.5666 | 23500 | 0.0108        | -                       |
| 2.6212 | 24000 | 0.0123        | -                       |
| 2.6758 | 24500 | 0.0113        | -                       |
| 2.7304 | 25000 | 0.0112        | -                       |
| 2.7851 | 25500 | 0.0104        | -                       |
| 2.8397 | 26000 | 0.0109        | -                       |
| 2.8943 | 26500 | 0.0112        | -                       |
| 2.9489 | 27000 | 0.0103        | -                       |
| 3.0    | 27468 | -             | 0.8558                  |


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