/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3176116
*  Stack Overflow answer #:3176250
*  And Stack Overflow answer#:3176138
*/
private static int Encode (int value, byte [] buffer, int index) {
    byte temp;
    bool leading = true;
    temp = (value > > 24) & 0xFF;
    if (temp > 0) {
        buffer [index ++] = temp;
        leading = false;
    }
    temp = (value > > 16) & 0xFF;
    if (temp > 0 || leading == false) {
        buffer [index ++] = temp;
        leading = false;
    }
    temp = (value > > 8) & 0xFF;
    if (temp > 0 || leading == false) {
        buffer [index ++] = temp;
        leading = false;
    }
    temp = value & 0xFF;
    buffer [index ++] = temp;
    return index;
}

private static int Encode (int value, byte [] buffer, int index) {
    int length = 0;
    int valueCopy = value;
    while (valueCopy != 0) {
        valueCopy > >= 8;
        length ++;
    }
    for (int i = 0; i < length; i ++) {
        buffer [index + length - i - 1] = (byte) value;
        value > >= 8;
    }
    return length;
}

