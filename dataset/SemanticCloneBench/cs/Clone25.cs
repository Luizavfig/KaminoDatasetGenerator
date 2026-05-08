/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15743192
*  Stack Overflow answer #:44203452
*  And Stack Overflow answer#:15743249
*/
public static bool isPrime (int number) {
    if (number == 1)
        return false;
    if (number == 2 || number == 3 || number == 5)
        return true;
    if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0)
        return false;
    var boundary = (int) Math.Floor (Math.Sqrt (number));
    int i = 6;
    while (i <= boundary) {
        if (number % (i + 1) == 0 || number % (i + 5) == 0)
            return false;
        i += 6;
    }
    return true;
}

boolean isPrime (int number) {
    if (number == 1)
        return false;
    if (number == 2)
        return true;
    var limit = Math.Ceiling (Math.Sqrt (number));
    for (int i = 2; i <= limit; ++ i) {
        if (number % i == 0)
            return false;
    }
    return true;
}

