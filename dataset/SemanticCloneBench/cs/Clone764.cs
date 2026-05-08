/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10824165
*  Stack Overflow answer #:51412772
*  And Stack Overflow answer#:52970993
*/
public string ConvertCsvFileToJsonObject (string path) {
    var csv = new List < string [] > ();
    var lines = File.ReadAllLines (path);
    foreach (string line in lines)
        csv.Add (line.Split (','));
    var properties = lines [0].Split (',');
    var listObjResult = new List < Dictionary < string, string > > ();
    for (int i = 1; i < lines.Length; i ++) {
        var objResult = new Dictionary < string, string > ();
        for (int j = 0; j < properties.Length; j ++)
            objResult.Add (properties [j], csv [i] [j]);
        listObjResult.Add (objResult);
    }
    return JsonConvert.SerializeObject (listObjResult);
}

public void convertFile (string inputFile, string outputFile) {
    using (var writer = new StreamWriter (outputFile))
    {
        int row = 0;
        writer.Write ("[\r\n");
        foreach (var e in new ChoCSVReader (inputFile).WithHeaderLineAt ()) {
            writer.Write ((row > 0 ? ",\r\n" : "") + e.DumpAsJson ());
            writer.Flush ();
            row ++;
        }
        writer.Write ("]");
        writer.Flush ();
        writer.Close ();
    }}

