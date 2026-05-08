/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5243237
*  Stack Overflow answer #:23390837
*  And Stack Overflow answer#:5243263
*/
private static int GetCryptographicRandomNumber (int lBound, int uBound) {
    uint urndnum;
    var rndnum = new Byte [4];
    if (lBound == uBound - 1) {
        return lBound;
    }
    uint xcludeRndBase = (uint.MaxValue - (uint.MaxValue % (uint) (uBound - lBound)));
    do
        {
            _rng.GetBytes (rndnum);
            urndnum = BitConverter.ToUInt32 (rndnum, 0);
        } while (urndnum >= xcludeRndBase);
    return (int) (urndnum % (uBound - lBound)) + lBound;
}

protected int GetCryptographicRandomNumber (int lBound, int uBound) {
    uint urndnum;
    byte [] rndnum = new Byte [4];
    if (lBound == uBound - 1) {
        return lBound;
    }
    uint xcludeRndBase = (uint.MaxValue - (uint.MaxValue % (uint) (uBound - lBound)));
    do
        {
            rng.GetBytes (rndnum);
            urndnum = System.BitConverter.ToUInt32 (rndnum, 0);
        } while (urndnum >= xcludeRndBase);
    return (int) (urndnum % (uBound - lBound)) + lBound;
}

