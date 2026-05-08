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

public PointF [] Intersect (CircleEquation circle) {
    var cx = circle.Center.X;
    var cy = circle.Center.Y;
    var r = circle.Radius;
    if (isVertical) {
        var distance = Math.Abs (cx - xConstForVertical);
        if (distance > r)
            return new PointF [0];
        if (distance == r)
            return new [] {new PointF (xConstForVertical, cy)};
        var dx = cx - xConstForVertical;
        var qe = new QuadraticEquation (1, - 2 * cy, r * r - dx * dx);
        return qe.Solve ();
    }
    var t = b - cy;
    var q = new QuadraticEquation (1 + a * a, 2 * a * t - 2 * cx, cx * cx + t * t - r * r);
    var solutions = q.Solve ();
    for (var i = 0; i < solutions.Length; i ++)
        solutions [i] = Intersect (solutions [i].X).Value;
    return solutions;
}

