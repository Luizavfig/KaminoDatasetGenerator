using System;
using System.Collections.Generic;
using System.Linq;

// Translated from python/test_task_func.py (BigCodeBench/4 original unittest suite).
// Each Python test_case_N maps 1:1 to a TestCaseN method below, preserving the
// same inputs, expected outputs and (for test_case_6) the same exception intent.
public static class TaskFuncTests
{
    private static List<object> L(params object[] items) { return new List<object>(items); }

    public static void TestCase1()
    {
        // Checks the basic functionality with single-element lists.
        var input = new Dictionary<object, List<object>> { { "a", L(1) }, { "b", L(2) }, { "c", L(3) } };
        var expected = new Dictionary<object, int> { { 1, 1 }, { 2, 1 }, { 3, 1 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_1");
    }

    public static void TestCase2()
    {
        // Verifies the function with lists that have distinct integers.
        var input = new Dictionary<object, List<object>> { { "a", L(1, 2) }, { "b", L(3, 4) }, { "c", L(5, 6) } };
        var expected = new Dictionary<object, int> { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_2");
    }

    public static void TestCase3()
    {
        // Tests the function with lists containing duplicate integers to ensure counts are aggregated correctly.
        var input = new Dictionary<object, List<object>> { { "a", L(1, 1, 2) }, { "b", L(3, 4, 4) }, { "c", L(5, 5, 5) } };
        var expected = new Dictionary<object, int> { { 1, 2 }, { 2, 1 }, { 3, 1 }, { 4, 2 }, { 5, 3 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_3");
    }

    public static void TestCase4()
    {
        // Validates how the function handles an empty dictionary.
        var input = new Dictionary<object, List<object>>();
        var expected = new Dictionary<object, int>();
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_4");
    }

    public static void TestCase5()
    {
        // Ensures the function handles dictionaries where lists are empty correctly.
        var input = new Dictionary<object, List<object>> { { "a", L() }, { "b", L() }, { "c", L() } };
        var expected = new Dictionary<object, int>();
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_5");
    }

    public static void TestCase6()
    {
        // Test input with mixed integer and non-integer types: the original Python
        // raises TypeError because a nested list is unhashable. The C# port raises
        // (mirroring the same malformed-input contract; see TaskFunc.cs comments).
        var input = new Dictionary<object, List<object>>
        {
            { "a", L(1, 2, "three") },
            { "b", L(4, null) },
            { "c", L(5, L(6)) },
        };
        GoldenTestHarness.Throws<Exception>(delegate { Solution.TaskFunc(input); }, "test_case_6");
    }

    public static void TestCase7()
    {
        // Test with large lists to evaluate performance.
        var input = new Dictionary<object, List<object>>
        {
            { "a", Enumerable.Range(0, 1000).Cast<object>().ToList() },
            { "b", Enumerable.Range(0, 1000).Cast<object>().ToList() },
        };
        var expected = new Dictionary<object, int>();
        for (int i = 0; i < 1000; i++) expected[i] = 2;
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_7");
    }

    public static void TestCase8()
    {
        // Test with non-string keys to see how the function handles it (keys are
        // never read by task_func, so this only proves key type is irrelevant).
        var input = new Dictionary<object, List<object>> { { 1, L(1, 2, 3) }, { 2.5, L(4, 5, 6) } };
        var expected = new Dictionary<object, int> { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_8");
    }

    public static int Main()
    {
        TestCase1();
        TestCase2();
        TestCase3();
        TestCase4();
        TestCase5();
        TestCase6();
        TestCase7();
        TestCase8();
        return GoldenTestHarness.Summary();
    }
}
