/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7159342
*  Stack Overflow answer #:12223030
*  And Stack Overflow answer#:18577183
*/
public static int [] FindMaxArrayEx (int [] srcArray) {
    int [] maxArray = new int [1];
    int maxTotal = int.MinValue;
    int curIndex = 0;
    int tmpTotal = 0;
    List < int > tmpArray = new List < int > ();
    if (srcArray.Length != 1) {
        for (int i = 0; i < srcArray.Length; i ++) {
            tmpTotal = 0;
            curIndex = i;
            tmpArray.Clear ();
            while (curIndex < srcArray.Length) {
                tmpTotal += srcArray [curIndex];
                tmpArray.Add (srcArray [curIndex]);
                if (tmpTotal > maxTotal) {
                    maxTotal = tmpTotal;
                    maxArray = tmpArray.ToArray ();
                }
                curIndex ++;
            }
        }
    } else {
        maxTotal = srcArray [0];
        maxArray = srcArray;
    }
    Console.WriteLine ("FindMaxArrayEx: {0}", maxTotal);
    return maxArray;
}

static int GetLargestContiguousSum (int [] inputArray) {
    if (inputArray.Length == 0)
        throw new ArgumentException ("the input parameter cannot be an empty array");
    int maxSum = 0;
    int currentSum = 0;
    maxSum = currentSum = inputArray [0];
    for (int i = 1; i < inputArray.Length; i ++) {
        currentSum = Math.Max (currentSum + inputArray [i], inputArray [i]);
        maxSum = Math.Max (currentSum, maxSum);
    }
    return maxSum;
}

