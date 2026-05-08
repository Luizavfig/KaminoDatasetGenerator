/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:860656
*  Stack Overflow answer #:6351168
*  And Stack Overflow answer#:6351168
*/
private static bool GetFileNameFromHandle (IntPtr handle, out string fileName, int wait) {
    using (FileNameFromHandleState f = new FileNameFromHandleState (handle))
    {
        ThreadPool.QueueUserWorkItem (new WaitCallback (GetFileNameFromHandle), f);
        if (f.WaitOne (wait)) {
            fileName = f.FileName;
            return f.RetValue;
        } else {
            fileName = string.Empty;
            return false;
        }
    }}

private static bool GetFileNameFromHandle (IntPtr handle, out string fileName) {
    IntPtr ptr = IntPtr.Zero;
    RuntimeHelpers.PrepareConstrainedRegions ();
    try {
        int length = 0x200;
        RuntimeHelpers.PrepareConstrainedRegions ();
        try {
        }
        finally {
            ptr = Marshal.AllocHGlobal (length);
        }
        NT_STATUS ret = NativeMethods.NtQueryObject (handle, OBJECT_INFORMATION_CLASS.ObjectNameInformation, ptr, length, out length);
        if (ret == NT_STATUS.STATUS_BUFFER_OVERFLOW) {
            RuntimeHelpers.PrepareConstrainedRegions ();
            try {
            }
            finally {
                Marshal.FreeHGlobal (ptr);
                ptr = Marshal.AllocHGlobal (length);
            }
            ret = NativeMethods.NtQueryObject (handle, OBJECT_INFORMATION_CLASS.ObjectNameInformation, ptr, length, out length);
        }
        if (ret == NT_STATUS.STATUS_SUCCESS) {
            fileName = Marshal.PtrToStringUni ((IntPtr) ((int) ptr + 8), (length - 9) / 2);
            return fileName.Length != 0;
        }
    }
    finally {
        Marshal.FreeHGlobal (ptr);
    }
    fileName = string.Empty;
    return false;
}

