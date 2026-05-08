/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26333719
*  Stack Overflow answer #:26335705
*  And Stack Overflow answer#:26334115
*/
static void Main (string [] args) {
    List < string > list = new List < string > ();
    list.Add ("Bill cat had");
    list.Add ("Bill had a cat");
    list.Add ("Bill had cat");
    list.Add ("Cat had Bill");
    Regex rex = new Regex (@"((Bill)).*((had)).*((cat))");
    foreach (string str in list) {
        if (rex.IsMatch (str)) {
            Console.WriteLine (str);
        }
    }
    Console.ReadLine ();
}

static void Main (string [] args) {
    sentences.Add ("Bill cat had");
    sentences.Add ("Bill had a cat");
    sentences.Add ("Cat had Bill");
    sentences.Add ("Bill had cats");
    pattern.Add ("Bill");
    pattern.Add ("had");
    pattern.Add ("cat");
    results = searchString (sentences, pattern);
    foreach (string res in results) {
        Console.WriteLine (res);
    }
    Console.Read ();
}

