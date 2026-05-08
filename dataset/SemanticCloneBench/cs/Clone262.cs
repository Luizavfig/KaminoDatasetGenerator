/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4552008
*  Stack Overflow answer #:4630302
*  And Stack Overflow answer#:4655782
*/
public static GraphicsPath Shrink (this GraphicsPath path, float width) {
    using (var p = new GraphicsPath ())
    {
        p.AddPath (path, false);
        p.CloseAllFigures ();
        p.Widen (new Pen (Color.Black, width * 2));
        var position = 0;
        var result = new GraphicsPath ();
        while (position < p.PointCount) {
            position += CountNextFigure (p.PathData, position);
            var figureCount = CountNextFigure (p.PathData, position);
            var points = new PointF [figureCount];
            var types = new byte [figureCount];
            Array.Copy (p.PathPoints, position, points, 0, figureCount);
            Array.Copy (p.PathTypes, position, types, 0, figureCount);
            position += figureCount;
            result.AddPath (new GraphicsPath (points, types), false);
        }
        path.Reset ();
        path.AddPath (result, false);
        return path;
    }}

public static GraphicsPath Shrink (this GraphicsPath originalPath, float width) {
    originalPath.CloseAllFigures ();
    originalPath.Flatten ();
    var parts = originalPath.SplitFigures ();
    var shrunkPaths = new List < GraphicsPath > ();
    foreach (var part in parts) {
        using (var widePath = new GraphicsPath (part.PathPoints, part.PathTypes))
        {
            widePath.Widen (new Pen (Color.Black, width * 2));
            var innerEdge = widePath.SplitFigures () [1];
            var fixedPath = CleanPath (innerEdge, part, width);
            if (fixedPath.PointCount > 0)
                shrunkPaths.Add (fixedPath);
        }}
    originalPath.Reset ();
    foreach (var p in shrunkPaths) {
        originalPath.AddPath (p, false);
    }
    return originalPath;
}

