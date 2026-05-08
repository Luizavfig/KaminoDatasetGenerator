/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15089373
*  Stack Overflow answer #:15089598
*  And Stack Overflow answer#:15089845
*/
static IEnumerable < double > TopNSorted (this IEnumerable < double > source, int n) {
    List < double > top = new List < double > (n + 1);
    using (var e = source.GetEnumerator ())
    {
        for (int i = 0; i < n; i ++) {
            if (e.MoveNext ())
                top.Add (e.Current);
            else
                throw new InvalidOperationException ("Not enough elements");
        }
        top.Sort ();
        while (e.MoveNext ()) {
            double c = e.Current;
            int index = top.BinarySearch (c);
            if (index < 0)
                index = ~ index;
            if (index < n) {
                top.Insert (index, c);
                top.RemoveAt (n);
            }
        }
    } return top;
}

static void Main () {
    const int SIZE = 1000000;
    const int K = 10;
    var random = new Random ();
    var values = new double [SIZE];
    for (var i = 0; i < SIZE; i ++)
        values [i] = random.NextDouble ();
    values [SIZE / 2] = 2.0;
    values [SIZE / 4] = 3.0;
    values [SIZE / 8] = 4.0;
    IEnumerable < double > result;
    var stopwatch = new Stopwatch ();
    stopwatch.Start ();
    result = values.OrderByDescending (x = > x).Take (K).ToArray ();
    stopwatch.Stop ();
    Console.WriteLine (stopwatch.ElapsedMilliseconds);
    stopwatch.Restart ();
    result = values.GetTopValues (K).ToArray ();
    stopwatch.Stop ();
    Console.WriteLine (stopwatch.ElapsedMilliseconds);
}

