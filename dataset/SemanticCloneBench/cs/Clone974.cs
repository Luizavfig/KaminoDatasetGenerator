/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10835083
*  Stack Overflow answer #:10835170
*  And Stack Overflow answer#:25535552
*/
bool AreSameAsMultiSets (List < T > first, List < T > second) {
    Dictionary < T, int > counts = new Dictionary < T, int > ();
    foreach (var item in first) {
        if (! counts.ContainsKey (item)) {
            counts.Add (item, 0);
        }
        counts [item] = counts [item] + 1;
    }
    foreach (var item in second) {
        if (! counts.ContainsKey (item)) {
            return false;
        }
        counts [item] = counts [item] - 1;
    }
    foreach (var entry in counts) {
        if (entry.Value != 0) {
            return false;
        }
    }
    return true;
}

[Test] public void ComparerIgnoreOrderSimpleArraysTest () {
    var a = new String [] {"A", "E", "F"};
    var b = new String [] {"A", "c", "d", "F"};
    var comparer = new CompareLogic ();
    comparer.Config.IgnoreCollectionOrder = true;
    comparer.Config.MaxDifferences = int.MaxValue;
    ComparisonResult result = comparer.Compare (a, b);
    Console.WriteLine (result.DifferencesString);
    Assert.IsTrue (result.Differences.Where (d = > d.Object1Value == "E").Count () == 1);
    Assert.IsTrue (result.Differences.Where (d = > d.Object2Value == "c").Count () == 1);
    Assert.IsTrue (result.Differences.Where (d = > d.Object2Value == "d").Count () == 1);
}

