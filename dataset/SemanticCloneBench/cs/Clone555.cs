/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:46580718
*  Stack Overflow answer #:46707962
*  And Stack Overflow answer#:46658645
*/
static void Main (string [] args) {
    string libreOfficePath = getLibreOfficePath ();
    ProcessStartInfo procStartInfo = new ProcessStartInfo (libreOfficePath, string.Format ("--convert-to pdf --nologo {0}", args [0]));
    procStartInfo.RedirectStandardOutput = true;
    procStartInfo.UseShellExecute = false;
    procStartInfo.CreateNoWindow = true;
    procStartInfo.WorkingDirectory = Environment.CurrentDirectory;
    Process process = new Process () {StartInfo = procStartInfo,};
    process.Start ();
    process.WaitForExit ();
    if (process.ExitCode != 0) {
        throw new LibreOfficeFailedException (process.ExitCode);
    }
}

static void Main (string [] args) {
    var fileInfo = new FileInfo (@"c:\temp\MyDocWithImages.docx");
    string fullFilePath = fileInfo.FullName;
    string htmlText = string.Empty;
    try {
        htmlText = ParseDOCX (fileInfo);
    }
    catch (OpenXmlPackageException e) {
        if (e.ToString ().Contains ("Invalid Hyperlink")) {
            using (FileStream fs = new FileStream (fullFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                UriFixer.FixInvalidUri (fs, brokenUri = > FixUri (brokenUri));
            } htmlText = ParseDOCX (fileInfo);
        }
    }
    var writer = File.CreateText ("test1.html");
    writer.WriteLine (htmlText.ToString ());
    writer.Dispose ();
}

