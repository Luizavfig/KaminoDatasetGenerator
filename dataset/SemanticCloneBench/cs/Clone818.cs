/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16529677
*  Stack Overflow answer #:16530075
*  And Stack Overflow answer#:16530075
*/
private static IEnumerable < Type > GetTypeArguments (Type t, IEnumerable < Type > values) {
    if (t.IsGenericType)
        foreach (var arg in t.GetGenericArguments ())
            values = values.Union (GetTypeArguments (arg, values));
    else
        values = values.Union (new [] {t});
    return values;
}

static void Main (string [] args) {
    var x = Tuple.Create (Guid.NewGuid (), new [] {1, 2, 3, 4, 5, 6});
    var serializer = DataContractSerializerFactory < Tuple < Guid, int [] > >.Create ();
    var sb = new StringBuilder ();
    using (var writer = XmlWriter.Create (sb))
    {
        serializer.WriteObject (writer, x);
        writer.Flush ();
        Console.WriteLine (sb.ToString ());
    }}

