/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11547438
*  Stack Overflow answer #:11547487
*  And Stack Overflow answer#:11547563
*/
protected void button1_Click (object sender, EventArgs e) {
    int safelyConvertedValue = - 1;
    if (! System.Int32.TryParse (textBox1.Text, out safelyConvertedValue)) {
        MessageBox.Show ("You need to enter a number between 1 an 9");
        return;
    }
    if (safelyConvertedValue < 0 || safelyConvertedValue > 9) {
        MessageBox.Show ("You need to enter a number between 1 an 9");
        return;
    }
    MyProcessor p = new MyProcessor ();
    textBox1.Text = p.AddTen (safelyConvertedValue).ToString ();
}

private void button1_Click (object sender, EventArgs e) {
    MyProcess myProcess = new MyProcess ();
    string result = textBox1.Text;
    int number;
    if (int.TryParse (textBox1.Text, out number)) {
        result = myProcess.AddTen (number).ToString ();
    }
    textBox1.Text = result;
}

