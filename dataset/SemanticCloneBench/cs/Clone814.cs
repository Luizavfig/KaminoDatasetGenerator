/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5940506
*  Stack Overflow answer #:23433749
*  And Stack Overflow answer#:5940595
*/
public static MvcHtmlString RequiredLabelFor < TModel, TValue > (this HtmlHelper < TModel > helper, Expression < Func < TModel, TValue > > expression, object htmlAttributes) {
    var metaData = ModelMetadata.FromLambdaExpression (expression, helper.ViewData);
    string htmlFieldName = ExpressionHelper.GetExpressionText (expression);
    string labelText = metaData.DisplayName ?? metaData.PropertyName ?? htmlFieldName.Split ('.').Last ();
    if (metaData.IsRequired)
        labelText += "<span class=\"required\"><![CDATA[*</span>";
    if (String.IsNullOrEmpty (labelText))
        return MvcHtmlString.Empty;
    var label = new TagBuilder ("label");
    label.Attributes.Add ("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId (htmlFieldName));
    foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties (htmlAttributes)) {
        label.MergeAttribute (prop.Name.Replace ('_', '-'), prop.GetValue (htmlAttributes).ToString (), true);
    }
    label.InnerHtml = labelText;
    return MvcHtmlString.Create (label.ToString ());
}

public static MvcHtmlString RequiredLabelFor < TModel, TValue > (this HtmlHelper < TModel > helper, Expression < Func < TModel, TValue > > expression) {
    var metaData = ModelMetadata.FromLambdaExpression (expression, helper.ViewData);
    string htmlFieldName = ExpressionHelper.GetExpressionText (expression);
    string labelText = metaData.DisplayName ?? metaData.PropertyName ?? htmlFieldName.Split ('.').Last ();
    if (metaData.IsRequired)
        labelText += "<span class=\"required-field\"><![CDATA[*</span>";
    if (String.IsNullOrEmpty (labelText))
        return MvcHtmlString.Empty;
    var label = new TagBuilder ("label");
    label.Attributes.Add ("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId (htmlFieldName));
    label.InnerHtml = labelText;
    return MvcHtmlString.Create (label.ToString ());
}

