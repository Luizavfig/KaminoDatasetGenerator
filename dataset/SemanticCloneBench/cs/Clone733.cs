/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:22000410
*  Stack Overflow answer #:22001850
*  And Stack Overflow answer#:22001754
*/
static void Main (string [] args) {
    var qin = new Quote {InsDetails = new InsuranceDetails {Details1 = "insurance details text"}, PayDetails = new PaymentDetails {Details1 = "payment details text"},};
    string xml;
    using (var stream = new MemoryStream ())
    {
        var serializer = new XmlSerializer (typeof (Quote));
        serializer.Serialize (stream, qin);
        stream.Position = 0;
        using (var sr = new StreamReader (stream))
        {
            xml = sr.ReadToEnd ();
        }} Quote qout;
    using (TextReader read = new StringReader (xml))
    {
        var deserializer = new XmlSerializer (typeof (Quote));
        var obj = deserializer.Deserialize (read);
        qout = (Quote) obj;
    } Console.WriteLine ("InsDetails.Details1='{0}'", qout.InsDetails.Details1);
    Console.WriteLine ("PayDetails.Details1='{0}'", qout.PayDetails.Details1);
}

public static T Deserialize < T > (string xml) {
    if (string.IsNullOrEmpty (xml)) {
        return default (T);
    }
    XmlSerializer serializer = new XmlSerializer (typeof (T));
    XmlReaderSettings settings = new XmlReaderSettings ();
    using (StringReader textReader = new StringReader (xml))
    {
        using (XmlReader xmlReader = XmlReader.Create (textReader, settings))
        {
            return (T) serializer.Deserialize (xmlReader);
        }}}

