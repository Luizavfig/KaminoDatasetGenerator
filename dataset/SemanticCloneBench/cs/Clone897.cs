/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:954198
*  Stack Overflow answer #:954282
*  And Stack Overflow answer#:954233
*/
public static string Debugify (this DbParameterCollection parameters) {
    List < string > ParameterValuesList = new List < string > ();
    foreach (DbParameter Parameter in parameters) {
        string ParameterName, ParameterValue;
        ParameterName = Parameter.ParameterName;
        if (Parameter.Direction == ParameterDirection.ReturnValue)
            continue;
        if (Parameter.Value == null || Parameter.Value.Equals (DBNull.Value))
            ParameterValue = "NULL";
        else {
            switch (Parameter.DbType) {
                case DbType.String : case DbType.Date : case DbType.DateTime : case DbType.Guid : case DbType.Xml :
                    ParameterValue = "'" + Parameter.Value.ToString ().Replace (Environment.NewLine, "").Left (80, "...") + "'";
                    break;
                default :
                    ParameterValue = Parameter.Value.ToString ();
                    break;
            }
            if (Parameter.Direction != ParameterDirection.Input)
                ParameterValue += " " + Parameter.Direction.ToString ();
        }
        ParameterValuesList.Add (string.Format ("{0}={1}", ParameterName, ParameterValue));
    }
    return string.Join (", ", ParameterValuesList.ToArray ());
}

public static IEnumerable < string > IntRanges (this IEnumerable < int > numbers) {
    int rangeStart = 0;
    int previous = 0;
    if (! numbers.Any ())
        yield break;
    rangeStart = previous = numbers.FirstOrDefault ();
    foreach (int n in numbers.Skip (1)) {
        if (n - previous > 1) {
            if (previous > rangeStart) {
                yield return string.Format ("{0}-{1}", rangeStart, previous);
            } else {
                yield return rangeStart.ToString ();
            }
            rangeStart = n;
        }
        previous = n;
    }
    if (previous > rangeStart) {
        yield return string.Format ("{0}-{1}", rangeStart, previous);
    } else {
        yield return rangeStart.ToString ();
    }
}

