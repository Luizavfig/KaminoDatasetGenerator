/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1539989
*  Stack Overflow answer #:1540309
*  And Stack Overflow answer#:1540309
*/
private bool Matches (object expectedValue, object actualValue) {
    bool matches = true;
    if (! MatchesNull (expectedValue, actualValue, ref matches)) {
        return matches;
    }
    Constraint eq = new DatesEqualConstraint (expectedValue).Within (tolerance ?? _regionalTolerance);
    if (eq.Matches (actualValue)) {
        return true;
    }
    if (MatchesVisited (expectedValue, actualValue, ref matches)) {
        if (MatchesDictionary (expectedValue, actualValue, ref matches) && MatchesList (expectedValue, actualValue, ref matches) && MatchesType (expectedValue, actualValue, ref matches) && MatchesPredicate (expectedValue, actualValue, ref matches)) {
            MatchesFields (expectedValue, actualValue, eq, ref matches);
        }
    }
    return matches;
}

public override bool Matches (object actualValue) {
    if (tolerance != null && tolerance is TimeSpan) {
        if (_expected is DateTime && actualValue is DateTime) {
            var expectedDate = (DateTime) _expected;
            var actualDate = (DateTime) actualValue;
            var toleranceSpan = (TimeSpan) tolerance;
            if ((actualDate - expectedDate).Duration () <= toleranceSpan) {
                return true;
            }
        }
        tolerance = null;
    }
    return base.Matches (actualValue);
}

