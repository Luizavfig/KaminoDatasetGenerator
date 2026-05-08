/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1380610
*  Stack Overflow answer #:52997583
*  And Stack Overflow answer#:13200082
*/
bool isWellFormatted (string line) {
    Stack < char > lastOpen = new Stack < char > ();
    foreach (var c in line) {
        switch (c) {
            case ')' :
                if (lastOpen.Count == 0 || lastOpen.Pop () != '(')
                    return false;
                break;
            case ']' :
                if (lastOpen.Count == 0 || lastOpen.Pop () != '[')
                    return false;
                break;
            case '}' :
                if (lastOpen.Count == 0 || lastOpen.Pop () != '{')
                    return false;
                break;
            case '(' :
                lastOpen.Push (c);
                break;
            case '[' :
                lastOpen.Push (c);
                break;
            case '{' :
                lastOpen.Push (c);
                break;
        }
    }
    if (lastOpen.Count == 0)
        return true;
    else
        return false;
}

static public bool CheckForBalancedBracketing (string IncomingString) {
    const char LeftParenthesis = '(';
    const char RightParenthesis = ')';
    uint BracketCount = 0;
    try {
        checked {
            for (int Index = 0; Index < IncomingString.Length; Index ++) {
                switch (IncomingString [Index]) {
                    case LeftParenthesis :
                        BracketCount ++;
                        continue;
                    case RightParenthesis :
                        BracketCount --;
                        continue;
                    default :
                        continue;
                }
            }
        }
    }
    catch (OverflowException) {
        return false;
    }
    if (BracketCount == 0) {
        return true;
    }
    return false;
}

