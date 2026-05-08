/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4099366
*  Stack Overflow answer #:32461272
*  And Stack Overflow answer#:32660198
*/
bool IsPositive (int number) {
    bool result = false;
    IntPtr memory = IntPtr.Zero;
    try {
        memory = Marshal.AllocHGlobal (4);
        if (memory == IntPtr.Zero)
            throw new OutOfMemoryException ();
        Marshal.WriteInt32 (memory, number);
        result = (Marshal.ReadByte (memory, 3) & 0x80) == 0;
    }
    finally {
        if (memory != IntPtr.Zero)
            Marshal.FreeHGlobal (memory);
    }
    return result;
}

bool isNegative (int n) {
    int i;
    for (i = 0; i <= Int32.MaxValue; i ++) {
        if (n == i)
            return false;
    }
    return true;
}

