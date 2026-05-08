/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:22917175
*  Stack Overflow answer #:22917263
*  And Stack Overflow answer#:22917246
*/
public static long fibo_n (long N) {
    if (N <= 0)
        return 0;
    if (N == 1)
        return 1;
    if (N <= 4)
        return N - 1;
    return fibo_n (N - 1) + fibo_n (N - 2);
}

public static long fibo_n (long N) {
    switch (N) {
        case 0 :
            return 0;
        case 1 :
            return 1;
        default :
            return fibo_n (N - 1) + fibo_n (N - 2);
    }
}

