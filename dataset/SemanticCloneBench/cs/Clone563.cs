/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1132702
*  Stack Overflow answer #:1133465
*  And Stack Overflow answer#:1132731
*/
static void Main (string [] args) {
    Func < string > a = (() = > "a");
    Func < string > b = (() = > "b");
    Foo foo = new Foo ();
    foo.Del = a;
    WriteFoo (foo);
    Foo bar = ReadFoo ();
    Console.WriteLine (bar.Del ());
    Console.ReadKey ();
}

static void Main (string [] args) {
    Foo foo = new Foo ();
    foo.Del = Test;
    BinaryFormatter formatter = new BinaryFormatter ();
    using (var stream = new FileStream ("test.bin", FileMode.Create, FileAccess.Write, FileShare.None))
    {
        formatter.Serialize (stream, foo);
    } using (var stream = new FileStream ("test.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        foo = (Foo) formatter.Deserialize (stream);
        Console.WriteLine (foo.Del ());
    }}

