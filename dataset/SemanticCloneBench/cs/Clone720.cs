/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4171140
*  Stack Overflow answer #:4171168
*  And Stack Overflow answer#:42008114
*/
private static IEnumerable < Enum > GetFlags (Enum value, Enum [] values) {
    ulong bits = Convert.ToUInt64 (value);
    List < Enum > results = new List < Enum > ();
    for (int i = values.Length - 1; i >= 0; i --) {
        ulong mask = Convert.ToUInt64 (values [i]);
        if (i == 0 && mask == 0L)
            break;
        if ((bits & mask) == mask) {
            results.Add (values [i]);
            bits -= mask;
        }
    }
    if (bits != 0L)
        return Enumerable.Empty < Enum > ();
    if (Convert.ToUInt64 (value) != 0L)
        return results.Reverse < Enum > ();
    if (bits == Convert.ToUInt64 (value) && values.Length > 0 && Convert.ToUInt64 (values [0]) == 0L)
        return values.Take (1);
    return Enumerable.Empty < Enum > ();
}

public static IEnumerable < T > GetUniqueFlags < T > (this Enum flags) {
    if (! typeof (T).IsEnum)
        throw new ArgumentException ("The generic type parameter must be an Enum.");
    if (flags.GetType () != typeof (T))
        throw new ArgumentException ("The generic type parameter does not match the target type.");
    ulong flag = 1;
    foreach (var value in Enum.GetValues (flags.GetType ()).Cast < T > ()) {
        ulong bits = Convert.ToUInt64 (value);
        while (flag < bits) {
            flag <<= 1;
        }
        if (flag == bits && flags.HasFlag (value as Enum)) {
            yield return value;
        }
    }
}

