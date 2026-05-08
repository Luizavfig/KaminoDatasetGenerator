/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1127601
*  Stack Overflow answer #:2143888
*  And Stack Overflow answer#:1328179
*/
public object MarshalNativeToManaged (IntPtr pNativeData) {
    if (m_marshaledObj != null)
        m_marshaledObj = null;
    unsafe {
        byte * pData = (byte *) pNativeData;
        int offset = 0;
        object res = new T ();
        ForEachField ((FieldInfo fi) = > {
            int size = Marshal.SizeOf (fi.FieldType);
            fi.SetValue (res, (object) (* ((byte *) (pData + offset))));
            offset += size;
        });
        return res;
    }}

public object MarshalNativeToManaged (IntPtr pNativeData) {
    TestDataStruct data = m_MarshaledInstance;
    m_MarshaledInstance = null;
    if (data == null)
        data = new TestDataStruct ();
    unsafe {
        byte * pData = (byte *) pNativeData;
        data.data1 = * pData;
        data.data2 = * (int *) (pData + 1);
        Marshal.Copy ((IntPtr) (pData + 5), data.data3, 0, 7);
        data.data4 = * (long *) (pData + 12);
        data.data5 = * (pData + 20);
    } return data;
}

