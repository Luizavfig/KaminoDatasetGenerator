/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:44221454
*  Stack Overflow answer #:44266945
*  And Stack Overflow answer#:44222169
*/
internal void Pop () {
    Debug.Assert (_count != 0);
    if (_count > 0) {
        -- _count;
        int ix = 0;
        while (ix < _count / 2) {
            int smallestChild = HeapLeftChild (ix);
            int rightChild = HeapRightFromLeft (smallestChild);
            if (rightChild < _count - 1 && _comparer.Compare (_heap [rightChild], _heap [smallestChild]) < 0) {
                smallestChild = rightChild;
            }
            if (_comparer.Compare (_heap [_count], _heap [smallestChild]) <= 0) {
                break;
            }
            _heap [ix] = _heap [smallestChild];
            ix = smallestChild;
        }
        _heap [ix] = _heap [_count];
        _heap [_count] = default (T);
    }
}

internal void Pop () {
    Debug.Assert (_count != 0);
    if (_count > 1) {
        int parent = 0;
        int leftChild = HeapLeftChild (parent);
        while (leftChild < _count) {
            int rightChild = HeapRightFromLeft (leftChild);
            int bestChild = (rightChild < _count && _comparer.Compare (_heap [rightChild], _heap [leftChild]) < 0) ? rightChild : leftChild;
            _heap [parent] = _heap [bestChild];
            parent = bestChild;
            leftChild = HeapLeftChild (parent);
        }
        _heap [parent] = _heap [_count - 1];
        int index = parent;
        var value = _heap [parent];
        while (index > 0) {
            int parentIndex = HeapParent (index);
            if (_comparer.Compare (value, _heap [parentIndex]) < 0) {
                var pivot = _heap [index];
                _heap [index] = _heap [parentIndex];
                _heap [parentIndex] = pivot;
                index = parentIndex;
            } else {
                break;
            }
        }
    }
    _count --;
}

