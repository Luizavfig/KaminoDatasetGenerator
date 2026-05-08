/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4243042
*  Stack Overflow answer #:4243079
*  And Stack Overflow answer#:7123291
*/
public static bool IsInPolygon (Point [] poly, Point point) {
    var coef = poly.Skip (1).Select ((p, i) = > (point.Y - poly [i].Y) * (p.X - poly [i].X) - (point.X - poly [i].X) * (p.Y - poly [i].Y)).ToList ();
    if (coef.Any (p = > p == 0))
        return true;
    for (int i = 1; i < coef.Count (); i ++) {
        if (coef [i] * coef [i - 1] < 0)
            return false;
    }
    return true;
}

public static bool IsInPolygon (Point [] poly, Point p) {
    Point p1, p2;
    bool inside = false;
    if (poly.Length < 3) {
        return inside;
    }
    var oldPoint = new Point (poly [poly.Length - 1].X, poly [poly.Length - 1].Y);
    for (int i = 0; i < poly.Length; i ++) {
        var newPoint = new Point (poly [i].X, poly [i].Y);
        if (newPoint.X > oldPoint.X) {
            p1 = oldPoint;
            p2 = newPoint;
        } else {
            p1 = newPoint;
            p2 = oldPoint;
        }
        if ((newPoint.X < p.X) == (p.X <= oldPoint.X) && (p.Y - (long) p1.Y) * (p2.X - p1.X) < (p2.Y - (long) p1.Y) * (p.X - p1.X)) {
            inside = ! inside;
        }
        oldPoint = newPoint;
    }
    return inside;
}

