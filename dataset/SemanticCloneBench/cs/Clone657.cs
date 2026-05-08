/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:34559807
*  Stack Overflow answer #:34559859
*  And Stack Overflow answer#:34559859
*/
private static void Main (string [] args) {
    const int maxPassword = 100000000;
    Console.WriteLine ("Enter number of threads: ");
    var threadsCountString = Console.ReadLine ();
    var threadsCount = int.Parse (threadsCountString);
    var threads = new Thread [threadsCount];
    for (int i = 0; i < threadsCount; i ++) {
        var thread = new Thread (Bruteforce);
        threads [i] = thread;
    }
    time.Start ();
    for (int i = 0; i < threadsCount; i ++) {
        threads [i].Start (new BruteforceParams {StartNumber = i * maxPassword / threadsCount, EndNumber = (i + 1) * maxPassword / threadsCount});
    }
    Console.ReadKey ();
}

private static void Bruteforce (object param) {
    var bp = (BruteforceParams) param;
    for (int i = bp.StartNumber; i < bp.EndNumber; i ++) {
        if (i == password) {
            Console.WriteLine ("Şifre=" + i);
            time.Stop ();
            Console.WriteLine ("Time elapsed: {0}", time.Elapsed);
        }
    }
}

