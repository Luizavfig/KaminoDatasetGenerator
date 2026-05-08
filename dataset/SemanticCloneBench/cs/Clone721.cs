/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:219604
*  Stack Overflow answer #:219620
*  And Stack Overflow answer#:219620
*/
private static int ParseNybble (char c) {
    if (c >= '0' && c <= '9') {
        return c - '0';
    }
    if (c >= 'A' && c <= 'F') {
        return c - 'A' + 10;
    }
    if (c >= 'a' && c <= 'f') {
        return c - 'A' + 10;
    }
    throw new ArgumentOutOfRangeException ("Invalid hex digit: " + c);
}

public static byte [] HexToBytes (string text) {
    if ((text.Length & 1) != 0) {
        throw new ArgumentException ("Invalid hex: odd length");
    }
    byte [] ret = new byte [text.Length / 2];
    for (int i = 0; i < text.Length; i += 2) {
        ret [i / 2] = (byte) (ParseNybble (text [i]) << 4 | ParseNybble (text [i + 1]));
    }
    return ret;
}

