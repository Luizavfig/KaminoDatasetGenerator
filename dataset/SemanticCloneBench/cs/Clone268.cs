/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7137121
*  Stack Overflow answer #:7137129
*  And Stack Overflow answer#:7137130
*/
static void Main () {
    HiResTimer timer = new HiResTimer ();
    Int64 counterAtStart = timer.Value;
    for (int count = 0; count < 10000; count ++) {
        count ++;
        count --;
    }
    Int64 counterAtEnd = timer.Value;
    Int64 timeElapsedInTicks = counterAtEnd - counterAtStart;
    Int64 timeElapseInTenthsOfMilliseconds = (timeElapsedInTicks * 10000) / timer.Frequency;
    MessageBox.Show ("Time Spent in operation (tenths of ms) " + timeElapseInTenthsOfMilliseconds + "\nCounter Value At Start: " + counterAtStart + "\nCounter Value At End : " + counterAtEnd + "\nCounter Frequency : " + timer.Frequency);
}

public static void Main (String [] args) {
    Timer timer = new Timer ();
    timer.Interval = 1;
    timer.Enabled = true;
    Stopwatch sw = Stopwatch.StartNew ();
    long start = 0;
    long end = sw.ElapsedMilliseconds;
    timer.Elapsed += (o, e) = > {
        start = end;
        end = sw.ElapsedMilliseconds;
        Console.WriteLine ("{0} milliseconds passed", end - start);
    };
    Console.ReadLine ();
}

