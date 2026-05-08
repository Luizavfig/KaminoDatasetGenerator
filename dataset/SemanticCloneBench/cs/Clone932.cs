/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10439242
*  Stack Overflow answer #:10439333
*  And Stack Overflow answer#:10439718
*/
int LeadingZeros (int x) {
    const int numIntBits = sizeof (int) * 8;
    x |= x > > 1;
    x |= x > > 2;
    x |= x > > 4;
    x |= x > > 8;
    x |= x > > 16;
    x -= x > > 1 & 0x55555555;
    x = (x > > 2 & 0x33333333) + (x & 0x33333333);
    x = (x > > 4) + x & 0x0f0f0f0f;
    x += x > > 8;
    x += x > > 16;
    return numIntBits - (x & 0x0000003f);
}

static int LeadingZeros (int value) {
    var uValue = (uint) value;
    int leadingZeros = 0;
    while (uValue != 0) {
        uValue = uValue > > 1;
        leadingZeros ++;
    }
    return (32 - leadingZeros);
}

