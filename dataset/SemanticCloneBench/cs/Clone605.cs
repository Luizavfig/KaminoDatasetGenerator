/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17672481
*  Stack Overflow answer #:17672752
*  And Stack Overflow answer#:17679322
*/
public static bool ChainNotNull < TFirst, TSecond, TThird, TFourth > (TFirst item1, Func < TFirst, TSecond > getItem2, Func < TSecond, TThird > getItem3, Func < TThird, TFourth > getItem4) {
    if (item1 == null)
        return false;
    var item2 = getItem2 (item1);
    if (item2 == null)
        return false;
    var item3 = getItem3 (item2);
    if (item3 == null)
        return false;
    var item4 = getItem4 (item3);
    if (item4 == null)
        return false;
    return true;
}

public static TOut ValueOrDefault < TIn, TOut > (this TIn input, Func < TIn, TOut > projection, TOut defaultValue) {
    try {
        var result = projection (input);
        if (result == null)
            result = defaultValue;
        return result;
    }
    catch (NullReferenceException) {
        return defaultValue;
    }
    catch (InvalidOperationException) {
        return defaultValue;
    }
}

