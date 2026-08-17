using System.Collections.Generic;

// Translated from python/test_task_func.py (BigCodeBench/670 original unittest suite).
public static class TaskFuncTests
{
    public static void TestCase1()
    {
        var w = new Dictionary<char, int> { { 'a', 1 }, { 'b', 2 }, { 'c', 3 } };
        GoldenTestHarness.AreEqual("c", Solution.TaskFunc("c", w), "test_case_1");
    }

    public static void TestCase2()
    {
        var w = new Dictionary<char, int> { { 'a', 10 }, { 'b', -5 }, { 'c', 3 } };
        GoldenTestHarness.AreEqual("aa", Solution.TaskFunc("aabc", w), "test_case_2");
    }

    public static void TestCase3()
    {
        var w = new Dictionary<char, int> { { 'a', 10 }, { 'b', -2 }, { 'c', 3 } };
        GoldenTestHarness.AreEqual("aabc", Solution.TaskFunc("aabc", w), "test_case_3");
    }

    public static void TestCase4()
    {
        var w = new Dictionary<char, int> { { 'a', 2 }, { 'b', -5 }, { 'c', 3 } };
        GoldenTestHarness.AreEqual("aa", Solution.TaskFunc("aabc", w), "test_case_4");
    }

    public static void TestCase5()
    {
        var w = new Dictionary<char, int> { { 'a', 0 }, { 'b', -1 }, { 'c', 1 } };
        GoldenTestHarness.AreEqual("c", Solution.TaskFunc("aabc", w), "test_case_5");
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
