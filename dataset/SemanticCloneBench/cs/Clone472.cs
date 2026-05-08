/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5651709
*  Stack Overflow answer #:5655634
*  And Stack Overflow answer#:29553084
*/
private static void updateBandwidthInterval (double [] xval, int i, int [] bandwidthInterval) {
    int left = bandwidthInterval [0];
    int right = bandwidthInterval [1];
    int nextRight = nextNonzero (weights, right);
    if (nextRight < xval.Length && xval [nextRight] - xval [i] < xval [i] - xval [left]) {
        int nextLeft = nextNonzero (weights, bandwidthInterval [0]);
        bandwidthInterval [0] = nextLeft;
        bandwidthInterval [1] = nextRight;
    }
}

private static void updateBandwidthInterval (double [] xval, int i, int [] bandwidthInterval) {
    int left = bandwidthInterval [0];
    int right = bandwidthInterval [1];
    if (left != 0 && xval [i] - xval [left - 1] < xval [right] - xval [i]) {
        bandwidthInterval [0] ++;
        bandwidthInterval [1] ++;
    } else if (right < xval.Length - 1 && xval [right + 1] - xval [i] < xval [i] - xval [left]) {
        bandwidthInterval [0] ++;
        bandwidthInterval [1] ++;
    }
}

