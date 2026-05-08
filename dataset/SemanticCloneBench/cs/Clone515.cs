/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26673881
*  Stack Overflow answer #:26676337
*  And Stack Overflow answer#:31268941
*/
public override object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext) {
    if (! (bindingContext.ModelType == typeof (Guid)))
        return base.BindModel (controllerContext, bindingContext);
    if (! bindingContext.ValueProvider.ContainsPrefix (bindingContext.ModelName))
        return null;
    string input = bindingContext.ValueProvider.GetValue (bindingContext.ModelName).AttemptedValue;
    if (string.IsNullOrEmpty (input))
        return null;
    Guid g;
    if (Guid.TryParse (input, out g))
        return g;
    var bytes = HttpServerUtility.UrlTokenDecode (s);
    var result = new Guid (bytes);
    return result;
}

public override object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext) {
    if (bindingContext.ModelType == typeof (Guid ?)) {
        var valueResult = bindingContext.ValueProvider.GetValue (bindingContext.ModelName);
        string input = valueResult.AttemptedValue;
        if (string.IsNullOrEmpty (input) || input == "0") {
            var modelState = new ModelState {Value = valueResult};
            bindingContext.ModelState.Add (bindingContext.ModelName, modelState);
            return null;
        }
    }
    return base.BindModel (controllerContext, bindingContext);
}

