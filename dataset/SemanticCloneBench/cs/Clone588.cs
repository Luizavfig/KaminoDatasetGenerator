/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13700028
*  Stack Overflow answer #:13700928
*  And Stack Overflow answer#:13700928
*/
public static IList < ReportFile > ReadFiles (int year, int month) {
    string [] fileNames = new string [] {"{0:YYYYMMDD}----1234D.dat", "{0:YYYYMMDD}----5678D.dat"};
    DateTime dateStart = new DateTime (year, month, 1);
    DateTime dateEnd = dateStart.AddMonths (1);
    var reportList = new List < ReportFile > ();
    DateTime date = dateStart;
    while (date < dateEnd) {
        foreach (var fileTemplate in fileNames) {
            var file = string.Format (fileTemplate, date);
            if (File.Exists (file)) {
                var report = new ReportFile () {Date = date, Path = file, Lines = GetReportLines (file)};
                reportList.Add (report);
            }
        }
        date = date.AddDays (1);
    }
    return reportList;
}

private static List < string > GetReportLines (string file) {
    var lines = new List < string > ();
    try {
        using (StreamReader reader = new StreamReader (file))
        {
            while (! reader.EndOfStream) {
                var line = reader.ReadLine ();
                if (true)
                    lines.Add (line);
            }
        }}
    catch (Exception ex) {
        lines.Add (string.Format ("ERROR Could not open report file {0}: {1}", file, ex.Message));
    }
    return lines;
}

