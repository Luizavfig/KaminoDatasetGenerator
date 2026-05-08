/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3714146
*  Stack Overflow answer #:3714266
*  And Stack Overflow answer#:13237888
*/
private void panel1_MouseMove (object sender, MouseEventArgs e) {
    using (Graphics g = panel1.CreateGraphics ())
    {
        using (Pen clear_pen = new Pen (panel1.BackColor, PEN_WIDTH))
        {
            clear_pen.StartCap = START_CAP;
            clear_pen.EndCap = END_CAP;
            g.DrawLine (clear_pen, mAnchorPoint, mPreviousPoint);
        } mPreviousPoint = e.Location;
        using (Pen draw_pen = new Pen (Color.Black, PEN_WIDTH))
        {
            draw_pen.StartCap = START_CAP;
            draw_pen.EndCap = END_CAP;
            g.DrawLine (draw_pen, mAnchorPoint, e.Location);
        }}}

private void pictureBox1_MouseMove (object sender, MouseEventArgs e) {
    if (o.Allow == true) {
        Graphics g = pictureBox1.CreateGraphics ();
        Pen p1 = new Pen (o.color, 5);
        g.DrawLine (p1, o.X, o.Y, e.X, e.Y);
        o.X = e.X;
        o.Y = e.Y;
    }
}

