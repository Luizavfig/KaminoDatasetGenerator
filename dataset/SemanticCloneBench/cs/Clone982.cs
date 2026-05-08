/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:873175
*  Stack Overflow answer #:873948
*  And Stack Overflow answer#:873948
*/
public static string GetWord (string input, int position) {
    char s = input [position];
    int sp1 = 0, sp2 = input.Length;
    for (int i = position; i > 0; i --) {
        char ch = input [i];
        if (ch == ' ' || ch == '\n') {
            sp1 = i;
            break;
        }
    }
    for (int i = position; i < input.Length; i ++) {
        char ch = input [i];
        if (ch == ' ' || ch == '\n') {
            sp2 = i;
            break;
        }
    }
    return input.Substring (sp1, sp2 - sp1).Replace ("\n", "");
}

void richTextBox1_MouseMove (object sender, MouseEventArgs e) {
    if (! timer1.Enabled) {
        string link = GetWord (richTextBox1.Text, richTextBox1.GetCharIndexFromPosition (e.Location));
        if (System.Text.RegularExpressions.Regex.IsMatch (link, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*$")) {
            tip.ToolTipTitle = link;
            Point p = richTextBox1.Location;
            tip.Show (link, this, p.X + e.X, p.Y + e.Y + 32, 1000);
            timer1.Enabled = true;
        }
    }
}

