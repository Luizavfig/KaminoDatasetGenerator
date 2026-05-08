/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35280531
*  Stack Overflow answer #:35280827
*  And Stack Overflow answer#:35280957
*/
static void Main (string [] args) {
    string [] ahri = {"Academy", "Challenger", "Dynasty", "Foxfire", "Midnight", "Popstar"};
    string [] leeSin = {"Traditional", "Acolyte", "Dragon Fist", "Musy Thai", "Pool Party", "SKT T1", "Knockout"};
    Console.WriteLine ("Conor's Random League of Legends Skin Selector v0.1");
    Console.WriteLine (" ");
    Console.WriteLine (" ");
    Random rnd = new Random ();
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine ("What champion would you like to select a skin for?..    ");
    string champion = Console.ReadLine ();
    Console.Write ("Press the 'enter' key for a random champion..     ");
    string question = Console.ReadLine ();
    if (champion == "ahri") {
        int randomNumber = rnd.Next (ahri.Length - 1);
        Console.WriteLine (ahri [randomNumber]);
    } else {
        int randomNumber = rnd.Next (leeSin.Length - 1);
        Console.WriteLine (leeSin [randomNumber]);
    }
}

static void Main (string [] args) {
    string [] ahri = {"Academy", "Challenger", "Dynasty", "Foxfire", "Midnight", "Popstar"};
    string [] leeSin = {"Traditional", "Acolyte", "Dragon Fist", "Musy Thai", "Pool Party", "SKT T1", "Knockout"};
    Console.WriteLine ("Conor's Random League of Legends Skin Selector v0.1");
    Console.WriteLine (" ");
    Console.WriteLine (" ");
    Random rnd = new Random ();
    Console.ForegroundColor = ConsoleColor.Gray;
    string [] champions;
    Console.WriteLine ("What champion would you like to select a skin for?..    ");
    string championName = Console.ReadLine ();
    if (championName.Equals ("ahri", StringComparison.CurrentCultureIgnoreCase)) {
        champions = ahri;
    } else if (championName.Equals ("leeSin", StringComparison.CurrentCultureIgnoreCase)) {
        champions = leeSin;
    } else {
        Console.WriteLine ("No champion selected, quitting...");
        return;
    }
    while (true) {
        Console.WriteLine ("Press the 'enter' key for a random champion..     ");
        if (Console.ReadKey (true).Key == ConsoleKey.Enter) {
            int randomNumber = rnd.Next (champions.Length);
            Console.WriteLine (champions [randomNumber]);
        }
    }
}

