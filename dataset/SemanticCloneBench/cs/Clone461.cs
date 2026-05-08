/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4733707
*  Stack Overflow answer #:4733738
*  And Stack Overflow answer#:4733738
*/
public static string CreateZip (string stDirToZip) {
    try {
        DirectoryInfo di = new DirectoryInfo (stDirToZip);
        string stZipPath = di.Parent.FullName + "\\" + di.Name + ".zip";
        CreateZip (stZipPath, stDirToZip);
        return stZipPath;
    }
    catch (Exception) {
        throw;
    }
}

public static void CreateZip (string stZipPath, string stDirToZip) {
    try {
        stDirToZip = Path.GetFullPath (stDirToZip);
        stZipPath = Path.GetFullPath (stZipPath);
        Console.WriteLine ("Zip directory " + stDirToZip);
        Stack < FileInfo > stackFiles = DirExplore (stDirToZip);
        ZipOutputStream zipOutput = null;
        if (File.Exists (stZipPath))
            File.Delete (stZipPath);
        Crc32 crc = new Crc32 ();
        zipOutput = new ZipOutputStream (File.Create (stZipPath));
        zipOutput.SetLevel (6);
        Console.WriteLine (stackFiles.Count + " files to zip.\n");
        int index = 0;
        foreach (FileInfo fi in stackFiles) {
            ++ index;
            int percent = (int) ((float) index / ((float) stackFiles.Count / 100));
            if (percent % 1 == 0) {
                Console.CursorLeft = 0;
                Console.Write (_stSchon [index % _stSchon.Length].ToString () + " " + percent + "% done.");
            }
            FileStream fs = File.OpenRead (fi.FullName);
            byte [] buffer = new byte [fs.Length];
            fs.Read (buffer, 0, buffer.Length);
            string stFileName = fi.FullName.Remove (0, stDirToZip.Length + 1);
            ZipEntry entry = new ZipEntry (stFileName);
            entry.DateTime = DateTime.Now;
            entry.Size = fs.Length;
            fs.Close ();
            crc.Reset ();
            crc.Update (buffer);
            entry.Crc = crc.Value;
            zipOutput.PutNextEntry (entry);
            zipOutput.Write (buffer, 0, buffer.Length);
        }
        zipOutput.Finish ();
        zipOutput.Close ();
        zipOutput = null;
    }
    catch (Exception) {
        throw;
    }
}

