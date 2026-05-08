/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35270204
*  Stack Overflow answer #:35270606
*  And Stack Overflow answer#:35270423
*/
static void Main (string [] args) {
    demo obj = new demo ();
    int n = 5;
    string uname, pass;
    Console.ForegroundColor = ConsoleColor.Green;
    label1 : Console.WriteLine ("\n");
    Console.WriteLine ("Enter username");
    uname = Console.ReadLine ();
    Console.WriteLine ("Enter Password");
    pass = Console.ReadLine ();
    obj.setName (uname);
    obj.setPass (pass);
    if (obj.getName () == "niit" && obj.getPass () == "1234") {
        Console.WriteLine ("welcome");
    } else {
        if (n < 1) {
            Console.Clear ();
            Console.WriteLine ("ScreenLock");
        } else {
            Console.WriteLine ("\n Invalid");
            Console.WriteLine ("\n To try again enter y");
            string yes = Console.ReadLine ();
            Console.WriteLine ("\n");
            if (yes == "y") {
                while (n >= 1) {
                    Console.Write (n + " Tries left");
                    n = -- n;
                    goto label1;
                }
            }
        }
    }
    Console.ReadKey ();
}

static void Main (string [] args) {
    demo obj = new demo ();
    string uname, pass;
    Console.ForegroundColor = ConsoleColor.Green;
    label1 : Console.Clear ();
    Console.WriteLine ("Enter username");
    uname = Console.ReadLine ();
    Console.WriteLine ("Enter Password");
    bool SuccessfulPassword = false;
    int AttemptsLeft = 5;
    while (! SuccessfulPassword && AttemptsLeft > 0) {
        pass = Console.ReadLine ();
        obj.setName (uname);
        obj.setPass (pass);
        if (obj.getName () == "niit") {
            if (obj.getPass () == "1234") {
                Console.WriteLine ("welcome");
                SuccessfulPassword = true;
            }
        } else {
            AttemptsLeft --;
            Console.Clear ();
            Console.WriteLine ("Invalid");
            Console.WriteLine ("\n \n \n To try again enter y");
            int n = 5;
            string yes = Console.ReadLine ();
            if (yes == "y") {
                Console.Write (AttemptsLeft + " Tries left");
            }
        }
        Console.ReadKey ();
    }
}

