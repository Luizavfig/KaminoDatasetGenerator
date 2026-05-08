/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3589100
*  Stack Overflow answer #:8165985
*  And Stack Overflow answer#:8154834
*/
private void OnUnhandledApplicationException (object sender, EventArgs e) {
    StringBuilder message = new StringBuilder ("<html><head><style>" + "body, table { font-size: 12px; font-family: Arial, sans-serif; }\r\n" + "table tr td { padding: 4px; }\r\n" + ".header { font-weight: 900; font-size: 14px; color: #fff; background-color: #2b4e74; }\r\n" + ".header2 { font-weight: 900; background-color: #c0c0c0; }\r\n" + "</style></head><body><table><tr><td class=\"header\"><![CDATA[\r\n\r\nUnhandled Exception logged by LogModule.dll:\r\n\r\nappId=");
    string appId = (string) AppDomain.CurrentDomain.GetData (".appId");
    if (appId != null) {
        message.Append (appId);
    }
    message.Append ("</td></tr>");
    HttpServerUtility server = HttpContext.Current.Server;
    Exception currentException = server.GetLastError ();
    if (currentException != null) {
        message.AppendFormat ("<tr><td class=\"header2\"><![CDATA[TYPE</td></tr><tr><td>{0}</td></tr><tr><td class=\"header2\"><![CDATA[REQUEST</td></tr><tr><td>{3}</td></tr><tr><td class=\"header2\"><![CDATA[MESSAGE</td></tr><tr><td>{1}</td></tr><tr><td class=\"header2\"><![CDATA[STACK TRACE</td></tr><tr><td>{2}</td></tr>", currentException.GetType ().FullName, currentException.Message, currentException.StackTrace, HttpContext.Current != null ? HttpContext.Current.Request.FilePath : "n/a");
        server.ClearError ();
    }
    message.Append ("</table></body></html>");
    HttpContext.Current.Response.Write (message.ToString ());
    server.ClearError ();
}

public void ProcessRequest (HttpContext context) {
    var restHandler = _createHandler.Invoke (null, new Object [] {context});
    var methodData = _webServiceMethodData.GetValue (restHandler);
    var rawParams = _getRawParams.Invoke (null, new [] {methodData, context});
    try {
        _invokeMethod.Invoke (null, new [] {context, methodData, rawParams});
    }
    catch (Exception ex) {
        while (ex is TargetInvocationException)
            ex = ex.InnerException;
        _writeExceptionJsonString.Invoke (null, new Object [] {context, ex});
    }
}

