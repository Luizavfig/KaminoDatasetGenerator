import warnings, os, re, json
warnings.filterwarnings("ignore") 
import numpy as np
import pandas as pd
from sklearn.manifold import MDS
import matplotlib.pyplot as plt
import matplotlib.cm as cm
from matplotlib.colors import Normalize
from scipy.cluster.hierarchy import linkage, fcluster
from scipy.spatial.distance import squareform
from statistics import mean, stdev
from src.config import *

def run_clustering(filtered_path_tests=FILTERED_PATH_TESTS, sample_path=SAMPLE_1_PATH, final_dataset=FINAL_DATASET):
    """
    Automatically cluster code clones based on CodeBLEU similarity metrics. It uses a  hierarchical agglomerative clustering approach to determine clusters.
    """
    print("Starting clustering process...")
    with open(filtered_path_tests, "r", encoding="utf-8") as f:
        clone_data = json.load(f)

    with open(sample_path, "r", encoding="utf-8") as f:
        complete_data = json.load(f)

    #  Build lookup 
    complete_lookup = {entry["id"]: entry for entry in complete_data}

    merged_data = []

    for entry in clone_data:
        clones = entry.get("clones", [])
        if not clones:
            print(f"⚠️ Entry {entry['id']} has no clones, skipping")
            continue

        affinity_matrix, clone_ids = _build_affinity_matrix(entry) 

        # Cluster clones
        labels = _agglomerative_cluster(affinity_matrix, CODEBLEU_THRESHOLD)
        save_cluster_csv_from_labels( entry, labels, output_csv_path=os.path.join(CLUSTER_DIR, "all_clusters.csv"))

        if len(set(labels)) == 0:
            labels = [0] * len(clones)

        # Select representatives
        reps = _select_representative_clones(entry, labels)
        if not reps:
            first_clone = clones[0]
            reps = [(0, first_clone["clone_id"], first_clone["code"])]

        # Build new clones list
        new_clones = []
        for cluster_label, cid, code in reps:
            orig_clone = next((c for c in clones if c["clone_id"] == cid), None)
            base = orig_clone or {} 
            new_clones.append({
                "clone_id": cid,
                "model": base.get("model"),
                "strategy": base.get("strategy"),
                "context": base.get("context"),
                "refacs": base.get("refacs"),
                "reprompt": base.get("reprompt"),
                "cluster": cluster_label,
                "code": code,
                "metrics": {"codebleu": {"originalcode": base.get("metrics", {}).get("codebleu", {}).get("originalcode", 1.0)
        }
    }})

        # Merge with complete dataset entry
        original_entry = complete_lookup.get(entry["id"], {}) 
        filtered_entry = original_entry.copy() 
        filtered_entry["clones"] = new_clones

        merged_data.append(filtered_entry) 

    #  Compute clone stats 
    clone_counts = [len(entry["clones"]) for entry in merged_data]
    min_clones = min(clone_counts) if clone_counts else 0
    max_clones = max(clone_counts) if clone_counts else 0
    avg_clones = mean(clone_counts) if clone_counts else 0
    std_clones = stdev(clone_counts) if len(clone_counts) > 1 else 0
    sum_clones = sum(clone_counts)

    print("\n Clone Statistics:")
    print(f"  - Total unique clones: {sum_clones}")
    print(f"  - Min clones per entry: {min_clones}")
    print(f"  - Max clones per entry: {max_clones}")
    print(f"  - Avg clones per entry: {avg_clones:.2f}")
    print(f"  - Std clones per entry: {std_clones:.2f}")

    #  Save final dataset 
    os.makedirs(os.path.dirname(final_dataset), exist_ok=True)
    with open(final_dataset, "w", encoding="utf-8") as f:
        json.dump(merged_data, f, indent=2, default=_np_converter)

    print(f"\n✅ New dataset with representatives saved to {final_dataset}, total entries: {len(merged_data)}")


def _agglomerative_cluster(affinity_matrix, similarity_threshold):
    """Agglomerative clustering using scipy"""
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


