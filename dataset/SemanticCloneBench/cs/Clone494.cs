/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11569593
*  Stack Overflow answer #:11570580
*  And Stack Overflow answer#:11569820
*/
static void Prepare (params Type [] types) {
    foreach (var type in types) {
        if (type != null && ! RuntimeTypeModel.Default.IsDefined (type)) {
            if (type.Namespace.StartsWith ("System"))
                return;
            Debug.WriteLine ("Preparing: " + type.FullName);
            var props = type.GetProperties ();
            Array.Sort (props, (x, y) = > string.Compare (x.Name, y.Name, StringComparison.Ordinal));
            var meta = RuntimeTypeModel.Default.Add (type, false);
            int fieldNum = 1;
            for (int i = 0; i < props.Length; i ++)
                if (props [i].CanWrite) {
                    meta.Add (fieldNum ++, props [i].Name);
                    if (! RuntimeTypeModel.Default.IsDefined (props [i].PropertyType))
                        if (props [i].PropertyType.HasElementType)
                            Prepare (props [i].PropertyType.GetElementType ());
                        else if (props [i].PropertyType.IsGenericType)
                            Prepare (props [i].PropertyType.GetGenericArguments ());
                        else
                            Prepare (props [i].PropertyType);
                }
        }
    }
}

static void Prepare (Type type) {
    if (type != null && ! RuntimeTypeModel.Default.IsDefined (type)) {
        Debug.WriteLine ("Preparing: " + type.FullName);
        var props = type.GetProperties ();
        Array.Sort (props, (x, y) = > string.Compare (x.Name, y.Name, StringComparison.Ordinal));
        var meta = RuntimeTypeModel.Default.Add (type, false);
        int fieldNum = 1;
        for (int i = 0; i < props.Length; i ++) {
            meta.Add (fieldNum ++, props [i].Name);
        }
    }
}

