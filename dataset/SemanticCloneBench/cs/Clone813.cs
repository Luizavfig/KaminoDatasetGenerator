/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10020949
*  Stack Overflow answer #:10022243
*  And Stack Overflow answer#:14637342
*/
public static List < Point > ConvexHull (List < Point > points) {
    if (points.Count < 3) {
        throw new ArgumentException ("At least 3 points reqired", "points");
    }
    List < Point > hull = new List < Point > ();
    Point vPointOnHull = points.Where (p = > p.X == points.Min (min = > min.X)).First ();
    Point vEndpoint;
    do
        {
            hull.Add (vPointOnHull);
            vEndpoint = points [0];
            for (int i = 1; i < points.Count; i ++) {
                if ((vPointOnHull == vEndpoint) || (Orientation (vPointOnHull, vEndpoint, points [i]) == - 1)) {
                    vEndpoint = points [i];
                }
            }
            vPointOnHull = vEndpoint;
        } while (vEndpoint != hull [0]);
    return hull;
}

private static int Orientation (Point p1, Point p2, Point p) {
    int Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);
    if (Orin > 0)
        return - 1;
    if (Orin < 0)
        return 1;
    return 0;
}

