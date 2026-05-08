/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:207306
*  Stack Overflow answer #:1410399
*  And Stack Overflow answer#:3062317
*/
private void OnSizeChanged (object sender, EventArgs e) {
    _offsetX = 0;
    _offsetY = 0;
    while (HitTest (Width / 2, _offsetY).HitArea != HitArea.PrevMonthDate && HitTest (Width / 2, _offsetY).HitArea != HitArea.Date) {
        _offsetY ++;
    }
    while (HitTest (_offsetX, Height / 2).HitArea != HitArea.Date) {
        _offsetX ++;
    }
    _dayBoxWidth = 0;
    DateTime dt1 = HitTest (Width / 2, _offsetY).Time;
    while (HitTest (Width / 2, _offsetY + _dayBoxHeight).Time == dt1) {
        _dayBoxHeight ++;
    }
    _dayBoxWidth = 0;
    DateTime dt2 = HitTest (_offsetX, Height / 2).Time;
    while (HitTest (_offsetX + _dayBoxWidth, Height / 2).Time == dt2) {
        _dayBoxWidth ++;
    }
}

private void OnSizeChanged (object sender, EventArgs e) {
    DiscardCachedMonthDateAreaLocations ();
    this.dayCellWidth = this.dayCellHeight = 0;
    this.Invalidate ();
    int middle = this.Width / (2 * this.CalendarDimensions.Width);
    int dateAreaTop = 0;
    while (this.HitTest (middle, dateAreaTop).HitArea != HitArea.PrevMonthDate && this.HitTest (middle, dateAreaTop).HitArea != HitArea.Date) {
        dateAreaTop ++;
        if (dateAreaTop > this.ClientSize.Height)
            return;
    }
    int dayCellHeight = 1;
    DateTime dayCellTime = this.HitTest (middle, dateAreaTop).Time;
    while (this.HitTest (middle, dateAreaTop + dayCellHeight).Time == dayCellTime) {
        dayCellHeight ++;
    }
    middle = this.Height / (2 * this.CalendarDimensions.Height);
    int dateAreaLeft = 0;
    while (this.HitTest (dateAreaLeft, middle).HitArea != HitArea.Date) {
        dateAreaLeft ++;
        if (dateAreaLeft > this.ClientSize.Width)
            return;
    }
    int dayCellWidth = 1;
    dayCellTime = this.HitTest (dateAreaLeft, middle).Time;
    while (this.HitTest (dateAreaLeft + dayCellWidth, middle).Time == dayCellTime) {
        dayCellWidth ++;
    }
    this.calendarFirstDayOfWeek = dayCellTime.DayOfWeek;
    this.dayCellWidth = dayCellWidth;
    this.dayCellHeight = dayCellHeight;
}

