/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6729827
*  Stack Overflow answer #:6765303
*  And Stack Overflow answer#:6731522
*/
private void button2_Click (object sender, RoutedEventArgs e) {
    var firstVisibleItem = GetFirstVisibleItem (listBox1);
    listBox1.Items.Insert (0, "item7");
    listBox1.Items.Insert (0, "item8");
    listBox1.Items.Insert (0, "item9");
    listBox1.Items.Insert (0, "item10");
    listBox1.Items.Insert (0, "item11");
    listBox1.Items.Insert (0, "item12");
    listBox1.Items.Insert (0, "item13");
    listBox1.Items.Insert (0, "item14");
    listBox1.Items.Insert (0, "item15");
    if (firstVisibleItem != null) {
        Application.Current.Dispatcher.BeginInvoke (DispatcherPriority.Loaded, new Action (delegate () {
            listBox1.ScrollIntoViewTop (firstVisibleItem);
        }));
    }
}

private void button2_Click (object sender, RoutedEventArgs e) {
    if (listBox1.SelectedItem != null) {
        fixedItem = (Item) listBox1.SelectedItem;
        selectedIndex = listBox1.SelectedIndex;
    }
    listBox1.Items.Insert (0, new Item {ItemName = "item7"});
    listBox1.Items.Insert (0, new Item {ItemName = "item8"});
    listBox1.Items.Insert (0, new Item {ItemName = "item9"});
    listBox1.Items.Insert (0, new Item {ItemName = "item10"});
    listBox1.Items.Insert (0, new Item {ItemName = "item11"});
    listBox1.Items.Insert (0, new Item {ItemName = "item12"});
    listBox1.Items.Insert (0, new Item {ItemName = "item13"});
    listBox1.Items.Insert (0, new Item {ItemName = "item14"});
    listBox1.Items.Insert (0, new Item {ItemName = "item15"});
    listBox1.Items.Remove (fixedItem);
    listBox1.Items.Insert (selectedIndex, fixedItem);
    listBox1.SelectedItem = fixedItem;
    listBox1.ScrollIntoView (fixedItem);
}

