/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8659351
*  Stack Overflow answer #:8659483
*  And Stack Overflow answer#:8659483
*/
public static float Noise (float x, float y, float z, int octaves, ref float min, ref float max) {
    var perlin = 0f;
    var octave = 1;
    for (var i = 0; i < octaves; i ++) {
        var noise = Noise (x * octave, y * octave, z * octave);
        perlin += noise / octave;
        octave *= 2;
    }
    perlin = Math.Abs ((float) Math.Pow (perlin, 2));
    max = Math.Max (perlin, max);
    min = Math.Min (perlin, min);
    return perlin;
}

public static float Noise (float x, float y, float z) {
    int X = (int) Math.Floor (x) % _halfLength;
    int Y = (int) Math.Floor (y) % _halfLength;
    int Z = (int) Math.Floor (z) % _halfLength;
    if (X < 0)
        X += _halfLength;
    if (Y < 0)
        Y += _halfLength;
    if (Z < 0)
        Z += _halfLength;
    x -= (int) Math.Floor (x);
    y -= (int) Math.Floor (y);
    z -= (int) Math.Floor (z);
    var u = Fade (x);
    var v = Fade (y);
    var w = Fade (z);
    int A = p [X] + Y, AA = p [A] + Z, AB = p [A + 1] + Z, B = p [X + 1] + Y, BA = p [B] + Z, BB = p [B + 1] + Z;
    return MathHelper.Lerp (MathHelper.Lerp (MathHelper.Lerp (Grad (p [AA], x, y, z), Grad (p [BA], x - 1, y, z), u), MathHelper.Lerp (Grad (p [AB], x, y - 1, z), Grad (p [BB], x - 1, y - 1, z), u), v), MathHelper.Lerp (MathHelper.Lerp (Grad (p [AA + 1], x, y, z - 1), Grad (p [BA + 1], x - 1, y, z - 1), u), MathHelper.Lerp (Grad (p [AB + 1], x, y - 1, z - 1), Grad (p [BB + 1], x - 1, y - 1, z - 1), u), v), w);
}

