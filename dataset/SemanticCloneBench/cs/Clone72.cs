/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:658498
*  Stack Overflow answer #:15229587
*  And Stack Overflow answer#:13355702
*/
[STAThread] static void Main (string [] args) {
    fileDialog.ShowDialog ();
    string fileName = fileDialog.FileName;
    if (string.IsNullOrEmpty (fileName) == false) {
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        if (Directory.Exists (@"c:\Provisioning\") == false)
            Directory.CreateDirectory (@"c:\Provisioning\");
        assemblyDirectory = Path.GetDirectoryName (fileName);
        Assembly loadedAssembly = Assembly.LoadFile (fileName);
        List < Type > assemblyTypes = loadedAssembly.GetTypes ().ToList < Type > ();
        foreach (var type in assemblyTypes) {
            if (type.IsInterface == false) {
                StreamWriter jsonFile = File.CreateText (string.Format (@"c:\Provisioning\{0}.json", type.Name));
                JavaScriptSerializer serializer = new JavaScriptSerializer ();
                jsonFile.WriteLine (serializer.Serialize (Activator.CreateInstance (type)));
                jsonFile.Close ();
            }
        }
    }
}

static void Main (string [] args) {
    AppDomainSetup domaininfo = new AppDomainSetup ();
    domaininfo.ApplicationBase = System.Environment.CurrentDirectory;
    Evidence adevidence = AppDomain.CurrentDomain.Evidence;
    AppDomain domain = AppDomain.CreateDomain ("MyDomain", adevidence, domaininfo);
    Type type = typeof (Proxy);
    var value = (Proxy) domain.CreateInstanceAndUnwrap (type.Assembly.FullName, type.FullName);
    var assembly = value.GetAssembly (args [0]);
}

