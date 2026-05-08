/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20271325
*  Stack Overflow answer #:20271600
*  And Stack Overflow answer#:20271800
*/
static Result Play (Input userInput) {
    Input computer = Input.Scissors;
    switch (userInput) {
        case Input.Paper :
            switch (computer) {
                case Input.Paper :
                    return Result.Draw;
                case Input.Rock :
                    return Result.Win;
                case Input.Scissors :
                    return Result.Lose;
                default :
                    throw new Exception ("Logic fail.");
            }
        case Input.Rock :
            switch (computer) {
                case Input.Paper :
                    return Result.Lose;
                case Input.Rock :
                    return Result.Draw;
                case Input.Scissors :
                    return Result.Win;
                default :
                    throw new Exception ("Logic fail.");
            }
        case Input.Scissors :
            switch (computer) {
                case Input.Paper :
                    return Result.Win;
                case Input.Rock :
                    return Result.Lose;
                case Input.Scissors :
                    return Result.Draw;
                default :
                    throw new Exception ("Logic fail.");
            }
        default :
            throw new Exception ("Logic fail.");
    }
}

static void Main (string [] args) {
    Random rand = new Random ();
    while (true) {
        Console.Write ("Your play ({0}) (q to exit) : ", string.Join (",", Enum.GetNames (typeof (RPSPlay))));
        var line = Console.ReadLine ();
        if (line.Equals ("q", StringComparison.OrdinalIgnoreCase))
            return;
        RPSPlay play;
        if (! Enum.TryParse (line, true, out play)) {
            Console.WriteLine ("Invalid Input");
            continue;
        }
        RPSPlay computerPlay = (RPSPlay) rand.Next (SIZE);
        Console.WriteLine ("Computer Played {0}", computerPlay);
        Console.WriteLine (Beats (play, computerPlay));
        Console.WriteLine ();
    }
}

