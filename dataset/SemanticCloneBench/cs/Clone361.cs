/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:679050
*  Stack Overflow answer #:1280628
*  And Stack Overflow answer#:698401
*/
public void ReadXml (System.Xml.XmlReader reader) {
    XmlSerializer keySerializer = new XmlSerializer (typeof (TKey));
    XmlSerializer valueSerializer = new XmlSerializer (typeof (TValue));
    bool wasEmpty = reader.IsEmptyElement;
    reader.Read ();
    if (wasEmpty)
        return;
    while (reader.NodeType != System.Xml.XmlNodeType.EndElement) {
        reader.ReadStartElement ("item");
        reader.ReadStartElement ("key");
        TKey key = (TKey) keySerializer.Deserialize (reader);
        reader.ReadEndElement ();
        reader.ReadStartElement ("value");
        TValue value = (TValue) valueSerializer.Deserialize (reader);
        reader.ReadEndElement ();
        this.Add (key, value);
        reader.ReadEndElement ();
        reader.MoveToContent ();
    }
    reader.ReadEndElement ();
}

public void ReadXml (XmlReader r) {
    if (r.Name != "dictionary")
        r.Read ();
    r.ReadStartElement ("dictionary");
    while (r.NodeType != XmlNodeType.EndElement) {
        r.ReadStartElement ("item");
        string key = r.ReadElementString ("key");
        string value = r.ReadElementString ("value");
        r.ReadEndElement ();
        r.MoveToContent ();
        dic.Add (Convert.ToInt32 (key), value);
    }
}

