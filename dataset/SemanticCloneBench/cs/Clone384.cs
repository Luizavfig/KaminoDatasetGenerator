/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10601313
*  Stack Overflow answer #:10602619
*  And Stack Overflow answer#:10601423
*/
int Compare (int x, int y) {
    int pow10 = (int) Math.Pow (10, Math.Floor (Math.Log (Math.Max (x, y), 10)));
    int matches = 0;
    while (pow10 > 0 && (x / pow10) == (y / pow10)) {
        matches ++;
        pow10 /= 10;
    }
    return matches;
}

public static int Compare (int i1, int i2) {
    int result = 0;
    while (i1 != 0 && i2 != 0) {
        var d1 = i1 % 10;
        var d2 = i2 % 10;
        i1 /= 10;
        i2 /= 10;
        if (d1 == d2) {
            ++ result;
        } else {
            result = 0;
        }
    }
    if (i1 != 0 || i2 != 0) {
        throw new ArgumentException ("Integers must be of same length.");
    }
    return result;
}

