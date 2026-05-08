/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20564862
*  Stack Overflow answer #:28647821
*  And Stack Overflow answer#:36484715
*/
public override object ProvideValue (IServiceProvider serviceProvider) {
    var provideValueTargetService = (IProvideValueTarget) serviceProvider.GetService (typeof (IProvideValueTarget));
    if (provideValueTargetService == null)
        return null;
    if (provideValueTargetService.TargetObject != null && provideValueTargetService.TargetObject.GetType ().FullName == "System.Windows.SharedDp")
        return this;
    var targetObject = provideValueTargetService.TargetObject as FrameworkElement;
    var targetProperty = provideValueTargetService.TargetProperty as DependencyProperty;
    if (targetObject == null || targetProperty == null)
        return null;
    var binding = new Binding ();
    binding.Path = this.Path;
    binding.XPath = this.XPath;
    binding.Mode = this.Mode;
    binding.UpdateSourceTrigger = this.UpdateSourceTrigger;
    binding.Converter = this.Converter;
    binding.ConverterParameter = this.ConverterParameter;
    binding.ConverterCulture = this.ConverterCulture;
    if (this.RelativeSource != null)
        binding.RelativeSource = this.RelativeSource;
    if (this.ElementName != null)
        binding.ElementName = this.ElementName;
    if (this.Source != null)
        binding.Source = this.Source;
    binding.FallbackValue = this.FallbackValue;
    var multiBinding = new MultiBinding ();
    multiBinding.Converter = HelperConverter.Current;
    multiBinding.ConverterParameter = targetProperty;
    multiBinding.Bindings.Add (binding);
    multiBinding.NotifyOnSourceUpdated = true;
    targetObject.SetBinding (ResourceBindingKeyHelperProperty, multiBinding);
    return null;
}

public override object ProvideValue (IServiceProvider serviceProvider) {
    var provideValueTarget = serviceProvider.GetService (typeof (IProvideValueTarget)) as IProvideValueTarget;
    if (provideValueTarget != null) {
        var targetObject = provideValueTarget.TargetObject as FrameworkElement;
        if (targetObject != null) {
            var targetProperty = provideValueTarget.TargetProperty as DependencyProperty;
            if (targetProperty != null) {
                targetObject.SetBinding (EnsureResourceKeyProperty (targetProperty), binding);
            }
        }
    }
    return null;
}

