/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7688445
*  Stack Overflow answer #:49840602
*  And Stack Overflow answer#:41248027
*/
private static string ExtractCN (string dn) {
    string [] parts = dn.Split (new char [] {','});
    for (int i = 0; i < parts.Length; i ++) {
        var p = parts [i];
        var elems = p.Split (new char [] {'='});
        var t = elems [0].Trim ().ToUpper ();
        var v = elems [1].Trim ();
        if (t == "CN") {
            return v;
        }
    }
    return null;
}

private static string ExtractCN (string distinguishedName) {
    string [] parts;
    parts = distinguishedName.Split (new [] {",DC="}, StringSplitOptions.None);
    var dc = parts.Skip (1);
    parts = parts [0].Split (new [] {",OU="}, StringSplitOptions.None);
    var ou = parts.Skip (1);
    parts = parts [0].Split (new [] {",CN="}, StringSplitOptions.None);
    var cnMulti = parts.Skip (1);
    var cn = parts [0];
    if (! Regex.IsMatch (cn, "^CN="))
        throw new CustomException (string.Format ("Unable to parse distinguishedName for commonName ({0})", distinguishedName));
    return Regex.Replace (cn, "^CN=", string.Empty);
}

