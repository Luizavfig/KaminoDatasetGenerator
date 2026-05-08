/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:39741606
*  Stack Overflow answer #:39741915
*  And Stack Overflow answer#:39741915
*/
private static void askUserToGuess (int count) {
    Console.WriteLine ("Enter a letter");
    char letter = char.Parse (Console.ReadLine ());
    for (int i = 0; i < HiddenWord.Length; i ++) {
        if ((HiddenWord [i] == letter) && (dashes [i] != letter)) {
            count ++;
            dashes [i] = letter;
            for (int j = 0; j < dashes.Length; j ++) {
                Console.Write (dashes [j] + " ");
            }
        }
    }
    if (count < dashes.Length)
        askUserToGuess (count);
}

static void Main (string [] args) {
    HiddenWord = "csharp";
    dashes = new char [HiddenWord.Length];
    for (int i = 0; i < dashes.Length; i ++) {
        dashes [i] = '_';
    }
    for (int i = 0; i < dashes.Length; i ++) {
        Console.Write (dashes [i] + "  ");
    }
    Console.WriteLine ();
    int count = 0;
    askUserToGuess (count);
    Console.ReadLine ();
}

