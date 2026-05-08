/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:42250539
*  Stack Overflow answer #:42251500
*  And Stack Overflow answer#:42251571
*/
static bool Check2DArray (int [,] data, int [,] find) {
    int dataLen = data.Length;
    int findLen = find.Length;
    for (int i = 0; i < dataLen; i ++) {
        int dataX = i % data.GetLength (0);
        int dataY = i / data.GetLength (0);
        bool okay = true;
        for (int j = 0; j < findLen && okay; j ++) {
            int findX = j % find.GetLength (1);
            int findY = j / find.GetLength (1);
            int checkedX = findX + dataX;
            int checkedY = findY + dataY;
            if (checkedX >= data.GetLength (0) || checkedY >= data.GetLength (1)) {
                okay = false;
                break;
            }
            okay = data [dataY + findY, dataX + findX] == find [findY, findX];
        }
        if (okay)
            return true;
    }
    return false;
}

public static bool Check2DArray (int [,] data, int [,] find) {
    for (int dRow = 0; dRow < data.GetLength (0) - find.GetLength (0); dRow ++) {
        for (int dCol = 0; dCol < data.GetLength (1) - find.GetLength (1); dCol ++) {
            bool found = true;
            for (int fRow = 0; fRow < find.GetLength (0); fRow ++) {
                for (int fCol = 0; fCol < find.GetLength (1); fCol ++) {
                    if (data [dRow + fRow, dCol + fCol] != find [fRow, fCol]) {
                        found = false;
                        break;
                    }
                }
                if (! found)
                    break;
            }
            if (found)
                return true;
        }
    }
    return false;
}

