/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8360360
*  Stack Overflow answer #:8360541
*  And Stack Overflow answer#:43746975
*/
public string ShrinkPath (string path, int maxLength) {
    List < string > parts = new List < string > (path.Split ('\\'));
    string start = parts [0] + @"\" + parts [1];
    parts.RemoveAt (1);
    parts.RemoveAt (0);
    string end = parts [parts.Count - 1];
    parts.RemoveAt (parts.Count - 1);
    parts.Insert (0, "...");
    while (parts.Count > 1 && start.Length + end.Length + parts.Sum (p = > p.Length) + parts.Count > maxLength)
        parts.RemoveAt (parts.Count - 1);
    string mid = "";
    parts.ForEach (p = > mid += p + @"\");
    return start + mid + end;
}

private string ShrinkPath (string path, int maxLength) {
    var parts = path.Split ('\\');
    var output = String.Join ("\\", parts, 0, parts.Length);
    var endIndex = (parts.Length - 1);
    var startIndex = endIndex / 2;
    var index = startIndex;
    var step = 0;
    while (output.Length >= maxLength && index != 0 && index != endIndex) {
        parts [index] = "...";
        output = String.Join ("\\", parts, 0, parts.Length);
        if (step >= 0)
            step ++;
        step = (step * - 1);
        index = startIndex + step;
    }
    return output;
}

