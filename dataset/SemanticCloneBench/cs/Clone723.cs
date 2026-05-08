/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4243042
*  Stack Overflow answer #:7123291
*  And Stack Overflow answer#:49434625
*/
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

public static bool IsInPolygon (this Point point, IEnumerable < Point > polygon) {
    bool result = false;
    var a = polygon.Last ();
    foreach (var b in polygon) {
        if ((b.X == point.X) && (b.Y == point.Y))
            return true;
        if ((b.Y == a.Y) && (point.Y == a.Y) && (a.X <= point.X) && (point.X <= b.X))
            return true;
        if ((b.Y < point.Y) && (a.Y >= point.Y) || (a.Y < point.Y) && (b.Y >= point.Y)) {
            if (b.X + (point.Y - b.Y) / (a.Y - b.Y) * (a.X - b.X) <= point.X)
                result = ! result;
        }
        a = b;
    }
    return result;
}

