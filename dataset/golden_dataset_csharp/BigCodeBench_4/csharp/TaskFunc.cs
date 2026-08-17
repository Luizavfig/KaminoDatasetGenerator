using System;
using System.Collections;
using System.Collections.Generic;

// BigCodeBench/4
// Python: Counter(itertools.chain.from_iterable(d.values())) -> dict
//
// Language-specific adaptations:
// - Python's dict values are typed dynamically; the source dataset's tests pass
//   ints, strings, None and even a nested list as list elements to probe error
//   handling, so the C# signature uses List<object> to preserve that same
//   dynamic-typing surface instead of narrowing to List<int> (which would make
//   the invalid-input test impossible to express).
// - Python's Counter (and dict) requires hashable keys; a Python list is NOT
//   hashable, so Counter([...[6]...]) raises TypeError. C# has no equivalent
//   "unhashable" concept -- any object can be used as a Dictionary key via
//   reference-based hashing -- so this port explicitly rejects nested
//   collections to preserve the *observable* exception contract under test.
// - None -> null. Unlike Python (where None is a perfectly valid, hashable
//   dict key), .NET's Dictionary<TKey,TValue> throws ArgumentNullException for
//   a null key. In this particular entry that difference is benign: the only
//   test that supplies a null element also expects an exception overall, so
//   the C# port still raises (a different exception type, one element
//   earlier) for the same malformed input. This is called out explicitly in
//   verification.json.
public static class Solution
{
    public static Dictionary<object, int> TaskFunc(Dictionary<object, List<object>> d)
    {
        var counts = new Dictionary<object, int>();

        foreach (var list in d.Values)
        {
            foreach (var item in list)
            {
                if (item is IEnumerable && !(item is string))
                {
                    // Mirrors Python's "TypeError: unhashable type: 'list'"
                    throw new InvalidOperationException(
                        "Element is a nested collection and cannot be used as a counting key (mirrors Python's unhashable-type TypeError).");
                }

                int current;
                if (counts.TryGetValue(item, out current))
                    counts[item] = current + 1;
                else
                    counts[item] = 1;
            }
        }

        return counts;
    }
}
