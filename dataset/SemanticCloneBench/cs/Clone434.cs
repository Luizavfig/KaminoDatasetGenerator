/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15981840
*  Stack Overflow answer #:15982138
*  And Stack Overflow answer#:15982041
*/
protected override void OnMouseMove (MouseEventArgs e) {
    if (e.Button == MouseButtons.Left) {
        rec.Width = e.X - rec.X;
        rec.Height = e.Y - rec.Y;
    } else if (e.Button == MouseButtons.Right) {
        rec.X = e.X - MouseDownLocation.X;
        rec.Y = e.Y - MouseDownLocation.Y;
    }
}

protected override void OnMouseMove (MouseEventArgs e) {
    if (e.Button == MouseButtons.Left) {
        rec.Width = e.X - rec.X;
        rec.Height = e.Y - rec.Y;
        this.Invalidate ();
    }
    if (e.Button == MouseButtons.Right) {
        rec.Location = new Point ((e.X - MouseDownLocation.X) + rec.Left, (e.Y - MouseDownLocation.Y) + rec.Top);
        MouseDownLocation = e.Location;
        this.Invalidate ();
    }
}

