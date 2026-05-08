/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17575375
*  Stack Overflow answer #:17575453
*  And Stack Overflow answer#:17576246
*/
public string IntToString (int a) {
    var chars = new [] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
    var str = string.Empty;
    if (a == 0) {
        str = chars [0];
    } else if (a == int.MinValue) {
        str = "-2147483648";
    } else {
        bool isNegative = (a < 0);
        if (isNegative) {
            a = - a;
        }
        while (a > 0) {
            str = chars [a % 10] + str;
            a /= 10;
        }
        if (isNegative) {
            str = "-" + str;
        }
    }
    return str;
}

string IntToString (int a) {
    if (a == int.MinValue)
        return "-2147483648";
    if (a < 0)
        return "-" + IntToString (- a);
    if (a == 0)
        return "0";
    var s = "";
    do
        {
            int r;
            a = Math.DivRem (a, 10, out r);
            s = new string ((char) (r + (int) '0'), 1) + s;
        } while (a > 0);
    return s;
}

