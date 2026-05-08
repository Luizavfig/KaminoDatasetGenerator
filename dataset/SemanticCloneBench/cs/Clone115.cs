/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2493800
*  Stack Overflow answer #:9438051
*  And Stack Overflow answer#:28433753
*/
protected override ValidationResult IsValid (object value, ValidationContext validationContext) {
    var isValid = true;
    var result = ValidationResult.Success;
    var nestedValidationProperties = value.GetType ().GetProperties ().Where (p = > IsDefined (p, typeof (ValidationAttribute))).OrderBy (p = > p.Name);
    foreach (var property in nestedValidationProperties) {
        var validators = GetCustomAttributes (property, typeof (ValidationAttribute)) as ValidationAttribute [];
        if (validators == null || validators.Length == 0)
            continue;
        foreach (var validator in validators) {
            var propertyValue = property.GetValue (value, null);
            result = validator.GetValidationResult (propertyValue, new ValidationContext (value, null, null));
            if (result == ValidationResult.Success)
                continue;
            isValid = false;
            break;
        }
        if (! isValid) {
            break;
        }
    }
    return result;
}

protected override ValidationResult IsValid (object value, ValidationContext validationContext) {
    var results = new List < ValidationResult > ();
    var context = new ValidationContext (value, null, null);
    Validator.TryValidateObject (value, context, results, true);
    if (results.Count != 0) {
        var compositeResults = new CompositeValidationResult (String.Format ("Validation for {0} failed!", validationContext.DisplayName));
        results.ForEach (compositeResults.AddResult);
        return compositeResults;
    }
    return ValidationResult.Success;
}

