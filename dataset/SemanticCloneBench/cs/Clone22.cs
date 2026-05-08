/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:51444102
*  Stack Overflow answer #:51444375
*  And Stack Overflow answer#:51444418
*/
static void Main (string [] args) {
    List < double > enteredNubers = new List < double > ();
    Console.WriteLine ("Enter number(s) or 0 to end: ");
    while (true) {
        string userinput = Console.ReadLine ().Trim ();
        if (userinput == "0")
            break;
        double num;
        if (double.TryParse (userinput, out num)) {
            enteredNubers.Add (num);
        } else
            Console.WriteLine ("Wrong input. Please enter number or 0 to end");
    }
    Average (enteredNubers);
    Console.ReadKey ();
}

static void Main (string [] args) {
    Console.WriteLine ("Type Exit to stop the program... \nEnter number");
    List < double > doubleList = new List < double > ();
    string input = Console.ReadLine ();
    double d;
    while (! input.Equals ("Exit")) {
        if (String.IsNullOrEmpty (input) || ! Double.TryParse (input, out d)) {
            break;
        }
        doubleList.Add (d);
        input = Console.ReadLine ();
    }
    average (doubleList);
    Console.ReadKey ();
}

