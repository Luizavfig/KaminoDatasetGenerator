/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:41154694
*  Stack Overflow answer #:41154831
*  And Stack Overflow answer#:41155066
*/
void Main () {
    var randomList = new List < int > ();
    var random = new Random (1969);
    for (var i = 0; i < 10; i ++) {
        randomList.Add (random.Next (0, 500));
    }
    randomList = new List < int > {190, 279, 37, 413, 90, 131, 64, 129, 287, 172};
    const int numSets = 9;
    var avgDict = Enumerable.Range (1, numSets).ToDictionary (e = > e, e = > (double) 0);
    var s = new Stack < int > ();
    foreach (var item in randomList) {
        s.Push (item);
        for (var i = 1; i <= numSets; i ++) {
            if (s.Count >= i) {
                var avg = s.Take (i).Average ();
                if (avg > avgDict [i])
                    avgDict [i] = avg;
            }
        }
    }
    avgDict.Dump ();
}

static void Main (string [] args) {
    var randomList = new List < int > ();
    var random = new Random (1969);
    int TotalRandomNumber = 10;
    for (var i = 0; i < TotalRandomNumber; i ++) {
        randomList.Add (random.Next (0, 500));
    }
    foreach (var item in randomList) {
        Console.WriteLine ("Random Number: " + item);
    }
    var AveNum = new List < double > ();
    int range = 3;
    for (int i = 1; i < TotalRandomNumber - range; i ++) {
        var three = randomList.GetRange (i, range);
        double result = three.Average ();
        Console.WriteLine ("Average Number: " + result);
        AveNum.Add (result);
    }
    Console.WriteLine ("Largest: " + AveNum.Max ());
}

