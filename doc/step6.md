⬅️ [Back to Main README](../README.md)

---
### 6. 🧬 Representative Selection

#### Goal
Select a subset of **diverse and non-redundant Type-IV clones** for each original function.

At this stage:
- All clones are **semantically equivalent** (pass tests)
- All clones are **syntactically different from the original**

However, many clones may still be **similar to each other**.

This step removes redundancy and ensures the final dataset captures **meaningful diversity**.

---

#### Key Idea

We group similar clones together and select **one representative per group**.

This is achieved using:
- **CodeBLEU-based similarity**
- **Hierarchical Agglomerative Clustering (HAC)**

---

#### Step 1: Similarity Matrix

For each set of clones corresponding to the same original function:

start code here
for i in clones:
    for j in clones:
        if i == j:
            A[i][j] = 1
        else:
            A[i][j] = CodeBLEU(clone_i, clone_j)
end code here

- `A[i][j]` represents **syntactic similarity**
- Values range in `[0, 1]`

---

#### Step 2: Distance Conversion

To apply clustering, similarity is converted into distance:

start code here
D = 1 - A
end code here

- High similarity → small distance  
- Low similarity → large distance  

---

#### Step 3: Clustering (HAC)

We apply **Hierarchical Agglomerative Clustering** using:
- **Average linkage**
- Distance threshold:

start code here
τ = 1 - θ
end code here

Where:
- `θ` = CodeBLEU threshold used in syntactic filtering

---

#### Cluster Formation Rule

Two clones belong to the same cluster if:

start code here
CodeBLEU(clone_i, clone_j) ≥ θ
end code here

This ensures clusters group **structurally similar clones**.

---

#### Step 4: Representative Selection (Medoid)

For each cluster, we select a **representative clone**.

Definition:

start code here
representative = argmax_i (
    average similarity between clone_i and all other clones in cluster
)
end code here

This clone:
- Best represents the cluster
- Is the most “central” implementation

---

#### Example Intuition

- Two clones may both pass filtering (low similarity to original)
- But still be very similar to each other

➡️ They will be grouped into the same cluster  
➡️ Only one will be selected  

---

#### Output

For each original function:
- A set of **representative clones**
- Each clone is:
  - Semantically correct  
  - Syntactically distinct from original  
  - Non-redundant with others  

Each clone is enriched with:
- `cluster_id`
- `is_representative`

---

#### Why This Step Matters

Without clustering:
- Dataset may contain many **near-duplicates**
- Certain patterns may be **overrepresented**

With clustering:
- Diversity is **balanced**
- Dataset is more useful for:
  - ML training  
  - Benchmarking  

---
