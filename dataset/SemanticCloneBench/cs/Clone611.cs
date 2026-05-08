/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2545482
*  Stack Overflow answer #:2546943
*  And Stack Overflow answer#:2545791
*/
public List < string > Keyword_Search (HtmlNode nSearch) {
    var wordFound = new List < string > ();
    string innerHtml = nSearch.InnerHtml;
    string pattern = "(\\b" + string.Join ("\\b)|(\\b", _keywordList) + "\\b)";
    Regex myRegex = new Regex (pattern, RegexOptions.IgnoreCase);
    MatchCollection myMatches = myRegex.Matches (innerHtml);
    foreach (Match myMatch in myMatches) {
        for (int i = 1; i < myMatch.Groups.Count; i ++) {
            if (myMatch.Groups [i].Success)
                wordFound.Add (_keywordList [i - 1]);
        }
    }
    return wordFound;
}

public List < string > Keyword_Search (HtmlNode nSearch) {
    var wordFound = new List < string > ();
    string innerHtml = nSearch.InnerHtml;
    foreach (string currWord in _keywordList) {
        bool isMatch = Regex.IsMatch (innerHtml, "\\b" + @currWord + "\\b", RegexOptions.IgnoreCase);
        if (isMatch) {
            wordFound.Add (currWord);
        }
    }
    return wordFound;
}

