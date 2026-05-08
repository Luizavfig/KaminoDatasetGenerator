/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:40493127
*  Stack Overflow answer #:40495134
*  And Stack Overflow answer#:40493573
*/
public static string ReplaceHashtagsWithInt (string input, int integer) {
    Regex regex = new Regex ("#+");
    StringBuilder output = new StringBuilder (input);
    int allig = 0;
    for (Match match = regex.Match (input); match.Success; match = match.NextMatch ()) {
        string num = integer.ToString ();
        if (num.Length <= match.Length)
            for (int i = 0; i < match.Length; i ++) {
                if (i < match.Length - num.Length)
                    output [match.Index + i + allig] = '0';
                else
                    output [match.Index + i + allig] = num [i - match.Length + num.Length];
            }
        else {
            output.Remove (match.Index + allig, match.Length);
            output.Insert (match.Index + allig, num);
            allig += num.Length - match.Length;
        }
    }
    return output.ToString ();
}

public static string ReplaceHashtagsWithInt (string input, int integer) {
    Regex regex = new Regex ("#+");
    var matches = regex.Matches (input).Cast < Match > ().Select (m = > m.Value).ToArray ();
    Array.Sort (matches);
    Array.Reverse (matches);
    foreach (string match in matches) {
        Regex r = new Regex (match);
        string zeroes = new string ('0', match.Length - integer.ToString ().Length) + integer;
        input = r.Replace (input, zeroes);
    }
    return input;
}

