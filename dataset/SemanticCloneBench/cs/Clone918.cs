/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:53618804
*  Stack Overflow answer #:53618867
*  And Stack Overflow answer#:53618927
*/
public static void Main () {
    var sw = new Stopwatch ();
    sw.Start ();
    bool f;
    for (int i = 1; i < 1001; i ++) {
        f = _arr.Contains ("Item " + i, StringComparer.OrdinalIgnoreCase);
    }
    Console.WriteLine (sw.Elapsed);
    sw.Restart ();
    for (int i = 1; i < 1001; i ++) {
        f = _hs.Any (w = > string.Equals (w, "Item " + i, StringComparison.InvariantCultureIgnoreCase));
    }
    Console.WriteLine (sw.Elapsed);
}

static void Main (string [] args) {
    var filePath = @"c:\temp\temp.txt";
    var words = File.ReadAllLines (filePath);
    Console.Write ("Enter a search term: ");
    var searchTerm = Console.ReadLine ();
    if (words.Contains (searchTerm, StringComparer.OrdinalIgnoreCase)) {
        Console.WriteLine ("We have your word!");
    } else {
        Console.WriteLine ("We do not have your word");
    }
    Console.ReadKey ();
}

