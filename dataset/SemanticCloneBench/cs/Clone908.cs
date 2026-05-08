/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:42695039
*  Stack Overflow answer #:42697135
*  And Stack Overflow answer#:42695732
*/
static bool IsXmlRooted (Stream st) {
    bool sawRoot = false;
    using (var reader = XmlReader.Create (st, new XmlReaderSettings () {ConformanceLevel = ConformanceLevel.Fragment}))
    {
        while (reader.Read ()) {
            if (reader.NodeType == XmlNodeType.Element && reader.Depth == 0) {
                if (sawRoot)
                    return false;
                sawRoot = true;
            }
        }
    } return true;
}

public static bool IsFragment (string xml) {
    try {
        XElement.Parse (xml);
        return false;
    }
    catch {
        XElement.Parse ("<root>" + xml + "</root>");
        return true;
    }
}

