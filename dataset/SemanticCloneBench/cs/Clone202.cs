/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11913567
*  Stack Overflow answer #:11913775
*  And Stack Overflow answer#:11913731
*/
public bool removeStock (string user_name, string stock_symbol) {
    user_name = user_name.Trim ();
    stock_symbol = stock_symbol.Trim ();
    string statement = "DELETE FROM users_stocks 
                          WHERE user_name = '" + user_name + "' 
                          AND stock_symbol = '" + stock_symbol + "'";
    SqlCommand cmdnon = new SqlCommand (statement, connection);
    try {
        connection.Open ();
        int num = cmdnon.ExecuteNonQuery ();
        connection.Close ();
        return true;
    }
    catch (SqlException ex) {
        Console.WriteLine (ex.ToString ());
        connection.Close ();
        return false;
    }
}

public bool removeStock (string user_name, string stock_symbol) {
    using (SqlConnection connection = new SqlConnection ("YOUR_CONNECTION_STRING"))
    {
        using (SqlCommand command = new SqlCommand ())
        {
            try {
                command.Connection = connection;
                command.CommandText = "DELETE FROM user_stocks WHERE user_name=@USERNAME AND stock_symbol=@STOCKSYMBOL";
                command.Parameters.Add ("@USERNAME", SqlDbType.VarChar).Value = user_name.Trim ();
                command.Parameters.Add ("@STOCKSYMBOL", SqlDbType.VarChar).Value = stock_symbol.Trim ();
                connection.Open ();
                int i = command.ExecuteNonQuery ();
                if (i == 0)
                    return false;
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine (ex.ToString ());
                connection.Close ();
                return false;
            }
            finally {
                connection.Close ();
            }
        }}}

