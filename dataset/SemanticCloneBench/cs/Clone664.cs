/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:76455
*  Stack Overflow answer #:20042058
*  And Stack Overflow answer#:50451872
*/
private void DrawGroupBox (GroupBox box, Graphics g, Color textColor, Color borderColor) {
    if (box != null) {
        Brush textBrush = new SolidBrush (textColor);
        Brush borderBrush = new SolidBrush (borderColor);
        Pen borderPen = new Pen (borderBrush);
        SizeF strSize = g.MeasureString (box.Text, box.Font);
        Rectangle rect = new Rectangle (box.ClientRectangle.X, box.ClientRectangle.Y + (int) (strSize.Height / 2), box.ClientRectangle.Width - 1, box.ClientRectangle.Height - (int) (strSize.Height / 2) - 1);
        g.Clear (this.BackColor);
        g.DrawString (box.Text, box.Font, textBrush, box.Padding.Left, 0);
        g.DrawLine (borderPen, rect.Location, new Point (rect.X, rect.Y + rect.Height));
        g.DrawLine (borderPen, new Point (rect.X + rect.Width, rect.Y), new Point (rect.X + rect.Width, rect.Y + rect.Height));
        g.DrawLine (borderPen, new Point (rect.X, rect.Y + rect.Height), new Point (rect.X + rect.Width, rect.Y + rect.Height));
        g.DrawLine (borderPen, new Point (rect.X, rect.Y), new Point (rect.X + box.Padding.Left, rect.Y));
        g.DrawLine (borderPen, new Point (rect.X + box.Padding.Left + (int) (strSize.Width), rect.Y), new Point (rect.X + rect.Width, rect.Y));
    }
}

private void groupSchitaCentru_Paint (object sender, PaintEventArgs e) {
    Pen blackPen = new Pen (Color.Black, 2);
    Point pointTopLeft = new Point (0, 7);
    Point pointBottomLeft = new Point (0, groupSchitaCentru.ClientRectangle.Height);
    Point pointTopRight = new Point (groupSchitaCentru.ClientRectangle.Width, 7);
    Point pointBottomRight = new Point (groupSchitaCentru.ClientRectangle.Width, groupSchitaCentru.ClientRectangle.Height);
    e.Graphics.DrawLine (blackPen, pointTopLeft, pointBottomLeft);
    e.Graphics.DrawLine (blackPen, pointTopLeft, pointTopRight);
    e.Graphics.DrawLine (blackPen, pointBottomRight, pointTopRight);
    e.Graphics.DrawLine (blackPen, pointBottomLeft, pointBottomRight);
}

