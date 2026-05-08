/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:740342
*  Stack Overflow answer #:741168
*  And Stack Overflow answer#:740354
*/
protected void OnUpload_Click (object sender, EventArgs e) {
    var path = Server.MapPath ("~/pics");
    var directory = new DirectoryInfo (path);
    if (directory.Exists == false) {
        directory.Create ();
    }
    var file = Path.Combine (path, upload.FileName);
    upload.SaveAs (file);
}

protected void Button1_Click (object sender, EventArgs e) {
    if (FileUpload1.HasFile && Path.GetExtension (FileUpload1.FileName) == ".jpg") {
        EnsureDirectoriesExist ();
        String filePath = Server.MapPath (@"~/pix/" + FileUpload1.FileName);
        FileUpload1.SaveAs (filePath);
    } else {
        lblMessage.Text = "Not a jpg file";
    }
}

