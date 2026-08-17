using System.Collections.Generic;

// Translated from python/test_task_func.py (BigCodeBench/1108 original unittest suite).
public static class TaskFuncTests
{
    private static Dictionary<string, object> D(params object[] kv)
    {
        var d = new Dictionary<string, object>();
        for (int i = 0; i < kv.Length; i += 2) d[(string)kv[i]] = kv[i + 1];
        return d;
    }

    public static void TestCase1()
    {
        var result = new List<Dictionary<string, object>>
        {
            D("hi", 7, "bye", 4, "http://google.com", 0),
            D("https://google.com", 0),
            D("http://www.cwi.nl", 1),
        };
        var expected = new Dictionary<object, int> { { 0, 2 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(result), "test_case_1");
    }

    public static void TestCase2()
    {
        var result = new List<Dictionary<string, object>>
        {
            D("http://google.com", 2),
            D("http://www.cwi.nl", 2),
            D("http://google.com", 3),
        };
        var expected = new Dictionary<object, int> { { 2, 2 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(result), "test_case_2");
    }

    public static void TestCase3()
    {
        var result = new List<Dictionary<string, object>> { D("http://google.com", 5) };
        var expected = new Dictionary<object, int> { { 5, 1 } };
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(result), "test_case_3");
    }

    public static void TestCase4()
    {
        var result = new List<Dictionary<string, object>>();
        var expected = new Dictionary<object, int>();
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(result), "test_case_4");
    }

    public static void TestCase5()
    {
        var result = new List<Dictionary<string, object>> { D("hi", 7, "bye", 4), D("hello", "world") };
        var expected = new Dictionary<object, int>();
        GoldenTestHarness.DictEqual(expected, Solution.TaskFunc(result), "test_case_5");
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
