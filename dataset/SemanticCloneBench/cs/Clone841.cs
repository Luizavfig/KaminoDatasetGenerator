/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32135421
*  Stack Overflow answer #:32136726
*  And Stack Overflow answer#:32135601
*/
private void button1_Click (object sender, EventArgs e) {
    if (textBox1.Text.Length != 0) {
        var numePrenume = textBox1.Text.Trim ().Split (' ');
        if (numePrenume.Count () > 1) {
            var nume = numePrenume [0];
            var prenume = numePrenume [1];
            var connString = @"Data Source=C:\Users\Andrei\Documents\Visual Studio 2010\Projects\Stellwag\Stellwag\Angajati.sdf";
            using (var conn = new SqlCeConnection (connString))
            {
            }}
    }
}

static void Main (string [] args) {
    var name = "   name  ";
    var nameParts = name.Trim ().Split (new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
    if (nameParts.Length < 2) {
        Console.WriteLine ("You've only entered one name");
    } else {
        Console.WriteLine ("First part: {0}", nameParts [0]);
        Console.WriteLine ("Second part: {0}", nameParts [1]);
    }
}

