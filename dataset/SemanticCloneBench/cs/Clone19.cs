/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:600293
*  Stack Overflow answer #:44934369
*  And Stack Overflow answer#:600307
*/
public static bool IsPowerOfTwo (ulong n) {
    if (n % 2 != 0)
        return false;
    double exp = Math.Log (n, 2);
    if (exp != Math.Floor (exp))
        return false;
    return Math.Pow (2, exp) == n;
}

private static bool IsPowerOfTwo (ulong number) {
    while (number != 0) {
        if (number == 1)
            return true;
        if ((number & 1) == 1)
            return false;
        number = number > > 1;
    }
    return false;
}

