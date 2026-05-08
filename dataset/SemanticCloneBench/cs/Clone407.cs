/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:124975
*  Stack Overflow answer #:17973520
*  And Stack Overflow answer#:4961388
*/
private void DrawLines (Graphics g) {
    g.Clear (BackColor);
    int y = - editBox.ScrollPos.Y;
    for (var i = 1; i < _lines + 1; i ++) {
        var size = g.MeasureString (i.ToString (), Font);
        g.DrawString (i.ToString (), Font, new SolidBrush (LineNumberColor), new Point (3, y));
        y += Font.Height + 2;
    }
    var max = (int) g.MeasureString ((_lines + 1).ToString (), Font).Width + 6;
    editBox.Location = new Point (max, 0);
    editBox.Size = new Size (ClientRectangle.Width - max, ClientRectangle.Height);
}

private void DrawLines (Graphics g) {
    int counter, y;
    g.Clear (BackColor);
    counter = lineIndex + 1;
    y = 2;
    int max = 0;
    while (y < ClientRectangle.Height - 15) {
        SizeF size = g.MeasureString (counter.ToString (), Font);
        g.DrawString (counter.ToString (), Font, new SolidBrush (ForeColor), new Point (3, y));
        counter ++;
        y += (int) size.Height;
        if (max < size.Width) {
            max = (int) size.Width;
        }
    }
    max += 6;
    editBox.Location = new Point (max, 0);
    editBox.Size = new Size (ClientRectangle.Width - max, ClientRectangle.Height);
}

