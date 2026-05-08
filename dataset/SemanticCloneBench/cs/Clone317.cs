/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:469798
*  Stack Overflow answer #:40814111
*  And Stack Overflow answer#:469970
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

