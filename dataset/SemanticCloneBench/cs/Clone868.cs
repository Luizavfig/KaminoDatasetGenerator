/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:21340983
*  Stack Overflow answer #:21341163
*  And Stack Overflow answer#:21341224
*/
static void Main (string [] args) {
    List < Phone > phones = new List < Phone > ();
    bool shouldContinue = true;
    do
        {
            phones.Add (GetPhone ());
            Console.Write ("Would like to process another phone? [Y or N]: ", shouldContinue);
            shouldContinue = Console.ReadLine ().ToUpper () == "Y";
        } while (shouldContinue == true);
    if (shouldContinue == false) {
        DisplayPhones (phones);
    }
}

static Phone inputPhone () {
    Phone p = new Phone ();
    Console.Write ("Enter the phone manufacturer: ");
    p.Manufacturer = Console.ReadLine ();
    Console.Write ("Enter the phone model: ");
    p.Model = Console.ReadLine ();
    Console.Write ("Is it cordless? [Y or N]: ");
    p.IsCordless = Console.ReadLine ().ToUpper () == "Y";
    Console.Write ("Enter the phone price: ");
    p.Price = Convert.ToDecimal (Console.ReadLine ());
    return p;
}

