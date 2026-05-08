/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1682902
*  Stack Overflow answer #:44450379
*  And Stack Overflow answer#:11813276
*/
public override int Read (byte [] buffer, int offset, int count) {
    int len = 0, c = count;
    while (c > 0 && ! bExit) {
        try {
            len = stream.Read (buffer, offset, c);
        }
        catch (Exception e) {
            if (e.HResult == - 2146232800) {
                continue;
            } else {
                break;
            }
        }
        if (! client.Connected || len == 0) {
            return 0;
        }
        offset += len;
        c -= len;
    }
    return count;
}

public override int Read (byte [] buffer, int offset, int count) {
    int i = 0;
    while (i < count && _writeEvent != null) {
        if (! _reset && _readposition >= _writeposition) {
            _writeEvent.WaitOne (100, true);
            continue;
        }
        buffer [i] = _buffer [_readposition + offset];
        _readposition ++;
        if (_readposition == _buffersize) {
            _readposition = 0;
            _reset = false;
        }
        i ++;
    }
    return count;
}

