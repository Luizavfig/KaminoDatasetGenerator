/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30300740
*  Stack Overflow answer #:30365363
*  And Stack Overflow answer#:30365363
*/
public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    existingValue = existingValue ?? Activator.CreateInstance (objectType, true);
    var jObject = JObject.Load (reader);
    var properties = objectType.GetProperties (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    foreach (var property in properties) {
        var jToken = jObject [property.Name];
        if (jToken == null) {
            _nullproperties.Add (property);
            continue;
        }
        var value = jToken.ToObject (property.PropertyType);
        if (ReportDefinedNullTokens && value == null)
            _nullproperties.Add (property);
        property.SetValue (existingValue, value, null);
    }
    return existingValue;
}

public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    var objectType = value.GetType ();
    var properties = objectType.GetProperties (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    writer.WriteStartObject ();
    foreach (var property in properties) {
        var propertyValue = property.GetValue (value, null);
        writer.WritePropertyName (property.Name);
        serializer.Serialize (writer, propertyValue);
    }
    writer.WriteEndObject ();
}

