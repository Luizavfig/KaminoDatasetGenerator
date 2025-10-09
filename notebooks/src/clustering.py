"""
Automatically cluster code clones based on
CodeBLEU similarity metrics and visualize them in a 2D space using Multidimensional Scaling (MDS).

It uses a fast hierarchical agglomerative clustering approach to determine clusters,
and assigns gradient colors to each cluster for visualization.
"""
import warnings, os, re
import numpy as np
from sklearn.manifold import MDS
import matplotlib.pyplot as plt
import matplotlib.cm as cm
from scipy.cluster.hierarchy import linkage, fcluster
from scipy.spatial.distance import squareform
output_dir="../results/clustering"
warnings.filterwarnings("ignore") 

# Agglomerative clustering using scipy (much faster)
def agg_cluster(affinity_matrix, similarity_threshold):
    n = affinity_matrix.shape[0]
    if n == 1:
        return np.array([0])
    
    # Convert similarity to distance
    distance_matrix = 1 - affinity_matrix
    condensed_dist = squareform(distance_matrix, checks=False)
    
    # Average linkage clustering
    Z = linkage(condensed_dist, method='average')
    
    # Form clusters based on distance threshold
    labels = fcluster(Z, t=1-similarity_threshold, criterion='distance')
    labels -= 1  # convert to 0-based labels
    return labels

# Cluster and plot clones
def cluster_and_plot(entry, similarity_threshold): 
    affinity_matrix, clone_ids = build_affinity_matrix(entry) 
    # Automatic clustering
    labels = agg_cluster(affinity_matrix, similarity_threshold)
    save_clusters_as_files(entry, labels) 
    save_representatives(entry, labels)  
    # MDS for visualization (fast config)
    dissimilarity = 1 - affinity_matrix
    mds = MDS(n_components=2, dissimilarity='precomputed', random_state=42, n_init=1, max_iter=100)
    points_2d = mds.fit_transform(dissimilarity)

    plot_clusters_mds(points_2d, labels, entry['id'])

# Plot with gradient colors
def plot_clusters_mds(points_2d, labels, entry_id):
    n_clusters = len(np.unique(labels))
    colormap = cm.get_cmap('viridis')

    # Map labels to gradient
    colors = [colormap(label / max(1, n_clusters - 1)) for label in labels]

    fig, ax = plt.subplots(figsize=(8,6))
    scatter = ax.scatter(points_2d[:,0], points_2d[:,1], c=colors, s=100)
    
    ax.set_title(f"Clone Clusters for Entry: {entry_id} (n_clusters={n_clusters})")
    ax.set_xlabel("MDS dim 1")
    ax.set_ylabel("MDS dim 2")

    # Create colorbar explicitly
    sm = plt.cm.ScalarMappable(cmap=colormap, norm=plt.Normalize(vmin=0, vmax=n_clusters-1))
    sm.set_array([])  # dummy array
    cbar = fig.colorbar(sm, ax=ax, ticks=range(n_clusters))
    cbar.set_label('Cluster')

    plt.show()

def print_cluster_stats(entry, labels):
    """
    For each cluster in an entry, prints:
    - Number of clones
    - List of clone IDs
    - Aggregate statistics (mean, std, min, max) of CodeBLEU scores between clones in the cluster
    """
    clones = entry["clones"]
    clone_ids = [clone["clone_id"] for clone in clones]
    unique_labels = np.unique(labels)

    for cluster_label in unique_labels:
        cluster_indices = [i for i, label in enumerate(labels) if label == cluster_label]
        n_clones = len(cluster_indices)
        print(f"\nCluster {cluster_label} - {n_clones} clone(s):")
        print("  Clones:", [clone_ids[i] for i in cluster_indices])

        if n_clones < 2:
            print("  Only one clone in this cluster, no pairwise scores.")
            continue

        # Collect all pairwise CodeBLEU scores
        scores = [
            clones[i]["metrics"]["codebleu"].get(clone_ids[j], 0)
            for idx_i, i in enumerate(cluster_indices)
            for j in cluster_indices[idx_i + 1:]
        ]

        mean_score = np.mean(scores)
        std_score = np.std(scores)
        min_score = np.min(scores)
        max_score = np.max(scores)

        print(f"  CodeBLEU stats - mean: {mean_score:.3f}, std: {std_score:.3f}, min: {min_score:.3f}, max: {max_score:.3f}")

