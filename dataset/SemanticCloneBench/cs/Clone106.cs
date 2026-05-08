/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30816178
*  Stack Overflow answer #:30816234
*  And Stack Overflow answer#:30816226
*/
static int GetPlayers () {
    int ? players;
    Console.Write ("How many people are playing?");
    while (players == null) {
        try {
            players = Convert.ToInt16 (Console.ReadLine ());
        }
        catch (Exception e) {
            Console.Write (e.Message + "\n" + "----------");
        }
    }
    return players.Value;
}

static int GetPlayers () {
    int players = 0;
    Console.Write ("How many people are playing?");
    try {
        players = Convert.ToInt16 (Console.ReadLine ());
    }
    catch (Exception e) {
        Console.Write (e.Message + "\n" + "----------");
        return GetPlayers ();
    }
    return players;
}

