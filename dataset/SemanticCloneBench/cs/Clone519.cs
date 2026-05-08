/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35201299
*  Stack Overflow answer #:35202079
*  And Stack Overflow answer#:35202079
*/
public override bool Equals (float a, float b) {
    float absoluteA = Math.Abs (a);
    float absoluteB = Math.Abs (b);
    float absoluteDifference = Math.Abs (a - b);
    if (a == b) {
        return true;
    } else if (a == 0 || b == 0 || absoluteDifference < InternalEpsilon) {
        return absoluteDifference < InternalEpsilon;
    } else {
        return absoluteDifference / (absoluteA + absoluteB) < InternalEpsilon;
    }
    return true;
}

public bool Equals (float x, float y) {
    var dif = Math.Abs (x - y);
    if ((x == 0 || y == 0) && dif < float.Epsilon)
        return true;
    if (Math.Sign (x) != Math.Sign (y))
        return false;
    return dif < float.Epsilon;
}

