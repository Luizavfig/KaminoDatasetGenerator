/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:39461801
*  Stack Overflow answer #:52395369
*  And Stack Overflow answer#:39462269
*/
public static void OnWillCreateAsset (string path) {
    path = path.Replace (".meta", "");
    int index = path.LastIndexOf (".");
    if (index < 0)
        return;
    string file = path.Substring (index);
    if (file != ".cs" && file != ".js" && file != ".boo")
        return;
    index = Application.dataPath.LastIndexOf ("Assets");
    path = Application.dataPath.Substring (0, index) + path;
    file = System.IO.File.ReadAllText (path);
    string lastPart = path.Substring (path.IndexOf ("Assets"));
    string _namespace = lastPart.Substring (0, lastPart.LastIndexOf ('/'));
    _namespace = _namespace.Replace ('/', '.');
    file = file.Replace ("#NAMESPACE#", _namespace);
    System.IO.File.WriteAllText (path, file);
    AssetDatabase.Refresh ();
}

public static void OnWillCreateAsset (string path) {
    path = path.Replace (".meta", "");
    int index = path.LastIndexOf (".");
    string file = path.Substring (index);
    if (file != ".cs" && file != ".js" && file != ".boo")
        return;
    index = Application.dataPath.LastIndexOf ("Assets");
    path = Application.dataPath.Substring (0, index) + path;
    file = System.IO.File.ReadAllText (path);
    file = file.Replace ("#CREATIONDATE#", System.DateTime.Now + "");
    file = file.Replace ("#PROJECTNAME#", PlayerSettings.productName);
    file = file.Replace ("#SMARTDEVELOPERS#", PlayerSettings.companyName);
    System.IO.File.WriteAllText (path, file);
    AssetDatabase.Refresh ();
}

