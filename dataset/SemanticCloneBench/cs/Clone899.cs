/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12043875
*  Stack Overflow answer #:12044261
*  And Stack Overflow answer#:12044807
*/
public static T ThrowIfNull < T > (this T target, params Expression < Func < T, object > > [] exprs) {
    foreach (var e in exprs) {
        var exp = e.Body as MemberExpression;
        if (exp == null) {
            throw new ArgumentException ("Argument 'expr' must be of the form x=>x.variableName");
        }
        var name = exp.Member.Name;
        if (e.Compile () (target) == null)
            throw new ArgumentNullException (name, "Parameter [" + name + "] can not be null");
    }
    return target;
}

public static string GetName (this Expression < Func < object > > expr) {
    if (expr.Body.NodeType == ExpressionType.MemberAccess)
        return ((MemberExpression) expr.Body).Member.Name;
    if (expr.Body.NodeType == ExpressionType.Convert && ((UnaryExpression) expr.Body).Operand.NodeType == ExpressionType.MemberAccess)
        return ((MemberExpression) ((UnaryExpression) expr.Body).Operand).Member.Name;
    throw new ArgumentException ("Argument 'expr' must be of the form ()=>variableName.");
}

