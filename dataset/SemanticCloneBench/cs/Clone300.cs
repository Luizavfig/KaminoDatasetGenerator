/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4108828
*  Stack Overflow answer #:21056550
*  And Stack Overflow answer#:4108907
*/
public static bool HasFlag (this Enum e, Enum flag) {
    if (flag == null) {
        throw new ArgumentNullException ("flag");
    }
    if (e.GetType () != (flag.GetType ())) {
        throw new ArgumentException (string.Format ("The type of the given flag is not of type {0}", e.GetType ()), "flag");
    }
    var typeCode = e.GetTypeCode ();
    if (typeCode == TypeCode.SByte || typeCode == TypeCode.Int16 || typeCode == TypeCode.Int32 || typeCode == TypeCode.Int64) {
        return (Convert.ToInt64 (e) & Convert.ToInt64 (flag)) != 0;
    }
    if (typeCode == TypeCode.Byte || typeCode == TypeCode.UInt16 || typeCode == TypeCode.UInt32 || typeCode == TypeCode.UInt64) {
        return (Convert.ToUInt64 (e) & Convert.ToUInt64 (flag)) != 0;
    }
    throw new Exception (string.Format ("The comparison of the type {0} is not implemented.", e.GetType ().Name));
}

public static bool HasFlag (this Enum variable, Enum value) {
    if (variable == null)
        return false;
    if (value == null)
        throw new ArgumentNullException ("value");
    if (! Enum.IsDefined (variable.GetType (), value)) {
        throw new ArgumentException (string.Format ("Enumeration type mismatch.  The flag is of type '{0}', was expecting '{1}'.", value.GetType (), variable.GetType ()));
    }
    ulong num = Convert.ToUInt64 (value);
    return ((Convert.ToUInt64 (variable) & num) == num);
}

