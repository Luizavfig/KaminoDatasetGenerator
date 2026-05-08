/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14976696
*  Stack Overflow answer #:14977280
*  And Stack Overflow answer#:14977015
*/
public int Compare (foo x, foo y) {
    if (x == null || y == null)
        return int.MinValue;
    if (x.name != y.name)
        return StringComparer.CurrentCulture.Compare (x.name, y.name);
    else if (x.date != y.date)
        return x.date.CompareTo (y.date);
    else if (x.counter != y.counter)
        return x.counter.CompareTo (y.counter);
    else
        return 0;
}

public int Compare (Foo x, Foo y) {
    if (x == null || y == null) {
        return x == y ? 0 : x == null ? - 1 : 1;
    }
    if (! string.Equals (x.Name, y.Name)) {
        return string.Compare (x.Name, y.Name);
    }
    if (! DateTime.Equals (x.Date, y.Date)) {
        return DateTime.Compare (x.Date, y.Date);
    }
    return x.Counter.CompareTo (y.Counter);
}

