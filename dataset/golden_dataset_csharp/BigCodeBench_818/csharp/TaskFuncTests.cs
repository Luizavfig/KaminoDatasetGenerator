using System.Collections.Generic;

// Translated from python/test_task_func.py (BigCodeBench/818 original unittest suite).
public static class TaskFuncTests
{
    public static void TestStandardInput()
    {
        var expected = new List<string> { "hello", "world", "this", "is", "a", "test" };
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc("Hello, world! This is a test."), "test_standard_input");
    }

    public static void TestEmptyString()
    {
        var expected = new List<string> { "" };
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc(""), "test_empty_string");
    }

    public static void TestStringWithNoPunctuation()
    {
        var expected = new List<string> { "python", "is", "great" };
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc("Python is great"), "test_string_with_no_punctuation");
    }

    public static void TestStringWithNumbers()
    {
        var expected = new List<string> { "1234", "test", "with", "numbers" };
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc("1234! Test with numbers."), "test_string_with_numbers");
    }

    public static void TestStringWithSpecialCharacters()
    {
        var expected = new List<string> { "special", "chars", "" };
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc("Special chars @#$%^&*()"), "test_string_with_special_characters");
    }

    public static void TestStringWithWhitespaces()
    {
        var expected = new List<string> { "", "extra", "whitespaces", "" };
        GoldenTestHarness.SequenceEqual(expected, Solution.TaskFunc("   Extra   whitespaces   "), "test_string_with_whitespaces");
    }

    public static int Main()
    {
        TestStandardInput();
        TestEmptyString();
        TestStringWithNoPunctuation();
        TestStringWithNumbers();
        TestStringWithSpecialCharacters();
        TestStringWithWhitespaces();
        return GoldenTestHarness.Summary();
    }
}
