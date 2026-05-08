/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3390288
*  Stack Overflow answer #:3390910
*  And Stack Overflow answer#:3390567
*/
private static string RemoveExcessPeriods (string text) {
    if (string.IsNullOrEmpty (text))
        return string.Empty;
    if (! text.Contains (".."))
        return text;
    string extension = Path.GetExtension (text);
    string fileName = Path.GetFileNameWithoutExtension (text);
    StringBuilder result = new StringBuilder (text.Length);
    bool lastCharacterWasPeriod = false;
    bool thisCharacterIsPeriod = fileName.Length > 0 && fileName [0] == '.';
    bool nextCharacterIsPeriod;
    for (int index = 0; index < fileName.Length; index ++) {
        nextCharacterIsPeriod = fileName.Length == index + 1 || fileName [index + 1] == '.';
        if (! thisCharacterIsPeriod)
            result.Append (fileName [index]);
        else if (thisCharacterIsPeriod && ! lastCharacterWasPeriod && ! nextCharacterIsPeriod)
            result.Append ('.');
        else if (thisCharacterIsPeriod && ! lastCharacterWasPeriod)
            result.Append (' ');
        lastCharacterWasPeriod = thisCharacterIsPeriod;
        thisCharacterIsPeriod = nextCharacterIsPeriod;
    }
    return result.ToString () + extension;
}

void ReplaceConsecutive (string src, int lenght, string replace) {
    char last;
    int count = 0;
    StringBuilder ret = new StringBuilder ();
    StringBuilder add = new StringBuilder ();
    foreach (char now in src) {
        if (now == last) {
            add.Append (now);
            if (count > lenght) {
                ret.Append (replace);
                add = new StringBuilder ();
            }
            count ++;
        } else {
            ret.Append (add);
            add = new StringBuilder ();
            count = 0;
            ret.Append (now);
        }
    }
    return ret.ToString ();
}

