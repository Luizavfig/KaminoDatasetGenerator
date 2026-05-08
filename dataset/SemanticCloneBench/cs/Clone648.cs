/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1336259
*  Stack Overflow answer #:1336338
*  And Stack Overflow answer#:1336338
*/
static void Main (string [] args) {
    if (args.Length == 2) {
        using (StreamReader input = new StreamReader (args [0]))
        using (StreamWriter output = new StreamWriter (args [1]))
        {
            int readSize = 0;
            int blockSize = 100000;
            char [] inBuffer = new char [blockSize];
            char [] outBuffer = new char [blockSize * 3];
            while ((readSize = input.ReadBlock (inBuffer, 0, blockSize)) > 0) {
                int writeSize = TransformBlock (inBuffer, outBuffer, readSize);
                output.Write (outBuffer, 0, writeSize);
            }
        }} else {
        Console.WriteLine ("Usage:  repchar {inputfile} {outputfile}");
    }
}

private static int TransformBlock (char [] inBuffer, char [] outBuffer, int size) {
    int j = 0;
    for (int i = 0; i < size; i ++) {
        outBuffer [j ++] = inBuffer [i];
        if (inBuffer [i] == '>') {
            outBuffer [j ++] = '\r';
            outBuffer [j ++] = '\n';
        }
    }
    return j;
}

