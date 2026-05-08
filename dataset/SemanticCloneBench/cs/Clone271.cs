/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5931266
*  Stack Overflow answer #:5931318
*  And Stack Overflow answer#:5931287
*/
static void Main (string [] args) {
    ArrayList siteList = new ArrayList ();
    ArrayList deserealizedArray = DeserializeArray ();
    foreach (var item in deserealizedArray) {
        Console.WriteLine (item);
    }
    Console.WriteLine ("---");
    siteList.Add ("Test 1");
    siteList.Add ("Test 2");
    foreach (var item in siteList) {
        Console.WriteLine (item);
    }
    SerializeArray (siteList);
    if (siteList.Contains ("Test 2")) {
        Console.WriteLine ("Test 2 exists!");
        Console.Read ();
    }
}

static void Main (string [] args) {
    ArrayList siteList = new ArrayList ();
    siteList.Add ("Test 1");
    siteList.Add ("Test 2");
    foreach (var item in siteList) {
        Console.WriteLine (item);
    }
    SerializeArray (siteList);
    siteList = DeserializeArray ();
    if (siteList.Contains ("Test 2")) {
        Console.WriteLine ("Test 2 exists!");
        Console.Read ();
    }
}

