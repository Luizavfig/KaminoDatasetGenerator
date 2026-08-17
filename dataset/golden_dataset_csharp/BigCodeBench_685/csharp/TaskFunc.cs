using System.Collections.Generic;

// BigCodeBench/685
// Python: list(chain.from_iterable(list_of_lists)) -> Counter(merged_list)
//
// Language-specific adaptations:
// - list of lists -> List<List<long>> (nested List<T> is the direct structural
//   equivalent of a Python list of lists; `long` is used to stay safe for
//   arbitrary-precision Python ints, though the tests only use small values).
// - itertools.chain.from_iterable has no BCL keyword; flattening is done with
//   a straightforward nested foreach, preserving Python's left-to-right,
//   sublist-by-sublist iteration order (irrelevant for a Counter's final
//   value, but relevant for anyone re-using the flattened sequence).
// - collections.Counter(...) -> Dictionary<long, int>. As in BigCodeBench/297,
//   only observed elements become keys, matching Counter's equality semantics
//   under test (the Python tests only ever compare against realized keys).
public static class Solution
{
    public static Dictionary<long, int> TaskFunc(List<List<long>> listOfLists)
    {
        var counts = new Dictionary<long, int>();

        foreach (var sublist in listOfLists)
        {
            foreach (var item in sublist)
            {
                int current;
                counts[item] = counts.TryGetValue(item, out current) ? current + 1 : 1;
            }
        }

        return counts;
    }
}
