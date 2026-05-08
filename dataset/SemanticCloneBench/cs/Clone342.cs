/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3663704
*  Stack Overflow answer #:3663856
*  And Stack Overflow answer#:3663793
*/
private void listBox1_DrawItem (object sender, DrawItemEventArgs e) {
    if (e.Index < 0)
        return;
    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        e = new DrawItemEventArgs (e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.Yellow);
    e.DrawBackground ();
    e.Graphics.DrawString (listBox1.Items [e.Index].ToString (), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
    e.DrawFocusRectangle ();
}

void listBox1_DrawItem (object sender, System.Windows.Forms.DrawItemEventArgs e) {
    int index = e.Index;
    Graphics g = e.Graphics;
    foreach (int selectedIndex in this.listBox1.SelectedIndices) {
        if (index == selectedIndex) {
            e.DrawBackground ();
            g.FillRectangle (new SolidBrush (Color.Red), e.Bounds);
        }
    }
    Font font = listBox1.Font;
    Color colour = listBox1.ForeColor;
    string text = listBox1.Items [index].ToString ();
    g.DrawString (text, font, new SolidBrush (Color.Black), (float) e.Bounds.X, (float) e.Bounds.Y);
    e.DrawFocusRectangle ();
}

