/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1076001
*  Stack Overflow answer #:1076045
*  And Stack Overflow answer#:1076027
*/
bool isFibonacci (int n) {
    foreach (int f in Fibonacci ()) {
        if (f > n)
            return false;
        if (f == n)
            return true;
    }
}

static bool isFibonacci (int n) {
    int [] fib = new int [100];
    fib [0] = 1;
    fib [1] = 1;
    for (int i = 2; i <= fib.Length; i ++) {
        fib [i] = fib [i - 1] + fib [i - 2];
        if (n == fib [i]) {
            return true;
        } else if (n < fib [i]) {
            return false;
        }
    }
    return false;
}

