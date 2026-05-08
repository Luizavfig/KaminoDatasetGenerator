/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35348969
*  Stack Overflow answer #:35348993
*  And Stack Overflow answer#:35349114
*/
public double convertToDouble (string number) {
    if (string.IsNullOrWhiteSpace (number)) {
        throw new ArgumentException ("The input cannot be null, empty string or consisted only of of white space characters", "number");
    }
    string temp = number;
    if (number.Contains ("x")) {
        int locationE = number.IndexOf ("x");
        string exponent = number.Substring (locationE + 5, number.Length - (locationE + 5));
        temp = number.Substring (0, locationE - 1) + "E" + exponent;
    }
    return Convert.ToDouble (temp);
}

public double convertToDouble (string number) {
    string temp = number;
    if (number.Contains ("x")) {
        int locationE = number.IndexOf ("x");
        string exponent = number.Substring (locationE + 5, number.Length - (locationE + 5));
        temp = number.Substring (0, locationE - 1) + "E" + exponent;
    }
    double returnDouble;
    if (double.TryParse (temp, out returnDouble))
        return returnDouble;
    return 0;
}

