using System.Collections.Generic;
using System.Text.RegularExpressions;

// BigCodeBench/1108
// Python: for each dict in `result`, for each key `j` in that dict, if `j`
// looks like a URL, collect dict[j]; return the single most common collected
// value (as a one-entry dict), or {} if nothing matched.
//
// Language-specific adaptations:
// - `result`, a list of dicts with heterogeneous values (ints, strings, ...)
//   -> List<Dictionary<string, object>>. The URL check only ever inspects
//   dictionary KEYS (which are always strings, in both Python and C#), so the
//   VALUES keep their original dynamic-typing surface as `object`.
// - The nested `for l_res in result: for j in l_res:` loop is preserved
//   verbatim as two nested foreach loops (explicit nested control flow),
//   rather than flattened with LINQ, to keep the same iteration/short-circuit
//   structure as the original.
// - Python's `re.match` anchors only at the START of the string (it does not
//   require matching the whole string, unlike re.fullmatch); the original
//   pattern also ends with `$`, so in practice it behaves like a full match
//   here. .NET's Regex.IsMatch searches anywhere in the string by default, so
//   the pattern is used with .NET's `Match` combined with checking the match
//   starts at index 0, reproducing re.match's "anchored at start" semantics
//   exactly (the trailing `$` in the pattern already anchors the end).
// - collections.Counter(...).most_common(1) -> a manual scan that returns the
//   single value with the highest occurrence count. Ties are broken by
//   insertion order in both Python's Counter.most_common (stable w.r.t. first
//   insertion for equal counts, as of CPython's current implementation) and
//   this port (first-seen-wins on ties), so the two remain equivalent for the
//   tie cases exercised by the test suite.
public static class Solution
{
    private static readonly Regex UrlPattern = new Regex(
        @"^(?:http|ftp)s?://" +
        @"(?:(?:[A-Z0-9](?:[A-Z0-9-]{0,61}[A-Z0-9])?\.)+(?:[A-Z]{2,6}\.?|[A-Z0-9-]{2,}\.?)|" +
        @"localhost|" +
        @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})" +
        @"(?::\d+)?" +
        @"(?:/?|[/?]\S+)$",
        RegexOptions.IgnoreCase);

    public static Dictionary<object, int> TaskFunc(List<Dictionary<string, object>> result)
    {
        var fromUserValues = new List<object>();

        foreach (var lRes in result)
        {
            foreach (var j in lRes.Keys)
            {
                var m = UrlPattern.Match(j);
                if (m.Success && m.Index == 0)
                {
                    fromUserValues.Add(lRes[j]);
                }
            }
        }

        var counts = new Dictionary<object, int>();
        var order = new List<object>();
        foreach (var value in fromUserValues)
        {
            int current;
            if (counts.TryGetValue(value, out current))
            {
                counts[value] = current + 1;
            }
            else
            {
                counts[value] = 1;
                order.Add(value);
            }
        }

        var mostCommon = new Dictionary<object, int>();
        object bestKey = null;
        int bestCount = -1;
        foreach (var key in order)
        {
            if (counts[key] > bestCount)
            {
                bestCount = counts[key];
                bestKey = key;
            }
        }
        if (bestKey != null || order.Count > 0)
        {
            mostCommon[bestKey] = bestCount;
        }

        return mostCommon;
    }
}
