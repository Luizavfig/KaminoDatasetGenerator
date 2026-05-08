/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3879152
*  Stack Overflow answer #:3879231
*  And Stack Overflow answer#:3879246
*/
public override int Read (byte [] buffer, int offset, int count) {
    if (streams.Count == 0)
        return 0;
    int bytesRead = streams.Peek ().Read (buffer, offset, count);
    if (bytesRead == 0) {
        streams.Dequeue ().Dispose ();
        bytesRead += Read (buffer, offset + bytesRead, count - bytesRead);
    }
    return bytesRead;
}

public override int Read (byte [] buffer, int offset, int count) {
    int result = 0;
    while (count > 0) {
        Stream stream = Current;
        if (stream == null)
            break;
        int thisCount = stream.Read (buffer, offset, count);
        result += thisCount;
        count -= thisCount;
        offset += thisCount;
        if (thisCount == 0)
            EndOfStream ();
    }
    position += result;
    return result;
}

