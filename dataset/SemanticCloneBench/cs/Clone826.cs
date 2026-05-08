/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1450774
*  Stack Overflow answer #:10012377
*  And Stack Overflow answer#:31233093
*/
private static string [] SplitIntoChunks (string text, int chunkSize, bool truncateRemaining) {
    string chunk = chunkSize.ToString ();
    string pattern = truncateRemaining ? ".{" + chunk + "}" : ".{1," + chunk + "}";
    string [] chunks = null;
    if (chunkSize > 0 && ! String.IsNullOrEmpty (text))
        chunks = (from Match m in Regex.Matches (text, pattern)
            select m.Value).ToArray ();
    return chunks;
}

static List < string > chunkMyStr (string str, int offSet) {
    List < string > resultChunks = new List < string > ();
    for (int i = 0; i < str.Length; i += offSet) {
        string temp = str.Substring (i, (str.Length - i) > offSet ? offSet : (str.Length - i));
        Console.WriteLine (temp);
        resultChunks.Add (temp);
    }
    return resultChunks;
}

