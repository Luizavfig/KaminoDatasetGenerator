/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:451950
*  Stack Overflow answer #:23541182
*  And Stack Overflow answer#:454597
*/
public static int IndexPosition (this XElement element) {
    if (element == null) {
        throw new ArgumentNullException ("element");
    }
    if (element.Parent == null) {
        return - 1;
    }
    if (element.Parent.Elements (element.Name).Count () == 1) {
        return - 2;
    }
    int i = 1;
    foreach (var sibling in element.Parent.Elements (element.Name)) {
        if (sibling == element) {
            return i;
        }
        i ++;
    }
    throw new InvalidOperationException ("element has been removed from its parent.");
}

public static int IndexPosition (this XElement element) {
    if (element == null) {
        throw new ArgumentNullException ("element");
    }
    if (element.Parent == null) {
        return - 1;
    }
    int i = 1;
    foreach (var sibling in element.Parent.Elements (element.Name)) {
        if (sibling == element) {
            return i;
        }
        i ++;
    }
    throw new InvalidOperationException ("element has been removed from its parent.");
}

