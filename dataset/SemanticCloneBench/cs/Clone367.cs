/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:856845
*  Stack Overflow answer #:6249992
*  And Stack Overflow answer#:14698822
*/
static void Main (string [] args) {
    int value = 997;
    string [,] arrValues = new string [5, 5];
    for (int i = 0; i < arrValues.GetLength (0); i ++) {
        for (int j = 0; j < arrValues.GetLength (1); j ++) {
            value ++;
            arrValues [i, j] = value.ToString ();
        }
    }
    ArrayPrinter.PrintToConsole (arrValues);
    Console.ReadLine ();
}

static void Main (String [] args) {
    TableBuilder tb = new TableBuilder ();
    tb.AddRow ("When", "ID", "Name");
    tb.AddRow ("----", "--", "----");
    tb.AddRow (DateTime.Now, "1", "Name1");
    tb.AddRow (DateTime.Now, "1", "Name2");
    Console.Write (tb.Output ());
    Console.WriteLine ();
    StringBuilder sb = new StringBuilder ();
    int i = 0;
    foreach (ITextRow tr in tb) {
        tr.Output (sb);
        if (i ++ > 1)
            sb.AppendLine ("more stuff per line");
    }
    Console.Write (sb.ToString ());
}

