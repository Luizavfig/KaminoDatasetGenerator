/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38556739
*  Stack Overflow answer #:38556777
*  And Stack Overflow answer#:38556782
*/
public void TestList () {
    cvList.Add (new ColumnAndValue () {ColumnName = "Column 1", ColumnValue = "Value 1"});
    cvList.Add (new ColumnAndValue () {ColumnName = "Column 2", ColumnValue = "Value 2"});
    cvList.Add (new ColumnAndValue () {ColumnName = "Column 3", ColumnValue = "Value 3"});
    cvList.Add (new ColumnAndValue () {ColumnName = "Column 4", ColumnValue = "Value 4"});
    List < string > c1 = cvList.Select (c = > c.ColumnName).ToList ();
    foreach (object obj in c1) {
        Console.WriteLine (obj.ToString ());
    }
}

public void TestList () {
    ColumnAndValue cv = new ColumnAndValue ();
    cv.ColumnName = "Column 1";
    cv.ColumnValue = "Value 1";
    cvList.Add (cv);
    cv = new ColumnAndValue ();
    cv.ColumnName = "Column 2";
    cv.ColumnValue = "Value 2";
    cvList.Add (cv);
    cv = new ColumnAndValue ();
    cv.ColumnName = "Column 3";
    cv.ColumnValue = "Value 3";
    cvList.Add (cv);
    cv = new ColumnAndValue ();
    cv.ColumnName = "Column 4";
    cv.ColumnValue = "Value 4";
    cvList.Add (cv);
    List < string > c1 = new List < string > ();
    c1 = cvList.Select (c = > c.ColumnName).ToList ();
    foreach (object obj in c1) {
        Console.WriteLine (obj.ToString ());
    }
}

