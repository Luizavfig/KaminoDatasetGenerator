/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6039268
*  Stack Overflow answer #:6040373
*  And Stack Overflow answer#:6039328
*/
static void Main (string [] args) {
    HttpWebResponse response = new HttpWebResponse ();
    try {
        response.GetResponse ();
    }
    catch (Exception ex) {
    }
    finally {
        response.Dispose ();
    }
}

static void Main (string [] args) {
    Foo foo = new Foo ();
    try {
        using (Bar bar = foo.CreateBar ())
        {
            throw new ApplicationException ("Something wrong inside the using.");
        }}
    catch (Exception exception) {
        Console.WriteLine (exception.Message);
    }
}

