/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6061291
*  Stack Overflow answer #:9105641
*  And Stack Overflow answer#:21624441
*/
public override object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder) {
    var propertyType = propertyDescriptor.PropertyType;
    if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition () == typeof (Nullable < >)) {
        var provider = bindingContext.ValueProvider.GetValue (bindingContext.ModelName);
        if (provider != null && provider.RawValue != null && Type.GetTypeCode (provider.RawValue.GetType ()) == TypeCode.Int32) {
            var value = new System.Web.Script.Serialization.JavaScriptSerializer ().Deserialize (provider.AttemptedValue, bindingContext.ModelMetadata.ModelType);
            return value;
        }
    }
    return base.GetPropertyValue (controllerContext, bindingContext, propertyDescriptor, propertyBinder);
}

public object BindModel (ControllerContext controllerContext, ModelBindingContext bindingContext) {
    var valueResult = bindingContext.ValueProvider.GetValue (bindingContext.ModelName);
    if (string.IsNullOrEmpty (valueResult.AttemptedValue)) {
        return (long ?) null;
    }
    var modelState = new ModelState {Value = valueResult};
    object actualValue = null;
    try {
        actualValue = Convert.ToInt64 (valueResult.AttemptedValue, CultureInfo.InvariantCulture);
    }
    catch (FormatException e) {
        modelState.Errors.Add (e);
    }
    bindingContext.ModelState.Add (bindingContext.ModelName, modelState);
    return actualValue;
}

