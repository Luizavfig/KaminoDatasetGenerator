/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:43599159
*  Stack Overflow answer #:43610280
*  And Stack Overflow answer#:43610280
*/
public bool doFindSum (ref int [] nums, int index, int current, int target) {
    numberCalled ++;
    if (index + 1 == nums.Length) {
        if (current == target) {
            ++ answer;
            return true;
        } else {
            return false;
        }
    }
    bool add = doFindSum (ref nums, index + 1, current + nums [index + 1], target);
    bool minus = doFindSum (ref nums, index + 1, current - nums [index + 1], target);
    return add || minus;
}

public int doFindSum (ref int [] nums, int index, int current, int target) {
    numberCalled ++;
    Tuple < int, int > tp = new Tuple < int, int > (index + 1, current);
    int value;
    if (dp.TryGetValue (tp, out value)) {
        tp1 ++;
        return value;
    }
    if (index + 1 == nums.Length) {
        if (current == target) {
            if (! dp.ContainsKey (tp)) {
                dp.Add (tp, 1);
                return 1;
            }
        }
        return 0;
    }
    int add = doFindSum (ref nums, index + 1, current + nums [index + 1], target);
    int minus = doFindSum (ref nums, index + 1, current - nums [index + 1], target);
    if ((! dp.ContainsKey (tp))) {
        dp.Add (tp, add + minus);
    }
    return add + minus;
}

