/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14666275
*  Stack Overflow answer #:14666338
*  And Stack Overflow answer#:14666390
*/
public static double Pow (double basevalue, int exponentvalue) {
    if (exponentvalue == 0) {
        return 1;
    }
    if (exponentvalue == 1) {
        return baseValue;
    }
    return baseValue * Pow (basevalue, exponentvalue - 1);
}

internal static double Pow (double @base, int exponent) {
    if (exponent < 0) {
        Console.Error.WriteLine ("Usage of this function is limited to positive exponents only");
        throw new Exception ();
    } else if (exponent == 1) {
        return @base;
    } else if (exponent == 0) {
        return 1;
    } else {
        return @base * Pow (@base, exponent - 1);
    }
}

