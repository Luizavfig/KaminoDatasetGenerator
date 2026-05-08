/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2820660
*  Stack Overflow answer #:2820693
*  And Stack Overflow answer#:21296841
*/
private static string GetPropertyName < TPropertySource > (Expression < Func < TPropertySource, object > > expression) {
    var lambda = expression as LambdaExpression;
    MemberExpression memberExpression;
    if (lambda.Body is UnaryExpression) {
        var unaryExpression = lambda.Body as UnaryExpression;
        memberExpression = unaryExpression.Operand as MemberExpression;
    } else {
        memberExpression = lambda.Body as MemberExpression;
    }
    Debug.Assert (memberExpression != null, "Please provide a lambda expression like 'n => n.PropertyName'");
    if (memberExpression != null) {
        var propertyInfo = memberExpression.Member as PropertyInfo;
        return propertyInfo.Name;
    }
    return null;
}

public static string GetPropertyName < T > (Expression < Func < T > > propertyLambda) {
    MemberExpression me = propertyLambda.Body as MemberExpression;
    if (me == null) {
        throw new ArgumentException ("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
    }
    string result = string.Empty;
    do
        {
            result = me.Member.Name + "." + result;
            me = me.Expression as MemberExpression;
        } while (me != null);
    result = result.Remove (result.Length - 1);
    return result;
}

