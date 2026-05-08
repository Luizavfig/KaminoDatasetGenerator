/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3759880
*  Stack Overflow answer #:25911768
*  And Stack Overflow answer#:4432145
*/
private void DefineGeometry () {
    var points = PointCollection;
    _figure.Segments.Clear ();
    if (points.Any ()) {
        _figure.StartPoint = points [0];
        if (points.Count > 1) {
            for (int i = 1; i < (points.Count - 1); i ++) {
                var v1 = (Point) points [i] - points [i - 1];
                var v2 = (Point) points [i + 1] - points [i];
                var radius = (points [i].Radius ?? Radius) ?? 0;
                radius = Math.Min (Math.Min (v1.Length, v2.Length) / 2, radius);
                double len = v1.Length;
                v1.Normalize ();
                v1 *= (len - radius);
                var line = new LineSegment ((Point) points [i - 1] + v1, true);
                _figure.Segments.Add (line);
                v2.Normalize ();
                v2 *= radius;
                var direction = (Vector.AngleBetween (v1, v2) > 0) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
                var arc = new ArcSegment ((Point) points [i] + v2, new Size (radius, radius), 0, false, direction, true);
                _figure.Segments.Add (arc);
            }
            _figure.Segments.Add (new LineSegment (points [points.Count - 1], true));
        }
    }
}

private void DefineGeometry () {
    PointCollection points = Points;
    if (points == null) {
        _geometry = Geometry.Empty;
        return;
    }
    PathFigure figure = new PathFigure ();
    if (points.Count > 0) {
        figure.StartPoint = points [0];
        if (points.Count > 1) {
            double desiredRadius = Radius;
            for (int i = 1; i < (points.Count - 1); i ++) {
                Vector v1 = points [i] - points [i - 1];
                Vector v2 = points [i + 1] - points [i];
                double radius = Math.Min (Math.Min (v1.Length, v2.Length) / 2, desiredRadius);
                double len = v1.Length;
                v1.Normalize ();
                v1 *= (len - radius);
                LineSegment line = new LineSegment (points [i - 1] + v1, true);
                figure.Segments.Add (line);
                v2.Normalize ();
                v2 *= radius;
                SweepDirection direction = (Vector.AngleBetween (v1, v2) > 0) ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
                ArcSegment arc = new ArcSegment (points [i] + v2, new Size (radius, radius), 0, false, direction, true);
                figure.Segments.Add (arc);
            }
            figure.Segments.Add (new LineSegment (points [points.Count - 1], true));
        }
    }
    PathGeometry geometry = new PathGeometry ();
    geometry.Figures.Add (figure);
    geometry.FillRule = FillRule;
    if (geometry.Bounds == Rect.Empty) {
        _geometry = Geometry.Empty;
    } else {
        _geometry = geometry;
    }
}

