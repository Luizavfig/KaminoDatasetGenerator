/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6729827
*  Stack Overflow answer #:6765303
*  And Stack Overflow answer#:6731522
*/
private void button3_Click (object sender, RoutedEventArgs e) {
    var firstVisibleItem = GetFirstVisibleItem (listBox1);
    listBox1.Items.Insert (0, "item16");
    listBox1.Items.Insert (0, "item17");
    listBox1.Items.Insert (0, "item18");
    listBox1.Items.Insert (0, "item19");
    listBox1.Items.Insert (0, "item20");
    listBox1.Items.Insert (0, "item21");
    listBox1.Items.Insert (0, "item22");
    listBox1.Items.Insert (0, "item23");
    listBox1.Items.Insert (0, "item24");
    if (firstVisibleItem != null) {
        Application.Current.Dispatcher.BeginInvoke (DispatcherPriority.Loaded, new Action (delegate () {
            listBox1.ScrollIntoViewTop (firstVisibleItem);
        }));
    }
}

private void button3_Click (object sender, RoutedEventArgs e) {
    if (listBox1.SelectedItem != null) {
        fixedItem = (Item) listBox1.SelectedItem;
        selectedIndex = listBox1.SelectedIndex;
    }
    listBox1.Items.Insert (0, new Item {ItemName = "item16"});
    listBox1.Items.Insert (0, new Item {ItemName = "item17"});
    listBox1.Items.Insert (0, new Item {ItemName = "item18"});
    listBox1.Items.Insert (0, new Item {ItemName = "item19"});
    listBox1.Items.Insert (0, new Item {ItemName = "item20"});
    listBox1.Items.Insert (0, new Item {ItemName = "item21"});
    listBox1.Items.Insert (0, new Item {ItemName = "item22"});
    listBox1.Items.Insert (0, new Item {ItemName = "item23"});
    listBox1.Items.Insert (0, new Item {ItemName = "item24"});
    listBox1.Items.Remove (fixedItem);
    listBox1.Items.Insert (selectedIndex, fixedItem);
    listBox1.SelectedItem = fixedItem;
    listBox1.ScrollIntoView (fixedItem);
}

