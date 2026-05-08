/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:914929
*  Stack Overflow answer #:914933
*  And Stack Overflow answer#:914964
*/
public static string RatingCalculator (int input) {
    if (input < 10) {
        return string.Empty;
    } else if (input < 20) {
        return "<img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star_empty.png\" alt=\"-\" /><img src=\"/images/star_empty.png\" alt=\"-\" /><img src=\"/images/star_empty.png\" alt=\"-\" /><img src=\"/images/star_empty.png\" alt=\"-\" />";
    } else if (input < 40) {
        return "<img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star_empty.png\" alt=\"-\" /><img src=\"/images/star_empty.png\" alt=\"-\" /><img src=\"/images/star_empty.png\" alt=\"-\" />";
    } else if (input < 70) {
        return "<img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star_empty.png\" alt=\"-\" /><img src=\"/images/star_empty.png\" alt=\"-\" />";
    } else if (input < 120) {
        return "<img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star_empty.png\" alt=\"-\" />";
    } else {
        return "<img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" /><img src=\"/images/star.png\" alt=\"*\" />";
    }
}

public static string RatingCalculator (int input) {
    int numStars;
    if (input < 10)
        return string.Empty;
    else if (input < 20)
        numStars = 1;
    else if (input < 40)
        numStars = 2;
    else if (input < 70)
        numStars = 3;
    else if (input < 120)
        numStars = 4;
    else
        numStars = 5;
    var sb = new StringBuilder ();
    for (int i = 0; i < numStars; i ++)
        sb.Append ("<img src=\"/images/star.png\" alt=\"*\" />");
    for (int i = numStars; i < 5; i ++)
        sb.Append ("<img src=\"/images/star_empty.png\" alt=\"-\" />");
    return sb.ToString ();
}

