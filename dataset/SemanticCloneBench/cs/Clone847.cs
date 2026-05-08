/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:39786191
*  Stack Overflow answer #:39786448
*  And Stack Overflow answer#:39787148
*/
private static IEnumerable < int > Approximations (IEnumerable < int > values, int target) {
    int sum = 0;
    bool first = true;
    foreach (var item in values) {
        if (sum + item < target || first) {
            first = false;
            sum += item;
        } else {
            if (sum + item - target < target - sum) {
                yield return sum + item;
                sum = 0;
                first = true;
            } else {
                yield return sum;
                sum = item;
            }
        }
    }
    if (first)
        yield break;
    yield return sum;
}

static IEnumerable < int > EnumNearestSums (IList < int > list, int z) {
    var target = (int) (list.Sum () / (double) z + 0.5);
    var index = 0;
    for (int i = 0; i < z; i ++) {
        var sum = 0;
        for (int j = index; j < list.Count; j ++) {
            index ++;
            var tmp = sum + list [j];
            if (tmp > target) {
                if (Math.Abs (target - sum) < Math.Abs (target - tmp)) {
                    index --;
                } else {
                    sum = tmp;
                }
                break;
            } else {
                sum = tmp;
            }
        }
        yield return sum;
    }
}

