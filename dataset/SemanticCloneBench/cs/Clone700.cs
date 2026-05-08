/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:52404957
*  Stack Overflow answer #:52405519
*  And Stack Overflow answer#:52405524
*/
public void Update1 (T obj, string [] input, object newval) {
    Type t = typeof (T);
    var param1 = Expression.Parameter (t);
    Expression exp = param1;
    foreach (var it in input.Skip (1).Take (input.Length - 2)) {
        var minfo = t.GetProperty (it).GetGetMethod ();
        exp = Expression.Call (exp, minfo);
        t = minfo.ReturnType;
    }
    var lastprop = t.GetProperty (input.Last ());
    var minfoset = lastprop.GetSetMethod ();
    var variableexp = Expression.Variable (lastprop.PropertyType);
    exp = Expression.Call (exp, minfoset, variableexp);
    var lambda = Expression.Lambda (exp, param1, variableexp);
    lambda.Compile ().DynamicInvoke (obj, newval);
}

void Update (object obj, string navigation, object newval) {
    var firstSlash = navigation.IndexOf ("/");
    if (firstSlash < 0) {
        obj.GetType ().GetProperty (navigation).SetValue (obj, newval);
    } else {
        var header = navigation.Substring (0, firstSlash);
        var tail = navigation.Substring (firstSlash + 1);
        var subObj = obj.GetType ().GetProperty (header).GetValue (obj);
        Update (subObj, tail, newval);
    }
}

