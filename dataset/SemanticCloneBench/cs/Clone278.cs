/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1168535
*  Stack Overflow answer #:11834068
*  And Stack Overflow answer#:1168659
*/
[Test] public static void Main (string [] args) {
    var method = typeof (Program).GetMethod ("Main");
    var type = typeof (Program);
    SomeValue = 1;
    Console.WriteLine (method.GetCustomAttributes (false).OfType < TestAttribute > ().First ().SomeValue);
    SomeValue = 2;
    Console.WriteLine (method.GetCustomAttributes (false).OfType < TestAttribute > ().First ().SomeValue);
    SomeValue = 3;
    Console.WriteLine (type.GetCustomAttributes (false).OfType < TestAttribute > ().First ().SomeValue);
    SomeValue = 4;
    Console.WriteLine (type.GetCustomAttributes (false).OfType < TestAttribute > ().First ().SomeValue);
    Console.ReadLine ();
}

static void Main (string [] args) {
    Console.WriteLine ("Program started");
    var ats = from a in typeof (Program).GetCustomAttributes (typeof (MyAttribute), true)
        let a2 = a as MyAttribute
        where a2 != null
        select a2;
    foreach (var a in ats)
        Console.WriteLine (a.Value);
    Console.WriteLine ("Program ended");
    Console.ReadLine ();
}

