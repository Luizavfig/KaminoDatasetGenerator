/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:51444102
*  Stack Overflow answer #:51444753
*  And Stack Overflow answer#:51444418
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

