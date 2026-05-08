/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12024406
*  Stack Overflow answer #:12025915
*  And Stack Overflow answer#:44932170
*/
private Bitmap RotateImage (Bitmap bmp, float angle) {
    Bitmap rotatedImage = new Bitmap (bmp.Width, bmp.Height);
    using (Graphics g = Graphics.FromImage (rotatedImage))
    {
        g.TranslateTransform (bmp.Width / 2, bmp.Height / 2);
        g.RotateTransform (angle);
        g.TranslateTransform (- bmp.Width / 2, - bmp.Height / 2);
        g.DrawImage (bmp, new Point (0, 0));
    } return rotatedImage;
}

private static Bitmap RotateImage (Bitmap bmp, float angle) {
    float alpha = angle;
    while (alpha < 0)
        alpha += 360;
    float gamma = 90;
    float beta = 180 - angle - gamma;
    float c1 = bmp.Height;
    float a1 = (float) (c1 * Math.Sin (alpha * Math.PI / 180) / Math.Sin (gamma * Math.PI / 180));
    float b1 = (float) (c1 * Math.Sin (beta * Math.PI / 180) / Math.Sin (gamma * Math.PI / 180));
    float c2 = bmp.Width;
    float a2 = (float) (c2 * Math.Sin (alpha * Math.PI / 180) / Math.Sin (gamma * Math.PI / 180));
    float b2 = (float) (c2 * Math.Sin (beta * Math.PI / 180) / Math.Sin (gamma * Math.PI / 180));
    int width = Convert.ToInt32 (b2 + a1);
    int height = Convert.ToInt32 (b1 + a2);
    Bitmap rotatedImage = new Bitmap (width, height);
    using (Graphics g = Graphics.FromImage (rotatedImage))
    {
        g.TranslateTransform (rotatedImage.Width / 2, rotatedImage.Height / 2);
        g.RotateTransform (angle);
        g.TranslateTransform (- rotatedImage.Width / 2, - rotatedImage.Height / 2);
        g.DrawImage (bmp, new Point ((width - bmp.Width) / 2, (height - bmp.Height) / 2));
    } return rotatedImage;
}

