/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1037913
*  Stack Overflow answer #:1039547
*  And Stack Overflow answer#:1039490
*/
public void readArchive () {
    StreamReader SR;
    string S;
    int i = 0;
    SR = File.OpenText (@"the path here for the excel archive");
    S = SR.ReadToEnd ();
    SR.Close ();
    Console.WriteLine (S);
    string [] words = S.Split (';');
    Array.Sort (words);
    for (i = 0; i < words.Length; i ++)
        Console.WriteLine (words [i]);
    StreamWriter SW;
    SW = File.CreateText (@"the path here for the .txt");
    for (i = 0; i < words.Length; i ++)
        SW.WriteLine (words [i]);
    SW.Close ();
}

static void Main (string [] args) {
    string inputFilename = @"c:\CSVIn.xlsx";
    string outputFilename = @"c:\CSVOut.csv";
    using (System.IO.FileStream outputStream = new System.IO.FileStream (outputFilename, System.IO.FileMode.Create, System.IO.FileAccess.Write))
    {
        IWorkbook workbook = Factory.GetWorkbook (inputFilename);
        foreach (IWorksheet worksheet in workbook.Worksheets) {
            byte [] csvBuffer = worksheet.SaveToMemory (FileFormat.CSV);
            outputStream.Write (csvBuffer, 0, csvBuffer.Length);
        }
        outputStream.Close ();
    }}

