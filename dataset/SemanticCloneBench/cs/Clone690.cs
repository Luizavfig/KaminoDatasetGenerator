/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2448303
*  Stack Overflow answer #:2448546
*  And Stack Overflow answer#:2448511
*/
static byte [] Year2Bcd (int year) {
    if (year < 0 || year > 9999)
        throw new ArgumentException ();
    int bcd = 0;
    for (int digit = 0; digit < 4; ++ digit) {
        int nibble = year % 10;
        bcd |= nibble << (digit * 4);
        year /= 10;
    }
    return new byte [] {(byte) ((bcd > > 8) & 0xff), (byte) (bcd & 0xff)};
}

static byte [] IntToBCD (int input) {
    if (input > 9999 || input < 0)
        throw new ArgumentOutOfRangeException ("input");
    int thousands = input / 1000;
    int hundreds = (input -= thousands * 1000) / 100;
    int tens = (input -= hundreds * 100) / 10;
    int ones = (input -= tens * 10);
    byte [] bcd = new byte [] {(byte) (thousands << 4 | hundreds), (byte) (tens << 4 | ones)};
    return bcd;
}

