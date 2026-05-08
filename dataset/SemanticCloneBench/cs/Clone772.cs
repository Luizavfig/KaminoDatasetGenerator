/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32101156
*  Stack Overflow answer #:35702168
*  And Stack Overflow answer#:32103418
*/
private void ResetFile (string filePath) {
    using (WordprocessingDocument doc = WordprocessingDocument.Open (filePath, true))
    {
        try {
            string uncheckValue = "â˜?";
            string checkValue = "â˜’";
            foreach (SdtContentCheckBox ctrl in doc.MainDocumentPart.Document.Body.Descendants < SdtContentCheckBox > ()) {
                if (ctrl.Checked.Val == OnOffValues.One) {
                    ctrl.Checked.Val = OnOffValues.Zero;
                    if (ctrl.Parent.Parent.Descendants < SdtContentRun > ().ToList ().Count > 0) {
                        SdtContentRun text = (SdtContentRun) ctrl.Parent.Parent.Descendants < SdtContentRun > ().ToList () [0];
                        text.InnerXml = text.InnerXml.Replace (checkValue, uncheckValue);
                    }
                }
            }
            doc.MainDocumentPart.Document.Save ();
        }
        catch {
        }
    }}

private static void SetCheckBox (OpenXmlElement field, bool isChecked) {
    if (isChecked) {
        field.Parent.Parent.FirstChild.GetFirstChild < SdtContentCheckBox > ().Checked.Val = OnOffValues.True;
        field.Parent.Parent.Descendants < Run > ().First ().GetFirstChild < Text > ().Text = "â˜’";
    } else {
        field.Parent.Parent.FirstChild.GetFirstChild < SdtContentCheckBox > ().Checked.Val = OnOffValues.False;
        field.Parent.Parent.Descendants < Run > ().First ().GetFirstChild < Text > ().Text = "â˜?";
    }
}

