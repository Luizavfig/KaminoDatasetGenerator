/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32710311
*  Stack Overflow answer #:32710405
*  And Stack Overflow answer#:32710848
*/
static void Main (string [] args) {
    List < string > selected = new List < string > {"A", "B", "B.1", "B.11", "C"};
    List < string > required = new List < string > {"B", "C"};
    var matching = from s in selected
        where required.Any (r = > s.StartsWith (r))
        select s;
    foreach (string m in matching) {
        Console.WriteLine (m);
    }
}

static void Main (string [] args) {
    List < string > selected = new List < string > {"A", "B", "B.1", "B.11", "C"};
    List < string > required = new List < string > {"B", "C"};
    required.Sort ();
    var matching = selected.Where (s = > {
        int index = required.BinarySearch (s);
        if (index >= 0)
            return true;
        index = ~ index;
        if (index == 0)
            return false;
        return s.StartsWith (required [index - 1]);
    });
    foreach (string m in matching) {
        Console.WriteLine (m);
    }
}

