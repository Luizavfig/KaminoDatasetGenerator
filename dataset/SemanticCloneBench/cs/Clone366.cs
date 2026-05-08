/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5156664
*  Stack Overflow answer #:5157855
*  And Stack Overflow answer#:5607010
*/
public static string Flatten (this ExpandoObject expando) {
    StringBuilder sb = new StringBuilder ();
    List < string > contents = new List < string > ();
    var d = expando as IDictionary < string, object >;
    sb.Append ("{");
    foreach (KeyValuePair < string, object > kvp in d) {
        contents.Add (String.Format ("{0}: {1}", kvp.Key, JsonConvert.SerializeObject (kvp.Value)));
    }
    sb.Append (String.Join (",", contents.ToArray ()));
    sb.Append ("}");
    return sb.ToString ();
}

public string Flatten (ExpandoObject expando) {
    StringBuilder sb = new StringBuilder ();
    List < string > contents = new List < string > ();
    var d = expando as IDictionary < string, object >;
    sb.Append ("{ ");
    foreach (KeyValuePair < string, object > kvp in d) {
        if (kvp.Value is ExpandoObject) {
            ExpandoObject expandoValue = (ExpandoObject) kvp.Value;
            StringBuilder expandoBuilder = new StringBuilder ();
            expandoBuilder.Append (String.Format ("\"{0}\":[", kvp.Key));
            String flat = Flatten (expandoValue);
            expandoBuilder.Append (flat);
            string expandoResult = expandoBuilder.ToString ();
            expandoResult += "]";
            contents.Add (expandoResult);
        } else if (kvp.Value is List < Object >) {
            List < Object > valueList = (List < Object >) kvp.Value;
            StringBuilder listBuilder = new StringBuilder ();
            listBuilder.Append (String.Format ("\"{0}\":[", kvp.Key));
            foreach (Object item in valueList) {
                if (item is ExpandoObject) {
                    String flat = Flatten (item as ExpandoObject);
                    listBuilder.Append (flat + ",");
                }
            }
            string listResult = listBuilder.ToString ();
            listResult = listResult.Remove (listResult.Length - 1);
            listResult += "]";
            contents.Add (listResult);
        } else {
            contents.Add (String.Format ("\"{0}\": {1}", kvp.Key, JsonSerializer.Serialize (kvp.Value)));
        }
    }
    sb.Append (String.Join (",", contents.ToArray ()));
    sb.Append ("}");
    return sb.ToString ();
}

