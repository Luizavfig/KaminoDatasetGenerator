/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:43788627
*  Stack Overflow answer #:43789022
*  And Stack Overflow answer#:43788781
*/
protected bool IsPalindrome (uint x) {
    uint original = x;
    uint reverse = 0;
    while (x > 0) {
        reverse *= 10;
        reverse += x % 10;
        x /= 10;
    }
    return original == reverse;
}

protected bool IsPalindrome (uint x) {
    var chars = x.ToString ();
    for (var i = 0; i < chars.Length / 2; i ++) {
        if (chars [i] != chars [chars.Length - 1 - i]) {
            return false;
        }
    }
    return true;
}

