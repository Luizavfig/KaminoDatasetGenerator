/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:43272390
*  Stack Overflow answer #:43873693
*  And Stack Overflow answer#:43272945
*/
int [,] GetSlice (int [,,] source, int dimension, int position) {
    int dimensions = source.Rank;
    int [] dims = new int [dimensions - 1];
    for (int j = 0; j < dims.Length; j ++) {
        dims [j] = source.GetLength (j + (j >= dimension ? 1 : 0));
    }
    var result = new int [dims [0], dims [1]];
    int [] start = new int [dimensions];
    int [] end = new int [dimensions];
    for (int i = 0; i < dimensions; i ++) {
        start [i] = dimension == i ? position : 0;
        end [i] = dimension == i ? position + 1 : source.GetLength (i);
    }
    int [] counters = new int [dimensions];
    for (counters [0] = start [0]; counters [0] < end [0]; counters [0] ++)
        for (counters [1] = start [1]; counters [1] < end [1]; counters [1] ++)
            for (counters [2] = start [2]; counters [2] < end [2]; counters [2] ++) {
                int [] sliceCoord = new int [dimensions - 1];
                for (int i = 0; i < t.Length; i ++) {
                    sliceCoord [i] = counters [i + (i >= dimension ? 1 : 0)];
                }
                result [sliceCoord [0], sliceCoord [1]] = source [counters [0], counters [1], counters [2]];
            }
    return result;
}

static int [,] GetSlice (int [,,] source, int dimension, int position) {
    int l1 = 0, l2 = 0;
    if (dimension == 0) {
        l1 = source.GetLength (1);
        l2 = source.GetLength (2);
    } else if (dimension == 1) {
        l1 = source.GetLength (0);
        l2 = source.GetLength (2);
    } else if (dimension == 2) {
        l1 = source.GetLength (0);
        l2 = source.GetLength (1);
    }
    var result = new int [l1, l2];
    var s0 = dimension == 0 ? position : 0;
    var s1 = dimension == 1 ? position : 0;
    var s2 = dimension == 2 ? position : 0;
    var m0 = dimension == 0 ? position + 1 : source.GetLength (0);
    var m1 = dimension == 1 ? position + 1 : source.GetLength (1);
    var m2 = dimension == 2 ? position + 1 : source.GetLength (2);
    for (var i0 = s0; i0 < m0; i0 ++)
        for (var i1 = s1; i1 < m1; i1 ++)
            for (var i2 = s2; i2 < m2; i2 ++) {
                int x = 0, y = 0;
                if (dimension == 0) {
                    x = i1;
                    y = i2;
                } else if (dimension == 1) {
                    x = i0;
                    y = i2;
                } else if (dimension == 2) {
                    x = i0;
                    y = i1;
                }
                result [x, y] = source [i0, i1, i2];
            }
    return result;
}

