/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:25488854
*  Stack Overflow answer #:25489144
*  And Stack Overflow answer#:25488963
*/
public int Compare (Level x, Level y) {
    if (object.ReferenceEquals (x, y))
        return 0;
    if (x == null)
        return 1;
    else if (y == null)
        return - 1;
    return x.LevelID.CompareTo (y.LevelID);
}

public int CompareTo (Level a, Level b) {
    if (a.LevelID < b.LevelID) {
        return - 1;
    } else if (a.LevelID == b.LevelID) {
        return 0;
    } else
        return 1;
}

