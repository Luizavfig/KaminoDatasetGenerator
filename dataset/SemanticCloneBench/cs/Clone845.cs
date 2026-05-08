/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19791482
*  Stack Overflow answer #:19792230
*  And Stack Overflow answer#:19791661
*/
bool Run (CancellationToken cancellationToken) {
    var DoIt = new Func < Action < CancellationToken >, bool > ((f) = > {
        f (cancellationToken);
        return cancellationToken.IsCancellationRequested;
    });
    if (! DoIt (Step1))
        return false;
    if (! DoIt (Step2))
        return false;
    if (! DoIt (Step3))
        return false;
    return true;
}

void Run () {
    var actions = new List < Action < CancellationToken > > () {ct = > Step1 (ct), ct = > Step2 (ct), ct = > Step3 (ct)};
    foreach (var action in actions) {
        action (cancellationToken);
        if (cancellationToken.IsCancellationRequested)
            return false;
    }
    return true;
}

