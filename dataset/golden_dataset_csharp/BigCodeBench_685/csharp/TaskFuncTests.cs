using System.Collections.Generic;

// Translated from python/test_task_func.py (BigCodeBench/685 original unittest suite).
public static class TaskFuncTests
{
    private static List<long> V(params long[] items) { return new List<long>(items); }

    public static void TestCase1()
    {
        var input = new List<List<long>> { V(1, 2, 3), V(4, 5, 6), V(7, 8, 9) };
        var expected = new Dictionary<long, int> { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 }, { 7, 1 }, { 8, 1 }, { 9, 1 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_1");
    }

    public static void TestCase2()
    {
        var input = new List<List<long>> { V(1, 2, 3), V(4, 5, 6), V(7, 8, 9), V(1, 2) };
        var expected = new Dictionary<long, int> { { 1, 2 }, { 2, 2 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 }, { 7, 1 }, { 8, 1 }, { 9, 1 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_2");
    }

    public static void TestCase3()
    {
        var input = new List<List<long>> { V(1, 2, 3), V(4, 5, 6), V(7, 8, 9), V(1, 2), V(1, 2, 3, 4, 5, 6, 7, 8, 9) };
        var expected = new Dictionary<long, int> { { 1, 3 }, { 2, 3 }, { 3, 2 }, { 4, 2 }, { 5, 2 }, { 6, 2 }, { 7, 2 }, { 8, 2 }, { 9, 2 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_3");
    }

    public static void TestCase4()
    {
        var input = new List<List<long>> { V(1, 2, 3), V(4, 5, 6), V(7, 8, 9), V(1, 2), V(1, 2, 3, 4, 5, 6, 7, 8, 9), V(1, 2, 3) };
        var expected = new Dictionary<long, int> { { 1, 4 }, { 2, 4 }, { 3, 3 }, { 4, 2 }, { 5, 2 }, { 6, 2 }, { 7, 2 }, { 8, 2 }, { 9, 2 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_4");
    }

    public static void TestCase5()
    {
        var input = new List<List<long>> { V(1, 2, 3), V(4, 5, 6), V(7, 8, 9), V(1, 2), V(1, 2, 3, 4, 5, 6, 7, 8, 9), V(1, 2, 3), V(1, 2, 3, 4, 5, 6, 7, 8, 9) };
        var expected = new Dictionary<long, int> { { 1, 5 }, { 2, 5 }, { 3, 4 }, { 4, 3 }, { 5, 3 }, { 6, 3 }, { 7, 3 }, { 8, 3 }, { 9, 3 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(input), "test_case_5");
    }

    public static int Main()
    {
        TestCase1();
        TestCase2();
        TestCase3();
        TestCase4();
        TestCase5();
        return GoldenTestHarness.Summary();
    }
}
