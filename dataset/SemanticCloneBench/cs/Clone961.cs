/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:40738804
*  Stack Overflow answer #:40739260
*  And Stack Overflow answer#:40738913
*/
protected void MakeButtons () {
    rowNum = UpDownRow.Text;
    int nr = Int16.Parse (rowNum);
    colNum = UpDownColumn.Text;
    int nc = Int16.Parse (colNum);
    int btnHeight = panel1.Height / Int16.Parse (rowNum);
    int btnWidth = panel1.Width / Int16.Parse (colNum);
    for (int row = 0; row < nr; row ++) {
        for (int column = 0; column < nc; column ++) {
            Button btnNew = new Button ();
            btnNew.Name = "btn_" + column + "_" + row;
            btnNew.Height = btnHeight - 5;
            btnNew.Width = btnWidth - 5;
            btnNew.Font = new Font ("Arial", 20);
            btnNew.Image = Properties.Resources.backg;
            btnNew.Visible = true;
            btnNew.Location = new Point (10 + (column * btnNew.Width), 10 + (row * btnNew.Height));
            btnNew.Click += new EventHandler (WhoClicked);
            panel1.Controls.Add (btnNew);
        }
    }
}

private void button2_Click (object sender, EventArgs e) {
    picSymbol = Properties.Resources.Player;
    Button btn = sender as Button;
    if (! btn.Enabled) {
        MessageBox.Show ("Too Many Player", "Player number exceed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        btn.Text = "Game Disabled";
    } else {
        btn.Enabled = false;
    }
}

