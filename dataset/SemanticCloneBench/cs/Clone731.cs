/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2108616
*  Stack Overflow answer #:23517320
*  And Stack Overflow answer#:35213018
*/
private void txt_miktar_TextChanged (object sender, TextChangedEventArgs e) {
    if ((sender as TextBox).Text.Length < 1) {
        return;
    }
    try {
        int adet = Convert.ToInt32 ((sender as TextBox).Text);
    }
    catch {
        string s = "";
        s = (sender as TextBox).Text;
        s = s.Substring (0, s.Length - 1);
        (sender as TextBox).Text = s;
        (sender as TextBox).Select (s.Length, s.Length);
    }
}

public bool isNumber (char ch, string text) {
    bool res = true;
    char decimalChar = Convert.ToChar (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
    if (ch == decimalChar && text.IndexOf (decimalChar) != - 1) {
        res = false;
        return res;
    }
    if (! Char.IsDigit (ch) && ch != decimalChar && ch != (char) Keys.Back)
        res = false;
    return res;
}

