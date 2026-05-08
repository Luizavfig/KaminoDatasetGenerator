/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14103288
*  Stack Overflow answer #:41065410
*  And Stack Overflow answer#:14103474
*/
public static Task < LoginCompletedEventArgs > RaiseInvoiceAsync (this Client client, string userName, string password) {
    var tcs = CreateSource < LoginCompletedEventArgs > ();
    LoginCompletedEventHandler handler = null;
    handler = (sender, e) = > TransferCompletion (tcs, e, () = > e, () = > client.LoginCompleted -= handler);
    client.LoginCompleted += handler;
    try {
        client.LoginAsync (userName, password, tcs);
    }
    catch {
        client.LoginCompleted -= handler;
        tcs.TrySetCanceled ();
        throw;
    }
    return tcs.Task;
}

private static void TransferCompletion < T > (TaskCompletionSource < T > tcs, AsyncCompletedEventArgs e, Func < T > getResult, Action unregisterHandler) {
    if (e.UserState == tcs) {
        if (e.Cancelled)
            tcs.TrySetCanceled ();
        else if (e.Error != null)
            tcs.TrySetException (e.Error);
        else
            tcs.TrySetResult (getResult ());
        if (unregisterHandler != null)
            unregisterHandler ();
    }
}

