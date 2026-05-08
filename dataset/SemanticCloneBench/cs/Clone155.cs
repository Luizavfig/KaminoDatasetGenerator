/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3879152
*  Stack Overflow answer #:3879231
*  And Stack Overflow answer#:3879208
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

public override int Read (Byte [] buffer, int offset, int count) {
    int result = 0;
    while (count > 0) {
        _UnderlyingStreams [_Index].Position = _Position - _UnderlyingStartingPositions [_Index];
        int bytesRead = _UnderlyingStreams [_Index].Read (buffer, offset, count);
        result += bytesRead;
        offset += bytesRead;
        count -= bytesRead;
        _Position += bytesRead;
        if (count > 0) {
            if (_Index < _UnderlyingStreams.Length - 1)
                _Index ++;
            else
                break;
        }
    }
    return result;
}

