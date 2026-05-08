/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18109890
*  Stack Overflow answer #:18109919
*  And Stack Overflow answer#:18109944
*/
static void Main () {
    int total = 0;
    var vowels = new HashSet < char > {'a', 'e', 'i', 'o', 'u'};
    Console.WriteLine ("Enter a Sentence");
    string sentence = Console.ReadLine ().ToLower ();
    for (int i = 0; i < sentence.Length; i ++) {
        if (vowels.Contains (sentence [i])) {
            total ++;
        }
    }
    Console.WriteLine ("Your total number of vowels is: {0}", total);
    Console.ReadLine ();
}

static void Main () {
    int total = 0;
    Console.WriteLine ("Enter a Sentence");
    string sentence = Console.ReadLine ().ToLower ();
    char [] vowels = {'a', 'e', 'i', 'o', 'u'};
    total = sentence.Count (x = > vowels.Contains (x));
    Console.WriteLine ("Your total number of vowels is: {0}", total);
    Console.ReadLine ();
}

