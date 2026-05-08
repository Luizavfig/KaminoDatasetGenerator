/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13159326
*  Stack Overflow answer #:47355769
*  And Stack Overflow answer#:38442826
*/
protected override bool ShouldRetryOn (Exception ex) {
    bool retry = false;
    SqlException sqlException = ex as SqlException;
    if (sqlException != null) {
        int [] errorsToRetry = {1205, - 2,};
        if (sqlException.Errors.Cast < SqlError > ().Any (x = > errorsToRetry.Contains (x.Number))) {
            retry = true;
        }
    }
    return retry;
}

protected override bool ShouldRetryOn (Exception exception) {
    var sqlException = exception as SqlException;
    if (sqlException != null) {
        foreach (SqlError err in sqlException.Errors) {
            if (_errorCodesToRetry.Contains (err.Number)) {
                return true;
            }
        }
    }
    return false;
}

