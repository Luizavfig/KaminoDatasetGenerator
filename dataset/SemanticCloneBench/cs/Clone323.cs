/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:40799565
*  Stack Overflow answer #:40800287
*  And Stack Overflow answer#:40799764
*/
public static void WriteMessage (string message) {
    var path = @"../../sth.txt";
    if (File.Exists (path)) {
        string [] lines = File.ReadAllLines (path);
        using (var writer = new StreamWriter (path, true))
        {
            if (lines.Length > 0) {
                writer.WriteLine ("Another Line Added - " + message);
            } else {
                writer.WriteLine (message);
            }
            writer.Flush ();
        }} else {
        using (StreamWriter writer = new StreamWriter (path))
        {
            writer.WriteLine (message);
            writer.Flush ();
        }}
}

public static void WriteMessage (string message) {
    string path = @"log.txt";
    FileStream stream;
    if (File.Exists (path)) {
        string [] lines = File.ReadAllLines (path);
        stream = new FileStream (path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        using (StreamWriter writer = new StreamWriter (stream))
        {
            if (lines.Length > 0) {
                writer.WriteLine ("\n" + "Another Line Added - " + message);
                writer.Flush ();
            }
        }} else {
        stream = new FileStream (path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter (stream))
        {
            writer.WriteLine (message);
            writer.Flush ();
        }}
}

