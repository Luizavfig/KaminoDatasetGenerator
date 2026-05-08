/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5891538
*  Stack Overflow answer #:9979160
*  And Stack Overflow answer#:41329961
*/
static void Main (string [] args) {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine ("Split Analyser starts");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine ("Press Esc to quit.....");
    Thread MainThread = new Thread (new ThreadStart (startProcess));
    Thread ConsoleKeyListener = new Thread (new ThreadStart (ListerKeyBoardEvent));
    MainThread.Name = "Processor";
    ConsoleKeyListener.Name = "KeyListener";
    MainThread.Start ();
    ConsoleKeyListener.Start ();
    while (true) {
        if (Terminate) {
            Console.WriteLine ("Terminating Process...");
            MainThread.Abort ();
            ConsoleKeyListener.Abort ();
            Thread.Sleep (2000);
            Thread.CurrentThread.Abort ();
            return;
        }
        if (stopProcessor) {
            Console.WriteLine ("Ending Process...");
            MainThread.Abort ();
            ConsoleKeyListener.Abort ();
            Thread.Sleep (2000);
            Thread.CurrentThread.Abort ();
            return;
        }
    }
}

static void Main (String [] args) {
    Console.WriteLine ("Press any key to prevent exit...");
    var tHold = Task.Run (() = > Console.ReadKey (true));
    if (tHold.IsCompleted) {
        while (Console.KeyAvailable)
            Console.ReadKey (true);
        Console.WriteLine ("Holding. Press 'Esc' to exit.");
        while (Console.ReadKey (true).Key != ConsoleKey.Escape)
            ;
    }
}

