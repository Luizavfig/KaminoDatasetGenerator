/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8481325
*  Stack Overflow answer #:8489098
*  And Stack Overflow answer#:10694294
*/
protected void Page_Load (object sender, EventArgs e) {
    string subject = Request.Params ["subject"];
    string message = Request.Params ["body-plain"];
    using (SqlConnection cn = new SqlConnection (ConfigurationManager.ConnectionStrings ["YOURCONNECTIONSTRING"].ConnectionString))
    {
        cn.Open ();
        using (SqlCommand cm = cn.CreateCommand ())
        {
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO SMS (subject, message, DateTime) VALUES (@Subject, @Message, @Dateandtime);";
            cm.Parameters.Add ("@Subject", SqlDbType.NVarChar).Value = subject;
            cm.Parameters.Add ("@Message", SqlDbType.NVarChar).Value = message;
            cm.Parameters.Add ("@Dateandtime", SqlDbType.DateTime).Value = DateTime.Now.ToString ();
            SqlDataReader dr = cm.ExecuteReader ();
            dr.Dispose ();
            cm.Dispose ();
        }}}

[HttpPost] [ValidateInput (false)] public ActionResult GoTruckGo (FormCollection oColl) {
    try {
        string sender = Request.Unvalidated ().Form ["sender"];
        string body = Request.Unvalidated ().Form ["body-plain"];
        sendLog (body);
    }
    catch (Exception ex) {
        sendLog ("entered catch = " + ex.Message);
    }
    return Content ("ok");
}

