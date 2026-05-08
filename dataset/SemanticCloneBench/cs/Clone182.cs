/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6437974
*  Stack Overflow answer #:6440368
*  And Stack Overflow answer#:6439788
*/
static void Main (string [] args) {
    DataTable Matrix = new DataTable ();
    Matrix.TableName = "Matrix";
    Matrix.Columns.Add (new DataColumn (MakeStringBeutiful ("Name")));
    Matrix.Columns.Add (new DataColumn (MakeStringBeutiful ("1 England")));
    Matrix.Columns.Add (new DataColumn (MakeStringBeutiful ("2 Germany")));
    Matrix.Columns.Add (new DataColumn (MakeStringBeutiful ("3 France ")));
    Matrix.Rows.Add ("1 England", "    x    ", "         ", "         ");
    Matrix.Rows.Add ("2 Germany", "         ", "    x    ", "         ");
    Matrix.Rows.Add ("3 France ", "         ", "         ", "    x    ");
    PrintMatrix (Matrix);
    Console.WriteLine ("Enter column number:");
    string sx = Console.ReadLine ();
    int x = int.Parse (sx);
    Console.WriteLine ("Enter row number:");
    string sy = Console.ReadLine ();
    int y = int.Parse (sy);
    Console.WriteLine ("Enter value:");
    string v = Console.ReadLine ();
    SetValue (x, y, v, Matrix);
    PrintMatrix (Matrix);
    Console.ReadLine ();
}

static void Main (string [] args) {
    var teams = CreateTeamTable ();
    var matches = CreateMatchTable ();
    int x = 'a';
    while (x != 'x') {
        PrintMenu (teams);
        x = Console.Read ();
        if (x == '1') {
            GetResults (matches);
        }
        if (x == '2') {
            ShowResult (teams, matches);
        }
    }
    Console.ReadKey ();
}

