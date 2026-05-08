/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:37651563
*  Stack Overflow answer #:37651659
*  And Stack Overflow answer#:37651637
*/
public string Insert () {
    string conStr = @"Data Source=ZARAK\SQLEXPRESS;Initial Catalog=ProjectDAL;integrated security=true";
    int queryResult = 0;
    try {
        string querySQL = "Insert INTO tbl_User(Name,Email,Password)VALUES(@name,@email,@password)";
        using (SqlConnection Conn = new SqlConnection (conStr))
        {
            using (SqlCommand cmd = new SqlCommand (querySQL, Conn))
            {
                cmd.Parameters.Add ("@name", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add ("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add ("@password", SqlDbType.VarChar).Value = password;
                queryResult = cmd.ExecuteNonQuery ();
            }} return queryResult + "Record/s Inserted successfully!";
    }
    catch (SqlException ex) {
        if (ex.Number == 2627) {
            return "Record Already Exists";
        }
        return "Some other error";
    }
}

public string Insert () {
    var result = String.Empty;
    SqlConnection Conn = new SqlConnection (@"Data Source=ZARAK\SQLEXPRESS;Initial Catalog=ProjectDAL;integrated security=true");
    try {
        Conn.Open ();
        SqlCommand cmd = new SqlCommand ("Insert INTO tbl_User(Name,Email,Password) VALUES ('" + name + "','" + email + "','" + password + "')", Conn);
        int restl = cmd.ExecuteNonQuery ();
        result = "Record Inserted successfully!";
    }
    catch (SqlException ex) {
        if (ex.Number == 2627) {
            result = "Record Already Exists";
        } else {
            result = ex.Message;
        }
    }
    finally {
        Conn.Close ();
    }
    return result;
}

