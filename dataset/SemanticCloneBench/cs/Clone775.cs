/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9
*  Stack Overflow answer #:13645039
*  And Stack Overflow answer#:7046204
*/
[TestMethod] public void TestAge () {
    string age = HowOld (new DateTime (2011, 1, 1), new DateTime (2012, 11, 30));
    Assert.AreEqual ("1 year", age);
    age = HowOld (new DateTime (2011, 11, 30), new DateTime (2012, 11, 30));
    Assert.AreEqual ("1 year", age);
    age = HowOld (new DateTime (2001, 1, 1), new DateTime (2012, 11, 30));
    Assert.AreEqual ("11 years", age);
    age = HowOld (new DateTime (2012, 1, 1), new DateTime (2012, 11, 30));
    Assert.AreEqual ("10 months", age);
    age = HowOld (new DateTime (2011, 12, 1), new DateTime (2012, 11, 30));
    Assert.AreEqual ("11 months", age);
    age = HowOld (new DateTime (2012, 10, 1), new DateTime (2012, 11, 30));
    Assert.AreEqual ("1 month", age);
    age = HowOld (new DateTime (2008, 2, 28), new DateTime (2009, 2, 28));
    Assert.AreEqual ("1 year", age);
    age = HowOld (new DateTime (2008, 3, 28), new DateTime (2009, 2, 28));
    Assert.AreEqual ("11 months", age);
    age = HowOld (new DateTime (2008, 3, 28), new DateTime (2009, 3, 28));
    Assert.AreEqual ("1 year", age);
    age = HowOld (new DateTime (2009, 1, 28), new DateTime (2009, 2, 28));
    Assert.AreEqual ("1 month", age);
    age = HowOld (new DateTime (2009, 2, 1), new DateTime (2009, 3, 1));
    Assert.AreEqual ("1 month", age);
    age = HowOld (new DateTime (2009, 1, 31), new DateTime (2009, 2, 28));
    Assert.AreEqual ("4 weeks", age);
    age = HowOld (new DateTime (2009, 2, 1), new DateTime (2009, 2, 28));
    Assert.AreEqual ("3 weeks", age);
    age = HowOld (new DateTime (2009, 2, 1), new DateTime (2009, 3, 1));
    Assert.AreEqual ("1 month", age);
    age = HowOld (new DateTime (2012, 11, 5), new DateTime (2012, 11, 30));
    Assert.AreEqual ("3 weeks", age);
    age = HowOld (new DateTime (2012, 11, 1), new DateTime (2012, 11, 30));
    Assert.AreEqual ("4 weeks", age);
    age = HowOld (new DateTime (2012, 11, 20), new DateTime (2012, 11, 30));
    Assert.AreEqual ("1 week", age);
    age = HowOld (new DateTime (2012, 11, 25), new DateTime (2012, 11, 30));
    Assert.AreEqual ("5 days", age);
    age = HowOld (new DateTime (2012, 11, 29), new DateTime (2012, 11, 30));
    Assert.AreEqual ("1 day", age);
    age = HowOld (new DateTime (2012, 11, 30), new DateTime (2012, 11, 30));
    Assert.AreEqual ("just born", age);
    age = HowOld (new DateTime (2000, 2, 29), new DateTime (2009, 2, 28));
    Assert.AreEqual ("8 years", age);
    age = HowOld (new DateTime (2000, 2, 29), new DateTime (2009, 3, 1));
    Assert.AreEqual ("9 years", age);
    Exception e = null;
    try {
        age = HowOld (new DateTime (2012, 12, 1), new DateTime (2012, 11, 30));
    }
    catch (ArgumentOutOfRangeException ex) {
        e = ex;
    }
    Assert.IsTrue (e != null);
}

public static Dictionary < string, int > CurrentAgeInYearsMonthsDays (DateTime ? ndtBirthDate, DateTime ? ndtReferralDate) {
    if (ndtBirthDate == null)
        return null;
    if (ndtReferralDate == null)
        return null;
    DateTime dtBirthDate = Convert.ToDateTime (ndtBirthDate);
    DateTime dtReferralDate = Convert.ToDateTime (ndtReferralDate);
    Dictionary < string, int > dYMD = new Dictionary < string, int > ();
    int iNowDate, iBirthDate, iYears, iMonths, iDays;
    string sDif = "";
    iNowDate = int.Parse (dtReferralDate.ToString ("yyyyMMdd"));
    iBirthDate = int.Parse (dtBirthDate.ToString ("yyyyMMdd"));
    sDif = (iNowDate - iBirthDate).ToString ();
    iYears = int.Parse (sDif.Substring (0, sDif.Length - 4));
    dYMD.Add ("Years", iYears);
    if (dtBirthDate.Month > dtReferralDate.Month)
        iMonths = 12 - dtBirthDate.Month + dtReferralDate.Month - 1;
    else
        iMonths = dtBirthDate.Month - dtReferralDate.Month;
    dYMD.Add ("Months", iMonths);
    if (dtBirthDate.Day > dtReferralDate.Day)
        if (dtReferralDate.Month == 1)
            iDays = DateTime.DaysInMonth (dtReferralDate.Year - 1, 12) - dtBirthDate.Day + dtReferralDate.Day;
        else
            iDays = DateTime.DaysInMonth (dtReferralDate.Year, dtReferralDate.Month - 1) - dtBirthDate.Day + dtReferralDate.Day;
    else
        iDays = dtReferralDate.Day - dtBirthDate.Day;
    dYMD.Add ("Days", iDays);
    return dYMD;
}

