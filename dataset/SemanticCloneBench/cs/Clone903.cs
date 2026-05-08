/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:814001
*  Stack Overflow answer #:5182805
*  And Stack Overflow answer#:24076812
*/
public static XmlDocument JsonToXml (string json) {
    XmlNode newNode = null;
    XmlNode appendToNode = null;
    XmlDocument returnXmlDoc = new XmlDocument ();
    returnXmlDoc.LoadXml ("<Document />");
    XmlNode rootNode = returnXmlDoc.SelectSingleNode ("Document");
    appendToNode = rootNode;
    string [] arrElementData;
    string [] arrElements = json.Split ('\r');
    foreach (string element in arrElements) {
        string processElement = element.Replace ("\r", "").Replace ("\n", "").Replace ("\t", "").Trim ();
        if ((processElement.IndexOf ("}") > - 1 || processElement.IndexOf ("]") > - 1) && appendToNode != rootNode) {
            appendToNode = appendToNode.ParentNode;
        } else if (processElement.IndexOf ("[") > - 1) {
            processElement = processElement.Replace (":", "").Replace ("[", "").Replace ("\"", "").Trim ();
            newNode = returnXmlDoc.CreateElement (processElement);
            appendToNode.AppendChild (newNode);
            appendToNode = newNode;
        } else if (processElement.IndexOf ("{") > - 1 && processElement.IndexOf (":") > - 1) {
            processElement = processElement.Replace (":", "").Replace ("{", "").Replace ("\"", "").Trim ();
            newNode = returnXmlDoc.CreateElement (processElement);
            appendToNode.AppendChild (newNode);
            appendToNode = newNode;
        } else {
            if (processElement.IndexOf (":") > - 1) {
                arrElementData = processElement.Replace (": \"", ":").Replace ("\",", "").Replace ("\"", "").Split (':');
                newNode = returnXmlDoc.CreateElement (arrElementData [0]);
                for (int i = 1; i < arrElementData.Length; i ++) {
                    newNode.InnerText += arrElementData [i];
                }
                appendToNode.AppendChild (newNode);
            }
        }
    }
    return returnXmlDoc;
}

protected object convert (XmlNode root) {
    Hashtable obj = new Hashtable ();
    for (int i = 0, n = root.ChildNodes.Count; i < n; i ++) {
        object result = null;
        XmlNode current = root.ChildNodes.Item (i);
        if (current.NodeType != XmlNodeType.Text)
            result = convert (current);
        else {
            int resultInt;
            double resultFloat;
            bool resultBoolean;
            if (Int32.TryParse (current.Value, out resultInt))
                return resultInt;
            if (Double.TryParse (current.Value, out resultFloat))
                return resultFloat;
            if (Boolean.TryParse (current.Value, out resultBoolean))
                return resultBoolean;
            return current.Value;
        }
        if (obj [current.Name] == null)
            obj [current.Name] = result;
        else if (obj [current.Name].GetType ().Equals (typeof (ArrayList)))
            ((ArrayList) obj [current.Name]).Add (result);
        else {
            ArrayList collision = new ArrayList ();
            collision.Add (obj [current.Name]);
            collision.Add (result);
            obj [current.Name] = collision;
        }
    }
    return obj;
}

