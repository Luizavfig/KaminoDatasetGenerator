/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:51444102
*  Stack Overflow answer #:51444753
*  And Stack Overflow answer#:51444375
*/
static void Main (string [] args) {
    Console.WriteLine ("Enter number(s): ");
    double [] values = new double [3];
    for (int i = 0; i < values.Length; i ++) {
        values [i] = Convert.ToDouble (Console.ReadLine ());
    }
    average (values);
    Console.ReadKey ();
}

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

