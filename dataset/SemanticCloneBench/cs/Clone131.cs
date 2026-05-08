/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2535287
*  Stack Overflow answer #:29823241
*  And Stack Overflow answer#:29443227
*/
public static object GetPropertyValue (object src, string propName) {
    if (src == null)
        throw new ArgumentException ("Value cannot be null.", "src");
    if (propName == null)
        throw new ArgumentException ("Value cannot be null.", "propName");
    if (propName.Contains (".")) {
        var temp = propName.Split (new char [] {'.'}, 2);
        return GetPropertyValue (GetPropertyValue (src, temp [0]), temp [1]);
    } else {
        var prop = src.GetType ().GetProperty (propName);
        return prop != null ? prop.GetValue (src, null) : null;
    }
}

public object GetPropertyValue (object obj, string propertyName) {
    var _propertyNames = propertyName.Split ('.');
    for (var i = 0; i < _propertyNames.Length; i ++) {
        if (obj != null) {
            var _propertyInfo = obj.GetType ().GetProperty (_propertyNames [i]);
            if (_propertyInfo != null)
                obj = _propertyInfo.GetValue (obj);
            else
                obj = null;
        }
    }
    return obj;
}

