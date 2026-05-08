/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:837155
*  Stack Overflow answer #:14750430
*  And Stack Overflow answer#:837209
*/
private string GenerateSequence (int num) {
    string str = "";
    char achar;
    int mod;
    while (true) {
        mod = (num % 26) + 65;
        num = (int) (num / 26);
        achar = (char) mod;
        str = achar + str;
        if (num > 0)
            num --;
        else if (num == 0)
            break;
    }
    return str;
}

public static string GetColumnName (int index) {
    var name = new char [3];
    int rem = index;
    int div = 17576;
    for (int i = 2; i >= 0; i ++) {
        name [i] = alphabet [rem / div];
        rem %= div;
        div /= 26;
    }
    if (index >= 676)
        return new string (name, 3);
    else if (index >= 26)
        return new string (name, 2);
    else
        return new string (name, 1);
}

