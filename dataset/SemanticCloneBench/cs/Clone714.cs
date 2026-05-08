/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:37076118
*  Stack Overflow answer #:37076207
*  And Stack Overflow answer#:37076207
*/
private int CountDivisorsOfNumber (int number) {
    int count = 0;
    int end = (int) Math.Sqrt (number);
    for (int i = 1; i < end; i ++) {
        if (number % i == 0)
            count += 2;
    }
    if (end * end == number)
        count ++;
    return count;
}

private int Find () {
    int number = 0;
    for (int i = 1;; i ++) {
        number += i;
        if (CountDivisorsOfNumber (number) > 250) {
            lblnum.Text = number.ToString ();
            return number;
        }
    }
}

