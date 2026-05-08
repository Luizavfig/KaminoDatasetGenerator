/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:45106385
*  Stack Overflow answer #:45106947
*  And Stack Overflow answer#:45106818
*/
public void PrintRandom () {
    Random r = new Random ();
    int strLength = r.Next (1, 10);
    var sb = new StringBuilder ();
    for (int i = 0; i < strLength; i ++) {
        int whichType = r.Next (0, 3);
        switch (whichType) {
            case 0 :
                sb.Append ((char) (97 + r.Next (0, 26)));
                break;
            case 1 :
                sb.Append ((char) (65 + r.Next (0, 26)));
                break;
            case 2 :
                sb.Append ((char) (48 + r.Next (0, 10)));
                break;
        }
    }
    Console.WriteLine (sb.ToString ());
    Console.ReadLine ();
}

private string RandomString () {
    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var numbers = "0123456789";
    var stringChars = new char [8];
    var random = new Random ();
    for (int i = 0; i < 2; i ++) {
        stringChars [i] = chars [random.Next (chars.Length)];
    }
    for (int i = 2; i < 6; i ++) {
        stringChars [i] = numbers [random.Next (numbers.Length)];
    }
    for (int i = 6; i < 8; i ++) {
        stringChars [i] = chars [random.Next (chars.Length)];
    }
    var finalString = new String (stringChars);
    return finalString;
}

