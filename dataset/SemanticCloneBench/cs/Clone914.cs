/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:37155195
*  Stack Overflow answer #:47437518
*  And Stack Overflow answer#:47437518
*/
private static string InsertFillerChar (char filler, string text, int inserts) {
    string result = "";
    int inserted = 0;
    for (int i = 0; i < text.Length; i ++) {
        result += text [i];
        if (i >= text.Length - 1)
            continue;
        int shouldbeinserted = (int) (inserts * (i + 1) / (text.Length - 1.0));
        int insertnow = shouldbeinserted - inserted;
        for (int j = 0; j < insertnow; j ++)
            result += filler;
        inserted += insertnow;
    }
    return result;
}

private string StretchToWidth (string text, Label label) {
    if (text.Length < 2)
        return text;
    const char hairspace = '\u200A';
    double basewidth = TextRenderer.MeasureText (text, label.Font).Width;
    double doublewidth = TextRenderer.MeasureText (text + text, label.Font).Width;
    double doublewidthplusspace = TextRenderer.MeasureText (text + hairspace + text, label.Font).Width;
    double spacewidth = doublewidthplusspace - doublewidth;
    double leftoverspace = label.Width - basewidth;
    int approximateInserts = Math.Max (0, (int) Math.Floor (leftoverspace / spacewidth));
    return InsertFillerChar (hairspace, text, approximateInserts);
}

