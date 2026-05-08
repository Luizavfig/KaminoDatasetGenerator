/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:955911
*  Stack Overflow answer #:955945
*  And Stack Overflow answer#:956332
*/
private static void copy (string srcFile, string dstFile, int offset, int length, byte [] buffer) {
    using (Stream inStream = File.OpenRead (srcFile))
    using (Stream outStream = File.OpenWrite (dstFile))
    {
        inStream.Seek (offset, SeekOrigin.Begin);
        int bufferLength = buffer.Length, bytesRead;
        while (length > bufferLength && (bytesRead = inStream.Read (buffer, 0, bufferLength)) > 0) {
            outStream.Write (buffer, 0, bytesRead);
            length -= bytesRead;
        }
        while (length > 0 && (bytesRead = inStream.Read (buffer, 0, length)) > 0) {
            outStream.Write (buffer, 0, bytesRead);
            length -= bytesRead;
        }
    }}

private static void Split (long offset) {
    FileStream reader = new FileStream (file_path, FileMode.Open, FileAccess.Read);
    reader.Seek (offset, SeekOrigin.Begin);
    long toRead = 0;
    if (offset + split_size <= reader.Length)
        toRead = split_size;
    else
        toRead = reader.Length - offset;
    byte [] buff = new byte [toRead];
    reader.Read (buff, 0, (int) toRead);
    reader.Dispose ();
    File.WriteAllBytes ("c:\\out" + offset + ".txt", buff);
}

