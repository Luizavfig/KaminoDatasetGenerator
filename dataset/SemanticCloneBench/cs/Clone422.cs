/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:512166
*  Stack Overflow answer #:512378
*  And Stack Overflow answer#:512357
*/
static void Main (string [] args) {
    var ListOfFoo = new List < Foo > ();
    ListOfFoo.Add (new Foo (1));
    ListOfFoo.Add (new Foo (2));
    ListOfFoo.Add (new Foo (3));
    ListOfFoo.Add (new Foo (4));
    var threads = new List < Thread > ();
    foreach (Foo f in ListOfFoo) {
        Thread thread = new Thread (() = > f.DoSomething ());
        threads.Add (thread);
        thread.Start ();
    }
}

static void Main () {
    List < Action > badActions = new List < Action > ();
    List < Action > goodActions = new List < Action > ();
    for (int i = 0; i < 10; i ++) {
        int copy = i;
        badActions.Add (() = > Console.WriteLine (i));
        goodActions.Add (() = > Console.WriteLine (copy));
    }
    Console.WriteLine ("Bad actions:");
    foreach (Action action in badActions) {
        action ();
    }
    Console.WriteLine ("Good actions:");
    foreach (Action action in goodActions) {
        action ();
    }
}

