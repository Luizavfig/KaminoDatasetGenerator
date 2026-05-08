/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4710729
*  Stack Overflow answer #:7746444
*  And Stack Overflow answer#:14516007
*/
public object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext) {
    if (bindingContext == null)
        throw new ArgumentNullException ("bindingContext");
    string modelName = bindingContext.ModelName;
    IDictionary < string, string > formDictionary = new Dictionary < string, string > ();
    Regex dictionaryRegex = new Regex (modelName + @"\[(?<key>.+?)\]", RegexOptions.CultureInvariant);
    foreach (var key in controllerContext.HttpContext.Request.Form.AllKeys.Where (k = > k.StartsWith (modelName + "["))) {
        Match m = dictionaryRegex.Match (key);
        if (m.Success) {
            formDictionary [m.Groups ["key"].Value] = controllerContext.HttpContext.Request.Form [key];
        }
    }
    return formDictionary;
}

public object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext) {
    if (bindingContext == null)
        throw new ArgumentNullException ("bindingContext");
    string modelName = bindingContext.ModelName;
    IDictionary < string, string > result = new Dictionary < string, string > ();
    var providers = bindingContext.ValueProvider as ValueProviderCollection;
    if (providers != null) {
        var dictionaryValueProvider = providers.OfType < DictionaryValueProvider < object > > ().FirstOrDefault (vp = > vp.ContainsPrefix (modelName));
        if (dictionaryValueProvider != null) {
            var prefixsFieldInfo = dictionaryValueProvider.GetType ().GetField ("_prefixes", BindingFlags.Instance | BindingFlags.NonPublic);
            if (prefixsFieldInfo != null) {
                var prefixes = prefixsFieldInfo.GetValue (dictionaryValueProvider) as HashSet < string >;
                if (prefixes != null) {
                    var keys = prefixes.Where (p = > p.StartsWith (modelName + "."));
                    foreach (var key in keys) {
                        result.Add (key.Substring (modelName.Length + 1), bindingContext.ValueProvider.GetValue (key).AttemptedValue);
                    }
                    return result;
                }
            }
        }
    }
    return null;
}

