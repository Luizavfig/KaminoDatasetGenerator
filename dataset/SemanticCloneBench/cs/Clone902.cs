/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10074482
*  Stack Overflow answer #:10075828
*  And Stack Overflow answer#:10074694
*/
private void PaintGradientBars (Graphics g, Rectangle r, Color startColor, Color endColor, int numBars) {
    int rMin = startColor.R;
    int gMin = startColor.G;
    int bMin = startColor.B;
    int rMax = endColor.R;
    int gMax = endColor.G;
    int bMax = endColor.B;
    int left = 0;
    for (int i = 0; i < numBars; i ++) {
        int rAvg = rMin + (int) ((rMax - rMin) * i / numBars);
        int gAvg = gMin + (int) ((gMax - gMin) * i / numBars);
        int bAvg = bMin + (int) ((bMax - bMin) * i / numBars);
        Color useColor = Color.FromArgb (rAvg, gAvg, bAvg);
        int width = (r.Width - left) / (numBars - i);
        using (SolidBrush br = new SolidBrush (useColor))
        {
            g.FillRectangle (br, new Rectangle (left, 0, width, r.Height));
        } left += width;
    }
}

private void pictureBox1_Paint (object sender, PaintEventArgs e) {
    int k = 20;
    Color mycolor = new Color ();
    for (int i = 0; i < 10; i ++) {
        mycolor = Color.FromArgb (i * k, i * k, i * k);
        SolidBrush mybrash = new SolidBrush (mycolor);
        e.Graphics.FillRectangle ((Brush) mybrash, 0 + i * k, 0, k, k);
    }
}

