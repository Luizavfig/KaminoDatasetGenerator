/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:22044290
*  Stack Overflow answer #:22044568
*  And Stack Overflow answer#:22045059
*/
static void Main (string [] args) {
    var first = new List < double > {1, 2, 3};
    var second = new List < double > {3, 4, 5};
    var lists = new List < List < double > > {first, second};
    var flatten = lists.SelectMany (a = > a).ToArray ();
    foreach (var i in flatten) {
        Console.WriteLine (i);
    }
}

public static void Main () {
    List < List < double > > listOfLists = new List < List < double > > ();
    listOfLists.Add (new List < double > () {1, 2, 3});
    listOfLists.Add (new List < double > () {4, 6});
    int flatLength = 0;
    foreach (List < double > list in listOfLists)
        flatLength += list.Count;
    double [] flattened = new double [flatLength];
    int iFlat = 0;
    foreach (List < double > list in listOfLists)
        foreach (double d in list)
            flattened [iFlat ++] = d;
    foreach (double d in flattened)
        Console.Write ("{0} ", d);
    Console.ReadLine ();
}

