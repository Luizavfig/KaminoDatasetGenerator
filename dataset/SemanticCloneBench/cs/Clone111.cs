/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13330992
*  Stack Overflow answer #:13331180
*  And Stack Overflow answer#:13331026
*/
public MyType doSomething (bool a, bool b) {
    switch (a) {
        case true :
            if (b)
                return doAB ();
            return doA ();
        default :
            if (b)
                return doB ();
            return doNotANotB ();
    }
}

public MyType doSomething (bool a, bool b) {
    if (a && b)
        return doAB ();
    else if (a && ! b)
        return doA ();
    else if (! a && b)
        return doB ();
    else
        return doNotANotB ();
}

