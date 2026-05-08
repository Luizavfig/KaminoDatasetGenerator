/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2421035
*  Stack Overflow answer #:2421142
*  And Stack Overflow answer#:2421313
*/
[TestMethod] public void TestGetCurrentFloor () {
    var elevator = new Elevator (Elevator.Environment.Offline);
    elevator.ElevatorArrivedOnFloor += TestElevatorArrived;
    lock (this)
    {
        elevator.GoToFloor (5);
        if (! Monitor.Wait (this, TIMEOUT))
            Assert.Fail ("Event did not arrive in time.");
    } int floor = elevator.GetCurrentFloor ();
    Assert.AreEqual (floor, 5);
}

[TestMethod] public void TestGetCurrentFloor () {
    var completedSync = new ManualResetEvent (false);
    var elevator = new Elevator (Elevator.Environment.Offline);
    elevator.ElevatorArrivedOnFloor += delegate (object sender, EventArgs e) {
        completedSync.Set ();
    };
    elevator.GoToFloor (5);
    completedSync.WaitOne (SOME_TIMEOUT_VALUE);
    int floor = elevator.GetCurrentFloor ();
    Assert.AreEqual (floor, 5);
}

