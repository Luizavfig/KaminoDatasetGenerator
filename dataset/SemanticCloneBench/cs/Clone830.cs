/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:39120429
*  Stack Overflow answer #:39120606
*  And Stack Overflow answer#:39120606
*/
public static void Main (string [] args) {
    List < Demo > all = new List < Demo > ();
    all.Add (new Demo {Name = "a"});
    all.Add (new Demo {Name = "ab"});
    all.Add (new Demo {Name = "abc"});
    all.Add (new Demo {Name = "cba"});
    all.Add (new Demo {Name = "bac"});
    all.Add (new Demo {Name = "ddd"});
    var t = Filter (all, "Name", "a");
    Console.WriteLine (t.Count);
}

public static List < T > Filter < T > (List < T > Filterable, string PropertyName, object ParameterValue) {
    ConstantExpression c = Expression.Constant (ParameterValue);
    ParameterExpression p = Expression.Parameter (typeof (T), "xx");
    MemberExpression m = Expression.PropertyOrField (p, PropertyName);
    MethodInfo method = typeof (string).GetMethod ("Contains", new [] {typeof (string)});
    var containsMethodExp = Expression.Call (m, method, c);
    var Lambda = Expression.Lambda < Func < T, bool > > (containsMethodExp, p);
    Func < T, Boolean > func = Lambda.Compile ();
    return Filterable.Where (func).ToList ();
}

