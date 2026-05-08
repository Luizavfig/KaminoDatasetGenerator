/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10731206
*  Stack Overflow answer #:10731355
*  And Stack Overflow answer#:10731368
*/
protected string formatException (Exception e) {
    Func < string, string > createFieldSet = t = > "<fieldset><legend><a href='#'>" + "<span class='show-expanded'>collapse message</span>" + "<span class='show-collapsed'>expand message</span>" + "</a></legend><p>" + t + "</p></fieldset>";
    var exError = new StringBuilder ("<form>");
    if (e == null) {
        throw new ArgumentNullException ("e");
    }
    while (e != null) {
        exError.AppendLine (createFieldSet (e.Message));
        exError.AppendLine (createFieldSet (e.StackTrace));
        e = e.InnerException;
    }
    exError.AppendLine ("</form>");
    return exError.ToString ();
}

private string privateFormatException (Exception e) {
    var exError = String.Empty;
    if (e == null) {
        return exError;
    }
    exError += "<fieldset><legend><a href='#'>" + "<span class='show-expanded'>collapse message</span>" + "<span class='show-collapsed'>expand message</span>" + "</a></legend><p>" + e.Message + "</p></fieldset>";
    exError += "<fieldset><legend><a href='#'>" + "<span class='show-expanded'>collapse trace</span>" + "<span class='show-collapsed'>expand trace</span>" + "</a></legend><p>" + e.StackTrace + "</p></fieldset>";
    return exError + privateFormatException (e.InnerException);
}

