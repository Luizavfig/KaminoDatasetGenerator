/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29839119
*  Stack Overflow answer #:29839444
*  And Stack Overflow answer#:29839444
*/
private void btnCheck_Click (object sender, EventArgs e) {
    int userGuess = int.Parse (txtGuess.Text);
    guessCount ++;
    if (userGuess == target) {
        this.BackColor = System.Drawing.Color.DarkOliveGreen;
        lblHowMuch.Text = String.Format ("You guessed the right number it took you {0} guesses", guessCount);
    } else {
        this.BackColor = userGuess < target ? System.Drawing.Color.Yellow : System.Drawing.Color.Red;
    }
    lblCount.Text = String.Format ("You made {0} Guesses", guessCount);
}

private void ResetData () {
    guessCount = 0;
    target = r.Next (0, 101);
    txtGuess.Text = "";
    lblCount.Text = "";
    lblHowMuch.Text = "";
    this.BackColor = System.Drawing.Color.Empty;
    txtGuess.Focus ();
}

