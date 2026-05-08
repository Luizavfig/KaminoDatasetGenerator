/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18127861
*  Stack Overflow answer #:18129148
*  And Stack Overflow answer#:18129472
*/
public string [] Parse (string input) {
    bool open = false;
    int openIndex = - 1;
    List < string > matches = new List < string > ();
    for (int i = 0; i < input.Length; i ++) {
        if (! open && input [i] == OpenToken) {
            open = true;
            openIndex = i;
        } else if (open && input [i] == CloseToken) {
            open = false;
            string match = input.Substring (openIndex + 1, i - openIndex - 1);
            matches.Add (match);
        } else if (open && input [i] == OpenToken && ThrowOnError)
            throw new Exception ("Open token found while match is open");
        else if (! open && input [i] == CloseToken && ThrowOnError)
            throw new Exception ("Close token found while match is not open");
    }
    return matches.ToArray ();
}

static void Main (string [] args) {
    string rawInput = @"**Hello {Full{Name}, I { wanted to 
            inform that your product {{ProductName} is ready.
            Please come to our } address {Addr{Street}ess} to get it!**";
    string pattern = "^[^{}]*" + "(" + "((?'Open'{)[^{}]*)+" + "((?'Close-Open'})[^{}]*)+" + ")*" + "(?(Open)(?!))$";
    var tokens = Regex.Match (Regex.Match (rawInput, @"{[\s\S]*}").Value, pattern, RegexOptions.Multiline).Groups ["Close"].Captures.Cast < Capture > ().Where (c = > ! c.Value.Contains ('{') && ! c.Value.Contains ('}')).ToList ();
    tokens.ForEach (c = > {
        Console.WriteLine (c.Value);
    });
}

