/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:37354142
*  Stack Overflow answer #:37354286
*  And Stack Overflow answer#:37354600
*/
public static void Main (string [] args) {
    var KP = Console.ReadKey ();
    if (KP.Key == ConsoleKey.F2) {
        return;
    }
    string UserName = KP.KeyChar + Console.ReadLine ();
    Console.WriteLine (UserName);
    Console.ReadLine ();
}

static void Main (string [] args) {
    ConsoleKeyInfo e;
    string userName = "";
    while (true) {
        e = Console.ReadKey ();
        if (e.Key == ConsoleKey.Enter) {
            break;
        } else if (e.Key == ConsoleKey.F2) {
        }
        userName += e.KeyChar;
    }
    Console.WriteLine ("username: " + userName);
    Console.Read ();
}

