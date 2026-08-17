using System.Collections.Generic;

// BigCodeBench/297
// Python: itertools.combinations(elements, subset_size) -> sums -> collections.Counter(sums)
//
// Language-specific adaptations:
// - Python's tuple `elements` -> C# IList<long> (an ordered, fixed collection;
//   List<T>/array both satisfy IList<T>). `long` is used instead of `int`
//   because Python integers have arbitrary precision and the sums of larger
//   subsets could in principle overflow a 32-bit int; using `long` keeps the
//   arithmetic behavior closer to Python's for the value ranges exercised here.
// - itertools.combinations(elements, r) has no direct BCL equivalent; it is
//   reimplemented explicitly below as a recursive/backtracking generator over
//   indices, preserving the same lexicographic enumeration order as Python
//   (irrelevant to the Counter result, but relevant if this helper is reused
//   elsewhere).
// - collections.Counter(sums) -> Dictionary<long, int> mapping each distinct
//   sum to how many subsets produced it. Python's Counter would silently
//   return counts for keys with count 0 if queried (Counter[missing] == 0);
//   the returned Dictionary here only contains keys that were actually seen,
//   which matches Counter's *iteration/equality* semantics (Counter() ==
//   Counter({}) and the tests only ever compare against realized keys).
public static class Solution
{
    public static Dictionary<long, int> TaskFunc(IList<long> elements, int subsetSize)
    {
        var counts = new Dictionary<long, int>();

        foreach (var combination in Combinations(elements, subsetSize))
        {
            long sum = 0;
            foreach (var value in combination) sum += value;

            int current;
            counts[sum] = counts.TryGetValue(sum, out current) ? current + 1 : 1;
        }

        return counts;
    }

    // Mirrors itertools.combinations(elements, r): yields every r-length
    // combination of elements in the input order, without repetition.
    private static IEnumerable<List<long>> Combinations(IList<long> elements, int r)
    {
        int n = elements.Count;
        if (r < 0 || r > n) yield break;

        var indices = new int[r];
        for (int i = 0; i < r; i++) indices[i] = i;

        if (r == 0)
        {
            yield return new List<long>();
            yield break;
        }

        while (true)
        {
            var combo = new List<long>(r);
            foreach (var idx in indices) combo.Add(elements[idx]);
            yield return combo;

            int pos = r - 1;
            while (pos >= 0 && indices[pos] == pos + n - r) pos--;
            if (pos < 0) yield break;

            indices[pos]++;
            for (int j = pos + 1; j < r; j++) indices[j] = indices[j - 1] + 1;
        }
    }
}
