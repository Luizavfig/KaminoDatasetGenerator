/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:383587
*  Stack Overflow answer #:21747144
*  And Stack Overflow answer#:384695
*/
public static int FastPower (int x, int pow) {
    switch (pow) {
        case 0 :
            return 1;
        case 1 :
            return x;
        case 2 :
            return x * x;
        case 3 :
            return x * x * x;
        case 4 :
            return x * x * x * x;
        case 5 :
            return x * x * x * x * x;
        case 6 :
            return x * x * x * x * x * x;
        case 7 :
            return x * x * x * x * x * x * x;
        case 8 :
            return x * x * x * x * x * x * x * x;
        case 9 :
            return x * x * x * x * x * x * x * x * x;
        case 10 :
            return x * x * x * x * x * x * x * x * x * x;
        case 11 :
            return x * x * x * x * x * x * x * x * x * x * x;
        default :
            int ret = 1;
            while (pow != 0) {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow > >= 1;
            }
            return ret;
    }
}

public static long IntPower (int x, short power) {
    if (power == 0)
        return 1;
    if (power == 1)
        return x;
    int n = power.GetType () == typeof (short) ? 15 : power.GetType () == typeof (int) ? 31 : power.GetType () == typeof (long) ? 63 : 0;
    long tmp = x;
    while (-- n > 0)
        tmp = tmp * tmp * (((power <<= 1) < 0) ? x : 1);
    return tmp;
}

