/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:462381
*  Stack Overflow answer #:462553
*  And Stack Overflow answer#:462553
*/
public static void ExitWindows (RestartOptions how, bool force) {
    switch (how) {
        case RestartOptions.Suspend :
            SuspendSystem (false, force);
            break;
        case RestartOptions.Hibernate :
            SuspendSystem (true, force);
            break;
        default :
            ExitWindows ((int) how, force);
            break;
    }
}

protected static void ExitWindows (int how, bool force) {
    EnableToken ("SeShutdownPrivilege");
    if (force)
        how = how | EWX_FORCE;
    if (ExitWindowsEx (how, 0) == 0)
        throw new PrivilegeException (FormatError (Marshal.GetLastWin32Error ()));
}

