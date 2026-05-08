/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5923767
*  Stack Overflow answer #:5924286
*  And Stack Overflow answer#:5924053
*/
static void Main (string [] args) {
    var fsm = new FiniteStateMachine ();
    Console.WriteLine (fsm.State);
    fsm.ProcessEvent (FiniteStateMachine.Events.PlugIn);
    Console.WriteLine (fsm.State);
    fsm.ProcessEvent (FiniteStateMachine.Events.TurnOn);
    Console.WriteLine (fsm.State);
    fsm.ProcessEvent (FiniteStateMachine.Events.TurnOff);
    Console.WriteLine (fsm.State);
    fsm.ProcessEvent (FiniteStateMachine.Events.TurnOn);
    Console.WriteLine (fsm.State);
    fsm.ProcessEvent (FiniteStateMachine.Events.RemovePower);
    Console.WriteLine (fsm.State);
    Console.ReadKey ();
}

static void Main (string [] args) {
    Process p = new Process ();
    Console.WriteLine ("Current State = " + p.CurrentState);
    Console.WriteLine ("Command.Begin: Current State = " + p.MoveNext (Command.Begin));
    Console.WriteLine ("Command.Pause: Current State = " + p.MoveNext (Command.Pause));
    Console.WriteLine ("Command.End: Current State = " + p.MoveNext (Command.End));
    Console.WriteLine ("Command.Exit: Current State = " + p.MoveNext (Command.Exit));
    Console.ReadLine ();
}

