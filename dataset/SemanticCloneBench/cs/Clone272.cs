/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:41017835
*  Stack Overflow answer #:41019537
*  And Stack Overflow answer#:41018292
*/
[HttpPost] public JsonResult SavePhoto (string base64) {
    string fileName = "test.jpg";
    var path = HttpContext.Current.Server.MapPath ("~/Uploads/Employee/");
    string uniqueFileName = Guid.NewGuid () + "_" + fileName;
    if (! Directory.Exists (path)) {
        Directory.CreateDirectory (path);
    }
    byte [] bytes = Convert.FromBase64String (base64);
    var fs = new FileStream (path + "/" + uniqueFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    fs.Write (bytes, 0, bytes.Length);
    fs.Flush ();
    fs.Close ();
    fs.Dispose ();
    return Json (new {status = true}, JsonRequestBehavior.DenyGet);
}

public JsonResult SavePhoto (string base64) {
    byte [] bytes = Convert.FromBase64String (base64);
    MemoryStream ms = new MemoryStream (bytes, 0, bytes.Length);
    ms.Write (bytes, 0, bytes.Length);
    Image image = Image.FromStream (ms, true);
    string filestoragename = Guid.NewGuid ().ToString () + ".jpeg";
    string outputPath = HttpContext.Current.Server.MapPath (@"~/Img/" + filestoragename);
    image.Save (outputPath, ImageFormat.Jpeg);
    return Json (new {status = true}, JsonRequestBehavior.DenyGet);
}

