/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2024607
*  Stack Overflow answer #:2024637
*  And Stack Overflow answer#:2024801
*/
public Control FindControl (Control root, string name) {
    if (root == null)
        throw new ArgumentNullException ("root");
    var stack = new Stack < Control > ();
    stack.Push (root);
    while (stack.Count > 0) {
        Control item = stack.Pop ();
        if (item.Name == name)
            return item;
        foreach (Control child in item.Controls) {
            stack.Push (child);
        }
    }
    return null;
}

public Control [] FilterControls (Control start, Func < Control, bool > isMatch) {
    var matches = new List < Control > ();
    Action < Control > filter = null;
    (filter = new Action < Control > (c = > {
        if (isMatch (c))
            matches.Add (c);
        foreach (Control c2 in c.Controls)
            filter (c2);
    })) (start);
    return matches.ToArray ();
}

