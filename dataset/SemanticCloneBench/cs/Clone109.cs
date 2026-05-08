/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:50982966
*  Stack Overflow answer #:50983939
*  And Stack Overflow answer#:50983193
*/
static void Main () {
    int numProcessors = Environment.ProcessorCount;
    Task < long > [] results = new Task < long > [numProcessors];
    long count = 10000000000;
    long elementsPerProcessor = count / numProcessors;
    for (int i = 0; i < numProcessors; ++ i) {
        long end;
        long start = i * elementsPerProcessor;
        if (i != (numProcessors - 1))
            end = start + elementsPerProcessor;
        else
            end = count;
        results [i] = Task.Run (() = > processElements (start, end));
    }
    long sum = results.Select (r = > r.Result).Sum ();
    Console.WriteLine (sum);
}

public static void Main (string [] args) {
    const int M = 10;
    int [,,] f = new int [M + 1, 10, 2];
    f [0, 0, 0] = 1;
    for (int len = 1; len <= M; ++ len) {
        for (int d = 0; d <= 9; ++ d) {
            for (int j = 0; j <= 9; ++ j) {
                f [len, d, 0] += f [len - 1, j, 0];
                f [len, d, 1] += f [len - 1, j, 1];
            }
        }
        f [len, 4, 0] -= f [len - 1, 1, 0];
        f [len, 4, 1] += f [len - 1, 1, 0];
    }
    int sum = 0;
    for (int i = 0; i <= 9; ++ i)
        sum += f [M, i, 1];
    Console.WriteLine (sum);
}

