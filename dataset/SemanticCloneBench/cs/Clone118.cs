/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:217187
*  Stack Overflow answer #:217211
*  And Stack Overflow answer#:217207
*/
static void Main (string [] args) {
    Vector3 vector = new Vector3 ();
    vector.x = 1;
    vector.y = 2;
    vector.z = 3;
    MemoryStream memoryStream = new MemoryStream ();
    BinaryFormatter binaryFormatter = new BinaryFormatter ();
    binaryFormatter.Serialize (memoryStream, vector);
    string str = System.Convert.ToBase64String (memoryStream.ToArray ());
}

static void Main (string [] args) {
    List < string > myList = new List < string > ();
    myList.Add ("One");
    myList.Add ("Two");
    myList.Add ("Three");
    NetDataContractSerializer serializer = new NetDataContractSerializer ();
    MemoryStream stream = new MemoryStream ();
    serializer.Serialize (stream, myList);
    stream.Position = 0;
    Console.WriteLine (ASCIIEncoding.ASCII.GetString (stream.ToArray ()));
    List < string > myList2 = (List < string >) serializer.Deserialize (stream);
    Console.WriteLine (myList2 [0]);
    Console.ReadKey ();
}

