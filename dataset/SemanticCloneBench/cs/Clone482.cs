/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:767999
*  Stack Overflow answer #:52896147
*  And Stack Overflow answer#:1031981
*/
public static int Next (int min, int max) {
    if (min >= max) {
        throw new ArgumentException ("Min value is greater or equals than Max value.");
    }
    byte [] intBytes = new byte [4];
    using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider ())
    {
        rng.GetNonZeroBytes (intBytes);
    } return min + Math.Abs (BitConverter.ToInt32 (intBytes, 0)) % (max - min + 1);
}

public int Next (int max) {
    var localBuffer = _local;
    if (localBuffer == null) {
        int seed;
        lock (Global)
        seed = Global.Next ();
        localBuffer = new Random (seed);
        _local = localBuffer;
    }
    return localBuffer.Next (max);
}

