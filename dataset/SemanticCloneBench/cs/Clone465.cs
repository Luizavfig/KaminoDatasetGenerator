/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:48604889
*  Stack Overflow answer #:48701022
*  And Stack Overflow answer#:48605033
*/
static void Main (string [] args) {
    int requiredMonths = 6;
    int weekDays = 7;
    DateTime date = new DateTime (2018, 2, 5);
    DateTime [] result = new DateTime [requiredMonths];
    for (int i = 0; i < requiredMonths; i ++) {
        DateTime firstDayOfNextMonth = date.AddMonths (i).AddDays (- date.Day + 1);
        for (int j = 0; j < weekDays; j ++) {
            if (firstDayOfNextMonth.AddDays (j).DayOfWeek.Equals (DayOfWeek.Monday)) {
                result [i] = firstDayOfNextMonth.AddDays (j);
            }
        }
    }
    foreach (var item in result) {
        Console.WriteLine (item);
    }
}

public static void Main (string [] args) {
    for (int mth = 1; mth <= 12; mth ++) {
        DateTime dt = new DateTime (2010, mth, 1);
        while (dt.DayOfWeek != DayOfWeek.Monday) {
            dt = dt.AddDays (1);
        }
        Console.WriteLine (dt.ToLongDateString ());
    }
    Console.ReadLine ();
}

