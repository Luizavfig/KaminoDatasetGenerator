using System.Collections.Generic;

// Translated from python/test_task_func.py (BigCodeBench/795 original unittest suite).
public static class TaskFuncTests
{
    private static List<object> L(params object[] items) { return new List<object>(items); }

    public static void TestCase1()
    {
        // Test Case 1: list of strings
        var input = L("A", "B", "C", "D", "E");
        var expected = L("C", "D", "E", "A", "B");
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc(input), "test_case_1");
    }

    public static void TestCase2()
    {
        // Test Case 2: list of integers
        var input = L(1, 2, 3, 4, 5);
        var expected = L(3, 4, 5, 1, 2);
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc(input), "test_case_2");
    }

    public static void TestCase3()
    {
        // Test Case 3: empty list
        var input = L();
        var expected = L();
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc(input), "test_case_3");
    }

    public static void TestCase4()
    {
        // Test Case 4: list of mixed types (mirrors Python's dynamic typing directly)
        var input = L(1, "A", 3.14, true, null);
        var expected = L(3.14, true, null, 1, "A");
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc(input), "test_case_4");
    }

    public static void TestCase5()
    {
        // Test Case 5: long list of integers (0..99)
        var input = new List<object>();
        for (int i = 0; i < 100; i++) input.Add(i);

        var expected = new List<object>();
        for (int i = 97; i < 100; i++) expected.Add(i);
        for (int i = 0; i < 97; i++) expected.Add(i);

        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc(input), "test_case_5");
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
