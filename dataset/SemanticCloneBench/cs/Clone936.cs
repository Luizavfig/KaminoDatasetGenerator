/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1134738
*  Stack Overflow answer #:1134904
*  And Stack Overflow answer#:1137125
*/
public static int GetSeed () {
    byte [] raw = Guid.NewGuid ().ToByteArray ();
    int i1 = BitConverter.ToInt32 (raw, 0);
    int i2 = BitConverter.ToInt32 (raw, 4);
    int i3 = BitConverter.ToInt32 (raw, 8);
    int i4 = BitConverter.ToInt32 (raw, 12);
    long val = i1 + i2 + i3 + i4;
    while (val > int.MaxValue) {
        val -= int.MaxValue;
    }
    return (int) val;
}

private string GetUID () {
    string rndString = "";
    var rnd = new RNGCryptoServiceProvider ();
    var data = new byte [18];
    rnd.GetBytes (data);
    foreach (byte item in data) {
        rndString += Convert.ToString ((int) item % 10);
    }
    return rndString;
}

