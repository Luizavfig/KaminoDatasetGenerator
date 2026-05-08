/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7784251
*  Stack Overflow answer #:7785006
*  And Stack Overflow answer#:7784338
*/
float func (float a, float b, bool side) {
    float seg_a = a - b;
    if (seg_a < 0)
        seg_a += 1;
    float seg_b = 1 - seg_a;
    float result;
    if (side && seg_a > 0.5 || ! side && ! (seg_a > 0.5))
        result = b + seg_a / 2;
    else
        result = a + seg_b / 2;
    if (result > 1)
        result -= 1;
    return result;
}

float func (float a, float b, bool side) {
    float result = (a + b) / 2;
    if (result > 0.5)
        result = (a + b - 1) / 2;
    if (side == true)
        return result;
    else
        return result < 0.5 ? result + 0.5 : result - 0.5;
}

