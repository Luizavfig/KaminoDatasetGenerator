/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:661561
*  Stack Overflow answer #:26783406
*  And Stack Overflow answer#:7437184
*/
public void Execute (Form form, Action guiCommand) {
    _timeout = _totalTimeout;
    while (! form.IsHandleCreated) {
        if (_timeout <= 0)
            return;
        Thread.Sleep (SLEEPING_STEP);
        _timeout -= SLEEPING_STEP;
    }
    if (form.InvokeRequired)
        form.Invoke (guiCommand);
    else
        guiCommand ();
}

public static void SetPropertyInGuiThread < C, V > (this C control, Expression < Func < C, V > > property, V value) where C : Control {
    var memberExpression = property.Body as MemberExpression;
    if (memberExpression == null)
        throw new ArgumentException ("The 'property' expression must specify a property on the control.");
    var propertyInfo = memberExpression.Member as PropertyInfo;
    if (propertyInfo == null)
        throw new ArgumentException ("The 'property' expression must specify a property on the control.");
    if (control.InvokeRequired)
        control.Invoke ((Action < C, Expression < Func < C, V > >, V >) SetPropertyInGuiThread, new object [] {control, property, value});
    else
        propertyInfo.SetValue (control, value, null);
}

