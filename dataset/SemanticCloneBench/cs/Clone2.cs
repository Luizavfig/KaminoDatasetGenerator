/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16100300
*  Stack Overflow answer #:16100455
*  And Stack Overflow answer#:19968599
*/
protected override ValidationResult IsValid (object value, ValidationContext validationContext) {
    var properties = this.PropertyNames.Select (validationContext.ObjectType.GetProperty);
    var values = properties.Select (p = > p.GetValue (validationContext.ObjectInstance, null)).OfType < string > ();
    var totalLength = values.Sum (x = > x.Length) + Convert.ToString (value).Length;
    if (totalLength < this.MinLength) {
        return new ValidationResult (this.FormatErrorMessage (validationContext.DisplayName));
    }
    return null;
}

protected override ValidationResult IsValid (object value, ValidationContext validationContext) {
    var model = (EmployeeModel) validationContext.ObjectInstance;
    if (model.Field1 == null) {
        return new ValidationResult ("Field1 is null");
    }
    if (model.Field2 == null) {
        return new ValidationResult ("Field2 is null");
    }
    if (model.Field3 == null) {
        return new ValidationResult ("Field3 is null");
    }
    return ValidationResult.Success;
}

