/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14129421
*  Stack Overflow answer #:14129466
*  And Stack Overflow answer#:14129580
*/
void Main () {
    Foo < int > fooObject = new Foo < int > ();
    fooObject.Items = new List < int > {1, 2, 3};
    object obj = (object) fooObject;
    PropertyInfo propInfo = obj.GetType ().GetProperty ("Items");
    object itemValue = propInfo.GetValue (obj, null);
    Console.WriteLine (itemValue);
    IList values = (IList) itemValue;
    foreach (var val in values)
        Console.WriteLine (val);
}

public void WhatsaFoo (object obj) {
    var genericType = obj.GetType ().GetGenericTypeDefinition ();
    if (genericType == typeof (Foo < >)) {
        var genArgs = obj.GetType ().GetGenericArguments ();
        var typedVariant = genericType.MakeGenericType (genArgs);
        var typeofT = obj.GetType ().GetGenericArguments ().First ();
        var itemsOf = typedVariant.GetProperty ("Items").GetValue (obj, null);
    }
}

