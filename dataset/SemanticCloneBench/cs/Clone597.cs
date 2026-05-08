/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:27763260
*  Stack Overflow answer #:27764592
*  And Stack Overflow answer#:27764592
*/
public object Get (string name) {
    object data = null;
    var field = _type.GetField (name);
    if (field != null) {
        data = field.GetValue (this);
    } else {
        var member = _type.GetProperty (name);
        if (member != null) {
            data = member.GetValue (this);
        }
    }
    return data;
}

public static void Main () {
    var b1 = new B1 ();
    var b2 = new B2 ();
    b1.Info1 = 1;
    b2.Info2 = "sad";
    Console.WriteLine (b1.Get < int > ("Info1"));
    Console.WriteLine (b2.Get ("Info2"));
    Console.WriteLine ("\r\n\r\n");
    var c = new C ();
    c.mObject = new B1 ();
    (c.mObject as B).Set ("Info1", 123);
    Console.WriteLine ((c.mObject as B).Get ("Info1"));
}

