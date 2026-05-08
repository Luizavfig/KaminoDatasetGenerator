/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17682949
*  Stack Overflow answer #:17971429
*  And Stack Overflow answer#:17683788
*/
public void FiscalYearRange () {
    TimeCalendar fiscalYearCalendar = new TimeCalendar (new TimeCalendarConfig {YearBaseMonth = YearMonth.April, YearType = YearType.FiscalYear});
    TimeRange timeRange = new TimeRange (new DateTime (2007, 10, 1), new DateTime (2012, 2, 25));
    Console.WriteLine ("Time range: " + timeRange);
    Console.WriteLine ();
    Console.WriteLine ("Start Quarter: " + new Quarter (timeRange.Start, fiscalYearCalendar));
    Console.WriteLine ("End Quarter: " + new Quarter (timeRange.End, fiscalYearCalendar));
    Console.WriteLine ();
    Year year = new Year (timeRange.Start, fiscalYearCalendar);
    while (year.Start < timeRange.End) {
        Console.WriteLine ("Fiscal Year: " + year);
        year = year.GetNextYear ();
    }
}

public DateTime GetStartOfFinancialQtr (DateTime dtGiven, int startMonth) {
    DateTime dtQuarter = new DateTime (dtGiven.Year, startMonth, 1);
    if (startMonth > dtGiven.Month) {
        while (dtQuarter > dtGiven) {
            dtQuarter = dtQuarter.AddMonths (- 3);
        }
    } else {
        while (dtQuarter.Month + 3 <= dtGiven.Month) {
            dtQuarter = dtQuarter.AddMonths (3);
        }
    }
    return dtQuarter;
}

