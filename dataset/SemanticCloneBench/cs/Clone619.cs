/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6396378
*  Stack Overflow answer #:33330715
*  And Stack Overflow answer#:40943999
*/
public int Compare (string s1, string s2) {
    int s1r, s2r;
    var s1n = IsNumeric (s1, out s1r);
    var s2n = IsNumeric (s2, out s2r);
    if (s1n && s2n)
        return s1r - s2r;
    else if (s1n)
        return - 1;
    else if (s2n)
        return 1;
    var num1 = Regex.Match (s1, @"\d+$");
    var num2 = Regex.Match (s2, @"\d+$");
    var onlyString1 = s1.Remove (num1.Index, num1.Length);
    var onlyString2 = s2.Remove (num2.Index, num2.Length);
    if (onlyString1 == onlyString2) {
        if (num1.Success && num2.Success)
            return Convert.ToInt32 (num1.Value) - Convert.ToInt32 (num2.Value);
        else if (num1.Success)
            return 1;
        else if (num2.Success)
            return - 1;
    }
    return string.Compare (s1, s2, true);
}

static void Main () {
    List < string > items = new List < string > () {"Example1.txt", "Example2.txt", "Example3.txt", "Example4.txt", "Example5.txt", "Example6.txt", "Example7.txt", "Example8.txt", "Example9.txt", "Example10.txt", "Example11.txt", "Example12.txt", "Example13.txt", "Example14.txt", "Example15.txt", "Example16.txt", "Example17.txt", "Example18.txt", "Example19.txt", "Example20.txt"};
    items.Sort ();
    foreach (var item in items) {
        Console.WriteLine (item);
    }
    Console.WriteLine ();
    items.Sort (new StrCmpLogicalComparer ());
    foreach (var item in items) {
        Console.WriteLine (item);
    }
    Console.ReadLine ();
}

