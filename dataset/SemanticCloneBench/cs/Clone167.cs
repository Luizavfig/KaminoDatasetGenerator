/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6865261
*  Stack Overflow answer #:6866025
*  And Stack Overflow answer#:31738571
*/
public bool btnRemoveCategory_IsVisible (Office.IRibbonControl ctl) {
    var item = ctl.Context as Inspector;
    var mailItem = item.CurrentItem as MailItem;
    if (item != null)
        return (item != null && HasMyCategory (item));
    else
        return false;
}

public bool btnRemoveCategory_IsVisible (Office.IRibbonControl ctl) {
    Explorer explorer = Globals.ThisAddIn.app.ActiveExplorer ();
    if (explorer != null && explorer.Selection != null && explorer.Selection.Count > 0) {
        object item = explorer.Selection [1];
        if (item is MailItem) {
            MailItem mailItem = item as MailItem;
        }
    }
}

