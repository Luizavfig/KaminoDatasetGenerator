/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5595338
*  Stack Overflow answer #:5595591
*  And Stack Overflow answer#:24824290
*/
public static IQueryable < TEntity > Where < TEntity > (this IQueryable < TEntity > source, IEnumerable < WhereSpecifier > orClauses) where TEntity : class {
    if (! orClauses.Any ())
        return source.Where (t = > false);
    Type type = typeof (TEntity);
    ParameterExpression parameter = null;
    Expression predicate = Expression.Constant (false, typeof (bool));
    ParameterExpression whereEnt = Expression.Parameter (type, "WhereEnt");
    foreach (WhereSpecifier orClause in orClauses) {
        Expression selector;
        if (orClause.Selector != null) {
            selector = orClause.Selector;
            parameter = orClause.Parameter;
        } else {
            parameter = whereEnt;
            Type selectorResultType;
            selector = GenerateSelector < TEntity > (parameter, orClause.Column, out selectorResultType);
        }
        Expression clause = selector.CallMethod (orClause.Method, MakeConstant (selector.Type, orClause.Value), orClause.Modifiers);
        predicate = Expression.Or (predicate, clause);
    }
    var lambda = Expression.Lambda (predicate, whereEnt);
    var resultExp = Expression.Call (typeof (Queryable), "Where", new [] {type}, source.Expression, Expression.Quote (lambda));
    return source.Provider.CreateQuery < TEntity > (resultExp);
}

public static Expression < Func < T, bool > > And < T > (this Expression < Func < T, bool > > leftExpression, Expression < Func < T, bool > > rightExpression) {
    if (leftExpression == null)
        return rightExpression;
    if (rightExpression == null)
        return leftExpression;
    var paramExpr = Expression.Parameter (typeof (T));
    var exprBody = Expression.And (leftExpression.Body, rightExpression.Body);
    exprBody = (BinaryExpression) new ParameterReplacer (paramExpr).Visit (exprBody);
    return Expression.Lambda < Func < T, bool > > (exprBody, paramExpr);
}

