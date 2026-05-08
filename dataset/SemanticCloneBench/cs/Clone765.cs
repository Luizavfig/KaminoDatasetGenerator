/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19761487
*  Stack Overflow answer #:19819759
*  And Stack Overflow answer#:19819759
*/
protected bool IsValid (string text) {
    Regex check = new Regex ("^" + ((this.AllowNegatives && this.MinValue < 0) ? (@"\-?") : "") + ((this.CurrencyChar != (char) 0) ? (@"(" + Regex.Escape (this.CurrencyChar.ToString ()) + ")?") : "") + @"\d*" + ((this.Precision > 0) ? (@"(\.\d{0," + this.Precision.ToString () + "})?") : "") + "$");
    if (! check.IsMatch (text))
        return false;
    if (text == "-" || text == this.CurrencyChar.ToString () || text == "-" + this.CurrencyChar.ToString ())
        return true;
    Decimal val = Decimal.Parse (text);
    if (val < this.MinValue)
        return false;
    if (val > this.MaxValue)
        return false;
    return true;
}

protected override void WndProc (ref Message m) {
    switch (m.Msg) {
        case 0x0302 :
            if (Clipboard.GetDataObject ().GetDataPresent (DataFormats.Text)) {
                string paste = Clipboard.GetDataObject ().GetData (DataFormats.Text).ToString ();
                string text = this.Text.Substring (0, this.SelectionStart) + paste + this.Text.Substring (this.SelectionStart + this.SelectionLength);
                if (this.IsValid (text)) {
                    base.WndProc (ref m);
                }
            }
            break;
        default :
            base.WndProc (ref m);
            break;
    }
}

