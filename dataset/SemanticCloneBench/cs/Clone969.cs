/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7411438
*  Stack Overflow answer #:48590650
*  And Stack Overflow answer#:48590650
*/
void Main () {
    "Control".Perf (n = > {
        var s = "*";
    });
    var text = "My name @is ,Wan.;'; Wan";
    var clean = new [] {'@', ',', '.', ';', '\''};
    test ("stackoverflow", text, string.Concat (clean), string.Empty);
    var target = "o";
    var f = "x";
    var replacement = "1";
    var fillers = new Dictionary < string, string > {{"short", new String (f [0], 10)}, {"med", new String (f [0], 300)}, {"long", new String (f [0], 1000)}, {"huge", new String (f [0], 10000)}};
    var formats = new Dictionary < string, string > {{"start", "{0}{1}{1}"}, {"middle", "{1}{0}{1}"}, {"end", "{1}{1}{0}"}};
    foreach (var filler in fillers)
        foreach (var format in formats) {
            var title = string.Join ("-", filler.Key, format.Key);
            var sample = string.Format (format.Value, target, filler.Value);
            test (title, sample, target, replacement);
        }
}

void test (string title, string sample, string target, string replacement) {
    var targets = target.ToCharArray ();
    var tox = "[" + target + "]";
    var x = new Regex (tox);
    var xc = new Regex (tox, RegexOptions.Compiled);
    var xci = new Regex (tox, RegexOptions.Compiled | RegexOptions.IgnoreCase);
    var p = new Perf ();
    p.Add (string.Join (" ", title, "Replace"), n = > targets.Aggregate (sample, (res, curr) = > res.Replace (new string (curr, 1), replacement)));
    p.Add (string.Join (" ", title, "SplitJoin"), n = > String.Join (replacement, sample.Split (targets)));
    p.Add (string.Join (" ", title, "LinqSplit"), n = > String.Concat (sample.Select (c = > targets.Contains (c) ? replacement : new string (c, 1))));
    p.Add (string.Join (" ", title, "Regex"), n = > Regex.Replace (sample, tox, replacement));
    p.Add (string.Join (" ", title, "Regex Insentive"), n = > Regex.Replace (sample, tox, replacement, RegexOptions.IgnoreCase));
    p.Add (string.Join (" ", title, "Regex, Uncompiled"), n = > x.Replace (sample, replacement));
    p.Add (string.Join (" ", title, "RegexCompiled"), n = > xc.Replace (sample, replacement));
    p.Add (string.Join (" ", title, "RegexCompiled Insensitive"), n = > xci.Replace (sample, replacement));
    var trunc = 40;
    var header = sample.Length > trunc ? sample.Substring (0, trunc) + "..." : sample;
    p.Vs (header);
}

