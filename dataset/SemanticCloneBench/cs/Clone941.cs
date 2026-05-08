/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11440973
*  Stack Overflow answer #:11441596
*  And Stack Overflow answer#:11441265
*/
private static IEnumerable < int > Merge (IEnumerable < int > enum1, IEnumerable < int > enum2) {
    IEnumerator < int > e1 = enum1.GetEnumerator ();
    IEnumerator < int > e2 = enum2.GetEnumerator ();
    bool remaining1 = e1.MoveNext ();
    bool remaining2 = e2.MoveNext ();
    while (remaining1 || remaining2) {
        if (remaining1 && remaining2) {
            if (e1.Current > e2.Current) {
                yield return e2.Current;
                remaining2 = e2.MoveNext ();
            } else {
                yield return e1.Current;
                remaining1 = e1.MoveNext ();
            }
        } else if (remaining2) {
            yield return e2.Current;
            remaining2 = e2.MoveNext ();
        } else {
            yield return e1.Current;
            remaining1 = e1.MoveNext ();
        }
    }
}

private static int [] Merge (int [] array1, int [] array2) {
    var mergedArray = new int [array1.Length + array2.Length];
    int i = 0, j = 0, k = 0;
    while (k < mergedArray.Length) {
        if (j == array2.Length || ((i < array1.Length) && (array [i] < array2 [j]))) {
            mergedArray [k] = array1 [i];
            i ++;
        } else {
            mergedArray [k] = array2 [j];
            j ++;
        }
        k ++;
    }
    return mergedArray;
}

