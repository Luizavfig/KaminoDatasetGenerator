/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2852161
*  Stack Overflow answer #:9715762
*  And Stack Overflow answer#:14361882
*/
private static Func < TArg, TRes > Memoize < TArg, TRes > (Func < TArg, TRes > func) {
    var cache = new Dictionary < TArg, TRes > ();
    return arg = > {
        TRes res;
        if (! cache.TryGetValue (arg, out res)) {
            Console.WriteLine ("Calculating " + arg.ToString ());
            res = func (arg);
            cache.Add (arg, res);
        } else {
            Console.WriteLine ("Getting from cache " + arg.ToString ());
        }
        return res;
    };
}

public static Func < R > Memoize < R > (this Func < R > f) {
    bool hasBeenCalled = false;
    R returnVal = default (R);
    return () = > {
        if (! hasBeenCalled) {
            hasBeenCalled = true;
            returnVal = f ();
        }
        return returnVal;
    };
}

