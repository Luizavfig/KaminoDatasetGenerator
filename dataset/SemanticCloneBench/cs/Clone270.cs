/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10862768
*  Stack Overflow answer #:10870675
*  And Stack Overflow answer#:10891136
*/
public FileStreamResult DownloadPDF () {
    MemoryStream workStream = new MemoryStream ();
    ZipFile zip = new ZipFile ();
    foreach (Bla bla in Blas) {
        MemoryStream pdfStream = new MemoryStream ();
        Document document = new Document ();
        PdfWriter.GetInstance (document, pdfStream).CloseStream = false;
        document.Open ();
        document.Close ();
        byte [] pdfByteInfo = pdfStream.ToArray ();
        zip.AddEntry (bla.filename + ".pdf", pdfByteInfo);
        pdfStream.Close ();
    }
    zip.Save (workStream);
    workStream.Position = 0;
    FileStreamResult fileResult = new FileStreamResult (workStream, System.Net.Mime.MediaTypeNames.Application.Zip);
    fileResult.FileDownloadName = "MultiplePDFs.zip";
    return fileResult;
}

public FileStreamResult DownloadPDF () {
    var readable = GetPipedStream (output = > {
        using (var zip = new ZipFile ())
        {
            foreach (Bla bla in Blas) {
                zip.AddEntry (bla.filename + ".pdf", (name, stream) = > {
                    var thisBla = GetBlaFromName (name);
                    Document document = new Document ();
                    PdfWriter.GetInstance (document, stream).CloseStream = false;
                    document.Open ();
                    document.Close ();
                });
            }
            zip.Save (output);
        }});
    var fileResult = new FileStreamResult (readable, System.Net.Mime.MediaTypeNames.Application.Zip);
    fileResult.FileDownloadName = "MultiplePDFs.zip";
    return fileResult;
}

