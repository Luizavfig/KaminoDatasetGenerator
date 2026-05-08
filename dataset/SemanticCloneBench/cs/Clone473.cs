/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11471676
*  Stack Overflow answer #:11473197
*  And Stack Overflow answer#:11474660
*/
public void WriteXml (XmlWriter writer) {
    using (MemoryStream ms = new MemoryStream ())
    {
        using (XmlWriter innerWriter = XmlWriter.Create (ms, new XmlWriterSettings {OmitXmlDeclaration = true}))
        {
            shipmentInfoSerializer.Serialize (innerWriter, this.Shipment);
            innerWriter.Flush ();
            writer.WriteCData (Encoding.UTF8.GetString (ms.ToArray ()));
        }}}

public void WriteXml (XmlWriter writer) {
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces ();
    ns.Add ("", "");
    XmlWriterSettings settings = new XmlWriterSettings ();
    settings.OmitXmlDeclaration = true;
    settings.Indent = true;
    StringBuilder sb = new StringBuilder ();
    using (XmlWriter innerWriter = XmlWriter.Create (sb, settings))
    {
        shipmentInfoSerializer.Serialize (innerWriter, this.Shipment, ns);
        innerWriter.Flush ();
        writer.WriteCData (sb.ToString ());
    }}

