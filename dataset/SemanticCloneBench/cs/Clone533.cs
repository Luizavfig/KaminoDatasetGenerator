/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2332053
*  Stack Overflow answer #:2332143
*  And Stack Overflow answer#:2332615
*/
public static void Main (string [] args) {
    int ctr = 0;
    string fileName = args [0];
    string result = "Checking data ";
    do
        {
            ctr += 1;
            result += ctr.ToString () + "...";
        } while (! File.Exists (fileName) && ctr <= 3);
    Console.WriteLine (result);
}

public static void Main (string [] args) {
    int retries = 0;
    bool success = false;
    int maxRetries = 3;
    string fileName = args [0];
    Console.Write ("Checking data ");
    while (! success && retries ++ < maxRetries) {
        Console.Write ("{0}...", retries);
        success = File.Exists (fileName);
    }
    Console.WriteLine (" {0}Found!", (success ? "" : "Not "));
}

