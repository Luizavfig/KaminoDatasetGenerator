from src.config import *
from src.steps import (preprocess as pp, clone_gen as cg, filtering as fl, reprompt as rp,clustering as cl)
from src.utils.helper_functions import startup
def main():
    startup()

    # Step 1: Normalization
    if (not os.path.exists(DATASET_PATH)): # Only runs if dataset files don't exist
        pp.pre_process_data()

    # Step 2: Clone Generation
    try:
        cg.test_LLM_connection() # check connection to LLM
        cg.run_generation()
    except Exception as e:
        print("LLM connection test failed on Step 2:", e)
        return
    
    # Step 3: Filtering based on codebleu
    fl.run_codebleu_filtering()

    # Step 4: Run tests on filtered clones
    fl.run_tests()
    
    # Step 5: Reprompting for clones passing at least 25% of tests but not 100%
    # try:
    #     cg.test_LLM_connection() # check connection to LLM
    #     rp.run_reprompt()
    # except Exception as e:
    #     print("LLM connection test failed on Step 5:", e)
    #     return

    # Step 6: Filering based on tests
    fl.run_test_filtering()

    # Step 7: Codebleu between all clones (similarity matrix)
    fl.compute_codebleu_for_all()

    # Step 8: Clustering
    cl.run_clustering()

    
if __name__ == "__main__":
    main()