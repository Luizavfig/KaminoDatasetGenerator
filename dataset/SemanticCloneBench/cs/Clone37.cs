/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1044688
*  Stack Overflow answer #:1379158
*  And Stack Overflow answer#:18080828
*/
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

public static System.DateTime AddBusinessDays (this System.DateTime source, int businessDays) {
    var dayOfWeek = businessDays < 0 ? ((int) source.DayOfWeek - 12) % 7 : ((int) source.DayOfWeek + 6) % 7;
    switch (dayOfWeek) {
        case 6 :
            businessDays --;
            break;
        case - 6 :
            businessDays ++;
            break;
    }
    return source.AddDays (businessDays + ((businessDays + dayOfWeek) / 5) * 2);
}

