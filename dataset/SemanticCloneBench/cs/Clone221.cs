/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5024375
*  Stack Overflow answer #:5024675
*  And Stack Overflow answer#:5024705
*/
private static double GetHeadingError (double initial, double final) {
    if (initial > 360 || initial < 0 || final > 360 || final < 0) {
    }
    var diff = final - initial;
    var absDiff = Math.Abs (diff);
    if (absDiff <= 180) {
        return absDiff == 180 ? absDiff : diff;
    } else if (final > initial) {
        return absDiff - 360;
    } else {
        return 360 - absDiff;
    }
}

private double GetHeadingError (double initial, double final) {
    if (initial == 360)
        initial = 0;
    if (final == 360)
        final = 0;
    double clockWise = (final - initial);
    double counterClockWise = (360 - final + initial);
    return (Math.Abs (clockWise) <= Math.Abs (counterClockWise)) ? clockWise : - counterClockWise;
}

