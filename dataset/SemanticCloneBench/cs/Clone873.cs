/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:419019
*  Stack Overflow answer #:10426375
*  And Stack Overflow answer#:10425490
*/
private static IEnumerable < IEnumerable < T > > ClumpIterator < T > (IEnumerable < T > source, int size) {
    Debug.Assert (source != null, "source is null.");
    T [] items = new T [size];
    int count = 0;
    foreach (var item in source) {
        items [count] = item;
        count ++;
        if (count == size) {
            yield return items;
            items = new T [size];
            count = 0;
        }
    }
    if (count > 0) {
        if (count == size)
            yield return items;
        else {
            T [] tempItems = new T [count];
            Array.Copy (items, tempItems, count);
            yield return tempItems;
        }
    }
}

static void Main (string [] args) {
    int i = 10;
    foreach (var group in Enumerable.Range (1, int.MaxValue).Skip (10000000).Chunk (3)) {
        foreach (var n in group) {
            Console.Write (n);
            Console.Write (" ");
        }
        Console.WriteLine ();
        if (i -- == 0)
            break;
    }
    var stuffs = Enumerable.Range (1, 10).Chunk (2).ToArray ();
    foreach (var idx in new [] {3, 2, 1}) {
        Console.Write ("idx " + idx + " ");
        foreach (var n in stuffs [idx]) {
            Console.Write (n);
            Console.Write (" ");
        }
        Console.WriteLine ();
    }
    Console.ReadKey ();
}

