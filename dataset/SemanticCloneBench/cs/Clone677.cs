/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:42438067
*  Stack Overflow answer #:42447317
*  And Stack Overflow answer#:42447317
*/
private ICommand ResolveCommand () {
    ICommand command = null;
    if (this.Command != null) {
        return this.Command;
    }
    var frameworkElement = this.AssociatedObject as FrameworkElement;
    if (frameworkElement != null) {
        object dataContext = frameworkElement.DataContext;
        if (dataContext != null) {
            PropertyInfo commandPropertyInfo = dataContext.GetType ().GetProperties (BindingFlags.Public | BindingFlags.Instance).FirstOrDefault (p = > typeof (ICommand).IsAssignableFrom (p.PropertyType) && string.Equals (p.Name, this.CommandName, StringComparison.Ordinal));
            if (commandPropertyInfo != null) {
                command = (ICommand) commandPropertyInfo.GetValue (dataContext, null);
            }
        }
    }
    return command;
}

protected override void Invoke (object parameter) {
    this.InvokeParameter = parameter;
    if (this.AssociatedObject != null) {
        ICommand command = this.ResolveCommand ();
        if ((command != null) && command.CanExecute (this.CommandParameter)) {
            command.Execute (this.CommandParameter);
        }
    }
}

