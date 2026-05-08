/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8079526
*  Stack Overflow answer #:36767109
*  And Stack Overflow answer#:36767109
*/
protected override void CalculateBiQuadCoefficients () {
    double k = Math.Tan (Math.PI * Frequency / SampleRate);
    double norm = 1 / (1 + k / Q + k * k);
    A0 = (1 + k * k) * norm;
    A1 = 2 * (k * k - 1) * norm;
    A2 = A0;
    B1 = A1;
    B2 = (1 - k / Q + k * k) * norm;
}

protected override void CalculateBiQuadCoefficients () {
    double norm;
    double v = Math.Pow (10, Math.Abs (GainDB) / 20.0);
    double k = Math.Tan (Math.PI * Frequency / SampleRate);
    double q = Q;
    if (GainDB >= 0) {
        norm = 1 / (1 + 1 / q * k + k * k);
        A0 = (1 + v / q * k + k * k) * norm;
        A1 = 2 * (k * k - 1) * norm;
        A2 = (1 - v / q * k + k * k) * norm;
        B1 = A1;
        B2 = (1 - 1 / q * k + k * k) * norm;
    } else {
        norm = 1 / (1 + v / q * k + k * k);
        A0 = (1 + 1 / q * k + k * k) * norm;
        A1 = 2 * (k * k - 1) * norm;
        A2 = (1 - 1 / q * k + k * k) * norm;
        B1 = A1;
        B2 = (1 - v / q * k + k * k) * norm;
    }
}

