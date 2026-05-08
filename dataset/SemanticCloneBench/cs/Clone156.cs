/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33056694
*  Stack Overflow answer #:33056898
*  And Stack Overflow answer#:33056991
*/
static void Main (string [] args) {
    int [] [] test1 = CreateRandomArrays (50, 200000);
    int [] [] test2 = CreateRandomArrays (50, 200000);
    Stopwatch s = new Stopwatch ();
    s.Start ();
    for (int i = 0; i < test1.Length; i ++)
        MyMethod1 (test1 [i], "z");
    s.Stop ();
    Console.WriteLine (s.ElapsedMilliseconds);
    s.Restart ();
    for (int i = 0; i < test2.Length; i ++)
        MyMethod2 (test2 [i], "z");
    s.Stop ();
    Console.WriteLine (s.ElapsedMilliseconds);
}

static void Main (string [] args) {
    IEnumerable < string > result;
    Console.Write ("Choose words order (A to Z (A), Z to A (Z), Reversed (R)): ");
    switch (Console.ReadLine ().ToUpper ()) {
        case "A" :
            result = words.OrderBy (w = > w);
            break;
        case "Z" :
            result = words.OrderByDescending (w = > w);
            break;
        case "R" :
            result = words.Reverse ();
            break;
        default :
            result = words.AsEnumerable ();
            break;
    }
    Console.WriteLine (string.Join (" ", result));
}

