/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2074283
*  Stack Overflow answer #:12426613
*  And Stack Overflow answer#:2074340
*/
static void WritePropertyNames () {
    TestObject lTestObject = new TestObject ();
    PropertyInfo [] lProperty = typeof (TestObject).GetProperties ();
    List < Expression > lExpressions = new List < Expression > ();
    MethodInfo lMethodInfo = typeof (Console).GetMethod ("WriteLine", new Type [] {typeof (string)});
    lProperty.ForEach (x = > {
        ConstantExpression lConstant = Expression.Constant (x.Name);
        MethodCallExpression lMethodCall = Expression.Call (lMethodInfo, lConstant);
        lExpressions.Add (lMethodCall);
    });
    BlockExpression lBlock = Expression.Block (lExpressions);
    LambdaExpression lLambda = Expression.Lambda < Action > (lBlock, null);
    Action lWriteProperties = lLambda.Compile () as Action;
    lWriteProperties ();
}

static Action < T > CreateAction < T > () {
    Action < T > result = null;
    var param = Expression.Parameter (typeof (T), "obj");
    foreach (var property in typeof (T).GetProperties (BindingFlags.Instance | BindingFlags.Public)) {
        if (property.GetIndexParameters ().Length > 0)
            continue;
        var propVal = Expression.Property (param, property);
        var call = Expression.Call (typeof (SomeType), "SomeMethod", new Type [] {propVal.Type}, propVal);
        result += Expression.Lambda < Action < T > > (call, param).Compile ();
    }
    return result;
}

