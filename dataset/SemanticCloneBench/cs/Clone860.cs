/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:34113666
*  Stack Overflow answer #:34114849
*  And Stack Overflow answer#:34114849
*/
[HttpGet] [Route ("api/TokenCancellationApi/BeginLongProcess/{seconds}")] public string BeginLongProcess (int seconds) {
    lock (_lock)
    {
        if (null != cTokenSource) {
            return "A long running is already underway.";
        }
        cTokenSource = new CancellationTokenSource ();
    } try {
        LongRunningFunc (cTokenSource.Token, seconds);
    }
    catch (OperationCanceledException) {
        return "The running process has been cancelled";
    }
    catch (Exception ex) {
        _lastError = ex.Message;
        return ex.Message;
    }
    finally {
        Cleanup (null);
    }
    return "Long running process has completed!";
}

[HttpGet] public string CancelLongProcess () {
    if (null != cTokenSource) {
        lock (_lock)
        {
            if (null != cTokenSource) {
                cTokenSource.Cancel ();
            }
            return "Cancellation Requested";
        }} else {
        return "Long running task already completed";
    }
}

