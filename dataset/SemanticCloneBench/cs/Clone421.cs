/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:31669526
*  Stack Overflow answer #:43832577
*  And Stack Overflow answer#:31670840
*/
public static bool IsBalanced (string input) {
    int numOpen = 0;
    while (input != "") {
        char c = input [0];
        input = input.Substring (1);
        numOpen = c == '(' ? (numOpen + 1) : (c == ')' ? (numOpen - 1) : numOpen);
    }
    return numOpen == 0;
}

bool IsBalanced (string input) {
    var first = input.IndexOf ('(');
    var last = input.LastIndexOf (')');
    if (first == - 1 && last == - 1)
        return true;
    if (first == - 1 && last != - 1 || first != - 1 && last == - 1)
        return false;
    if (first > last)
        return false;
    return IsBalanced (input.Substring (first, last - first));
}

