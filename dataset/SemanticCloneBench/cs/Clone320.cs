/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6657899
*  Stack Overflow answer #:13249749
*  And Stack Overflow answer#:28882185
*/
private static void AppendToDocument (string sourcePdfPath1, string sourcePdfPath2, string outputPdfPath) {
    using (var sourceDocumentStream1 = new FileStream (sourcePdfPath1, FileMode.Open))
    {
        using (var sourceDocumentStream2 = new FileStream (sourcePdfPath2, FileMode.Open))
        {
            using (var destinationDocumentStream = new FileStream (outputPdfPath, FileMode.Create))
            {
                var pdfConcat = new PdfConcatenate (destinationDocumentStream);
                var pdfReader = new PdfReader (sourceDocumentStream1);
                var pages = new List < int > ();
                for (int i = 0; i < pdfReader.NumberOfPages; i ++) {
                    pages.Add (i);
                }
                pdfReader.SelectPages (pages);
                pdfConcat.AddPages (pdfReader);
                pdfReader = new PdfReader (sourceDocumentStream2);
                pages = new List < int > ();
                for (int i = 0; i < pdfReader.NumberOfPages; i ++) {
                    pages.Add (i);
                }
                pdfReader.SelectPages (pages);
                pdfConcat.AddPages (pdfReader);
                pdfReader.Close ();
                pdfConcat.Close ();
            }}}}

private static void AppendToDocument (string sourcePdfPath) {
    var tempFileLocation = Path.GetTempFileName ();
    var bytes = File.ReadAllBytes (sourcePdfPath);
    using (var reader = new PdfReader (bytes))
    {
        var numberofPages = reader.NumberOfPages;
        var modPages = (numberofPages % 4);
        var pages = modPages == 0 ? 0 : 4 - modPages;
        if (pages == 0)
            return;
        using (var fileStream = new FileStream (tempFileLocation, FileMode.Create, FileAccess.Write))
        {
            using (var stamper = new PdfStamper (reader, fileStream))
            {
                var rectangle = reader.GetPageSize (1);
                for (var i = 1; i <= pages; i ++)
                    stamper.InsertPage (numberofPages + i, rectangle);
            }}} File.Delete (sourcePdfPath);
    File.Move (tempFileLocation, sourcePdfPath);
}

