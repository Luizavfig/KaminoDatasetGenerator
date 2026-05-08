/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4728407
*  Stack Overflow answer #:4728935
*  And Stack Overflow answer#:4729409
*/
public T Dequeue () {
    if (this._size == 0) {
        ThrowHelper.ThrowInvalidOperationException (ExceptionResource.InvalidOperation_EmptyQueue);
    }
    T local = this._array [this._head];
    this._array [this._head] = default (T);
    this._head = (this._head + 1) % this._array.Length;
    this._size --;
    this._version ++;
    return local;
}

public T Dequeue () {
    while (! _first.IsValid && _first.Next != null)
        _first = _first.Next;
    if (IsEmpty)
        throw new InvalidOperationException ();
    return _first.TakeValue ();
}

