/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8763447
*  Stack Overflow answer #:8763679
*  And Stack Overflow answer#:8763791
*/
protected void IndexChanged (object sender, EventArgs e) {
    ilist1 = (DropDownList) sender;
    if (ilist1.SelectedIndex == 0) {
    } else if (ilist1.SelectedIndex == 1 && ilist2.SelectedIndex != 2) {
        ilist2.SelectedIndex = 2;
    } else if (ilist1.SelectedIndex == 2 && ilist2.SelectedIndex != 1) {
        ilist2.SelectedIndex = 1;
    }
}

protected void IndexChanged (object sender, EventArgs e) {
    DropDownList theList = (DropDownList) sender;
    if (theList.ID == "Id of list 1") {
        if (theList.SelectedValue == "No")
            list2.Items.FindByValue ("Yes").Selected = true;
    } else {
        if (theList.SelectedValue == "Yes")
            list1.Items.FindByValue ("No").Selected = true;
    }
}

