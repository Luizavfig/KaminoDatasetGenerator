/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6980888
*  Stack Overflow answer #:10389737
*  And Stack Overflow answer#:10389737
*/
private static void ApplyResourceToControl (ComponentResourceManager res, Control control, CultureInfo lang) {
    if (control.GetType () == typeof (MenuStrip)) {
        MenuStrip strip = (MenuStrip) control;
        ApplyResourceToToolStripItemCollection (strip.Items, res, lang);
    }
    foreach (Control c in control.Controls) {
        ApplyResourceToControl (res, c, lang);
        res.ApplyResources (c, c.Name, lang);
    }
    res.ApplyResources (control, control.Name, lang);
}

private static void ApplyResourceToToolStripItemCollection (ToolStripItemCollection col, ComponentResourceManager res, CultureInfo lang) {
    for (int i = 0; i < col.Count; i ++) {
        ToolStripItem item = (ToolStripMenuItem) col [i];
        if (item.GetType () == typeof (ToolStripMenuItem)) {
            ToolStripMenuItem menuitem = (ToolStripMenuItem) item;
            ApplyResourceToToolStripItemCollection (menuitem.DropDownItems, res, lang);
        }
        res.ApplyResources (item, item.Name, lang);
    }
}

