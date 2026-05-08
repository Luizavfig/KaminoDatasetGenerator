/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1044688
*  Stack Overflow answer #:1044957
*  And Stack Overflow answer#:1044821
*/
public static DateTime AddBusinessDays (this DateTime date, int days) {
    date = date.AddDays ((days / 5) * 7);
    int remainder = days % 5;
    switch (date.DayOfWeek) {
        case DayOfWeek.Tuesday :
            if (remainder > 3)
                date = date.AddDays (2);
            break;
        case DayOfWeek.Wednesday :
            if (remainder > 2)
                date = date.AddDays (2);
            break;
        case DayOfWeek.Thursday :
            if (remainder > 1)
                date = date.AddDays (2);
            break;
        case DayOfWeek.Friday :
            if (remainder > 0)
                date = date.AddDays (2);
            break;
        case DayOfWeek.Saturday :
            if (days > 0)
                date = date.AddDays ((remainder == 0) ? 2 : 1);
            break;
        case DayOfWeek.Sunday :
            if (days > 0)
                date = date.AddDays ((remainder == 0) ? 1 : 0);
            break;
        default :
            break;
    }
    return date.AddDays (remainder);
}

public static int GetBusinessDays (DateTime start, DateTime end) {
    if (start.DayOfWeek == DayOfWeek.Saturday) {
        start = start.AddDays (2);
    } else if (start.DayOfWeek == DayOfWeek.Sunday) {
        start = start.AddDays (1);
    }
    if (end.DayOfWeek == DayOfWeek.Saturday) {
        end = end.AddDays (- 1);
    } else if (end.DayOfWeek == DayOfWeek.Sunday) {
        end = end.AddDays (- 2);
    }
    int diff = (int) end.Subtract (start).TotalDays;
    int result = diff / 7 * 5 + diff % 7;
    if (end.DayOfWeek < start.DayOfWeek) {
        return result - 2;
    } else {
        return result;
    }
}

