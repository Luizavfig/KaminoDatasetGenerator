/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15733713
*  Stack Overflow answer #:15733795
*  And Stack Overflow answer#:17377672
*/
protected override object GetInstance (string key, Type service) {
    var serviceType = service;
    if (serviceType == null) {
        var typeName = Assembly.GetExecutingAssembly ().DefinedTypes.Where (x = > x.Name == key).Select (x = > x.FullName).FirstOrDefault ();
        if (typeName == null)
            throw new InvalidOperationException ("No matching type found");
        serviceType = Type.GetType (typeName);
    }
    return container.GetInstance (serviceType);
}

protected override object GetInstance (Type type, string name) {
    var result = default (object);
    if (name != null) {
        result = Container.Resolve (type, name);
    } else {
        result = Container.Resolve (type);
    }
    return result;
}

