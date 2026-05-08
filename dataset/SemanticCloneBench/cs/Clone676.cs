/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2971387
*  Stack Overflow answer #:2997420
*  And Stack Overflow answer#:2971492
*/
public void DoWorkUpdatingRow (object state) {
    List < DataRow > rowsToWorkOn = (List < DataRow >) state;
    foreach (DataRow dr in rowsToWorkOn) {
        Monitor.Enter (this);
        try {
            dr ["value"] = dr ["id"] + " new value";
        }
        finally {
            Monitor.Exit (this);
        }
    }
}

private void ThreadProc (object obj) {
    var grid = (DataGridView) obj;
    foreach (DataGridViewRow row in grid.Rows) {
        if (Parser.GetPreparationByClientNameForSynonims (row.Cells ["Prep"].Value.ToString ()) != null)
            UpdateGridSafe (grid, row.Index, 1);
        Thread.Sleep (10);
    }
    NotifyDone ();
}

