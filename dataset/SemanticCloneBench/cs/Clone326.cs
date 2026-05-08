/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:36405840
*  Stack Overflow answer #:36407117
*  And Stack Overflow answer#:36406353
*/
public static void MultiplyDigitArrays (int [] lhs, int [] rhs, int [] result) {
    var n1 = BigInteger.Parse (string.Join ("", lhs));
    var n2 = BigInteger.Parse (string.Join ("", rhs));
    var resultBi = BigInteger.Multiply (n1, n2);
    Array.Clear (result, 0, result.Length);
    var stResult = resultBi.ToString ().PadLeft (result.Length, '0');
    for (int i = 0; i < stResult.Length; i ++) {
        result [(stResult.Length - 1) - i] = int.Parse (stResult [i].ToString ());
    }
}

public static int [] MultiplyDigitArrays (int [] lhs, int [] rhs) {
    int length1 = Math.Max (lhs.Length, rhs.Length);
    var result = new int [length1 * length1];
    for (int i = 0; i < length1; i ++) {
        int [] PartialProduct = new int [length1 * length1];
        int length2 = Math.Min (lhs.Length, rhs.Length);
        for (int j = 0; j < length2; j ++) {
            int multiplicand = (lhs.Length < rhs.Length) ? rhs [i] : lhs [i];
            int multiplier = (lhs.Length < rhs.Length) ? lhs [j] : rhs [j];
            int product = PartialProduct [i + j] + multiplicand * multiplier;
            PartialProduct [i + j] = product % 10;
            int carry = product / 10;
            PartialProduct [i + j + 1] = PartialProduct [i + j + 1] + carry;
        }
        result = SumDigitArrays (PartialProduct, result);
    }
    return result;
}

