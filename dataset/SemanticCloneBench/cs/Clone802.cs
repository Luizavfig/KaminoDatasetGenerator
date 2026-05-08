/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2644139
*  Stack Overflow answer #:2667618
*  And Stack Overflow answer#:2667618
*/
static void Main (string [] args) {
    var sourceFileNames = new List < FileList > ();
    sourceFileNames.Add (new FileList {FileNames = "1.txt"});
    sourceFileNames.Add (new FileList {FileNames = "2.txt"});
    sourceFileNames.Add (new FileList {FileNames = "3.txt"});
    sourceFileNames.Add (new FileList {FileNames = "4.txt"});
    List < FileList > destinationFileNames = new List < FileList > ();
    destinationFileNames.Add (new FileList {FileNames = "1.txt"});
    destinationFileNames.Add (new FileList {FileNames = "2.txt"});
    var except = sourceFileNames.Except (destinationFileNames);
    foreach (var f in except)
        Console.WriteLine (f.FileNames);
    Console.ReadLine ();
}

public bool Equals (FileList other) {
    if (Object.ReferenceEquals (other, null))
        return false;
    if (Object.ReferenceEquals (this, other))
        return true;
    return FileNames.Equals (other.FileNames);
}