def cluster_and_plot(entry, similarity_threshold=CODEBLEU_THRESHOLD, output_dir=CLUSTER_DIR): 
    """Cluster and plot clones for visualization"""
    affinity_matrix, clone_ids = _build_affinity_matrix(entry)  
    labels = _agglomerative_cluster(affinity_matrix, similarity_threshold)
    _save_clusters_as_files(entry, labels, output_dir) 
    _save_representatives(entry, labels, output_dir)   
    dissimilarity = 1 - affinity_matrix
    mds = MDS(n_components=2, dissimilarity='precomputed', random_state=42, n_init=1, max_iter=100)
    points_2d = mds.fit_transform(dissimilarity)

    _plot_clusters_mds(points_2d, labels, entry['id'])


def _plot_clusters_mds(points_2d, labels, entry_id):
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
    sm = plt.cm.ScalarMappable(cmap=colormap, norm=Normalize(vmin=0, vmax=n_clusters-1))
    sm.set_array([]) 
    cbar = fig.colorbar(sm, ax=ax, ticks=range(n_clusters))
    cbar.set_label('Cluster')

    plt.show()

def _save_clusters_as_files(entry, labels, output_dir=CLUSTER_DIR):
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

def _select_representative_clones(entry, labels):
    """
    Select one representative clone per cluster (the medoid), based on highest average CodeBLEU similarity to other clones in the cluster.
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
        assert best_idx is not None, f"No best index found for cluster {cluster_label}"
        representatives.append((cluster_label, clone_ids[best_idx], clones[best_idx].get("code", "")))

    return representatives

def _sanitize_id(entry_id: str) -> str:
    """Replaces any non-alphanumeric or separator character with underscore"""
    return re.sub(r"[^\w\-]", "_", entry_id) 

def _save_representatives(entry, labels, output_dir=CLUSTER_DIR):
    reps = _select_representative_clones(entry, labels)

    safe_id = _sanitize_id(entry["id"])
    entry_dir = os.path.join(output_dir, "representatives", safe_id)
    os.makedirs(entry_dir, exist_ok=True)

    file_path = os.path.join(entry_dir, f"{safe_id}_representatives.py")
    with open(file_path, "w", encoding="utf-8") as f:
        for cluster_label, cid, code in reps:
            f.write(f"# Cluster {cluster_label} - Representative clone {cid}\n")
            f.write(code.strip() + "\n\n")

    print(f"Saved all representatives for entry {entry['id']} in {file_path}")



def _build_affinity_matrix(entry):
    """
    Build the CodeBLEU-based affinity (similarity) matrix for clones in an entry
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

def _np_converter(obj):
    if isinstance(obj, np.integer):
        return int(obj)
    elif isinstance(obj, np.floating):
        return float(obj)
    elif isinstance(obj, np.ndarray):
        return obj.tolist()
    else:
        raise TypeError(f"Object of type {type(obj)} is not JSON serializable")

def save_cluster_csv_from_labels(entry, labels, output_csv_path):
    """ 
    Save cluster information for a single entry (all clones) into a CSV. This uses the already computed `labels`.
    """
    clones = entry.get("clones", [])
    if not clones:
        return

    clusters = {}
    clone_ids = [c["clone_id"] for c in clones]

    # Group clone IDs by cluster
    for cid, label in zip(clone_ids, labels):
        clusters.setdefault(label, []).append(cid)

    # Prepare rows
    rows = []
    for cluster_label, ids in clusters.items():
        rows.append({
            "entry_id": entry["id"],
            "cluster_id": cluster_label,
            "num_clones": len(ids),
            "clone_ids": ";".join(ids)
        })
 
    os.makedirs(os.path.dirname(output_csv_path), exist_ok=True)
    df = pd.DataFrame(rows)
    if os.path.exists(output_csv_path):
        # append
        df.to_csv(output_csv_path, mode="a", header=False, index=False)
    else:
        df.to_csv(output_csv_path, index=False)

    print(f"✅ Saved clusters for entry {entry['id']} to {output_csv_path}")
