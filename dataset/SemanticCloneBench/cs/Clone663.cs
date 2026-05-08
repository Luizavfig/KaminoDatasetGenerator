/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14010472
*  Stack Overflow answer #:14051788
*  And Stack Overflow answer#:14095798
*/
public void ReadXml (System.Xml.XmlReader reader) {
    reader.Read ();
    reader.MoveToContent ();
    if (reader.LocalName == "AnotherNode") {
        var innerXml = Serializer < AnotherClass >.CreateSerializer ();
        Remove = (AnotherClass) innerXml.Deserialize (reader);
        reader.MoveToContent ();
    }
    reader.Read ();
    if (reader.IsStartElement ()) {
        do
            {
                var innerXml = Serializer < T >.CreateSerializer ();
                var obj = (T) innerXml.Deserialize (reader);
                Updates.Add (obj);
            } while (reader.MoveToContent () == XmlNodeType.Element);
    }
}

public static string Serialize (T source, XmlSerializerNamespaces namespaces, XmlWriterSettings settings) {
    if (source == null)
        throw new ArgumentNullException ("source", "Object to serialize cannot be null");
    string xml = null;
    XmlSerializer serializer = new XmlSerializer (source.GetType ());
    using (MemoryStream memoryStream = new MemoryStream ())
    {
        using (XmlWriter xmlWriter = XmlWriter.Create (memoryStream, settings))
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer (typeof (T));
            x.Serialize (xmlWriter, source, namespaces);
            memoryStream.Position = 0;
            using (StreamReader sr = new StreamReader (memoryStream))
            {
                xml = sr.ReadToEnd ();
            }}} return xml;
}

