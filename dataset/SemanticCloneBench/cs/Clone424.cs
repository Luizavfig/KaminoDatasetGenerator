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

public override void Write (string value) {
    if (_bufferState > 0) {
        if (value == AmpToken) {
            _bufferState ++;
            return;
        } else {
            Write ('&');
            _bufferState = 0;
        }
    }
    base.Write (value);
}

