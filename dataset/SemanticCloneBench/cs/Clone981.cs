/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:18072425
*  Stack Overflow answer #:18072811
*  And Stack Overflow answer#:18072760
*/
public bool Equals (Shape s) {
    int count = 0;
    int [] temp1 = new int [this.coordinate.Length];
    foreach (int x in this.coordinate)
        temp1 [count ++] = x;
    count = 0;
    int [] temp2 = new int [s.coordinate.Length];
    foreach (int x in s.coordinate)
        temp2 [count ++] = x;
    return temp1.SequenceEqual (temp2);
}

public override bool Equals (object other) {
    if (other == null)
        return false;
    if (ReferenceEquals (this, other))
        return true;
    var shape = other as Shape;
    return Equals (shape);
}

