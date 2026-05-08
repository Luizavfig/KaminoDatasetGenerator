/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2352804
*  Stack Overflow answer #:2352878
*  And Stack Overflow answer#:2353548
*/
public static Image RotateImage (Image img, float rotationAngle) {
    int minx = int.MaxValue, maxx = int.MinValue, miny = int.MaxValue, maxy = int.MinValue;
    using (Bitmap bmp = new Bitmap (1, 1))
    {
        using (Graphics g = Graphics.FromImage (bmp))
        {
            g.TranslateTransform ((float) img.Width / 2, (float) img.Height / 2);
            g.RotateTransform (rotationAngle);
            g.TranslateTransform (- (float) img.Width / 2, - (float) img.Height / 2);
            Point [] pts = new Point [4];
            pts [0] = new Point (0, 0);
            pts [1] = new Point (img.Width, 0);
            pts [2] = new Point (img.Width, img.Height);
            pts [3] = new Point (0, img.Height);
            g.TransformPoints (CoordinateSpace.Device, CoordinateSpace.World, pts);
            foreach (Point pt in pts) {
                minx = Math.Min (minx, pt.X);
                maxx = Math.Max (maxx, pt.X);
                miny = Math.Min (miny, pt.Y);
                maxy = Math.Max (maxy, pt.Y);
            }
        }} Bitmap bmp2 = new Bitmap (maxx - minx, maxy - miny);
    using (Graphics g = Graphics.FromImage (bmp2))
    {
        g.TranslateTransform ((float) bmp2.Width / 2, (float) bmp2.Height / 2);
        g.RotateTransform (rotationAngle);
        g.TranslateTransform (- (float) bmp2.Width / 2, - (float) bmp2.Height / 2);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage (img, bmp2.Width / 2 - img.Width / 2, bmp2.Height / 2 - img.Height / 2);
    } return bmp2;
}

public static Bitmap RotateImage (Bitmap bmpSrc, float theta) {
    Matrix mRotate = new Matrix ();
    mRotate.Translate (bmpSrc.Width / - 2, bmpSrc.Height / - 2, MatrixOrder.Append);
    mRotate.RotateAt (theta, new System.Drawing.Point (0, 0), MatrixOrder.Append);
    using (GraphicsPath gp = new GraphicsPath ())
    {
        gp.AddPolygon (new System.Drawing.Point [] {new System.Drawing.Point (0, 0), new System.Drawing.Point (bmpSrc.Width, 0), new System.Drawing.Point (0, bmpSrc.Height)});
        gp.Transform (mRotate);
        System.Drawing.PointF [] pts = gp.PathPoints;
        Rectangle bbox = boundingBox (bmpSrc, mRotate);
        Bitmap bmpDest = new Bitmap (bbox.Width, bbox.Height);
        using (Graphics gDest = Graphics.FromImage (bmpDest))
        {
            Matrix mDest = new Matrix ();
            mDest.Translate (bmpDest.Width / 2, bmpDest.Height / 2, MatrixOrder.Append);
            gDest.Transform = mDest;
            gDest.DrawImage (bmpSrc, pts);
            return bmpDest;
        }}}

