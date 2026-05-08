/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:679050
*  Stack Overflow answer #:1280628
*  And Stack Overflow answer#:698401
*/
public void WriteXml (System.Xml.XmlWriter writer) {
    XmlSerializer keySerializer = new XmlSerializer (typeof (TKey));
    XmlSerializer valueSerializer = new XmlSerializer (typeof (TValue));
    foreach (TKey key in this.Keys) {
        writer.WriteStartElement ("item");
        writer.WriteStartElement ("key");
        keySerializer.Serialize (writer, key);
        writer.WriteEndElement ();
        writer.WriteStartElement ("value");
        TValue value = this [key];
        valueSerializer.Serialize (writer, value);
        writer.WriteEndElement ();
        writer.WriteEndElement ();
    }
}

public void WriteXml (XmlWriter w) {
    w.WriteStartElement ("dictionary");
    foreach (int key in dic.Keys) {
        string val = dic [key];
        w.WriteStartElement ("item");
        w.WriteElementString ("key", key.ToString ());
        w.WriteElementString ("value", val);
        w.WriteEndElement ();
    }
    w.WriteEndElement ();
}

