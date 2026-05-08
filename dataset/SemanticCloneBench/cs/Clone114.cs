/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9923158
*  Stack Overflow answer #:9923382
*  And Stack Overflow answer#:9924084
*/
static void Main () {
    string strn = "A great things are happen with great humans.";
    System.Console.WriteLine ("'{0}'", strn);
    bool case1 = strn.StartsWith ("A great");
    System.Console.WriteLine ("starts with 'A great'? {0}", case1);
    bool case2 = strn.StartsWith ("A great", System.StringComparison.OrdinalIgnoreCase);
    System.Console.WriteLine ("starts with 'A great'? {0} (ignoring case)", case2);
    bool case3 = strn.EndsWith (".");
    System.Console.WriteLine ("ends with '.'? {0}", case3);
    int start = strn.IndexOf ("great");
    int end = strn.LastIndexOf ("great");
    string strn2 = strn.Substring (start, end - start);
    System.Console.WriteLine ("between two 'great' words: '{0}'", strn2);
}

static void Main () {
    foreach (var pattern in new [] {"World", "dick", "Dick", "ick", "2012", "Attach"})
        Console.WriteLine ("{0} records match '{1}'", Database.Search (pattern).Count (), pattern);
    var regex = new Regex (@"N\w+s", RegexOptions.IgnoreCase);
    Console.WriteLine (@"{0} records match regular expression 'N\w+s'", Database.Search (regex).Count ());
    foreach (var contextMatch in Database.ByProperty (regex)) {
        Console.WriteLine ("1 match of regex in propery {0} with value '{1}'", contextMatch.Property.Name, contextMatch.Property.GetGetMethod ().Invoke (contextMatch.Item, new object [0]));
    }
}

