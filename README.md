# KaminoDatasetGenerator
A pipeline to generate type 4 clones using LLMs

## Requirements 
* A hugging face token must be place in a .env file
    * ```HF_TOKEN=token_here```
* Python 3 or newer
* Ollama running in a server (default port for local connection or 3333 for remote)
* Inside the *pipeline* folder, run `pip install -r required_packages.txt` to install required packages -- depending on your Python kernell addionatinal packages may need to be instaled
* [MS C++ build tools](https://visualstudio.microsoft.com/pt-br/visual-cpp-build-tools/) -- make sure to install Desktop development with C++ (include Win 10/11 SDK and C++ CMake tools for Windows) -- this is **required by Codebleu**

## To run
Inside *pipeline* folder, run ```python -m src.main```

# Configuration
The pipeline is pre-configured with the setup used for the experiments. 
To change the configuration, modify [config.py](pipeline/src/config.py)