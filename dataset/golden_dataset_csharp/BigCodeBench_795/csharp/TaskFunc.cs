using System;
using System.Collections.Generic;

// BigCodeBench/795
// Python: build a deque from a list, rotate it right by 3, print the sqrt of
// the sum of its numeric elements (if positive), and return the deque.
//
// Language-specific adaptations (this entry is deliberately the richest one
// in the Golden Dataset for illustrating Python-dynamic-typing pitfalls):
// - Python's `list` (which may freely mix int, str, float, bool, None) ->
//   C# `List<object>`. A narrower type (e.g. List<int>) would be idiomatic
//   C# but cannot represent the mixed-type test input the original suite
//   exercises (test_case_4 passes [1, 'A', 3.14, True, None]).
// - collections.deque(...).rotate(3) has no BCL equivalent; deque is
//   optimized for O(1) rotate/append at both ends, which List<T> cannot match
//   (a Python-faithful *value* translation is possible, an *asymptotic
//   performance* translation is not without a custom ring-buffer type). Since
//   this function only needs to return the final rotated order, rotation is
//   implemented directly via a modulo-indexed rebuild: rotated[i] = original[(i
//   - k) mod n], which reproduces deque.rotate(k)'s exact resulting order for
//   any k (including k > n, via the modulo) at the cost of O(n) instead of
//   deque's O(k).
// - isinstance(item, (int, float)) has a well-known Python quirk: `bool` is a
//   *subclass* of `int`, so `isinstance(True, int)` is True and Python's
//   isinstance check silently includes booleans as numeric. C# has no such
//   inheritance relationship between bool and int, so this port explicitly
//   special-cases `item is bool` (mapping True/False to 1/0) to preserve the
//   exact same numeric_sum contribution as the Python original -- omitting
//   this special case would be a silent semantic bug, not just a style choice.
// - Python's f-string number formatting and C#'s double.ToString() do not
//   guarantee byte-identical output (different shortest-round-trip
//   algorithms), so the printed line's exact digit string may differ between
//   runtimes even though the numeric value is equal. This is a side effect,
//   not part of any assertion in the original test suite, so it does not
//   affect observable-behavior equivalence for testing purposes; it is
//   recorded here for completeness (see verification.json).
public static class Solution
{
    public static List<object> TaskFunc(List<object> l)
    {
        if (l == null || l.Count == 0)
        {
            return new List<object>();
        }

        int n = l.Count;
        int k = ((3 % n) + n) % n;

        var rotated = new List<object>(n);
        for (int i = 0; i < n; i++)
        {
            rotated.Add(l[((i - k) % n + n) % n]);
        }

        double numericSum = 0.0;
        foreach (var item in rotated)
        {
            if (item is bool) numericSum += (bool)item ? 1 : 0;
            else if (item is int) numericSum += (int)item;
            else if (item is long) numericSum += (long)item;
            else if (item is double) numericSum += (double)item;
        }

        if (numericSum > 0)
        {
            // Invariant culture avoids a real bug we hit while verifying this port on a
            // pt-BR host: the default double.ToString() prints "3,872983346207417"
            // (comma decimal separator) instead of Python's always-invariant
            // "3.872983346207417". Locale-dependent formatting is a common source of
            // silent Python->C# behavioral drift and is called out in verification.json.
            Console.WriteLine("The square root of the sum of numeric elements: " +
                Math.Sqrt(numericSum).ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        return rotated;
    }
}
