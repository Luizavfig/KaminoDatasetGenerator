/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5401231
*  Stack Overflow answer #:5401946
*  And Stack Overflow answer#:5407471
*/
public override bool IsValid (object value) {
    var model = value as MyViewModel;
    if (model == null) {
        return false;
    }
    if (model.WireTransfer == 1) {
        return ! string.IsNullOrEmpty (model.FirstName) && ! string.IsNullOrEmpty (model.LastName);
    } else if (model.WireTransfer == 2) {
        return ! string.IsNullOrEmpty (model.PaypalEmail);
    }
    return false;
}

protected override ValidationResult IsValid (object value, ValidationContext context) {
    if (context.ObjectInstance != null) {
        Type type = context.ObjectInstance.GetType ();
        PropertyInfo info = type.GetProperty (DependentProperty);
        object dependentValue;
        if (info != null) {
            dependentValue = info.GetValue (context.ObjectInstance, null);
            if (object.Equals (dependentValue, TargetValue)) {
                if (string.IsNullOrWhiteSpace (Convert.ToString (value))) {
                    return new ValidationResult (ErrorMessage);
                }
            }
        }
    }
    return ValidationResult.Success;
}

