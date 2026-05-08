/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10353627
*  Stack Overflow answer #:10353871
*  And Stack Overflow answer#:10353652
*/
public static T Map < T > (Dictionary < string, string > dictionary) where T : class, new () {
    var obj = new T ();
    var properties = typeof (T).GetProperties ();
    foreach (var item in dictionary) {
        var prop = properties.FirstOrDefault (p = > p.Name.Equals (item.Key, StringComparison.InvariantCultureIgnoreCase));
        if (prop != null)
            prop.SetValue (obj, item.Value, null);
    }
    return obj;
}

public Person Map (Dictionary < string, string > row) {
    var p = new Person ();
    if (row.ContainsKey ("name"))
        Person.Name = row ["name"];
    if (row.ContainsKey ("age"))
        Person.Age = row ["age"];
    return p;
}

