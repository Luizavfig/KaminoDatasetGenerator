/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:860656
*  Stack Overflow answer #:6351168
*  And Stack Overflow answer#:6351168
*/
private static string GetHandleTypeToken (IntPtr handle, int processId) {
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
        return GetHandleTypeToken (handle);
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

private static string GetHandleTypeToken (IntPtr handle) {
    int length;
    NativeMethods.NtQueryObject (handle, OBJECT_INFORMATION_CLASS.ObjectTypeInformation, IntPtr.Zero, 0, out length);
    IntPtr ptr = IntPtr.Zero;
    RuntimeHelpers.PrepareConstrainedRegions ();
    try {
        RuntimeHelpers.PrepareConstrainedRegions ();
        try {
        }
        finally {
            ptr = Marshal.AllocHGlobal (length);
        }
        if (NativeMethods.NtQueryObject (handle, OBJECT_INFORMATION_CLASS.ObjectTypeInformation, ptr, length, out length) == NT_STATUS.STATUS_SUCCESS) {
            return Marshal.PtrToStringUni ((IntPtr) ((int) ptr + 0x60));
        }
    }
    finally {
        Marshal.FreeHGlobal (ptr);
    }
    return string.Empty;
}

