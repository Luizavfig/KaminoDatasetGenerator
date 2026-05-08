/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:34841883
*  Stack Overflow answer #:34841922
*  And Stack Overflow answer#:34841940
*/
private void button1_Click (object sender, EventArgs e) {
    textBox2.Clear ();
    float ? v = try_get_input ();
    if (v != null) {
        textBox2.AppendText (Math.Sin (v.Value).ToString ());
    } else {
        textBox2.AppendText ("Invalid Input");
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

