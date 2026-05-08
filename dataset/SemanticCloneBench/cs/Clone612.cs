/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8880213
*  Stack Overflow answer #:31726008
*  And Stack Overflow answer#:8880244
*/
private bool uploadImage (ref Bitmap p) {
    SqlConnection con = new SqlConnection ();
    con.ConnectionString = Configuration.ConfigurationManager.ConnectionStrings ("ConnStringHere").ConnectionString;
    SqlCommand cmd = new SqlCommand ();
    cmd.CommandText = "INSERT INTO Table_Name (File2) VALUES (@File2)";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = con;
    SqlParameter File1 = new SqlParameter ("@File2", SqlDbType.Image);
    MemoryStream ms = new MemoryStream ();
    using (Bitmap tempImage = new Bitmap (p))
    {
        tempImage.Save (ms, p.RawFormat);
    } byte [] data = ms.GetBuffer ();
    if (! isValidImage (data)) {
        return false;
    }
    File1.Value = data;
    cmd.Parameters.Add (File1);
    con.Open ();
    int result = cmd.ExecuteNonQuery ();
    if (result > 0) {
        con.Close ();
        return true;
    } else {
        con.Close ();
        return false;
    }
}

private byte [] ImgToObj (System.Drawing.Image obj) {
    if (obj == null)
        return null;
    else {
        BinaryFormatter bf = new BinaryFormatter ();
        using (MemoryStream ms = new MemoryStream ())
        {
            bf.Serialize (ms, obj);
            return ms.ToArray ();
        }}
}

