/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11307819
*  Stack Overflow answer #:11307975
*  And Stack Overflow answer#:11310239
*/
public void doWork () {
    int h = 0;
    do
        {
            Thread.Sleep (3000);
            h.Dump ();
            h ++;
        } while (true);
}

public void doWork (int h2) {
    Stopwatch sw = new Stopwatch ();
    sw.Start ();
    try {
        t ++;
        Console.WriteLine ("h={0}, h2={1}, threads={2} [start]", h, h2, t);
        Thread.Sleep (3000);
    }
    finally {
        sw.Stop ();
        var tim = sw.Elapsed;
        var elapsedMS = tim.Seconds * 1000 + tim.Milliseconds;
        t --;
        Console.WriteLine ("h={0}, h2={1}, threads={2} [end, sleep time={3} ms] ", h, h2, t, elapsedMS);
    }
}

