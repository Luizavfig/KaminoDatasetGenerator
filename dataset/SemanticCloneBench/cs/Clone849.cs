/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1333864
*  Stack Overflow answer #:1376358
*  And Stack Overflow answer#:1376358
*/
public void ReadXml (XmlReader reader) {
    if (! reader.HasAttributes)
        throw new FormatException ("expected a type attribute!");
    string type = reader.GetAttribute ("type");
    reader.Read ();
    if (type == "null")
        return;
    XmlSerializer serializer = new XmlSerializer (Type.GetType (type));
    this.Value = (T) serializer.Deserialize (reader);
    reader.ReadEndElement ();
}

public void WriteXml (XmlWriter writer) {
    if (Value == null) {
        writer.WriteAttributeString ("type", "null");
        return;
    }
    Type type = this.Value.GetType ();
    XmlSerializer serializer = new XmlSerializer (type);
    writer.WriteAttributeString ("type", type.AssemblyQualifiedName);
    serializer.Serialize (writer, this.Value);
}

