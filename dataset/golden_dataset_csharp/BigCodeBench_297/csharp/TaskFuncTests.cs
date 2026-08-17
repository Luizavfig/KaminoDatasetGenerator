using System;
using System.Collections.Generic;

// Translated from python/test_task_func.py (BigCodeBench/297 original unittest suite).
public static class TaskFuncTests
{
    public static void TestCase1()
    {
        // Test with a tuple of positive integers and subset_size of 2
        var elements = new List<long> { 1, 2, 3, 4, 5 };
        var expected = new Dictionary<long, int> { { 3, 1 }, { 4, 1 }, { 5, 2 }, { 6, 2 }, { 7, 2 }, { 8, 1 }, { 9, 1 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(elements, 2), "test_case_1");
    }

    public static void TestCase2()
    {
        // Test with a tuple containing negative, positive and zero integers and subset_size of 3
        var elements = new List<long> { -3, -2, 0, 2, 3, 5 };
        var expected = new Dictionary<long, int>
        {
            { 0, 3 }, { 5, 3 }, { 2, 2 }, { 3, 2 }, { -5, 1 }, { -3, 1 }, { -2, 1 }, { -1, 1 },
            { 4, 1 }, { 1, 1 }, { 6, 1 }, { 7, 1 }, { 8, 1 }, { 10, 1 },
        };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(elements, 3), "test_case_2");
    }

    public static void TestCase3()
    {
        // Test with a tuple of positive integers and subset_size of 1
        var elements = new List<long> { 1, 2, 3, 4, 5 };
        var expected = new Dictionary<long, int> { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(elements, 1), "test_case_3");
    }

    public static void TestCase4()
    {
        // Test with an empty tuple
        var elements = new List<long>();
        var expected = new Dictionary<long, int>();
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(elements, 2), "test_case_4");
    }

    public static void TestCase5()
    {
        // Test with a subset_size greater than tuple length
        var elements = new List<long> { 1, 2, 3 };
        var expected = new Dictionary<long, int>();
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(elements, 5), "test_case_5");
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
