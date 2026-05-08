/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7723164
*  Stack Overflow answer #:7723298
*  And Stack Overflow answer#:7723547
*/
static void Main (string [] args) {
    var l = new List < List < double > > () {new List < Double > () {0, 16.0000, 15.0000, 0, 2.7217, 3.7217}, new List < Double > () {0, 0, 15.0000, 15.0000, 5.6904, 5.6904}};
    int i = 1;
    var result = from sublist in l
        select new {min = sublist.Min (), max = sublist.Max (), index = i ++};
    foreach (var r in result)
        Console.WriteLine (String.Format ("Index: {0} Min: {1} Max: {2}", r.index, r.min, r.max));
    Console.ReadKey ();
}

static void Main (string [] args) {
    List < List < double > > lists = new List < List < double > > () {new List < double > () {0, 0}, new List < double > () {16.0000, 0}, new List < double > () {16.0000, 15.0000}, new List < double > () {0, 15.0000}, new List < double > () {2.7217, 5.6904}, new List < double > () {3.7217, 5.6904}};
    var r = new {col1_max = (from x in lists
        select x [0]).Max (), col1_min = (from x in lists
        select x [0]).Min (), col2_max = (from x in lists
        select x [1]).Max (), col2_min = (from x in lists
        select x [1]).Min (),};
    Console.WriteLine (string.Format ("col1_max = {0}\r\ncol1_min = {1}\r\ncol2_max = {2}\r\ncol3_max = {3}", r.col1_max, r.col1_min, r.col2_max, r.col2_min));
    Console.Read ();
}

