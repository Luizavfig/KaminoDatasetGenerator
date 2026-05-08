/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:20065780
*  Stack Overflow answer #:20066033
*  And Stack Overflow answer#:20067933
*/
static void Main (string [] args) {
    Thread thread = new Thread (new ThreadStart (Zombie));
    thread.Start ();
    Thread.Sleep (500);
    thread.Abort ();
    Monitor.Enter (_lock);
    Console.WriteLine ("Main entered");
    Console.ReadKey ();
}

static void Main (string [] args) {
    for (var i = 0; i < 150; i ++) {
        CreateImage ();
    }
    GC.Collect ();
    FindPrimeNumber (1000000);
    foreach (var zombie in Zombie.Undead) {
        zombie.Image.Save (@"C:\temp\x.png");
    }
    Console.ReadLine ();
}

