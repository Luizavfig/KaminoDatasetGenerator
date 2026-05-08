/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:31964938
*  Stack Overflow answer #:41592915
*  And Stack Overflow answer#:37845607
*/
static void Main (string [] args) {
    List < string > path = new List < string > (args);
    string filePathstr = string.Join (" ", path.ToArray ());
    string folderPathstr = Path.GetDirectoryName (filePathstr);
    try {
        Application ap = new Application ();
        Document document = ap.Documents.Open (filePathstr);
        foreach (Field field in document.GetAllFields ()) {
            field.Update ();
        }
        document.Save ();
        document.Close ();
    }
    catch (NullReferenceException) {
        System.Windows.Forms.MessageBox.Show ("A valid file was not selected.");
    }
}

static void Main (string [] args) {
    List < string > path = new List < string > (args);
    string filePathstr = string.Join (" ", path.ToArray ());
    string folderPathstr = Path.GetDirectoryName (filePathstr);
    try {
        Application ap = new Application ();
        Document document = ap.Documents.Open (filePathstr);
        document.Fields.Update ();
        foreach (Section section in document.Sections) {
            document.Fields.Update ();
            HeadersFooters headers = section.Headers;
            foreach (HeaderFooter header in headers) {
                Fields fields = header.Range.Fields;
                foreach (Field field in fields) {
                    field.Update ();
                }
            }
            HeadersFooters footers = section.Footers;
            foreach (HeaderFooter footer in footers) {
                Fields fields = footer.Range.Fields;
                foreach (Field field in fields) {
                    field.Update ();
                }
            }
        }
        document.Save ();
        document.Close ();
    }
    catch (NullReferenceException) {
        System.Windows.Forms.MessageBox.Show ("A valid file was not selected.");
    }
}

