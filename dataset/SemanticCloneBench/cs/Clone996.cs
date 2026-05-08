/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8793762
*  Stack Overflow answer #:8794666
*  And Stack Overflow answer#:43610352
*/
unsafe void LoopString () {
    fixed (char * p = longString) {
        char c1, c2, c3, c4;
        Int64 len = longString.Length;
        Int64 * lptr = (Int64 *) p;
        Int64 l;
        for (int i = 0; i < len; i += 8) {
            l = * lptr;
            c1 = (char) (l & 0xffff);
            c2 = (char) (l > > 16);
            c3 = (char) (l > > 32);
            c4 = (char) (l > > 48);
            lptr ++;
        }
    }}

[Benchmark] public unsafe char Unsafe () {
    char c = '\0';
    var longString = _longString;
    int strLength = longString.Length;
    fixed (char * p = longString) {
        var p1 = p;
        for (int i = 0; i < strLength; i ++) {
            c |= * p1;
            p1 ++;
        }
    } return c;
}

