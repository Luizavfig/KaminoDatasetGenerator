from src.config import *
from src.steps import (preprocess as pp, clone_gen as cg, filtering as fl, reprompt as rp,clustering as cl)
def main():
    print("Starting pipeline...")
    print("Make sure to run `pip install -r required_packages.txt` if you haven't already.")
    # Step 1: Preprocess dataset
    if (not os.path.exists(DATASET_PATH)): # Only run if dataset file doesn't exist
        pp.pre_process_data()

    # Step 2: Clone Generation
    try:
        cg.test_LLM_connection() # check connection to LLM
        cg.run_generation()
    except Exception as e:
        print("⚠️ LLM connection test failed:", e)
        return
    
    # Step 3: Filtering based on codebleu
    fl.run_codebleu_filtering()

    # Step 4: Run tests on filtered clones
    fl.run_tests()
    
    # Step 5: Reprompting for failing clones
    rp.run_reprompt()

    # Step 6: Filering based on tests
    fl.run_test_filtering()

    # Step 6: Codebleu between all and Clustering
    fl.compute_codebleu_for_all()
    cl.run_clustering()

    
if __name__ == "__main__":
    main()