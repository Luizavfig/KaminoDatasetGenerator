/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11248585
*  Stack Overflow answer #:11248725
*  And Stack Overflow answer#:11248615
*/
protected override Expression VisitMember (MemberExpression node) {
    var propertyMaps = _typeMap.GetPropertyMaps ();
    Contract.Assume (propertyMaps != null);
    var propertyMap = propertyMaps.SingleOrDefault (map = > map.SourceMember == node.Member);
    if (propertyMap == null)
        return base.VisitMember (node);
    var destinationProperty = propertyMap.DestinationProperty;
    Contract.Assume (destinationProperty != null);
    var destinationMember = destinationProperty.MemberInfo;
    Contract.Assume (destinationMember != null);
    var property = destinationMember as PropertyInfo;
    if (property == null)
        return base.VisitMember (node);
    var newPropertyAccess = Expression.Property (_newParameter, property);
    return base.VisitMember (newPropertyAccess);
}

protected override Expression VisitMember (MemberExpression node) {
    var memberExpression = (MemberExpression) node;
    var declaringType = memberExpression.Member.DeclaringType;
    var propertyName = memberExpression.Member.Name;
    if (typeof (AccountModel) == declaringType) {
        switch (propertyName) {
            case "Bal" :
                propertyName = "Balance";
                break;
            case "Name" :
                propertyName = "CustomerName";
                break;
        }
        memberExpression = Expression.Property (this.Visit (memberExpression.Expression), typeof (Account).GetProperty (propertyName));
    }
    return memberExpression;
}

