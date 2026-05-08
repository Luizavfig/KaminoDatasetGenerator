/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10206000
*  Stack Overflow answer #:14477031
*  And Stack Overflow answer#:10206055
*/
private void timer_Elapsed (object sender, System.Timers.ElapsedEventArgs e) {
    _timer.Stop ();
    try {
        EventLog.WriteEntry (Program.EventLogName, "Checking emails " + _count ++);
    }
    catch (Exception ex) {
        EventLog.WriteEntry (Program.EventLogName, "This is my error " + ex.Message);
    }
    _timer.Start ();
}

private void timer_Elapsed (object sender, System.Timers.ElapsedEventArgs e) {
    log.Info ("Info - Check time");
    DateTime startAt = DateTime.Today.AddHours (9).AddMinutes (48);
    if (_lastRun < startAt && DateTime.Now >= startAt) {
        _timer.Stop ();
        try {
            log.Info ("Info - Import");
            SmartImportService.WebService.WebServiceSoapClient test = new WebService.WebServiceSoapClient ();
            test.Import ();
        }
        catch (Exception ex) {
            log.Error ("This is my error - ", ex);
        }
        _lastRun = DateTime.Now;
        _timer.Start ();
    }
}

