/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9575099
*  Stack Overflow answer #:9622299
*  And Stack Overflow answer#:9622299
*/
private void FillBuffer (long position) {
    long newStart;
    if (position > bufferStart) {
        newStart = position;
    } else {
        newStart = Math.Max (0, position - buffer.Length + 2);
    }
    int bytesRead;
    int index = 0;
    stream.Position = newStart;
    while ((bytesRead = stream.Read (buffer, index, buffer.Length - index)) > 0) {
        index += bytesRead;
    }
    bufferStart = newStart;
    bufferEnd = bufferStart + index;
}

private void FillBuffer (long start, long end) {
    if (end - start > buffer.Length) {
        throw new ArgumentException ("Buffer not big enough!");
    }
    if (end > fileLength) {
        throw new ArgumentException ("Beyond end of file");
    }
    if (start >= bufferStart && end < bufferEnd) {
        return;
    }
    if (start >= bufferStart) {
        int shiftAmount = (int) (end - bufferEnd);
        Buffer.BlockCopy (buffer, shiftAmount, buffer, 0, (int) (bufferEnd - bufferStart - shiftAmount));
        stream.Position = bufferEnd;
        int bytesRead;
        int index = (int) (bufferEnd - bufferStart - shiftAmount);
        while ((bytesRead = stream.Read (buffer, index, buffer.Length - index)) > 0) {
            index += bytesRead;
        }
        bufferStart += shiftAmount;
        bufferEnd = bufferStart + index;
        return;
    }
    bufferStart = - 1;
    bufferEnd = - 1;
    FillBuffer (start);
}

