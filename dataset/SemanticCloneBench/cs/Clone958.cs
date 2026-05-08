/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1393451
*  Stack Overflow answer #:1393593
*  And Stack Overflow answer#:1393482
*/
public Element GetAnyoneElseFromTheList (Element el) {
    int cnt = this.ElementList.Count (e = > e != el);
    if (cnt < 1)
        return null;
    Random rand = new Random ();
    int num = rand.Next (cnt);
    index = 0;
    while (num > 0) {
        if (this.ElementList [index] != el)
            num --;
        index ++;
    }
    return this.ElementList [index];
}

public Element GetAnyoneElseFromTheList (Element el) {
    Random rndElement = new Random ();
    int index;
    if (this.ElementList.Count > 1) {
        index = rndElement.Next (0, this.ElementList.Count - 1);
        if (this.ElementList [index] == el)
            return this.ElementList [this.ElementList.Count - 1];
        else
            return this.ElementList [index];
    } else
        return null;
}

