using System;

// Translated from python/test_task_func.py (BigCodeBench/747 original unittest suite).
public static class TaskFuncTests
{
    public static void Test1()
    {
        var result = Solution.TaskFunc("1,2,3.5,abc,4,5.6");
        GoldenTestHarness.AreEqual(5, result.Key, "test_1 (count)");
        double expected = Math.Sqrt(1) + Math.Sqrt(2) + Math.Sqrt(3.5) + Math.Sqrt(4) + Math.Sqrt(5.6);
        GoldenTestHarness.AlmostEqual(expected, result.Value, 1e-7, "test_1 (sqrt_sum)");
    }

    public static void Test2()
    {
        var result = Solution.TaskFunc("a,b,c,10,20.5");
        GoldenTestHarness.AreEqual(2, result.Key, "test_2 (count)");
        double expected = Math.Sqrt(10) + Math.Sqrt(20.5);
        GoldenTestHarness.AlmostEqual(expected, result.Value, 1e-7, "test_2 (sqrt_sum)");
    }

    public static void Test3()
    {
        var result = Solution.TaskFunc("1.1,2.2,3.3");
        GoldenTestHarness.AreEqual(3, result.Key, "test_3 (count)");
        double expected = Math.Sqrt(1.1) + Math.Sqrt(2.2) + Math.Sqrt(3.3);
        GoldenTestHarness.AlmostEqual(expected, result.Value, 1e-7, "test_3 (sqrt_sum)");
    }

    public static void Test4()
    {
        var result = Solution.TaskFunc("");
        GoldenTestHarness.AreEqual(0, result.Key, "test_4 (count)");
        GoldenTestHarness.AreEqual(0.0, result.Value, "test_4 (sqrt_sum)");
    }

    public static void Test5()
    {
        var result = Solution.TaskFunc("apple,banana,3.14,15,grape,1001");
        GoldenTestHarness.AreEqual(3, result.Key, "test_5 (count)");
        double expected = Math.Sqrt(3.14) + Math.Sqrt(15) + Math.Sqrt(1001);
        GoldenTestHarness.AlmostEqual(expected, result.Value, 1e-7, "test_5 (sqrt_sum)");
    }

    public static int Main()
    {
        Test1();
        Test2();
        Test3();
        Test4();
        Test5();
        return GoldenTestHarness.Summary();
    }
}
