/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3227927
*  Stack Overflow answer #:18529216
*  And Stack Overflow answer#:28589272
*/
protected static Dictionary < DateTime, String > getDateRange (String lowerDate, String higherDate, String frequency) {
    DateTime startDate, endDate;
    startDate = Convert.ToDateTime (lowerDate);
    endDate = Convert.ToDateTime (higherDate);
    Dictionary < DateTime, String > returnDict = new Dictionary < DateTime, String > ();
    while (frequency.Equals ("weekly") ? (startDate.AddDays (7) <= endDate) : (startDate.AddMonths (1) <= endDate)) {
        if (frequency.Equals ("weekly")) {
            returnDict.Add (startDate, startDate + "-" + startDate.AddDays (7));
            startDate = startDate.AddDays (8);
        }
        if (frequency.Equals ("monthly")) {
            returnDict.Add (startDate, startDate + "-" + startDate.AddMonths (1));
            startDate = startDate.AddMonths (1).AddDays (1);
        }
    }
    returnDict.Add (startDate, startDate + "-" + endDate);
    return returnDict;
}

static public List < string > get_hours_between_two_dates (DateTime start_date, DateTime end_date) {
    List < string > hours_24_list = new List < string > ();
    DateTime temp_start;
    DateTime temp_end;
    temp_start = new DateTime (start_date.Year, start_date.Month, start_date.Day, start_date.Hour, 0, 0);
    temp_end = new DateTime (end_date.Year, end_date.Month, end_date.Day, end_date.Hour, 0, 0);
    for (DateTime date = temp_start; date <= temp_end; date = date.AddHours (1)) {
        hours_24_list.Add (date.ToShortTimeString ());
    }
    return hours_24_list;
}

