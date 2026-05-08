/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7485037
*  Stack Overflow answer #:7543935
*  And Stack Overflow answer#:7543935
*/
public override void Write (char value) {
    if (value == '&') {
        if (_bufferState == 0) {
            _bufferState ++;
            return;
        } else {
            _bufferState = 0;
        }
    } else if (value == ';') {
        if (_bufferState > 1) {
            _bufferState ++;
            return;
        } else {
            Write ('&');
            Write (AmpToken);
            _bufferState = 0;
        }
    } else if (value == '\n') {
        base.Write ("&#10;");
        return;
    }
    base.Write (value);
}

public override void Write (char [] buffer, int index, int count) {
    if (_bufferState > 2) {
        _bufferState = 0;
        base.Write ('&');
        string replace;
        if ((buffer != null) && ((replace = GetReplaceLength (buffer, index, count)) != null)) {
            base.Write (replace);
            base.Write (buffer, index + replace.Length, count - replace.Length);
            return;
        } else {
            base.Write (AmpToken);
            base.Write (';');
        }
    }
    base.Write (buffer, index, count);
}

