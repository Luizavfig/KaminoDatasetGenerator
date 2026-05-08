/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:469798
*  Stack Overflow answer #:469970
*  And Stack Overflow answer#:813201
*/
public bool IsCompletedBy (Keys key) {
    if (Keys [Position + 1] == key) {
        Position ++;
    } else if (Position == 1 && key == System.Windows.Forms.Keys.Up) {
    } else if (Keys [0] == key) {
        Position = 0;
    } else {
        Position = - 1;
    }
    if (Position == Keys.Count - 1) {
        Position = - 1;
        return true;
    }
    return false;
}

public bool IsCompletedBy (Keys key) {
    _offset %= _target;
    if (key == _code [_offset])
        _offset ++;
    else if (key == _code [0])
        _offset = 2;
    return _offset > _length;
}

