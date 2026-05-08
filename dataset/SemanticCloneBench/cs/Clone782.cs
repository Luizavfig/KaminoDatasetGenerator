/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10188933
*  Stack Overflow answer #:10209911
*  And Stack Overflow answer#:10209911
*/
private void UpdateRtb (string search) {
    lastsearch = search;
    if (rtb is RichTextBox) {
        ((RichTextBox) rtb).Text = "";
        List < string > help_contents;
        if (search != "")
            help_contents = _contents.Where (s = > s.Contains (search)).ToList ();
        else
            help_contents = _contents;
        for (int i = 0; i < help_contents.Count; i ++) {
            ((RichTextBox) rtb).Text += help_contents [i] + "\n";
        }
    }
}

public int Add (object value) {
    if (_count < _contents.Count + 1) {
        _contents.Add ((string) value);
        _count ++;
        UpdateRtb (lastsearch);
        return (_count);
    } else {
        return - 1;
    }
}

