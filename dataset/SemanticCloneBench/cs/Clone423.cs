/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3220497
*  Stack Overflow answer #:26536920
*  And Stack Overflow answer#:7036911
*/
public static IntPtr EnsureHandle (this WindowInteropHelper helper) {
    if (helper == null)
        throw new ArgumentNullException ("helper");
    if (helper.Handle == IntPtr.Zero) {
        var window = (Window) typeof (WindowInteropHelper).InvokeMember ("_window", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic, null, helper, null);
        try {
            typeof (Window).InvokeMember ("SafeCreateWindow", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic, null, window, null);
        }
        catch (MissingMethodException) {
            typeof (Window).InvokeMember ("CreateSourceWindow", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic, null, window, new object [] {false});
        }
    }
    return helper.Handle;
}

public static IntPtr EnsureHandle (this WindowInteropHelper helper) {
    if (helper == null)
        throw new ArgumentNullException ("helper");
    if (helper.Handle == IntPtr.Zero) {
        var window = (Window) typeof (WindowInteropHelper).InvokeMember ("_window", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic, null, helper, null);
        typeof (Window).InvokeMember ("SafeCreateWindow", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic, null, window, null);
    }
    return helper.Handle;
}

