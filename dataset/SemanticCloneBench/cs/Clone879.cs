/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:41983037
*  Stack Overflow answer #:42066838
*  And Stack Overflow answer#:42006582
*/
void browser_DocumentCompleted (object sender, WebBrowserDocumentCompletedEventArgs e) {
    WebBrowser browser = (WebBrowser) sender;
    HtmlElement expandDetails = browser.Document.GetElementById ("form:SummarySubView:closedToggleControl");
    if (expandDetails == null) {
    } else {
        expandDetails.InvokeMember ("click");
        while (expandDetails != null) {
            expandDetails = browser.Document.GetElementById ("form:SummarySubView0:closedToggleControl");
            Application.DoEvents ();
            System.Threading.Thread.Sleep (200);
        }
    }
}

private void WebBrowser1_DocumentCompleted (object sender, WebBrowserDocumentCompletedEventArgs e) {
    WebBrowser wb = sender as WebBrowser;
    if (wb.Document.Window.Parent == null) {
        t = new Timer ();
        t.Tick += (Timersender, eventargs) = > {
            t.Stop ();
        };
        t.Interval = 2000;
        t.Start ();
    }
}

