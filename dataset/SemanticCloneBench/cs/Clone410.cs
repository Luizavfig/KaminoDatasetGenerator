/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:27860151
*  Stack Overflow answer #:29922342
*  And Stack Overflow answer#:27861028
*/
public override void ExecutePageHierarchy () {
    StringWriter fakeOutput = new StringWriter ();
    TextWriter outputStackTopOutput = OutputStack.Pop ();
    OutputStack.Push (fakeOutput);
    base.ExecutePageHierarchy ();
    string content = fakeOutput.ToString ();
    OutputStack.Pop ();
    OutputStack.Push (outputStackTopOutput);
    outputStackTopOutput.Write (content);
}

public override void ExecutePageHierarchy () {
    var layoutReferenceMarkup = @"<script type=""text/html"" data-layout-id=""" + TemplateInfo.VirtualPath + @"""><![CDATA[</script>";
    base.ExecutePageHierarchy ();
    string output = Output.ToString ();
    if (output.Contains ("</body>")) {
        Response.Clear ();
        Response.Write (output.Replace ("</body>", layoutReferenceMarkup + "</body>"));
        Response.End ();
    } else {
        Output.Write (layoutReferenceMarkup);
    }
}

