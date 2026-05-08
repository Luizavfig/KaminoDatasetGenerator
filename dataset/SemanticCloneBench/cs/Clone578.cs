/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:248273
*  Stack Overflow answer #:248525
*  And Stack Overflow answer#:1322835
*/
static int CountDays (DayOfWeek day, DateTime start, DateTime end) {
    TimeSpan ts = end - start;
    int count = (int) Math.Floor (ts.TotalDays / 7);
    int remainder = (int) (ts.TotalDays % 7);
    int sinceLastDay = (int) (end.DayOfWeek - day);
    if (sinceLastDay < 0)
        sinceLastDay += 7;
    if (remainder >= sinceLastDay)
        count ++;
    return count;
}

private int CountDays (DateTime start, DateTime end, DayOfWeek selectedDay) {
    if (start.Date > end.Date) {
        return 0;
    }
    int totalDays = (int) end.Date.Subtract (start.Date).TotalDays;
    DayOfWeek startDay = start.DayOfWeek;
    DayOfWeek endDay = end.DayOfWeek;
    int startToEnd = (int) endDay - (int) startDay;
    if (startToEnd < 0) {
        startToEnd += 7;
    }
    int startToSelected = (int) selectedDay - (int) startDay;
    if (startToSelected < 0) {
        startToSelected += 7;
    }
    bool isSelectedBetweenStartAndEnd = startToEnd >= startToSelected;
    if (isSelectedBetweenStartAndEnd) {
        return totalDays / 7 + 1;
    } else {
        return totalDays / 7;
    }
}

