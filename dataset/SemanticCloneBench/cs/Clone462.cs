/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:31333473
*  Stack Overflow answer #:31333931
*  And Stack Overflow answer#:31333529
*/
static void CompareRows (DataTable original, DataTable modified) {
    foreach (DataRow row1 in modified.Rows) {
        bool isModified = true;
        var array1 = row1.ItemArray;
        foreach (DataRow row2 in original.Rows) {
            var array2 = row2.ItemArray;
            if (array1.SequenceEqual (array2)) {
                isModified = false;
            }
        }
        if (isModified)
            row1.SetModified ();
    }
}

static void CompareRows (DataTable table1, DataTable table2) {
    foreach (DataRow row1 in table1.Rows) {
        foreach (DataRow row2 in table2.Rows) {
            var array1 = row1.ItemArray;
            var array2 = row2.ItemArray;
            if (array1.SequenceEqual (array2)) {
                Console.WriteLine ("Equal: {0} {1}", row1 ["Drug"], row2 ["Drug"]);
            } else {
                Console.WriteLine ("Not equal: {0} {1}", row1 ["Drug"], row2 ["Drug"]);
            }
        }
    }
}

