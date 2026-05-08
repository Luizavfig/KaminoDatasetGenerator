/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11097356
*  Stack Overflow answer #:11105412
*  And Stack Overflow answer#:20990926
*/
public void Execute (IServiceProvider serviceProvider) {
    try {
        OnExecute (serviceProvider);
    }
    catch (Exception ex) {
        bool rethrow = false;
        try {
            OnError (ex);
        }
        catch {
            rethrow = true;
        }
        if (rethrow) {
            throw;
        }
    }
    finally {
        OnCleanup ();
    }
}

public void Trace (string message) {
    if (string.IsNullOrWhiteSpace (message) || this.TracingService == null) {
        return;
    }
    if (this.PluginExecutionContext == null) {
        this.TracingService.Trace (message);
    } else {
        this.TracingService.Trace ("{0}, Correlation Id: {1}, Initiating User: {2}", message, this.PluginExecutionContext.CorrelationId, this.PluginExecutionContext.InitiatingUserId);
    }
}

