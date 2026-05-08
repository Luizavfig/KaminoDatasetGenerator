/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10980668
*  Stack Overflow answer #:11659466
*  And Stack Overflow answer#:10985139
*/
public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    if (! CanConvert (objectType)) {
        throw new NotSupportedException ();
    }
    if (reader.TokenType == JsonToken.Null) {
        reader.Skip ();
        return null;
    } else if (reader.TokenType == JsonToken.StartObject) {
        return new T [] {serializer.Deserialize < T > (reader)};
    } else {
        return serializer.Deserialize < T [] > (reader);
    }
}

public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    if (reader.TokenType == JsonToken.StartArray) {
        object result = serializer.Deserialize (reader, objectType);
        return result;
    } else {
        var resultObject = serializer.Deserialize < T > (reader);
        return new T [] {resultObject};
    }
}

