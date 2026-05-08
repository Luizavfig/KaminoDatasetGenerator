/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9660280
*  Stack Overflow answer #:37660625
*  And Stack Overflow answer#:18426357
*/
public static string getDropBoxPath () {
    try {
        var appDataPath = Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData);
        var dbPath = Path.Combine (appDataPath, "Dropbox\\host.db");
        if (! File.Exists (dbPath)) {
            return null;
        } else {
            var lines = File.ReadAllLines (dbPath);
            var dbBase64Text = Convert.FromBase64String (lines [1]);
            var folderPath = Encoding.UTF8.GetString (dbBase64Text);
            return folderPath;
        }
    }
    catch (Exception ex) {
        throw ex;
    }
}

private static string GetDropBoxPath () {
    var appDataPath = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData);
    var dbPath = Path.Combine (appDataPath, "Dropbox\\host.db");
    if (! File.Exists (dbPath))
        return null;
    var lines = File.ReadAllLines (dbPath);
    var dbBase64Text = Convert.FromBase64String (lines [1]);
    var folderPath = Encoding.UTF8.GetString (dbBase64Text);
    return folderPath;
}

