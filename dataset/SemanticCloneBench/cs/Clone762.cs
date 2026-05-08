/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12415576
*  Stack Overflow answer #:12415945
*  And Stack Overflow answer#:12415704
*/
static IOperations < T > Create () {
    var type = typeof (T);
    switch (Type.GetTypeCode (type)) {
        case TypeCode.Byte :
            return (IOperations < T >) new ByteOperations ();
        case TypeCode.Single :
            return (IOperations < T >) new SingleOperations ();
        default :
            var message = String.Format ("Operations for type {0} is not supported.", type.Name);
            throw new NotSupportedException (message);
    }
}

static void Main () {
    List < byte > bytes = new List < byte > ();
    bytes.Add (2);
    bytes.Add (1);
    List < float > floats = new List < float > ();
    floats.Add (2.5F);
    floats.Add (1F);
    Console.WriteLine (DoStuff (bytes));
    Console.WriteLine (DoStuff (floats));
    Console.ReadLine ();
}

