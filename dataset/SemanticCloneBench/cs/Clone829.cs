/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15850633
*  Stack Overflow answer #:15850930
*  And Stack Overflow answer#:15850930
*/
void initialize () {
    ConcurrentQueue < string > queue = new ConcurrentQueue < string > ();
    foreach (string url in websites) {
        queue.Enqueue (url);
    }
    List < Thread > threads = new List < Thread > ();
    for (int i = 0; i < threadCountFromTheUser; i ++) {
        threads.Add (new Thread (work));
    }
}

void work () {
    while (! queue.IsEmpty) {
        string url;
        bool fetchedUrl = queue.TryDequeue (out url);
        if (fetchedUrl)
            ping (url);
    }
}

