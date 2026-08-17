using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Minimal, dependency-free assertion harness used by every entry's *Tests.cs file.
// No NuGet test framework (xUnit/NUnit/MSTest) is available in this environment
// (no .NET SDK, only the legacy csc.exe compiler bundled with .NET Framework 4.8),
// so this harness plays the same role unittest.TestCase plays on the Python side:
// each test is a method that reports PASS/FAIL, and a summary is printed at the end.
public static class GoldenTestHarness
{
    private static int _passed = 0;
    private static int _failed = 0;

    public static void AreEqual<T>(T expected, T actual, string testName)
    {
        bool ok = EqualityComparer<T>.Default.Equals(expected, actual);
        Report(ok, testName, Describe(expected), Describe(actual));
    }

    public static void SequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, string testName)
    {
        var e = expected == null ? new List<T>() : expected.ToList();
        var a = actual == null ? new List<T>() : actual.ToList();
        bool ok = e.SequenceEqual(a);
        Report(ok, testName, Describe(e), Describe(a));
    }

    public static void DictEqual<TKey, TValue>(IDictionary<TKey, TValue> expected, IDictionary<TKey, TValue> actual, string testName)
    {
        bool ok = expected.Count == actual.Count;
        if (ok)
        {
            foreach (var kv in expected)
            {
                TValue actualValue;
                if (!actual.TryGetValue(kv.Key, out actualValue) || !EqualityComparer<TValue>.Default.Equals(kv.Value, actualValue))
                {
                    ok = false;
                    break;
                }
            }
        }
        Report(ok, testName, Describe(expected), Describe(actual));
    }

    public static void IsTrue(bool condition, string testName)
    {
        Report(condition, testName, "true", condition.ToString());
    }

    public static void AlmostEqual(double expected, double actual, double delta, string testName)
    {
        bool ok = Math.Abs(expected - actual) <= delta;
        Report(ok, testName, expected.ToString("R"), actual.ToString("R"));
    }

    public static void Throws<TException>(Action action, string testName) where TException : Exception
    {
        bool ok = false;
        string actualDescription = "no exception";
        try
        {
            action();
        }
        catch (TException)
        {
            ok = true;
            actualDescription = "threw " + typeof(TException).Name;
        }
        catch (Exception ex)
        {
            actualDescription = "threw " + ex.GetType().Name + " (expected " + typeof(TException).Name + ")";
        }
        Report(ok, testName, "throws " + typeof(TException).Name, actualDescription);
    }

    private static string Describe(object value)
    {
        if (value == null) return "null";

        var dict = value as IDictionary;
        if (dict != null)
        {
            var parts = new List<string>();
            foreach (DictionaryEntry entry in dict)
                parts.Add(Describe(entry.Key) + ": " + Describe(entry.Value));
            return "{" + string.Join(", ", parts.ToArray()) + "}";
        }

        if (value is string) return "\"" + value + "\"";

        var enumerable = value as IEnumerable;
        if (enumerable != null)
        {
            var parts = new List<string>();
            foreach (var item in enumerable)
                parts.Add(Describe(item));
            return "[" + string.Join(", ", parts.ToArray()) + "]";
        }

        return value.ToString();
    }

    private static void Report(bool ok, string testName, string expected, string actual)
    {
        if (ok)
        {
            _passed++;
            Console.WriteLine("[PASS] " + testName);
        }
        else
        {
            _failed++;
            Console.WriteLine("[FAIL] " + testName + " -- expected: " + expected + " | actual: " + actual);
        }
    }

    public static int Summary()
    {
        int total = _passed + _failed;
        Console.WriteLine();
        Console.WriteLine(_passed + "/" + total + " tests passed (" + _failed + " failed).");
        return _failed == 0 ? 0 : 1;
    }
}
