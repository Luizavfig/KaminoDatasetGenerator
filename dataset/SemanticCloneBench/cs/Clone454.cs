/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1532046
*  Stack Overflow answer #:1532100
*  And Stack Overflow answer#:1532157
*/
int RandomLevel () {
    int height = 1;
    lock (rnd)
    {
        while (rnd.NextDouble >= 0.5 && height < MaxHeight)
            height ++;
    } return height;
}

int RandomLevel () {
    int height = 1;
    double newRand;
    lock (rnd)
    {
        newRand = rnd.NextDouble ();
    } while (newRand >= 0.5 && height < MaxHeight) {
        height ++;
        lock (rnd)
        {
            newRand = rnd.NextDouble ();
        }}
    return height;
}

