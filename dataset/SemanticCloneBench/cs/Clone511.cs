/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:31796689
*  Stack Overflow answer #:38155562
*  And Stack Overflow answer#:31812179
*/
public override int Read (char [] buffer, int index, int count) {
    var ret = base.Read (buffer, index, count);
    for (int i = 0; i < ret; i ++) {
        int idx = index + i;
        if (! XmlConvert.IsXmlChar (buffer [idx]))
            buffer [idx] = ' ';
    }
    return ret;
}

public override int Read (char [] buffer, int index, int count) {
    try {
        var rVal = base.Read (buffer, index, count);
        var filteredBuffer = buffer.Select (x = > XmlConvert.IsXmlChar (x) ? x : ' ').ToArray ();
        Buffer.BlockCopy (filteredBuffer, 0, buffer, 0, count);
        return rVal;
    }
    catch (Exception ex) {
        this._logger.Error ("Read(char[], int, int)", ex);
        throw;
    }
}

