/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:26270873
*  Stack Overflow answer #:26270992
*  And Stack Overflow answer#:26270968
*/
static void Main (string [] args) {
    string Path = @"C:\Abhishek\Documents";
    string filePath = @"C:\Abhishek\Documents.txt";
    bool isDirExists = Directory.Exists (Path);
    bool isFileExists = File.Exists (filePath);
    if (isDirExists) {
        Console.WriteLine ("Directory Exists");
    } else {
        Console.WriteLine ("Directory does not exists");
    }
    if (isFileExists) {
        Console.WriteLine ("File Exists");
    } else {
        Console.WriteLine ("File does not exists");
    }
    Console.ReadKey ();
}

static void Main (string [] args) {
    string path = @"C:\";
    FileAttributes attributes = File.GetAttributes (path);
    switch (attributes) {
        case FileAttributes.Directory :
            if (Directory.Exists (path))
                Console.WriteLine ("This directory exists.");
            else
                Console.WriteLine ("This directory does not exist.");
            break;
        default :
            if (File.Exists (path))
                Console.WriteLine ("This file exists.");
            else
                Console.WriteLine ("This file does not exist.");
            break;
    }
}

