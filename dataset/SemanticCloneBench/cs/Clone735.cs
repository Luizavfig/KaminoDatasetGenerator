/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:40305645
*  Stack Overflow answer #:40306703
*  And Stack Overflow answer#:40305901
*/
public static void AssignValueToProperty (this ObjectAccessor accessor, string propertyName, object value) {
    var index = propertyName.IndexOf ('.');
    if (index == - 1) {
        accessor [propertyName] = value;
    } else {
        accessor = ObjectAccessor.Create (accessor [propertyName.Substring (0, index)]);
        AssignValueToProperty (accessor, propertyName.Substring (index + 1), value);
    }
}

public static void UseFastMember () {
    var b = new B {Second = "some value here"};
    var a = new A {First = b};
    var value = "hello";
    var a_accessor = ObjectAccessor.Create (a);
    var first = a_accessor ["First"];
    var b_accessor = ObjectAccessor.Create (first);
    b_accessor ["Second"] = value;
}

