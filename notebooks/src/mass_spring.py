import networkx as nx
import matplotlib.pyplot as plt
import numpy as np
from matplotlib.patches import Patch

# Define all possible color schemes
MODEL_COLORS = {
    "gpt-oss:20b": "red",
    "gpt-oss:latest": "lightcoral",
    "llama3.1:latest": "blue",
    "llama4:latest": "lightskyblue",
    "deepseek-r1": "gray",
    "gemma3:latest": "green",
    "original": "gold"
}

CONTEXT_COLORS = {
    "complete": "red",
    "minimal": "orange",
    "requirements": "green",
    "uml": "blue",
    "ast": "purple",
    "translation": "brown",
    "original": "gold"
}

STRATEGIES = ["zero-shot", "few-shot", "cot"]
STRATEGY_COLORS = {s: c for s, c in zip(STRATEGIES, ["red", "blue", "green"])}
STRATEGY_COLORS["original"] = "gold"

NFRS = [f"nfr{i}" for i in range(6)]
NFR_COLORS = {nfr: c for nfr, c in zip(NFRS, ["red", "blue", "green", "orange", "purple", "brown"])}
NFR_COLORS["original"] = "gold"

def plot_mass_spring_graph(data, entry_index, color_by="model"):
    """
    Plots a semantic clone graph using a mass-spring layout.
    
    Parameters:
        data (list): The dataset containing entries with original code and clones.
        entry_index (int): Index of the entry to visualize.
        color_by (str): The attribute to color nodes by. Options: "model", "context", "strategy", "nfrs".
    """
    # --- Pick a single entry ---
    entry = data[entry_index]

    # --- Choose color scheme ---
    if color_by == "model":
        color_scheme = MODEL_COLORS
        attr_name = "model"
    elif color_by == "context":
        color_scheme = CONTEXT_COLORS
        attr_name = "context"
    elif color_by == "strategy":
        color_scheme = STRATEGY_COLORS
        attr_name = "strategy"
    elif color_by == "nfrs":
        color_scheme = NFR_COLORS
        attr_name = "nfrs"
    else:
        raise ValueError("Supported color_by options: 'model', 'context', 'strategy', 'nfrs'")

    # --- Create graph ---
    G = nx.Graph()
    original_id = "original"
    G.add_node(original_id, label="Original", **{attr_name: "original"}, color=color_scheme["original"])

    clones = entry["clones"]
    scores = [clone["metrics"]["codebleu"]["originalcode"] for clone in clones]
    min_score, max_score = min(scores), max(scores)

    # Add clone nodes and edges
    for clone in clones:
        clone_id = clone["clone_id"]
        node_attr = clone.get(attr_name, "unknown")
        color = color_scheme.get(node_attr, "gray")
        G.add_node(clone_id, label="", **{attr_name: node_attr}, color=color)

        codebleu_score = clone["metrics"]["codebleu"]["originalcode"]
        distance = 1 / (codebleu_score + 1e-5)
        G.add_edge(original_id, clone_id, weight=distance)

    # Connect clones to each other
    for i, clone_i in enumerate(clones):
        id_i = clone_i["clone_id"]
        metrics_i = clone_i["metrics"]["codebleu"]
        for j in range(i + 1, len(clones)):
            id_j = clones[j]["clone_id"]
            codebleu_score = metrics_i.get(id_j, 0.01)
            distance = 1 / (codebleu_score + 1e-5)
            G.add_edge(id_i, id_j, weight=distance)

    # --- Visualization --- 
    pos = nx.spring_layout(G, weight="weight", seed=42)
    colors = [G.nodes[n]["color"] for n in G.nodes()]

    plt.figure(figsize=(7,7))
    nx.draw_networkx_nodes(G, pos, node_size=150, node_color=colors)
    nx.draw_networkx_edges(G, pos, width=0)  # hide edges
    labels = {original_id: "Original"}  # only label original
    nx.draw_networkx_labels(G, pos, labels, font_size=8)

    # --- Concentric circles centered on the original node ---
    orig_x, orig_y = pos[original_id]
    num_zones = 4
    zone_radii = np.linspace(0, 1, num_zones + 1)[1:] 
    label_x = orig_x + 1.05

    for r in zone_radii:
        circle = plt.Circle((orig_x, orig_y), r, color='black', fill=False, linestyle='--', alpha=0.8)
        plt.gca().add_patch(circle)
        codebleu_value = max_score - r * (max_score - min_score)
        plt.plot([orig_x, label_x], [orig_y + r, orig_y + r], color='gray', linewidth=0.8, linestyle='--')
        plt.text(label_x + 0.02, orig_y + r, f"{codebleu_value:.2f}", fontsize=8, color='gray', va='center')

    # Legend
    legend_handles = [Patch(color=color, label=name) for name, color in color_scheme.items()]
    plt.legend(handles=legend_handles, loc='lower left', fontsize=8, frameon=False)

    plt.axis("equal")
    plt.axis("off")
    plt.show()
