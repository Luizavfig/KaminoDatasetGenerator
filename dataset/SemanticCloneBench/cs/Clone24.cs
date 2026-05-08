/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2243593
*  Stack Overflow answer #:2243754
*  And Stack Overflow answer#:2243759
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

static void Main (string [] args) {
    if (args.Length == 0 || args.Length > 1) {
        ShowUsage ();
        return;
    }
    string target = args [0];
    string path = Path.IsPathRooted (target) ? target : Path.GetDirectoryName (Process.GetCurrentProcess ().MainModule.FileName) + Path.DirectorySeparatorChar + target;
    Console.Write (Assembly.LoadFile (path).GetName ().Version.ToString (2));
}

