/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17447817
*  Stack Overflow answer #:17448499
*  And Stack Overflow answer#:17447920
*/
public static Double Correlation (Double [] Xs, Double [] Ys) {
    Double sumX = 0;
    Double sumX2 = 0;
    Double sumY = 0;
    Double sumY2 = 0;
    Double sumXY = 0;
    int n = Xs.Length < Ys.Length ? Xs.Length : Ys.Length;
    for (int i = 0; i < n; ++ i) {
        Double x = Xs [i];
        Double y = Ys [i];
        sumX += x;
        sumX2 += x * x;
        sumY += y;
        sumY2 += y * y;
        sumXY += x * y;
    }
    Double stdX = Math.Sqrt (sumX2 / n - sumX * sumX / n / n);
    Double stdY = Math.Sqrt (sumY2 / n - sumY * sumY / n / n);
    Double covariance = (sumXY / n - sumX * sumY / n / n);
    return covariance / stdX / stdY;
}

public double ComputeCoeff (double [] values1, double [] values2) {
    if (values1.Length != values2.Length)
        throw new ArgumentException ("values must be the same length");
    var avg1 = values1.Average ();
    var avg2 = values2.Average ();
    var sum1 = values1.Zip (values2, (x1, y1) = > (x1 - avg1) * (y1 - avg2)).Sum ();
    var sumSqr1 = values1.Sum (x = > Math.Pow ((x - avg1), 2.0));
    var sumSqr2 = values2.Sum (y = > Math.Pow ((y - avg2), 2.0));
    var result = sum1 / Math.Sqrt (sumSqr1 * sumSqr2);
    return result;
}

