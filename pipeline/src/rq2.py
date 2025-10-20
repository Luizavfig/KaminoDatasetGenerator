from src.config import *
from src.steps import (normalization as nz, clone_gen as cg, filtering as fl, reprompt as rp,clustering as cl)
from src.utils.efficiency import select_top_n_configs
from src.utils.helper_functions import startup
def main():
    startup()
    # Step 1: Normalization (not needed)

    # Calculate top-N efficient configurations
    top_configs = select_top_n_configs()

    # Step 2: Clone Generation with only top-N efficient configurations
    cg.run_efficient_generation(top_configs=top_configs)
        
    # Step 3: Filtering based on codebleu
    fl.run_codebleu_filtering()

    # Step 4: Run tests on filtered clones
    fl.run_tests()
    
    # Step 5: Reprompting for clones passing at least 25% of tests but not 100%
    rp.run_reprompt()
    
    # Step 6: Filering based on tests
    fl.run_test_filtering()

    # Step 7: Codebleu between all clones (similarity matrix)
    fl.compute_codebleu_for_all()

    # Step 8: Clustering
    cl.run_clustering()

    
if __name__ == "__main__":
    main()