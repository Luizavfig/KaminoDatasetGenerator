/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11437079
*  Stack Overflow answer #:11437353
*  And Stack Overflow answer#:11437187
*/
public string GetResultsWithHyphen (string inText) {
    var counter = 0;
    var outString = string.Empty;
    while (counter < inText.Length) {
        if (counter % 4 == 0)
            outString = string.Format ("{0}-{1}", outString, inText.Substring (counter, 1));
        else
            outString += inText.Substring (counter, 1);
        counter ++;
    }
    return outString;
}

public string GetResultsWithHyphen (string input) {
    string output = "";
    int start = 0;
    while (start < input.Length) {
        output += input.Substring (start, Math.Min (4, input.Length - start)) + "-";
        start += 4;
    }
    return output.Trim ('-');
}

