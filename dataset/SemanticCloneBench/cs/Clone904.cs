/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15221437
*  Stack Overflow answer #:15221509
*  And Stack Overflow answer#:41580582
*/
private bool IsTableSame (DataTable t1, DataTable t2) {
    if (t1 == null)
        return false;
    if (t2 == null)
        return false;
    if (t1.Rows.Count != t2.Rows.Count)
        return false;
    if (t1.Columns.Count != t2.Columns.Count)
        return false;
    if (t1.Columns.Cast < DataColumn > ().Any (dc = > ! t2.Columns.Contains (dc.ColumnName))) {
        return false;
    }
    for (int i = 0; i <= t1.Rows.Count - 1; i ++) {
        if (t1.Columns.Cast < DataColumn > ().Any (dc1 = > t1.Rows [i] [dc1.ColumnName].ToString () != t2.Rows [i] [dc1.ColumnName].ToString ())) {
            return false;
        }
    }
    return true;
}

private void AssertTableRecordsAreEqual (DataTable expectedTable, DataTable actualTable) {
    Assert.IsNotNull (actualTable, "Table is empty");
    Assert.AreEqual (expectedTable.Columns.Count, actualTable.Columns.Count, "Number of columns in actual and expected tables are different");
    Assert.AreEqual (expectedTable.Rows.Count, actualTable.Rows.Count, "Number of records in actual and expected tables are different");
    Assert.IsFalse (expectedTable.Columns.Cast < DataColumn > ().Any (dc = > ! actualTable.Columns.Contains (dc.ColumnName)), "Table column names are different");
    for (int i = 0; i <= expectedTable.Rows.Count - 1; i ++) {
        Assert.IsFalse (expectedTable.Columns.Cast < DataColumn > ().Any (dc1 = > expectedTable.Rows [i] [dc1.ColumnName].ToString () != actualTable.Rows [i] [dc1.ColumnName].ToString ()), "Table row value is different");
    }
}

