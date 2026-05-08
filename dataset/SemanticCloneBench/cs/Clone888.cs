/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:47752
*  Stack Overflow answer #:4954239
*  And Stack Overflow answer#:23652999
*/
static void Main (string [] args) {
    List < string > alpha = new List < string > ();
    for (char a = 'a'; a <= 'd'; a ++) {
        alpha.Add (a.ToString ());
        alpha.Add (a.ToString ());
    }
    Console.WriteLine ("Data :");
    alpha.ForEach (delegate (string t) {
        Console.WriteLine (t);
    });
    alpha.ForEach (delegate (string v) {
        if (alpha.FindAll (delegate (string t) {
            return t == v;
        }).Count > 1)
            alpha.Remove (v);
    });
    Console.WriteLine ("Unique Result :");
    alpha.ForEach (delegate (string t) {
        Console.WriteLine (t);
    });
    Console.ReadKey ();
}

public static void RemoveDuplicates < T > (IList < T > list) {
    if (list == null) {
        return;
    }
    int i = 1;
    while (i < list.Count) {
        int j = 0;
        bool remove = false;
        while (j < i && ! remove) {
            if (list [i].Equals (list [j])) {
                remove = true;
            }
            j ++;
        }
        if (remove) {
            list.RemoveAt (i);
        } else {
            i ++;
        }
    }
}

