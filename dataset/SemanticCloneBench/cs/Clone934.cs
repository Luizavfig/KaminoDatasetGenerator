/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:46374252
*  Stack Overflow answer #:46383247
*  And Stack Overflow answer#:46383247
*/
private static void GetNavigationProperties (Type baseType, Type type, string parentPropertyName, IList < string > accumulator) {
    var properties = type.GetProperties ();
    var navigationPropertyInfoList = properties.Where (prop = > prop.IsDefined (typeof (NavigationPropertyAttribute)));
    foreach (PropertyInfo prop in navigationPropertyInfoList) {
        var propertyType = prop.PropertyType;
        var elementType = propertyType.GetTypeInfo ().IsGenericType ? propertyType.GetGenericArguments () [0] : propertyType;
        var properyName = string.Format ("{0}{1}{2}", parentPropertyName, string.IsNullOrEmpty (parentPropertyName) ? string.Empty : ".", prop.Name);
        accumulator.Add (properyName);
        var isJsonIgnored = prop.IsDefined (typeof (JsonIgnoreAttribute));
        if (! isJsonIgnored && elementType != baseType) {
            GetNavigationProperties (baseType, elementType, properyName, accumulator);
        }
    }
}

public static Func < IQueryable < T >, IQueryable < T > > GetNavigations < T > () where T : BaseEntity {
    var type = typeof (T);
    var navigationProperties = new List < string > ();
    GetNavigationProperties (type, type, string.Empty, navigationProperties);
    Func < IQueryable < T >, IQueryable < T > > includes = (query = > {
        return navigationProperties.Aggregate (query, (current, inc) = > current.Include (inc));
    });
    return includes;
}

