/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:388483
*  Stack Overflow answer #:8375647
*  And Stack Overflow answer#:19859421
*/
public static MvcHtmlString EnumDropDownListFor < TModel, TEnum > (this HtmlHelper < TModel > htmlHelper, Expression < Func < TModel, TEnum > > expression, object htmlAttributes) {
    ModelMetadata metadata = ModelMetadata.FromLambdaExpression (expression, htmlHelper.ViewData);
    Type enumType = GetNonNullableModelType (metadata);
    IEnumerable < TEnum > values = Enum.GetValues (enumType).Cast < TEnum > ();
    IEnumerable < SelectListItem > items = from value in values
        select new SelectListItem {Text = GetEnumDescription (value), Value = value.ToString (), Selected = value.Equals (metadata.Model)};
    if (metadata.IsNullableValueType)
        items = SingleEmptyItem.Concat (items);
    return htmlHelper.DropDownListFor (expression, items, htmlAttributes);
}

public static string GetDescription < TEnum > (this TEnum value) {
    var fi = value.GetType ().GetField (value.ToString ());
    if (fi != null) {
        var attributes = (DescriptionAttribute []) fi.GetCustomAttributes (typeof (DescriptionAttribute), false);
        if (attributes.Length > 0) {
            return attributes [0].Description;
        }
    }
    return value.ToString ();
}

