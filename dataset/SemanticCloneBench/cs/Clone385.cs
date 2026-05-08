/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:34559289
*  Stack Overflow answer #:34559714
*  And Stack Overflow answer#:34559673
*/
public static int [] RowSums (int [] [] arr2D) {
    int [] sums = new int [arr2D.GetLength (0)];
    int rowSums = 0;
    foreach (int [] arr in arr2D) {
        sums [rowSums] = ArraySum (arr);
        rowSums ++;
    }
    return sums;
}

public static int [] RowSums (int [,] arr2D) {
    int numRows = arr2D.GetLength (0);
    int numColumns = arr2D.GetLength (1);
    int [] sums = new int [numRows];
    for (int row = 0; row < numRows; ++ row) {
        for (int col = 0; col < numColumns; ++ col) {
            sums [row] += arr2D [row, col];
        }
    }
    return sums;
}

