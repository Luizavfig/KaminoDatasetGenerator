/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1290621
*  Stack Overflow answer #:1291365
*  And Stack Overflow answer#:1291211
*/
static void Main (string [] args) {
    String a = "Hello ";
    String b = " World! ";
    int it = 20000;
    char [] result = new char [a.Length + it * b.Length];
    a.ToCharArray ().CopyTo (result, 0);
    for (int i = 0; i < it; i ++)
        b.ToCharArray ().CopyTo (result, a.Length + i * b.Length);
    Console.WriteLine (result);
}

static void Main (string [] args) {
    String a = "Hello ";
    String b = " World! ";
    System.IO.MemoryStream ms = new System.IO.MemoryStream (20000 * b.Length + a.Length);
    System.IO.StreamWriter sw = new System.IO.StreamWriter (ms);
    sw.Write (a);
    for (int i = 0; i < 20000; i ++) {
        sw.Write (b);
    }
    ms.Seek (0, System.IO.SeekOrigin.Begin);
    System.IO.StreamReader sr = new System.IO.StreamReader (ms);
    Console.WriteLine (sr.ReadToEnd ());
}

