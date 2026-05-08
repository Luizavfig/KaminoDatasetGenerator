/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:46815162
*  Stack Overflow answer #:46816571
*  And Stack Overflow answer#:46816571
*/
private void fillTheListBox (string filePath) {
    List < string > results = new List < string > ();
    string currentLine = string.Empty;
    using (StreamReader sr = new StreamReader (filePath))
    {
        while ((currentLine = sr.ReadLine ()) != null) {
            foreach (string item in currentLine.Split (',')) {
                results.Add (item);
            }
        }
    } lstbx.DataSource = results;
}

private void fillTheListBox (string filePath, bool ShowHeader) {
    List < string > headerLine = new List < string > ();
    List < string > results = new List < string > ();
    int whichLineAmIon = 0;
    string currentLine = string.Empty;
    using (StreamReader sr = new StreamReader (filePath))
    {
        while ((currentLine = sr.ReadLine ()) != null) {
            string [] splitted = currentLine.Split (',');
            for (int i = 0; i < splitted.Length; i ++) {
                if (whichLineAmIon == 0) {
                    headerLine.Add (splitted [i]);
                } else {
                    results.Add (headerLine [i] + " : " + splitted [i]);
                }
            }
            whichLineAmIon ++;
        }
    } lstbx.DataSource = results;
}

