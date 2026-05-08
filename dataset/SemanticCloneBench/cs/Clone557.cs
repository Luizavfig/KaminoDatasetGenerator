/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1080442
*  Stack Overflow answer #:1080470
*  And Stack Overflow answer#:1085466
*/
static byte [] StreamToByteArray (Stream inputStream) {
    if (! inputStream.CanRead) {
        throw new ArgumentException ();
    }
    if (inputStream.CanSeek) {
        inputStream.Seek (0, SeekOrigin.Begin);
    }
    byte [] output = new byte [inputStream.Length];
    int bytesRead = inputStream.Read (output, 0, output.Length);
    Debug.Assert (bytesRead == output.Length, "Bytes read from stream matches stream length");
    return output;
}

public byte [] StreamToByteArray (string fileName) {
    byte [] total_stream = new byte [0];
    using (Stream input = File.Open (fileName, FileMode.Open, FileAccess.Read))
    {
        byte [] stream_array = new byte [0];
        byte [] buffer = new byte [32];
        int read = 0;
        while ((read = input.Read (buffer, 0, buffer.Length)) > 0) {
            stream_array = new byte [total_stream.Length + read];
            total_stream.CopyTo (stream_array, 0);
            Array.Copy (buffer, 0, stream_array, total_stream.Length, read);
            total_stream = stream_array;
        }
    } return total_stream;
}

