/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14945478
*  Stack Overflow answer #:14945587
*  And Stack Overflow answer#:14945569
*/
public static bool IsSchoolYearFormat (string format, int minYear, int maxYear) {
    string [] parts = format.Trim ().Split (new [] {'-'}, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 2) {
        int fromYear;
        int toYear;
        if (int.TryParse (parts [0], out fromYear) && int.TryParse (parts [1], out toYear)) {
            if (fromYear >= minYear && toYear <= maxYear && fromYear + 1 == toYear)
                return true;
        }
    }
    return false;
}

public bool IsSchoolYearFormat (string toCheck) {
    string [] arr = toCheck.Trim ().Split ('-');
    if (arr.Length != 2) {
        return false;
    }
    int one, two;
    if (! int.TryParse (arr [0], out one)) {
        return false;
    }
    if (! int.TryParse (arr [1], out two)) {
        return false;
    }
    return two - 1 == one && two > 1900 && one > 1900;
}

