/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10155429
*  Stack Overflow answer #:10155854
*  And Stack Overflow answer#:10155701
*/
public override bool IsValid (object value) {
    Type typeInfo = value.GetType ();
    PropertyInfo [] propertyInfo = typeInfo.GetProperties ();
    foreach (var property in propertyInfo) {
        if (null != property.GetValue (value, null)) {
            return true;
        }
    }
    return false;
}

protected override ValidationResult IsValid (object value, ValidationContext validationContext) {
    var viewModel = value as TimeInMinutesViewModel;
    if (viewModel == null) {
        return null;
    }
    if (viewModel.Hours != 0 || viewModel.Minutes != 0)
        return null;
    return new ValidationResult (FormatErrorMessage (validationContext.DisplayName));
}

