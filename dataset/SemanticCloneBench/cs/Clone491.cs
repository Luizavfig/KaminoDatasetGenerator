/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:985657
*  Stack Overflow answer #:985685
*  And Stack Overflow answer#:30096944
*/
public int Compare (Object stringA, Object stringB) {
    string [] valueA = stringA.ToString ().Split ('/');
    string [] valueB = stringB.ToString ().Split ('/');
    if (valueA.Length != 2 || valueB.Length != 2) {
        stringA.ToString ().CompareTo (stringB.ToString ());
    }
    if (valueA [0] == valueB [0]) {
        return int.Parse (valueA [1]).CompareTo (int.Parse (valueB [1]));
    } else {
        return int.Parse (valueA [0]).CompareTo (int.Parse (valueB [0]));
    }
}

public int Compare (string stringA, string stringB) {
    string small = stringA;
    string big = stringB;
    if (stringA.Length > stringB.Length) {
        small = stringB;
        big = stringA;
    } else if (stringA.Length < stringB.Length) {
        small = stringA;
        big = stringB;
    }
    for (int j = 0; j < small.Length; j ++) {
        if (Convert.ToInt32 (small [j]) > Convert.ToInt32 (big [j]))
            return - 1;
        if (Convert.ToInt32 (small [j]) < Convert.ToInt32 (big [j]))
            return 1;
    }
    if (big.Length > small.Length)
        return 1;
    return 0;
}

