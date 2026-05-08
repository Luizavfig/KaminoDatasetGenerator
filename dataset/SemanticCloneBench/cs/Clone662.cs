/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19188630
*  Stack Overflow answer #:19190140
*  And Stack Overflow answer#:19192237
*/
private static IEnumerable < T [] > EnumerateCombos < T > (IEnumerable < T > items, List < T > currentCombo, int startIndex, int threshold) {
    if (currentCombo.Count >= threshold) {
        yield break;
    }
    for (int i = startIndex; i < items.Count (); i ++) {
        var item = items.Skip (i).First ();
        currentCombo.Add (item);
        yield return currentCombo.ToArray ();
        foreach (var combo in EnumerateCombos (items, currentCombo, i + 1, threshold)) {
            yield return combo;
        }
        currentCombo.RemoveAt (currentCombo.Count - 1);
    }
}

public static IEnumerable < IEnumerable < T > > GetCombinations < T > (IEnumerable < T > values, int threshold) {
    var remaining = values;
    foreach (T value in values) {
        yield return value.Yield ();
        if (threshold < 2) {
            continue;
        }
        remaining = remaining.Skip (1);
        foreach (var combination in GetCombinations (remaining, threshold - 1)) {
            yield return value.Yield ().Concat (combination);
        }
    }
}

