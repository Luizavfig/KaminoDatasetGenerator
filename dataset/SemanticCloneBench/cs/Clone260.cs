/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17575375
*  Stack Overflow answer #:17575590
*  And Stack Overflow answer#:17576246
*/
public string IntToString (int a) {
    if (a == 0)
        return "0";
    if (a == int.MinValue)
        return "-2147483648";
    var isNegative = false;
    if (a < 0) {
        a = - a;
        isNegative = true;
    }
    var stack = new Stack < char > ();
    while (a != 0) {
        var c = a % 10 + '0';
        stack.Push ((char) c);
        a /= 10;
    }
    if (isNegative)
        stack.Push ('-');
    return new string (stack.ToArray ());
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

