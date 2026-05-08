/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19512210
*  Stack Overflow answer #:19512406
*  And Stack Overflow answer#:46241672
*/
void Main () {
    var a = new StateRandom (123);
    a.Next (100);
    a.Next (100);
    a.Next (100);
    var state = a.NumberOfInvokes;
    Console.WriteLine (a.Next (100));
    Console.WriteLine (a.Next (100));
    Console.WriteLine (a.Next (100));
    var b = new StateRandom (123, state);
    Console.WriteLine (b.Next (100));
    Console.WriteLine (b.Next (100));
    Console.WriteLine (b.Next (100));
}

public void LoadState (int [] saveState) {
    if (saveState.Length != 59) {
        throw new Exception ("GrimoireRandom state was corrupted!");
    }
    _seed = saveState [0];
    _inext = saveState [1];
    _inextp = saveState [2];
    _seedArray = new int [59];
    for (int i = 3; i < this._seedArray.Length; i ++) {
        _seedArray [i - 3] = saveState [i];
    }
}

