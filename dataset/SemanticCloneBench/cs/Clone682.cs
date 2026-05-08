/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:191153
*  Stack Overflow answer #:12754615
*  And Stack Overflow answer#:191265
*/
public static void Main (string [] args) {
    Test.checkInt (1);
    Test.checkMax (1);
    Test.checkMin (1);
    Test.checkInt (10);
    Test.checkMax (10);
    Test.checkMin (10);
    Test.checkInt (20);
    Test.checkMax (20);
    Test.checkMin (20);
    Test.checkInt (30);
    Test.checkMax (30);
    Test.checkMin (30);
    Test.checkInt (254);
    Test.checkMax (254);
    Test.checkMin (254);
    Test.checkInt (255);
    Test.checkMax (255);
    Test.checkMin (255);
    Test.checkInt (256);
    Test.checkMax (256);
    Test.checkMin (256);
}

public void UseReader (string psSELECT, DataReaderUser readerUser) {
    using (SqlConnection connection = new SqlConnection (_connectionString))
    try {
        SqlCommand command = new SqlCommand (psSELECT, connection);
        connection.Open ();
        SqlDataReader reader = command.ExecuteReader ();
        while (reader.Read ())
            readerUser (reader);
    }
    catch (System.Exception ex) {
        throw ex;
    }
}

