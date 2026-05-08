/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10320232
*  Stack Overflow answer #:17710285
*  And Stack Overflow answer#:24321377
*/
public Task < IEnumerable < string > > Post () {
    if (Request.Content.IsMimeMultipartContent ()) {
        string fullPath = HttpContext.Current.Server.MapPath ("~/uploads");
        MyMultipartFormDataStreamProvider streamProvider = new MyMultipartFormDataStreamProvider (fullPath);
        var task = Request.Content.ReadAsMultipartAsync (streamProvider).ContinueWith (t = > {
            if (t.IsFaulted || t.IsCanceled)
                throw new HttpResponseException (HttpStatusCode.InternalServerError);
            var fileInfo = streamProvider.FileData.Select (i = > {
                var info = new FileInfo (i.LocalFileName);
                return "File uploaded as " + info.FullName + " (" + info.Length + ")";
            });
            return fileInfo;
        });
        return task;
    } else {
        throw new HttpResponseException (Request.CreateResponse (HttpStatusCode.NotAcceptable, "Invalid Request!"));
    }
}

[HttpPost] public JsonResult PostImage (HttpPostedFileBase file) {
    try {
        if (file != null && file.ContentLength > 0 && file.ContentLength <= 10485760) {
            var fileName = Path.GetFileName (file.FileName);
            var path = Path.Combine (Server.MapPath ("~/") + "HisloImages" + "\\", fileName);
            file.SaveAs (path);
            return Json (JsonResponseFactory.SuccessResponse ("Status:0 ,Message: OK"), JsonRequestBehavior.AllowGet);
        } else {
            return Json (JsonResponseFactory.ErrorResponse ("Status:1 , Message: Upload Again and File Size Should be Less Than 10MB"), JsonRequestBehavior.AllowGet);
        }
    }
    catch (Exception ex) {
        return Json (JsonResponseFactory.ErrorResponse (ex.Message), JsonRequestBehavior.AllowGet);
    }
}

