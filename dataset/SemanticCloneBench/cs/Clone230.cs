/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35412416
*  Stack Overflow answer #:35412904
*  And Stack Overflow answer#:35413165
*/
void ICollection.CopyTo (Array array, int index) {
    if (array == null)
        throw new ArgumentNullException ("array");
    PlcParameter [] ppArray = array as PlcParameter [];
    if (ppArray == null)
        throw new ArgumentException ();
    ((ICollection < PlcParameter >) this).CopyTo (ppArray, index);
}

void ICollection.CopyTo (Array array, int index) {
    if (array != null && array.Rank != 1)
        throw new ArgumentException ("Only single dimensional arrays are supported for the requested action.", "array");
    T [] typedArray = array as T [];
    if (typedArray != null) {
        CopyTo (typedArray, index);
        return;
    }
    object [] objectArray = array as object [];
    if (objectArray != null) {
        for (int i = 0; i < size; i ++) {
            objectArray [index ++] = GetElementAt (i);
        }
    }
    throw new ArgumentException ("Target array type is not compatible with the type of items in the collection.");
}

