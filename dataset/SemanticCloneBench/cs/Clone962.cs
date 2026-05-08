/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12983731
*  Stack Overflow answer #:19125294
*  And Stack Overflow answer#:12992171
*/
public static long BinomCoefficient (long n, long k) {
    if (k > n) {
        return 0;
    }
    if (n == k) {
        return 1;
    }
    if (k > n - k) {
        k = n - k;
    }
    long c = 1;
    for (long i = 1; i <= k; i ++) {
        c *= n --;
        c /= i;
    }
    return c;
}

public static long GetBinCoeff (long N, long K) {
    long r = 1;
    long d;
    if (K > N)
        return 0;
    for (d = 1; d <= K; d ++) {
        r *= N --;
        r /= d;
    }
    return r;
}

