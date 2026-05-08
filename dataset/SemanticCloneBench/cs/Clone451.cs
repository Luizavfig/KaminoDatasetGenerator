/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1111194
*  Stack Overflow answer #:1111432
*  And Stack Overflow answer#:1112762
*/
public static int Delta (int a, int b) {
    int delta = 0;
    if (a == b) {
        return 0;
    } else if (a < b) {
        while (a < b) {
            a ++;
            delta ++;
        }
        return delta;
    } else {
        while (b < a) {
            b ++;
            delta ++;
        }
        return delta;
    }
}

public static int Delta (int a, int b) {
    int delta = 0;
    while (a < b) {
        ++ a;
        ++ delta;
    }
    while (b < a) {
        ++ b;
        ++ delta;
    }
    return delta;
}

