/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2243593
*  Stack Overflow answer #:2243754
*  And Stack Overflow answer#:14492499
*/
static void Main (string [] args) {
    var assemblyFilename = args.FirstOrDefault ();
    if (assemblyFilename != null && File.Exists (assemblyFilename)) {
        try {
            var assembly = Assembly.ReflectionOnlyLoadFrom (assemblyFilename);
            var name = assembly.GetName ();
            using (var file = File.AppendText ("C:\\AssemblyInfo.txt"))
            {
                file.WriteLine ("{0} - {1}", name.FullName, name.Version);
            }}
        catch (Exception ex) {
            throw;
        }
    }
}

public static void WriteAppCastFile (string castPath, string exeVersion) {
    TextWriter tw = new StreamWriter (castPath);
    tw.WriteLine (@"<?xml version=""1.0"" encoding=""utf-8""?>");
    tw.WriteLine (@"<item>");
    tw.WriteLine (@"<title>MyApp - New version! Release " + exeVersion + " is available.</title>");
    tw.WriteLine (@"<version>" + exeVersion + "</version>");
    tw.WriteLine (@"<url>http://www.example.com/pathto/updates/MyApp.exe</url>");
    tw.WriteLine (@"<changelog>http://www.example.com/pathto/updates/MyApp_release_notes.html</changelog>");
    tw.WriteLine (@"</item>");
    tw.Close ();
}

