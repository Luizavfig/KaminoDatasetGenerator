/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24477219
*  Stack Overflow answer #:24662869
*  And Stack Overflow answer#:24662869
*/
protected override bool EvaluateIsValid () {
    string controlValue = GetControlValidationValue (ControlToValidate);
    if (controlValue == null) {
        return true;
    }
    var result = (! controlValue.Trim ().Equals (InitialValue.Trim ()));
    if (! result) {
        var control = (WebControl) NamingContainer.FindControl (ControlToValidate);
        if (! control.CssClass.Contains (CssControlErrorClass))
            control.CssClass += " " + CssControlErrorClass;
    }
    return result;
}

protected override bool EvaluateIsValid () {
    string controlValue = GetControlValidationValue (ControlToValidate);
    if (controlValue == null || controlValue.Trim ().Length == 0) {
        return true;
    }
    try {
        Match m = Regex.Match (controlValue, ValidationExpression);
        var result = (m.Success && m.Index == 0 && m.Length == controlValue.Length);
        if (! result) {
            var control = (WebControl) NamingContainer.FindControl (ControlToValidate);
            if (! control.CssClass.Contains (CssControlErrorClass))
                control.CssClass += " " + CssControlErrorClass;
        }
        return result;
    }
    catch {
        return true;
    }
}

