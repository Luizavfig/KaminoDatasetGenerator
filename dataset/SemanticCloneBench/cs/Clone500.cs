/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:45404111
*  Stack Overflow answer #:45404471
*  And Stack Overflow answer#:45404471
*/
public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    if (reader.TokenType == JsonToken.Null)
        return null;
    var token = JToken.Load (reader);
    if (token.Type != JTokenType.Array)
        throw new JsonSerializationException ("token was not an array");
    var contract = serializer.ContractResolver.ResolveContract (objectType) as JsonObjectContract;
    if (contract == null)
        throw new JsonSerializationException ("invalid type " + objectType.FullName);
    var value = existingValue ?? contract.DefaultCreator ();
    foreach (var pair in contract.Properties.Where (p = > ! ShouldSkip (p)).Zip (token, (p, v) = > new {Value = v, Property = p})) {
        var propertyValue = pair.Value.ToObject (pair.Property.PropertyType, serializer);
        pair.Property.ValueProvider.SetValue (value, propertyValue);
    }
    return value;
}

public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    if (reader.TokenType == JsonToken.Null)
        return null;
    var token = JToken.Load (reader);
    if (token.Type == JTokenType.Boolean)
        return (bool) token;
    return token.ToString () != "0";
}

