/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11165840
*  Stack Overflow answer #:11166736
*  And Stack Overflow answer#:11166736
*/
public IAsyncResult BeginMultiply (LargeNumber x, LargeNumber y, AsyncCallback callback, object state) {
    AsyncResult < LargeNumber > ar = new AsyncResult < BigInteger > (callback, state);
    ThreadPool.QueueUserWorkItem (o = > {
        var asyncResult = (AsyncResult < LargeNumber >) o;
        try {
            var largeNumber = Multiply (x, y);
            asyncResult.SetAsCompleted (largeNumber, false);
        }
        catch (Exception e) {
            asyncResult.SetAsCompleted (e, false);
        }
    }, ar);
    return ar;
}

public IAsyncResult BeginMultiply (LargeNumber x, LargeNumber y, LargeNumber z, AsyncCallback callback, object state) {
    AsyncResult < LargeNumber > ar = new AsyncResult < LargeNumber > (callback, state);
    BeginMultiply (x, y, (asyncResult1) = > {
        var firstResult = EndMultiply (asyncResult1);
        BeginMultiply (firstResult, z, (asyncResult2) = > {
            var secondResult = EndMultiply (asyncResult2);
            ar.SetAsCompleted (secondResult, true);
        }, state);
    }, state);
    return ar;
}

