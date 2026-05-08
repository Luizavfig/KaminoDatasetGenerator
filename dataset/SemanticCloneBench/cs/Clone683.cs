/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3147836
*  Stack Overflow answer #:44333050
*  And Stack Overflow answer#:3148691
*/
public static void ProcessCsv () {
    var filename = @"your_file_path\filename.csv";
    DataTable dt = new DataTable ("MyTable");
    List < string > product_codes = new List < string > ();
    using (CsvReader csv = new CsvReader (new StreamReader (filename), true))
    {
        int fieldCount = csv.FieldCount;
        string [] headers = csv.GetFieldHeaders ();
        for (int i = 0; i < headers.Length; i ++) {
            dt.Columns.Add (headers [i], typeof (string));
        }
        while (csv.ReadNextRecord ()) {
            DataRow dr = dt.NewRow ();
            for (int i = 0; i < fieldCount; i ++) {
                product_codes.Add (csv [i]);
                dr [i] = csv [i];
            }
            dt.Rows.Add (dr);
        }
    }}

static void Main (string [] args) {
    TextReader reader = new StringReader ("('ABCDEFG', 123542, 'XYZ 99,9')");
    TextFieldParser fieldParser = new TextFieldParser (reader);
    fieldParser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
    fieldParser.SetDelimiters (",");
    String [] currentRow;
    while (! fieldParser.EndOfData) {
        try {
            currentRow = fieldParser.ReadFields ();
            foreach (String currentField in currentRow) {
                Console.WriteLine (currentField);
            }
        }
        catch (MalformedLineException e) {
            Console.WriteLine ("Line {0} is not valid and will be skipped.", e);
        }
    }
}

