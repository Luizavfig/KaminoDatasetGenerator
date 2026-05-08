/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5262693
*  Stack Overflow answer #:5265378
*  And Stack Overflow answer#:5265378
*/
private ObjectActivator CreateActivator (ConstructorInfo ctor) {
    Type type = ctor.DeclaringType;
    ParameterInfo [] paramsInfo = ctor.GetParameters ();
    ParameterExpression param = Expression.Parameter (typeof (object []), "args");
    Expression [] argsExp = new Expression [paramsInfo.Length];
    for (int i = 0; i < paramsInfo.Length; i ++) {
        Expression index = Expression.Constant (i);
        Type paramType = paramsInfo [i].ParameterType;
        Expression paramAccessorExp = Expression.ArrayIndex (param, index);
        Expression paramCastExp = Expression.Convert (paramAccessorExp, paramType);
        argsExp [i] = paramCastExp;
    }
    NewExpression newExp = Expression.New (ctor, argsExp);
    LambdaExpression lambda = Expression.Lambda (typeof (ObjectActivator), newExp, param);
    return (ObjectActivator) lambda.Compile ();
}

private ObjectActivator CreateActivator (string className) {
    Type type = Type.GetType (className);
    if (type == null)
        throw new ArgumentException ("Incorrect class name", "className");
    ConstructorInfo ctor = type.GetConstructors ().SingleOrDefault (w = > w.GetParameters ().Length == 1 && w.GetParameters () [0].ParameterType == typeof (object));
    if (ctor == null)
        throw new Exception ("There is no any constructor with 1 object parameter.");
    return CreateActivator (ctor);
}

