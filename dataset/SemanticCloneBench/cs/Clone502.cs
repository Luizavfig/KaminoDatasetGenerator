/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:31258219
*  Stack Overflow answer #:31258299
*  And Stack Overflow answer#:31258984
*/
static void Main (string [] args) {
    List < string > color1 = new List < string > {"blue", "green", "mother", "black", "gray"};
    List < string > color2 = new List < string > {"mother", "green", "father", "black", "gray"};
    string rd = GetRandom (color1);
    if (color2.Contains (rd)) {
        Console.WriteLine (rd);
    } else {
    }
    Console.Read ();
}

public static void Main () {
    List < string > mainList = new List < string > {"blue", "green", "mother", "black", "gray"};
    List < string > checkList = new List < string > {"mother", "green", "father", "black", "gray"};
    Random r = new Random ();
    for (int i = 0; i < 5; i ++) {
        string mainListItem = mainList [r.Next (0, mainList.Count)];
        Console.WriteLine (checkList.Contains (mainListItem) ? "{0} found in checkList" : "{0} not found in checkList", mainListItem);
    }
}

