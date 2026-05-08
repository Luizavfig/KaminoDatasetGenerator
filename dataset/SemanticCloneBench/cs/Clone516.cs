/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7702573
*  Stack Overflow answer #:7702778
*  And Stack Overflow answer#:7703409
*/
static void Main (string [] args) {
    ConnectionStringSettings csv = ConfigurationManager.ConnectionStrings ["csv"];
    List stats = new List ();
    using (OleDbConnection cn = new OleDbConnection (csv.ConnectionString))
    {
        cn.Open ();
        using (OleDbCommand cmd = cn.CreateCommand ())
        {
            cmd.CommandText = "SELECT * FROM [Stats.csv]";
            cmd.CommandType = CommandType.Text;
            using (OleDbDataReader reader = cmd.ExecuteReader (CommandBehavior.CloseConnection))
            {
                int fieldSport = reader.GetOrdinal ("sport");
                int fieldDate = reader.GetOrdinal ("date");
                int fieldTeamOne = reader.GetOrdinal ("teamone");
                int fieldTeamTwo = reader.GetOrdinal ("teamtwo");
                int fieldScore = reader.GetOrdinal ("score");
                foreach (DbDataRecord record in reader) {
                    stats.Add (new Stat {Sport = record.GetString (fieldSport), Date = record.GetDateTime (fieldDate), TeamOne = record.GetString (fieldTeamOne), TeamTwo = record.GetString (fieldTeamTwo), Score = record.GetInt32 (fieldScore)});
                }
            }}} foreach (Stat stat in stats) {
        Console.WriteLine ("Sport: {0}", stat.Sport);
    }
}

static void Main (string [] args) {
    using (var csvReader = new TextFieldParser (@"sportsResults.csv"))
    {
        csvReader.SetDelimiters (new string [] {","});
        string [] fields;
        while (! csvReader.EndOfData) {
            fields = csvReader.ReadFields ();
            Console.WriteLine (String.Join (",", fields));
        }
    }}

