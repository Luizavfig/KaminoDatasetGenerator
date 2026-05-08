/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1215326
*  Stack Overflow answer #:1215472
*  And Stack Overflow answer#:7150598
*/
public static void DrawNormalizedAudio (ref float [] data, PictureBox pb, Color color) {
    Bitmap bmp;
    if (pb.Image == null) {
        bmp = new Bitmap (pb.Width, pb.Height);
    } else {
        bmp = (Bitmap) pb.Image;
    }
    int BORDER_WIDTH = 5;
    int width = bmp.Width - (2 * BORDER_WIDTH);
    int height = bmp.Height - (2 * BORDER_WIDTH);
    using (Graphics g = Graphics.FromImage (bmp))
    {
        g.Clear (Color.Black);
        Pen pen = new Pen (color);
        int size = data.Length;
        for (int iPixel = 0; iPixel < width; iPixel ++) {
            int start = (int) ((float) iPixel * ((float) size / (float) width));
            int end = (int) ((float) (iPixel + 1) * ((float) size / (float) width));
            float min = float.MaxValue;
            float max = float.MinValue;
            for (int i = start; i < end; i ++) {
                float val = data [i];
                min = val < min ? val : min;
                max = val > max ? val : max;
            }
            int yMax = BORDER_WIDTH + height - (int) ((max + 1) *.5 * height);
            int yMin = BORDER_WIDTH + height - (int) ((min + 1) *.5 * height);
            g.DrawLine (pen, iPixel + BORDER_WIDTH, yMax, iPixel + BORDER_WIDTH, yMin);
        }
    } pb.Image = bmp;
}

public static Bitmap DrawNormalizedAudio (List < float > data, Color foreColor, Color backColor, Size imageSize) {
    Bitmap bmp = new Bitmap (imageSize.Width, imageSize.Height);
    int BORDER_WIDTH = 0;
    float width = bmp.Width - (2 * BORDER_WIDTH);
    float height = bmp.Height - (2 * BORDER_WIDTH);
    using (Graphics g = Graphics.FromImage (bmp))
    {
        g.Clear (backColor);
        Pen pen = new Pen (foreColor);
        float size = data.Count;
        for (float iPixel = 0; iPixel < width; iPixel += 1) {
            int start = (int) (iPixel * (size / width));
            int end = (int) ((iPixel + 1) * (size / width));
            if (end > data.Count)
                end = data.Count;
            float posAvg, negAvg;
            averages (data, start, end, out posAvg, out negAvg);
            float yMax = BORDER_WIDTH + height - ((posAvg + 1) *.5f * height);
            float yMin = BORDER_WIDTH + height - ((negAvg + 1) *.5f * height);
            g.DrawLine (pen, iPixel + BORDER_WIDTH, yMax, iPixel + BORDER_WIDTH, yMin);
        }
    } return bmp;
}

