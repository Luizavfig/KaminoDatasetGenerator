/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7142138
*  Stack Overflow answer #:7208325
*  And Stack Overflow answer#:27506529
*/
public static Control GetAnyControlAt (TableLayoutPanel pp, int col, int row) {
    bool fnd = false;
    Control sendCC = null;
    foreach (Control cc in pp.Controls) {
        if (pp.GetCellPosition (cc).Column == col) {
            if (pp.GetCellPosition (cc).Row == row) {
                sendCC = cc;
                fnd = true;
                break;
            }
        }
    }
    if (fnd == true) {
        return sendCC;
    } else {
        return null;
    }
}

public static Control GetAnyControlAt (this TableLayoutPanel panel, int column, int row) {
    foreach (Control control in panel.Controls) {
        var cellPosition = panel.GetCellPosition (control);
        if (cellPosition.Column == column && cellPosition.Row == row)
            return control;
    }
    return null;
}

