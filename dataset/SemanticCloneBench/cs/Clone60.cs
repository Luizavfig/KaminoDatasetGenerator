/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1846068
*  Stack Overflow answer #:36712377
*  And Stack Overflow answer#:1848023
*/
private void dateTimePicker1_ValueChanged (object sender, EventArgs e) {
    if (this.dateTimePicker1.Value.Minute % 5 == 0)
        return;
    if (this.dateTimePicker1.Value.Minute % 5 == 1)
        this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddMinutes (4);
    if (this.dateTimePicker1.Value.Minute % 5 == 4)
        this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddMinutes (- 4);
}

private void dateTimePicker1_ValueChanged (object sender, EventArgs e) {
    if (! mBusy) {
        mBusy = true;
        DateTime dt = dateTimePicker1.Value;
        if ((dt.Minute * 60 + dt.Second) % 300 != 0) {
            TimeSpan diff = dt - mPrevDate;
            if (diff.Ticks < 0)
                dateTimePicker1.Value = mPrevDate.AddMinutes (- 5);
            else
                dateTimePicker1.Value = mPrevDate.AddMinutes (5);
        }
        mBusy = false;
    }
    mPrevDate = dateTimePicker1.Value;
}

