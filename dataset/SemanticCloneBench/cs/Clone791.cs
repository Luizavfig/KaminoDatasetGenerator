/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9033
*  Stack Overflow answer #:31293
*  And Stack Overflow answer#:3138039
*/
private static void parallelSpeedTest () {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine ("parallelSpeedTest");
    long totalObjectsCreated = 0;
    long totalElapsedTime = 0;
    var tasks = new List < Task > ();
    var processorCount = Environment.ProcessorCount;
    Console.WriteLine ("Running on {0} cores", processorCount);
    for (var t = 0; t < processorCount; t ++) {
        tasks.Add (Task.Factory.StartNew (() = > {
            const int reps = 1000000000;
            var sp = Stopwatch.StartNew ();
            for (var j = 0; j < reps; ++ j) {
                new object ();
            }
            sp.Stop ();
            Interlocked.Add (ref totalObjectsCreated, reps);
            Interlocked.Add (ref totalElapsedTime, sp.ElapsedMilliseconds);
        }));
    }
    Task.WaitAll (tasks.ToArray ());
    Console.WriteLine ("Created {0:N} objects in 1 sec\n", (totalObjectsCreated / (totalElapsedTime / processorCount)) * 1000);
}

[System.ComponentModel.EditorBrowsable (System.ComponentModel.EditorBrowsableState.Never)] [SecurityPermission (SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)] public override IMessage Invoke (IMessage msg) {
    IMethodCallMessage msgMethodCall = msg as IMethodCallMessage;
    Debug.Assert (msgMethodCall != null);
    MethodCallMessageWrapper mc = new MethodCallMessageWrapper (msgMethodCall);
    MethodInfo mi = (MethodInfo) mc.MethodBase;
    IMessage retval = null;
    string profileName = ProfileClassName + "." + mi.Name;
    using (ProfileManager.Start (profileName))
    {
        IMessage myReturnMessage = RemotingServices.ExecuteMessage (_target, msgMethodCall);
        retval = myReturnMessage;
    } return retval;
}

