/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:394816
*  Stack Overflow answer #:7115130
*  And Stack Overflow answer#:3346055
*/
public static Dictionary < int, int > GetAllProcessParentPids () {
    var childPidToParentPid = new Dictionary < int, int > ();
    var processCounters = new SortedDictionary < string, PerformanceCounter [] > ();
    var category = new PerformanceCounterCategory ("Process");
    var instanceNames = category.GetInstanceNames ();
    foreach (string t in instanceNames) {
        try {
            processCounters [t] = category.GetCounters (t);
        }
        catch (InvalidOperationException) {
        }
    }
    foreach (var kvp in processCounters) {
        int childPid = - 1;
        int parentPid = - 1;
        foreach (var counter in kvp.Value) {
            if ("ID Process".CompareTo (counter.CounterName) == 0) {
                childPid = (int) (counter.NextValue ());
            } else if ("Creating Process ID".CompareTo (counter.CounterName) == 0) {
                parentPid = (int) (counter.NextValue ());
            }
        }
        if (childPid != - 1 && parentPid != - 1) {
            childPidToParentPid [childPid] = parentPid;
        }
    }
    return childPidToParentPid;
}

public static Process GetParentProcess (IntPtr handle) {
    ParentProcessUtilities pbi = new ParentProcessUtilities ();
    int returnLength;
    int status = NtQueryInformationProcess (handle, 0, ref pbi, Marshal.SizeOf (pbi), out returnLength);
    if (status != 0)
        throw new Win32Exception (status);
    try {
        return Process.GetProcessById (pbi.InheritedFromUniqueProcessId.ToInt32 ());
    }
    catch (ArgumentException) {
        return null;
    }
}

