/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4104536
*  Stack Overflow answer #:33526652
*  And Stack Overflow answer#:4104601
*/
void Main () {
    var length = 10;
    var size = 4;
    test (10, 4);
    test (10, 6);
    test (10, 2);
    test (10, 1);
    var sideeffects = Enumerable.Range (1, 10).Select (i = > {
        string.Format ("Side effect on {0}", i).Dump ();
        return i;
    });
    "--------------".Dump ("Before Chunking");
    var result = Chunk (sideeffects, 4);
    "--------------".Dump ("After Chunking");
    result.Dump ("SideEffects");
    var list = new List < int > ();
    foreach (var segment in result) {
        list.AddRange (segment);
    }
    list.Dump ("After crawling");
    var segment3 = result.Last ().ToList ();
    segment3.Dump ("Last Segment");
}

public static List < List < T > > SplitIntoChunks < T > (List < T > list, int chunkSize) {
    if (chunkSize <= 0) {
        throw new ArgumentException ("chunkSize must be greater than 0.");
    }
    List < List < T > > retVal = new List < List < T > > ();
    int index = 0;
    while (index < list.Count) {
        int count = list.Count - index > chunkSize ? chunkSize : list.Count - index;
        retVal.Add (list.GetRange (index, count));
        index += chunkSize;
    }
    return retVal;
}

