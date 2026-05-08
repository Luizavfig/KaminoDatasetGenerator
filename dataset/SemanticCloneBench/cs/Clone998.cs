/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:336633
*  Stack Overflow answer #:8621467
*  And Stack Overflow answer#:28866330
*/
public static bool Is32bitProcess (Process proc) {
    if (! IsThis64bitProcess ())
        return true;
    foreach (ProcessModule module in proc.Modules) {
        try {
            string fname = Path.GetFileName (module.FileName).ToLowerInvariant ();
            if (fname.Contains ("wow64")) {
                return true;
            }
        }
        catch {
        }
    }
    return false;
}

public static bool Is64BitOperatingSystem () {
    if (IntPtr.Size == 8)
        return true;
    IntPtr moduleHandle = GetModuleHandle ("kernel32");
    if (moduleHandle != IntPtr.Zero) {
        IntPtr processAddress = GetProcAddress (moduleHandle, "IsWow64Process");
        if (processAddress != IntPtr.Zero) {
            bool result;
            if (IsWow64Process (GetCurrentProcess (), out result) && result)
                return true;
        }
    }
    return false;
}

