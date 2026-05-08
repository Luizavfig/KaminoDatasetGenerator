/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1083955
*  Stack Overflow answer #:7999489
*  And Stack Overflow answer#:13549335
*/
private void Form1_Load (object sender, EventArgs e) {
    DateTime dteThen = DateTime.Parse ("3/31/2010");
    DateTime dteNow = DateTime.Now;
    int intDiffInYears = 0;
    int intDiffInMonths = 0;
    int intDiffInDays = 0;
    if (dteNow.Month >= dteThen.Month) {
        if (dteNow.Day >= dteThen.Day) {
            intDiffInYears = dteNow.Year - dteThen.Year;
            intDiffInMonths = dteNow.Month - dteThen.Month;
            intDiffInDays = dteNow.Day - dteThen.Day;
        } else {
            if (dteNow.Month == dteThen.Month) {
                intDiffInYears = dteNow.Year - dteThen.Year - 1;
                intDiffInMonths = 11;
                int intDaysInSharedMonth = System.DateTime.DaysInMonth (dteThen.Year, dteThen.Month);
                intDiffInDays = intDaysInSharedMonth - dteThen.Day + dteNow.Day;
            } else {
                intDiffInYears = dteNow.Year - dteThen.Year;
                intDiffInMonths = dteNow.Month - dteThen.Month - 1;
                int intDaysInPrevMonth = System.DateTime.DaysInMonth (dteNow.Year, (dteNow.Month - 1));
                intDiffInDays = intDaysInPrevMonth - dteThen.Day + dteNow.Day;
            }
        }
    } else {
        intDiffInYears = dteNow.Year - dteThen.Year - 1;
        intDiffInMonths = 12 - dteThen.Month + dteNow.Month;
        if (dteNow.Day >= dteThen.Day) {
            intDiffInDays = dteNow.Day - dteThen.Day;
        } else {
            intDiffInMonths --;
            int intDaysInPrevMonth = System.DateTime.DaysInMonth (dteNow.Year, (dteNow.Month - 1));
            intDiffInDays = intDaysInPrevMonth - dteThen.Day + dteNow.Day;
        }
    }
    this.addToBox ("Years: " + intDiffInYears + " Months: " + intDiffInMonths + " Days: " + intDiffInDays);
}

private void dateTimePicker1_ValueChanged (object sender, EventArgs e) {
    int gyear = dateTimePicker1.Value.Year;
    int gmonth = dateTimePicker1.Value.Month;
    int gday = dateTimePicker1.Value.Day;
    int syear = DateTime.Now.Year;
    int smonth = DateTime.Now.Month;
    int sday = DateTime.Now.Day;
    int difday = DateTime.DaysInMonth (syear, gmonth);
    agedisplay = (syear - gyear);
    lmonth = (smonth - gmonth);
    lday = (sday - gday);
    if (smonth < gmonth) {
        agedisplay = agedisplay - 1;
    }
    if (smonth == gmonth) {
        if (sday < (gday)) {
            agedisplay = agedisplay - 1;
        }
    }
    if (smonth < gmonth) {
        lmonth = (- (- smonth) + (- gmonth) + 12);
    }
    if (lday < 0) {
        lday = difday - (- lday);
        lmonth = lmonth - 1;
    }
    if (smonth == gmonth && sday < gday && gyear != syear) {
        lmonth = 11;
    }
    ageDisplay.Text = Convert.ToString (agedisplay) + " Years,  " + lmonth + " Months,  " + lday + " Days.";
}

