/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10709821
*  Stack Overflow answer #:39797038
*  And Stack Overflow answer#:53873708
*/
static void Main (string [] args) {
    Console.WriteLine ("Enter the string");
    string x = Console.ReadLine ();
    Console.WriteLine ("enter the string to be searched");
    string SearchText = Console.ReadLine ();
    string [] myarr = new string [30];
    myarr = x.Split (' ');
    int i = 0;
    foreach (string s in myarr) {
        i = i + 1;
        if (s == SearchText) {
            Console.WriteLine ("The string found at position:" + i);
        }
    }
    Console.ReadLine ();
}

public static string ReplaceTextBetween (string strSource, string strStart, string strEnd, string strReplace) {
    int Start, End, strSourceEnd;
    if (strSource.Contains (strStart) && strSource.Contains (strEnd)) {
        Start = strSource.IndexOf (strStart, 0) + strStart.Length;
        End = strSource.IndexOf (strEnd, Start);
        strSourceEnd = strSource.Length - 1;
        string strToReplace = strSource.Substring (Start, End - Start);
        string newString = string.Concat (strSource.Substring (0, Start), strReplace, strSource.Substring (Start + strToReplace.Length, strSourceEnd - Start));
        return newString;
    } else {
        return string.Empty;
    }
}

