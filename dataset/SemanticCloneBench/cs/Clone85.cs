/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8045972
*  Stack Overflow answer #:8045986
*  And Stack Overflow answer#:8046226
*/
static void Main (string [] args) {
    string choice = "";
    displayMenu ();
    do
        {
            choice = getChoice ();
        } while (choice != "10");
    {
        Console.ReadLine ();
    }}

static void Main (string [] args) {
    bool isInt;
    int intNumber;
    int choice;
    string stringInput = Console.ReadLine ();
    isInt = int.TryParse (stringInput, out intNumber);
    if (! isInt) {
        Console.WriteLine ("Input is not a number");
    } else {
        choice = intNumber;
    }
}

