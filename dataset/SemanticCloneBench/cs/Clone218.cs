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
    const double sqrt2 = 1.4142135623730951;
    double k = Math.Tan (Math.PI * Frequency / SampleRate);
    double v = Math.Pow (10, Math.Abs (GainDB) / 20.0);
    double norm;
    if (GainDB >= 0) {
        norm = 1 / (1 + sqrt2 * k + k * k);
        A0 = (1 + Math.Sqrt (2 * v) * k + v * k * k) * norm;
        A1 = 2 * (v * k * k - 1) * norm;
        A2 = (1 - Math.Sqrt (2 * v) * k + v * k * k) * norm;
        B1 = 2 * (k * k - 1) * norm;
        B2 = (1 - sqrt2 * k + k * k) * norm;
    } else {
        norm = 1 / (1 + Math.Sqrt (2 * v) * k + v * k * k);
        A0 = (1 + sqrt2 * k + k * k) * norm;
        A1 = 2 * (k * k - 1) * norm;
        A2 = (1 - sqrt2 * k + k * k) * norm;
        B1 = 2 * (v * k * k - 1) * norm;
        B2 = (1 - Math.Sqrt (2 * v) * k + v * k * k) * norm;
    }
}

