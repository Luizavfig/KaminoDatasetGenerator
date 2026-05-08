/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3330989
*  Stack Overflow answer #:40679286
*  And Stack Overflow answer#:28557035
*/
private static JToken NormalizeToken (JToken token) {
    JObject o;
    JArray array;
    if ((o = token as JObject) != null) {
        List < JProperty > orderedProperties = new List < JProperty > (o.Properties ());
        orderedProperties.Sort (delegate (JProperty x, JProperty y) {
            return x.Name.CompareTo (y.Name);
        });
        JObject normalized = new JObject ();
        foreach (JProperty property in orderedProperties) {
            normalized.Add (property.Name, NormalizeToken (property.Value));
        }
        return normalized;
    } else if ((array = token as JArray) != null) {
        for (int i = 0; i < array.Count; i ++) {
            array [i] = NormalizeToken (array [i]);
        }
        return array;
    } else {
        return token;
    }
}

private static JObject SortPropertiesAlphabetically (JObject original) {
    var result = new JObject ();
    foreach (var property in original.Properties ().ToList ().OrderBy (p = > p.Name)) {
        var value = property.Value as JObject;
        if (value != null) {
            value = SortPropertiesAlphabetically (value);
            result.Add (property.Name, value);
        } else {
            result.Add (property.Name, property.Value);
        }
    }
    return result;
}