def save_clusters_as_files(entry, labels):
    """
    Saves all clones from each cluster into a single file.
    """
    
    clones = entry["clones"]
    clone_ids = [clone["clone_id"] for clone in clones]
    unique_labels = np.unique(labels)

    entry_dir = os.path.join(f"{output_dir}/clusters", entry["id"])
    os.makedirs(entry_dir, exist_ok=True)

    for cluster_label in unique_labels:
        cluster_indices = [i for i, label in enumerate(labels) if label == cluster_label]
        cluster_file_path = os.path.join(entry_dir, f"cluster_{cluster_label}.py")

        with open(cluster_file_path, "w", encoding="utf-8") as f:
            for i in cluster_indices:
                clone_code = clones[i].get("code", "")
                f.write(f"# Clone {clone_ids[i]}\n")
                f.write(clone_code.strip() + "\n\n")

    print(f"Saved clusters for entry {entry['id']} in {entry_dir}")

def select_representative_clones(entry, labels):
    """
    Select one representative clone per cluster (the medoid),
    based on highest average CodeBLEU similarity to other clones in the cluster.
    
    Returns:
        list of (cluster_label, clone_id, clone_code)
    """
    clones = entry["clones"]
    clone_ids = [clone["clone_id"] for clone in clones]
    unique_labels = np.unique(labels)
    representatives = []

    for cluster_label in unique_labels:
        cluster_indices = [i for i, label in enumerate(labels) if label == cluster_label]
        
        if len(cluster_indices) == 1:
            i = cluster_indices[0]
            representatives.append((cluster_label, clone_ids[i], clones[i].get("code", "")))
            continue

        # Compute average similarity for each clone in the cluster
        best_idx = None
        best_avg_sim = -1
        for i in cluster_indices:
            sims = [
                clones[i]["metrics"]["codebleu"].get(clone_ids[j], 0)
                for j in cluster_indices if j != i
            ]
            avg_sim = np.mean(sims) if sims else 0
            if avg_sim > best_avg_sim:
                best_avg_sim = avg_sim
                best_idx = i

        representatives.append((cluster_label, clone_ids[best_idx], clones[best_idx].get("code", "")))

    return representatives

def sanitize_id(entry_id: str) -> str:
    # replace any non-alphanumeric or separator character with underscore
    return re.sub(r"[^\w\-]", "_", entry_id)

def save_representatives(entry, labels):
    reps = select_representative_clones(entry, labels)

    safe_id = sanitize_id(entry["id"])
    entry_dir = os.path.join(output_dir, "representatives", safe_id)
    os.makedirs(entry_dir, exist_ok=True)

    file_path = os.path.join(entry_dir, f"{safe_id}_representatives.py")
    with open(file_path, "w", encoding="utf-8") as f:
        for cluster_label, cid, code in reps:
            f.write(f"# Cluster {cluster_label} - Representative clone {cid}\n")
            f.write(code.strip() + "\n\n")

    print(f"Saved all representatives for entry {entry['id']} in {file_path}")



def build_affinity_matrix(entry):
    """
    Build the CodeBLEU-based affinity (similarity) matrix for clones in an entry.

    Parameters
    ----------
    entry : dict
        An entry containing a list of clones. Each clone must have:
        - "clone_id"
        - "metrics" -> "codebleu" dictionary with similarities.

    Returns
    -------
    affinity_matrix : np.ndarray
        Symmetric n x n similarity matrix (values in [0,1]).
    clone_ids : list
        List of clone IDs in the same order as the matrix indices.
    """
    clones = entry["clones"]
    clone_ids = [clone["clone_id"] for clone in clones]
    n = len(clone_ids)

    affinity_matrix = np.zeros((n, n))
    for i in range(n):
        for j in range(n):
            if i == j:
                affinity_matrix[i, j] = 1.0
            else:
                affinity_matrix[i, j] = clones[i]["metrics"]["codebleu"].get(clone_ids[j], 0)

    return affinity_matrix, clone_ids







