/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20185015
*  Stack Overflow answer #:31189443
*  And Stack Overflow answer#:20185061
*/
public static void WriteLog (string strLog) {
    StreamWriter log;
    FileStream fileStream = null;
    DirectoryInfo logDirInfo = null;
    FileInfo logFileInfo;
    string logFilePath = "C:\\Logs\\";
    logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString ("MM-dd-yyyy") + "." + "txt";
    logFileInfo = new FileInfo (logFilePath);
    logDirInfo = new DirectoryInfo (logFileInfo.DirectoryName);
    if (! logDirInfo.Exists)
        logDirInfo.Create ();
    if (! logFileInfo.Exists) {
        fileStream = logFileInfo.Create ();
    } else {
        fileStream = new FileStream (logFilePath, FileMode.Append);
    }
    log = new StreamWriter (fileStream);
    log.WriteLine (strLog);
    log.Close ();
}

public void Log (string logMessage, TextWriter txtWriter) {
    try {
        txtWriter.Write ("\r\nLog Entry : ");
        txtWriter.WriteLine ("{0} {1}", DateTime.Now.ToLongTimeString (), DateTime.Now.ToLongDateString ());
        txtWriter.WriteLine ("  :");
        txtWriter.WriteLine ("  :{0}", logMessage);
        txtWriter.WriteLine ("-------------------------------");
    }
    catch (Exception ex) {
    }
}

