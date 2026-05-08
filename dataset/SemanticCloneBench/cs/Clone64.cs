/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4710729
*  Stack Overflow answer #:11148034
*  And Stack Overflow answer#:7746444
*/
public object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext) {
    if (! controllerContext.HttpContext.Request.ContentType.StartsWith ("application/json", StringComparison.OrdinalIgnoreCase)) {
        return null;
    }
    var inpStream = controllerContext.HttpContext.Request.InputStream;
    inpStream.Seek (0, SeekOrigin.Begin);
    StreamReader reader = new StreamReader (controllerContext.HttpContext.Request.InputStream);
    string bodyText = reader.ReadToEnd ();
    reader.Close ();
    if (String.IsNullOrEmpty (bodyText)) {
        return null;
    }
    return JsonValue.Parse (bodyText);
}

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

