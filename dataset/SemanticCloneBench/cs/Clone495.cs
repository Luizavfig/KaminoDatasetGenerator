/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38644354
*  Stack Overflow answer #:38644564
*  And Stack Overflow answer#:38644678
*/
private void CreateAction () {
    int bus = 4;
    this.doWorkLater = new Action (() = > {
        var busCopy = bus;
        this.WorkMethod (busCopy);
    });
    bus = 42;
    doWorkLater ();
}

private void CreateAction () {
    int bus = 4;
    CustomObject [] data = new object [16];
    int length = 1500;
    var busCopy = bus;
    var dataCopy = data;
    var lengthCopy = length;
    this.doWorkLater = new Action (() = > {
        this.WorkMethod (busCopy, dataCopy, lengthCopy);
    });
    bus = 10;
    length = 1700;
    this.doWorkLater ();
}

