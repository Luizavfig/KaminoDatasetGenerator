/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10252207
*  Stack Overflow answer #:10284149
*  And Stack Overflow answer#:10252325
*/
public void Serialize (object i_objectToSerialize, Stream i_streamToSerializeTo) {
    StringWriter sw = new StringWriter ();
    this.m_regularXmlSerializer.Serialize (sw, i_objectToSerialize);
    XDocument objectXml = XDocument.Parse (sw.ToString ());
    sw.Dispose ();
    SerializeExtra (i_objectToSerialize, objectXml);
    string res = objectXml.ToString ();
    byte [] bytesToWrite = Encoding.UTF8.GetBytes (res);
    i_streamToSerializeTo.Write (bytesToWrite, 0, bytesToWrite.Length);
}

public static string Serialize (object obj) {
    Type type = obj.GetType ();
    var stringBuilder = new StringBuilder ();
    var serializer = new XmlSerializer (type);
    serializer.Serialize (new StringWriter (stringBuilder), obj);
    XDocument doc = XDocument.Load (new StringReader (stringBuilder.ToString ()));
    foreach (XElement xElement in SerializeAnyThing (obj)) {
        doc.Descendants ().First ().Add (xElement);
    }
    return doc.ToString ();
}

