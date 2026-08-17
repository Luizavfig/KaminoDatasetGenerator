using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// BigCodeBench/747
// Python: re.findall(r'\b\d+(?:\.\d+)?\b', s) -> count, sum(math.sqrt(float(n)))
//
// Language-specific adaptations:
// - Python's `re` module -> System.Text.RegularExpressions.Regex. Python's
//   \b word-boundary and \d work the same way for ASCII digits in .NET's
//   regex engine, so the pattern is translated verbatim.
// - Python's tuple return `(count, sqrt_sum)` -> a C# tuple `(int, double)`.
//   Since this Golden Dataset entry targets the legacy C# 5 compiler available
//   in this environment (no ValueTuple / .NET SDK), the pair is returned as a
//   `KeyValuePair<int, double>` instead of a C# 7+ tuple literal; semantically
//   both represent an ordered (count, sum) pair and are unpacked the same way
//   by callers. A modern toolchain (C# 7+) could use `(int Count, double
//   SqrtSum)` directly with no behavioral difference.
// - Python's `float` parsing (float(num)) -> double.Parse(num,
//   CultureInfo.InvariantCulture), forcing invariant (dot-decimal) parsing
//   regardless of the host machine's locale -- Python's float() is always
//   locale-independent, whereas C#'s default double.Parse is culture-sensitive
//   and could otherwise silently misparse "3.5" as an integer 35 fraction-free
//   on comma-decimal locales.
public static class Solution
{
    private static readonly Regex NumberPattern = new Regex(@"\b\d+(?:\.\d+)?\b");

    public static KeyValuePair<int, double> TaskFunc(string s)
    {
        var matches = NumberPattern.Matches(s ?? "");
        int count = matches.Count;

        double sqrtSum = 0.0;
        foreach (Match m in matches)
        {
            double value = double.Parse(m.Value, System.Globalization.CultureInfo.InvariantCulture);
            sqrtSum += Math.Sqrt(value);
        }

        return new KeyValuePair<int, double>(count, sqrtSum);
    }
}
