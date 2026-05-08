/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:650098
*  Stack Overflow answer #:40925499
*  And Stack Overflow answer#:38974435
*/
public void updatedatabase () {
    SqlConnection conn = new SqlConnection ("Data Source=" + txtserver.Text.Trim () + ";Initial Catalog=" + txtdatabase.Text.Trim () + ";User ID=" + txtuserid.Text.Trim () + ";Password=" + txtpwd.Text.Trim () + "");
    try {
        conn.Open ();
        string script = File.ReadAllText (Server.MapPath ("~/Script/DatingDemo.sql"));
        IEnumerable < string > commandStrings = Regex.Split (script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        foreach (string commandString in commandStrings) {
            if (commandString.Trim () != "") {
                new SqlCommand (commandString, conn).ExecuteNonQuery ();
            }
        }
        lblmsg.Text = "Database updated successfully.";
    }
    catch (SqlException er) {
        lblmsg.Text = er.Message;
        lblmsg.ForeColor = Color.Red;
    }
    finally {
        conn.Close ();
    }
}

private static string Execute (string credentials, string scriptDir, string scriptFilename) {
    Process process = new Process ();
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.WorkingDirectory = scriptDir;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.FileName = "sqlplus";
    process.StartInfo.Arguments = string.Format ("{0} @{1}", credentials, scriptFilename);
    process.StartInfo.CreateNoWindow = true;
    process.Start ();
    string output = process.StandardOutput.ReadToEnd ();
    process.WaitForExit ();
    return output;
}

