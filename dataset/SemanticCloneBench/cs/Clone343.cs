/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30180672
*  Stack Overflow answer #:30181106
*  And Stack Overflow answer#:30181358
*/
private static string FormatNumber (long num) {
    long i = (long) Math.Pow (10, (int) Math.Max (0, Math.Log10 (num) - 2));
    num = num / i * i;
    if (num >= 1000000000)
        return (num / 1000000000D).ToString ("0.##") + "B";
    if (num >= 1000000)
        return (num / 1000000D).ToString ("0.##") + "M";
    if (num >= 1000)
        return (num / 1000D).ToString ("0.##") + "K";
    return num.ToString ("#,0");
}

static string FormatNumber (uint n) {
    if (n < 1000)
        return n.ToString ();
    if (n < 10000)
        return String.Format ("{0:#,.##}K", n - 5);
    if (n < 100000)
        return String.Format ("{0:#,.#}K", n - 50);
    if (n < 1000000)
        return String.Format ("{0:#,.}K", n - 500);
    if (n < 10000000)
        return String.Format ("{0:#,,.##}M", n - 5000);
    if (n < 100000000)
        return String.Format ("{0:#,,.#}M", n - 50000);
    if (n < 1000000000)
        return String.Format ("{0:#,,.}M", n - 500000);
    return String.Format ("{0:#,,,.##}B", n - 5000000);
}

