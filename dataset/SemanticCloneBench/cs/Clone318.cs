/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:469798
*  Stack Overflow answer #:40814111
*  And Stack Overflow answer#:813201
*/
public bool IsCompletedBy (Keys key) {
    if (key == _code [_index]) {
        if (_index == _code.Length - 1) {
            _index = 0;
            return true;
        }
        ++ _index;
    } else {
        _index = 0;
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

