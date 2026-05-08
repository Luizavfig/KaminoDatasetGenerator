/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16064698
*  Stack Overflow answer #:16064699
*  And Stack Overflow answer#:16065660
*/
static void FindFilenamesInMessage (string message) {
    var matches = Regex.Matches (message, @"\w:\\", RegexOptions.Compiled);
    int length = message.Length;
    foreach (var index in matches.Cast < Match > ().Select (m = > m.Index).Reverse ()) {
        length = length - index;
        while (length > 0) {
            var subString = message.Substring (index, length);
            if (File.Exists (subString)) {
                length = index;
                break;
            }
            length --;
        }
    }
}

static void FindFilenamesInMessage (string message) {
    var matches = Regex.Matches (message, @"\w:\\", RegexOptions.Compiled);
    foreach (var idx in matches.Cast < Match > ().Select (m = > m.idx).Reverse ()) {
        int length = 3;
        var potentialPath = message.Substring (idx, length);
        var lastGoodPath = potentialPath;
        while (Directory.Exists (potentialPath)) {
            lastGoodPath = potentialPath;
            while (idx + length < message.Length && message [idx + length] != '\\')
                length ++;
            length ++;
            if (idx + length >= message.Length)
                length = (message.Length - idx) - 1;
            potentialPath = message.Substring (idx, length);
        }
        potentialPath = message.Substring (idx);
        foreach (var file in Directory.EnumerateFiles (lastGoodPath).OrderByDescending (s = > s.Length)) {
            if (! potentialPath.StartsWith (file))
                continue;
            break;
        }
    }
}

