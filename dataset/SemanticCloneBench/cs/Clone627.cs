/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29168218
*  Stack Overflow answer #:33511480
*  And Stack Overflow answer#:29169459
*/
private void tsi_MouseEnter (object sender, EventArgs e) {
    ToolStripItem tsi = (ToolStripItem) sender;
    Bitmap bm = new Bitmap (tsi.Width, tsi.Height);
    for (int y = 0; y < tsi.Height; y ++) {
        for (int x = 0; x < tsi.Width; x ++)
            bm.SetPixel (x, y, Color.FromArgb (150, Color.White));
    }
    tsi.BackgroundImage = bm;
}

protected override void OnRenderButtonBackground (ToolStripItemRenderEventArgs e) {
    if (! e.Item.Selected) {
        base.OnRenderButtonBackground (e);
    } else {
        Rectangle rectangle = new Rectangle (0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
        e.Graphics.FillRectangle (Brushes.Green, rectangle);
        e.Graphics.DrawRectangle (Pens.Olive, rectangle);
    }
}

