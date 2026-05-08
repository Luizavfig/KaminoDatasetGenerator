/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30633258
*  Stack Overflow answer #:30633371
*  And Stack Overflow answer#:30633565
*/
private static void Main (string [] args) {
    const string input = @"[Testing.User]|Info:([Testing.Info]|Name:([System.String]|Matt)|Age:([System.Int32]|21))|Description:([System.String]|This is some description)";
    const string pattern = @"(\[Testing\.User\])\|(Info:.*)\|(Description:.*)";
    var match = Regex.Match (input, pattern);
    if (match.Success) {
        for (int i = 1; i < match.Groups.Count; i ++) {
            Console.WriteLine ("[" + i + "] = " + match.Groups [i]);
        }
    }
    Console.ReadLine ();
}

public static void Main () {
    String text = "[Testing.User]|Info:([Testing.Info]|Name:([System.String]|Matt)|Age:([System.Int32]|21))|Description:([System.String]|This is some description)";
    String pattern = "(\\[\\w+\\.\\w+\\])\\|(\\w+:.+)\\|(\\w+:.+)";
    Match match = Regex.Match (text, pattern);
    if (match.Success) {
        Console.WriteLine (match.Groups [1]);
        Console.WriteLine (match.Groups [2]);
        Console.WriteLine (match.Groups [3]);
    }
}

