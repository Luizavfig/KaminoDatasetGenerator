/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:46955226
*  Stack Overflow answer #:46970185
*  And Stack Overflow answer#:46970259
*/
public static int [] Find (int totalItems, int [] values, int totalTobeSelected) {
    var result = new List < int > ();
    if (totalTobeSelected <= 1) {
        result.Add (values.Max ());
    } else if (totalTobeSelected == totalItems) {
        result.AddRange (values.OrderBy (i = > i).ToList ());
    } else {
        var mainSet = values.OrderBy (i = > i).ToList ();
        var setDic = new Dictionary < int, IEnumerable < int > > ();
        for (int i = 0; (totalItems - i >= totalTobeSelected); i ++) {
            var set = mainSet.GetRange (i, totalTobeSelected);
            var diff = Math.Abs (set [0] - set [1]);
            if (setDic.ContainsKey (diff))
                continue;
            setDic.Add (diff, set);
        }
        if (setDic.Count > 0) {
            var minKey = setDic.Keys.Min ();
            result.AddRange (setDic [minKey]);
        }
    }
    return result.ToArray ();
}

public static int [] Find (int totalItems, int [] values, int totalToBeSelected) {
    Array.Sort (values);
    Array.Reverse (values);
    int diff = values [0];
    int indx = 0;
    for (int i = 0; i < totalItems - totalToBeSelected + 1; i ++) {
        int temp_diff = values [i] - values [i + totalToBeSelected - 1];
        if (temp_diff < diff) {
            diff = temp_diff;
            indx = i;
        }
    }
    int [] results = new int [totalToBeSelected];
    Array.Copy (values, indx, results, 0, totalToBeSelected);
    return results;
}

