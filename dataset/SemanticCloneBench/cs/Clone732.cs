/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:406485
*  Stack Overflow answer #:26562389
*  And Stack Overflow answer#:18628506
*/
public static T [] Slice < T > (this T [] arr, int offset, int length) {
    int start, end;
    if (offset < 0)
        start = arr.Length + offset;
    else
        start = offset;
    if (start < 0)
        start = 0;
    else if (start > arr.Length)
        start = arr.Length;
    if (length < 0)
        end = arr.Length + length;
    else
        end = start + length;
    if (end < 0)
        end = 0;
    if (end > arr.Length)
        end = arr.Length;
    int len = end - start;
    T [] result = new T [len];
    for (int i = 0; i < len; i ++) {
        result [i] = arr [start + i];
    }
    return result;
}

public IEnumerable < IEnumerable < T > > Slice () {
    var length = _steps.Length;
    var index = 1;
    var step = 0;
    for (var i = 0; _isHasNext; ++ i) {
        if (i < length) {
            step = _steps [i];
            _currentStep = step - 1;
        }
        while (_index < index && _isHasNext) {
            _isHasNext = MoveNext ();
        }
        if (_isHasNext) {
            yield return SliceInternal ();
            index += step;
        }
    }
}

