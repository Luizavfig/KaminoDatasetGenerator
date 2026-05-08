/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:25058948
*  Stack Overflow answer #:25061949
*  And Stack Overflow answer#:25061949
*/
private void ReDimSeatStates () {
    while (_SeatStates.Count < Rows)
        _SeatStates.Add (new List < SeatState > ());
    if (_SeatStates.First ().Count < Columns)
        foreach (var columnList in _SeatStates)
            while (columnList.Count < Columns)
                columnList.Add (SeatState.Empty);
    while (_SeatStates.Count > Rows)
        _SeatStates.RemoveAt (_SeatStates.Count - 1);
    if (_SeatStates.First ().Count > Columns)
        foreach (var columnList in _SeatStates)
            while (columnList.Count > Columns)
                columnList.RemoveAt (columnList.Count - 1);
}

private void OnMouseUp (object sender, MouseEventArgs e) {
    var heightPerSeat = Height / (float) Rows;
    var widthPerSeat = Width / (float) Columns;
    var row = (int) (e.X / widthPerSeat);
    var column = (int) (e.Y / heightPerSeat);
    var seatState = _SeatStates [row] [column];
    switch (seatState) {
        case SeatState.Empty :
            _SeatStates [row] [column] = SeatState.Selected;
            break;
        case SeatState.Selected :
            _SeatStates [row] [column] = SeatState.Empty;
            break;
    }
    Invalidate ();
}

