/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4552008
*  Stack Overflow answer #:4655782
*  And Stack Overflow answer#:4655782
*/
public PointF ? Intersect (LineSegment other) {
    var p = line.Intersect (other.line);
    if (p == null)
        return null;
    if (bindingRectangle.Contains (p.Value) && other.bindingRectangle.Contains (p.Value)) {
        return p;
    }
    return null;
}

public PointF ? Intersect (LineEquation other) {
    if (isVertical && other.isVertical)
        return null;
    if (a == other.a)
        return null;
    if (isVertical)
        return other.Intersect (xConstForVertical);
    if (other.isVertical)
        return Intersect (other.xConstForVertical);
    var x = (b - other.b) / (other.a - a);
    return Intersect (x);
}

