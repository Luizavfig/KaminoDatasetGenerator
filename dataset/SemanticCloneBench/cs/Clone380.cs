/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8537997
*  Stack Overflow answer #:8538895
*  And Stack Overflow answer#:8538895
*/
public override int Read () {
    int i = _source.Read ();
    if (i == - 1)
        return - 1;
    if (i == '\r') {
        if (_source.Peek () == '\n')
            _source.Read ();
        return i;
    }
    if (isNewLine (i))
        return '\n';
    return i;
}

public override int Read (char [] buffer, int index, int count) {
    char [] tmpBuffer = new char [count];
    int cChars = count = _source.Read (tmpBuffer, 0, count);
    if (cChars == 0)
        return 0;
    for (int i = 0; i != cChars; ++ i) {
        char cur = tmpBuffer [i];
        if (cur == '\r') {
            if (i == cChars - 1) {
                if (_source.Peek () == '\n') {
                    _source.Read ();
                    -- count;
                }
            } else if (tmpBuffer [i + 1] == '\r') {
                ++ i;
                -- count;
            }
            buffer [index ++] = '\n';
        } else if (isNewLine (cur))
            buffer [index ++] = '\n';
        else
            buffer [index ++] = '\n';
    }
    return count;
}

