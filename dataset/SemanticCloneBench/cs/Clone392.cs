/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6617804
*  Stack Overflow answer #:6619488
*  And Stack Overflow answer#:6619511
*/
static void Main (string [] args) {
    var dt = new DataTable {Columns = {{"Lastname", typeof (string)}, {"Firstname", typeof (string)}}};
    dt.Rows.Add ("Lennon", "John");
    dt.Rows.Add ("McCartney", "Paul");
    dt.Rows.Add ("Harrison", "George");
    dt.Rows.Add ("Starr", "Ringo");
    List < string > s = dt.AsEnumerable ().Select (x = > x [0].ToString ()).ToList ();
    foreach (string e in s)
        Console.WriteLine (e);
    Console.ReadLine ();
}

static void Main (string [] args) {
    var cols = new string [] {"col1", "col2", "col3", "col4", "col5"};
    DataTable table = new DataTable ();
    foreach (var col in cols)
        table.Columns.Add (col);
    table.Rows.Add (new object [] {"1", "2", "3", "4", "5"});
    table.Rows.Add (new object [] {"1", "2", "3", "4", "5"});
    table.Rows.Add (new object [] {"1", "2", "3", "4", "5"});
    table.Rows.Add (new object [] {"1", "2", "3", "4", "5"});
    table.Rows.Add (new object [] {"1", "2", "3", "4", "5"});
    foreach (var col in cols) {
        var results = from p in table.AsEnumerable ()
            select p [col];
        Console.WriteLine ("*************************");
        foreach (var result in results) {
            Console.WriteLine (result);
        }
    }
    Console.ReadLine ();
}

