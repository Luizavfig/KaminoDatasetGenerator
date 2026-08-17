using System.Collections.Generic;

// BigCodeBench/670
// Python: iterate every (start, end) pair from combinations(range(len(x)+1), 2),
// take substring x[start:end], sum weights via w.get(c, 0), keep the max.
//
// Language-specific adaptations:
// - Python's `str` -> C# `string`. Python slicing x[start:end] has no direct
//   operator in C#; it is replaced by string.Substring(start, end - start),
//   which is the closest equivalent for a half-open [start, end) range.
// - dict.get(c, 0) (a default-valued lookup) -> Dictionary<char,int> has no
//   built-in default-value getter, so it is replaced by
//   `w.TryGetValue(c, out v) ? v : 0`, which is the idiomatic C# equivalent.
// - itertools.combinations(range(len(x) + 1), 2) enumerates every 2-element
//   combination of the index range in increasing order, which for a 2-subset
//   is exactly every (start, end) pair with start < end -- i.e. a nested loop.
//   This is made explicit as two nested `for` loops in C#, which is both more
//   idiomatic and behaviorally identical (same enumeration order, so ties are
//   resolved identically: the first max found is kept, matching Python's `>`
//   comparison which never replaces the incumbent on ties).
public static class Solution
{
    public static string TaskFunc(string x, Dictionary<char, int> w)
    {
        double maxWeight = double.NegativeInfinity;
        string maxSubstr = "";

        for (int start = 0; start <= x.Length; start++)
        {
            for (int end = start + 1; end <= x.Length; end++)
            {
                string substr = x.Substring(start, end - start);

                int weight = 0;
                foreach (var c in substr)
                {
                    int value;
                    weight += w.TryGetValue(c, out value) ? value : 0;
                }

                if (weight > maxWeight)
                {
                    maxWeight = weight;
                    maxSubstr = substr;
                }
            }
        }

        return maxSubstr;
    }
}
