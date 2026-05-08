/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:308615
*  Stack Overflow answer #:27571627
*  And Stack Overflow answer#:308648
*/
public static string ReadLine (this BinaryReader reader) {
    if (reader.IsEndOfStream ())
        return null;
    StringBuilder result = new StringBuilder ();
    char character;
    while (! reader.IsEndOfStream () && (character = reader.ReadChar ()) != '\n')
        if (character != '\r' && character != '\n')
            result.Append (character);
    return result.ToString ();
}

public string ReadLine () {
    StringBuilder result = new StringBuilder ();
    char lastChar = reader.ReadChar ();
    try {
        char newChar = reader.ReadChar ();
        if (lastChar == '\r' && newChar == '\n')
            return result.ToString ();
        result.Append (lastChar);
        lastChar = newChar;
    }
    catch (EndOfStreamException) {
        result.Append (lastChar);
        return result.ToString ();
    }
}

