/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9247478
*  Stack Overflow answer #:9249592
*  And Stack Overflow answer#:9249592
*/
private object ReadObject (JsonReader reader) {
    IDictionary < string, object > expandoObject = new ExpandoObject ();
    while (reader.Read ()) {
        switch (reader.TokenType) {
            case JsonToken.PropertyName :
                string propertyName = reader.Value.ToString ().ToPascalCase ();
                if (! reader.Read ())
                    throw new Exception ("Unexpected end.");
                object v = ReadValue (reader);
                expandoObject [propertyName] = v;
                break;
            case JsonToken.Comment :
                break;
            case JsonToken.EndObject :
                return expandoObject;
        }
    }
    throw new Exception ("Unexpected end.");
}

private object ReadValue (JsonReader reader) {
    while (reader.TokenType == JsonToken.Comment) {
        if (! reader.Read ())
            throw new Exception ("Unexpected end.");
    }
    switch (reader.TokenType) {
        case JsonToken.StartObject :
            return ReadObject (reader);
        case JsonToken.StartArray :
            return ReadList (reader);
        default :
            if (IsPrimitiveToken (reader.TokenType))
                return reader.Value;
            throw new Exception (string.Format (CultureInfo.InvariantCulture, "Unexpected token when converting ExpandoObject: {0}", reader.TokenType));
    }
}

