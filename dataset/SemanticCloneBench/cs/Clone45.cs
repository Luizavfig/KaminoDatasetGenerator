/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:23522294
*  Stack Overflow answer #:23950021
*  And Stack Overflow answer#:23860590
*/
private void textBox1_TextChanged (object sender, EventArgs e) {
    Point caretLocalLoc = textBox1.GetPositionFromCharIndex (textBox1.Text.Length - 1);
    Point caretLoc = new Point (caretLocalLoc.X + InitialTextBoxLoc.X, caretLocalLoc.Y + InitialTextBoxLoc.Y);
    Point scrollLoc = flowLayoutPanel1.AutoScrollPosition;
    if (caretLoc.X >= flowLayoutPanel1.Size.Width - 10) {
        scrollLoc.X = caretLoc.X;
    }
    if (caretLoc.Y >= flowLayoutPanel1.Size.Height - 10) {
        scrollLoc.Y = caretLoc.Y;
    }
    flowLayoutPanel1.AutoScrollPosition = scrollLoc;
}

private void textBox1_TextChanged (object sender, EventArgs e) {
    int lineHeight = 0;
    if (textBox1.Lines.Count () > 1) {
        Point p1 = textBox1.GetPositionFromCharIndex (textBox1.GetFirstCharIndexFromLine (0));
        Point p2 = textBox1.GetPositionFromCharIndex (textBox1.GetFirstCharIndexFromLine (1));
        lineHeight = Math.Abs (p1.Y - p2.Y);
    }
    int lineIndex = textBox1.GetLineFromCharIndex (textBox1.SelectionStart);
    flowLayoutPanel1.AutoScrollPosition = new Point (0, lineIndex * lineHeight);
}

