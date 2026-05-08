/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6194932
*  Stack Overflow answer #:6195037
*  And Stack Overflow answer#:6194984
*/
public ActionResult ChangeProfilePicture () {
    var fileUpload = Request.Files [0];
    var threads = new Task [3];
    threads [0] = Task.Factory.StartNew (() = > ResizeAndUpload (fileUpload.InputStream, Size.Original));
    threads [1] = Task.Factory.StartNew (() = > ResizeAndUpload (fileUpload.InputStream, Size.Profile));
    threads [2] = Task.Factory.StartNew (() = > ResizeAndUpload (fileUpload.InputStream, Size.Thumb));
    Task.WaitAll (threads, 120000);
    return Content ("Success", "text/plain");
}

public ActionResult ChangeProfilePicture () {
    var fileUpload = Request.Files [0];
    var threads = new Thread [3];
    threads [0] = new Thread (() = > ResizeAndUpload (fileUpload.InputStream, Size.Original));
    threads [1] = new Thread (() = > ResizeAndUpload (fileUpload.InputStream, Size.Profile));
    threads [2] = new Thread (() = > ResizeAndUpload (fileUpload.InputStream, Size.Thumb));
    threads [0].Start ();
    threads [1].Start ();
    threads [2].Start ();
    threads [0].Join ();
    threads [1].Join ();
    threads [2].Join ();
    return Content ("Success", "text/plain");
}

