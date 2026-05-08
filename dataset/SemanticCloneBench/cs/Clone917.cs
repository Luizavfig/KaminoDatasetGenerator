/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24051206
*  Stack Overflow answer #:24052157
*  And Stack Overflow answer#:28743082
*/
public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    JToken token = JToken.Load (reader);
    if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer) {
        return token.ToObject < decimal > ();
    }
    if (token.Type == JTokenType.String) {
        return Decimal.Parse (token.ToString (), System.Globalization.CultureInfo.GetCultureInfo ("es-ES"));
    }
    if (token.Type == JTokenType.Null && objectType == typeof (decimal ?)) {
        return null;
    }
    throw new JsonSerializationException ("Unexpected token type: " + token.Type.ToString ());
}

public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
    Decimal ? d = default (Decimal ?);
    if (value != null) {
        d = value as Decimal ?;
        if (d.HasValue) {
            d = new Decimal ? (new Decimal (Decimal.ToDouble (d.Value)));
        }
    }
    JToken.FromObject (d).WriteTo (writer);
}

