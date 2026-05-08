/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1292490
*  Stack Overflow answer #:10805153
*  And Stack Overflow answer#:1292523
*/
static void Main (string [] args) {
    using (StreamReader sr = new StreamReader (args [0], Encoding.UTF8))
    using (StreamWriter sw = new StreamWriter (args [1], false, Encoding.Unicode))
    {
        string line;
        while ((line = sr.ReadLine ()) != null) {
            sw.WriteLine (line);
        }
    }}

public static void Main () {
    using (StreamWriter output = new StreamWriter ("practice.txt"))
    {
        string srcString = "Area = \u03A0r^2";
        byte [] utf8String = Encoding.UTF8.GetBytes (srcString);
        byte [] asciiString = Encoding.ASCII.GetBytes (srcString);
        output.WriteLine ("UTF-8  Bytes: {0}", BitConverter.ToString (utf8String));
        output.WriteLine ("ASCII  Bytes: {0}", BitConverter.ToString (asciiString));
        output.WriteLine ("UTF-8  Text : {0}", Encoding.UTF8.GetString (utf8String));
        output.WriteLine ("ASCII  Text : {0}", Encoding.ASCII.GetString (asciiString));
        Console.WriteLine (Encoding.UTF8.GetString (utf8String));
        Console.WriteLine (Encoding.ASCII.GetString (asciiString));
    }}

