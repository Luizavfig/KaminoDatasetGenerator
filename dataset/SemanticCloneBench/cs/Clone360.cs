/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:375590
*  Stack Overflow answer #:375649
*  And Stack Overflow answer#:375747
*/
public static void Main () {
    XmlReaderSettings settings = new XmlReaderSettings ();
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
    settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
    XmlReader reader = XmlReader.Create ("inlineSchema.xml", settings);
    while (reader.Read ())
        ;
}

public static void Main () {
    var XsdPath = "C:\\Path\\To\\MySchemaDocument.xsd";
    var XmlPath = "C:\\Path\\To\\MyXmlDocument.xml";
    var XsdDoc = new XmlTextReader (XsdPath);
    var XmlDoc = new XmlTextReader (XmlPath);
    var WellFormed = true;
    XmlDocument xDoc = new XmlDocument ();
    try {
        xDoc.Load (XmlDoc);
    }
    catch (XmlException Ex) {
        WellFormed = false;
    }
    if (WellFormed & Validated (XmlDoc, XsdDoc)) {
    }
}

