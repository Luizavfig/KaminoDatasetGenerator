/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:34841883
*  Stack Overflow answer #:34841952
*  And Stack Overflow answer#:34841940
*/
private void button1_Click (object sender, EventArgs e) {
    textBox2.Clear ();
    float result;
    if (float.TryParse (textBox1.Text, out result)) {
        textBox2.AppendText (Math.Sin (result).ToString ());
    } else {
        textBox2.Text = "Invalid Input";
    }
}

private void button1_Click (object sender, EventArgs e) {
    textBox2.Clear ();
    try {
        float v = float.Parse (textBox1.Text);
        textBox2.AppendText ((Math.Sin (v)).ToString ());
    }
    catch {
        textBox2.Clear ();
        textBox2.AppendText ("Invalid Input");
    }
}

