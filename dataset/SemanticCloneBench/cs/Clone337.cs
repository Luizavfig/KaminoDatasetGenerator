/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:48572062
*  Stack Overflow answer #:48574295
*  And Stack Overflow answer#:48573113
*/
public static void Main () {
    int numTasks = 20;
    int maxParallelism = 3;
    BlockingCollection = new BlockingCollection < Task < int > > (maxParallelism);
    Task.Factory.StartNew (() = > Producer (numTasks));
    foreach (var task in BlockingCollection.GetConsumingEnumerable ()) {
        task.Wait ();
        Console.WriteLine ("              Consumed: " + task.Result);
        task.Dispose ();
    }
}

public static void Main () {
    var blockingCollection = new QueuedBlockingCollection < int > (10);
    var tasks = new Task [10];
    for (int i = 1; i <= 10; i ++)
        blockingCollection.Add (99);
    for (int i = 1; i <= 10; i ++) {
        int index = i;
        tasks [index - 1] = Task.Run (() = > blockingCollection.Enqueue (index));
        Task.Delay (100).Wait ();
    }
    while (blockingCollection.Count > 0) {
        var n = blockingCollection.Take ();
        Console.WriteLine (n);
    }
    Task.WaitAll (tasks);
    while (blockingCollection.Count > 0) {
        var n = blockingCollection.Take ();
        Console.WriteLine (n);
    }
}

