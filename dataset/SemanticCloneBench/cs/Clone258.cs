/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33947113
*  Stack Overflow answer #:33947224
*  And Stack Overflow answer#:33947289
*/
internal static MyEnum [] GetFlags (this MyEnum modKey) {
    List < MyEnum > flags = new List < MyEnum > ();
    foreach (var flag in Enum.GetValues (typeof (MyEnum))) {
        if (modKey & flag == flag)
            flags.Add ((MyEnum) flag);
    }
    return flags.ToArray ();
}

internal static MyEnum [] GetFlags (this MyEnum modKey) {
    List < MyEnum > result = new List < MyEnum > ();
    while (modKey != 0) {
        var highestFlag = Enum.GetValues (typeof (MyEnum)).Cast < MyEnum > ().OrderByDescending (v = > v).FirstOrDefault (v = > modKey.HasFlag (v));
        result.Add (highestFlag);
        modKey ^= highestFlag;
    }
    return result.ToArray ();
}

