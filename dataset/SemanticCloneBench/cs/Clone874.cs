/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:648700
*  Stack Overflow answer #:2554092
*  And Stack Overflow answer#:2467823
*/
public static void DelayedExecute (int millisecondsToDelay, MethodInvoker methodToExecute) {
    Timer timer = new Timer ();
    timer.Interval = millisecondsToDelay;
    timer.Tick += delegate {
        if (timer.Enabled) {
            timer.Stop ();
            methodToExecute.Invoke ();
            timer.Dispose ();
        }
    };
    timer.Start ();
}

public static Timer Do (Action action, int dueTime) {
    var state = new TimerState ();
    state.Timer = new Timer (o = > {
        action ();
        lock (o)
        {
            ((TimerState) o).Timer.Dispose ();
        }}, state, dueTime, - 1);
    return state.Timer;
}

