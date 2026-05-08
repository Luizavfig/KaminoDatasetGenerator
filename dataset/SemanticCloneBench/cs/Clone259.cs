/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17575375
*  Stack Overflow answer #:17575590
*  And Stack Overflow answer#:17575453
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

