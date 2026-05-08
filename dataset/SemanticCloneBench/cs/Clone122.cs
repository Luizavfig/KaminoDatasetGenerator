/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:860656
*  Stack Overflow answer #:6351168
*  And Stack Overflow answer#:6351168
*/
private static bool GetFileNameFromHandle (IntPtr handle, int processId, out string fileName) {
    IntPtr currentProcess = NativeMethods.GetCurrentProcess ();
    bool remote = (processId != NativeMethods.GetProcessId (currentProcess));
    SafeProcessHandle processHandle = null;
    SafeObjectHandle objectHandle = null;
    try {
        if (remote) {
            processHandle = NativeMethods.OpenProcess (ProcessAccessRights.PROCESS_DUP_HANDLE, true, processId);
            if (NativeMethods.DuplicateHandle (processHandle.DangerousGetHandle (), handle, currentProcess, out objectHandle, 0, false, DuplicateHandleOptions.DUPLICATE_SAME_ACCESS)) {
                handle = objectHandle.DangerousGetHandle ();
            }
        }
        return GetFileNameFromHandle (handle, out fileName, 200);
    }
    finally {
        if (remote) {
            if (processHandle != null) {
                processHandle.Close ();
            }
            if (objectHandle != null) {
                objectHandle.Close ();
            }
        }
    }
}

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

