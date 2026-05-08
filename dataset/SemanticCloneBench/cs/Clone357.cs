/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1127601
*  Stack Overflow answer #:2143888
*  And Stack Overflow answer#:1328179
*/
public unsafe IntPtr MarshalManagedToNative (object obj) {
    IntPtr nativeData = (IntPtr) 0;
    if (obj != null) {
        if (m_marshaledObj != null)
            throw new ApplicationException ("This instance has already marshaled a managed type");
        m_marshaledObj = obj;
        nativeData = Marshal.AllocHGlobal (GetNativeDataSize ());
        byte * pData = (byte *) nativeData;
        int offset = 0;
        ForEachField ((FieldInfo fi) = > {
            int size = Marshal.SizeOf (fi.FieldType);
            using (PinnedObject po = new PinnedObject (fi.GetValue (obj)))
            {
                MemCpy (pData + offset, po, size);
            } offset += size;
        });
    }
    return nativeData;
}

public IntPtr MarshalManagedToNative (object ManagedObj) {
    m_MarshaledInstance = (TestDataStruct) ManagedObj;
    IntPtr nativeData = Marshal.AllocHGlobal (GetNativeDataSize ());
    if (m_MarshaledInstance != null) {
        unsafe {
            byte * pData = (byte *) nativeData;
            * pData = m_MarshaledInstance.data1;
            * (int *) (pData + 1) = m_MarshaledInstance.data2;
            Marshal.Copy (m_MarshaledInstance.data3, 0, (IntPtr) (pData + 5), 7);
            * (long *) (pData + 12) = m_MarshaledInstance.data4;
            * (pData + 20) = m_MarshaledInstance.data5;
        }}
    return nativeData;
}

