/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32778070
*  Stack Overflow answer #:32778575
*  And Stack Overflow answer#:32778261
*/
private bool IsAnagramFast (string a, string b) {
    if (a.Length != b.Length) {
        return false;
    }
    var aFrequency = CalculateFrequency (a);
    var bFrequency = CalculateFrequency (b);
    foreach (var key in aFrequency.Keys) {
        if (! bFrequency.ContainsKey (key))
            return false;
        if (aFrequency [key] != bFrequency [key])
            return false;
    }
    return true;
}

public void Main () {
    string str1 = "dog";
    string str2 = "god";
    bool isAnagram = (((str1 + str2).Any (c = > str1.Count (x = > x == c) != str2.Count (x = > x == c))));
    if (isAnagram) {
        Console.WriteLine ("no anagram");
    } else {
        Console.WriteLine ("Anagram");
    }
}

