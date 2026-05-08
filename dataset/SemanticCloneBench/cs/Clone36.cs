/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1044688
*  Stack Overflow answer #:1044957
*  And Stack Overflow answer#:1379158
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

public static DateTime AddBusinessDays (this DateTime current, int days) {
    var sign = Math.Sign (days);
    var unsignedDays = Math.Abs (days);
    for (var i = 0; i < unsignedDays; i ++) {
        do
            {
                current = current.AddDays (sign);
            } while (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday);
    }
    return current;
}

