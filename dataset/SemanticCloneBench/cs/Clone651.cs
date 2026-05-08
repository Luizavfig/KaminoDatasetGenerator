/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17485048
*  Stack Overflow answer #:17485234
*  And Stack Overflow answer#:17488415
*/
private static DateTime NthOf (DateTime CurDate, int Occurrence, DayOfWeek Day) {
    var fday = new DateTime (CurDate.Year, CurDate.Month, 1);
    if (Occurrence == 1) {
        for (int i = 0; i < 7; i ++) {
            if (fday.DayOfWeek == Day) {
                return fday;
            } else {
                fday = fday.AddDays (1);
            }
        }
        return fday;
    } else {
        var fOc = fday.DayOfWeek == Day ? fday : fday.AddDays (Day - fday.DayOfWeek);
        if (fOc.Month < CurDate.Month)
            Occurrence = Occurrence + 1;
        return fOc.AddDays (7 * (Occurrence - 1));
    }
}

public static DateTime GetFirstDay (int year, int month, DayOfWeek day, int occurance) {
    DateTime result = new DateTime (year, month, 1);
    int i = 0;
    while (result.DayOfWeek != day || occurance != i) {
        result = result.AddDays (1);
        if ((result.DayOfWeek == day))
            i ++;
    }
    return result;
}

