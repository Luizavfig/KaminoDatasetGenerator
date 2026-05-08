/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18655821
*  Stack Overflow answer #:18656196
*  And Stack Overflow answer#:18656201
*/
public string SplitLongWords (string text, int maxWordLength) {
    var result = new StringBuilder ();
    int currentWordLength = 0;
    foreach (char c in text) {
        if (char.IsWhiteSpace (c)) {
            currentWordLength = 0;
        } else if (currentWordLength == maxWordLength) {
            currentWordLength = 1;
            result.Append (' ');
        } else {
            ++ currentWordLength;
        }
        result.Append (c);
    }
    return result.ToString ().TrimEnd ();
}

public static string Truncate (string text, int maxlength) {
    maxlength = maxlength - 2;
    string truncated = string.Empty;
    int lastSpace = 0;
    if (text.Length > maxlength) {
        string temp = text.Substring (0, maxlength);
        lastSpace = temp.LastIndexOf (" ");
        truncated = temp.Substring (0, lastSpace);
    } else {
        return text;
    }
    return truncated.Trim ().Insert (truncated.Length, "- ") + text.Substring (lastSpace);
}

