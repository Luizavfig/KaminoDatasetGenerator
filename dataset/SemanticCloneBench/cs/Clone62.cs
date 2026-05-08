/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29927918
*  Stack Overflow answer #:29929126
*  And Stack Overflow answer#:29930038
*/
string ConvertDashToCamelCase (string input) {
    StringBuilder sb = new StringBuilder ();
    bool caseFlag = false;
    for (int i = 0; i < input.Length; ++ i) {
        char c = input [i];
        if (c == '-') {
            caseFlag = true;
        } else if (caseFlag) {
            sb.Append (char.ToUpper (c));
            caseFlag = false;
        } else {
            sb.Append (char.ToLower (c));
        }
    }
    return sb.ToString ();
}

string ConvertDashToCamelCase (string input) {
    StringBuilder sb = new StringBuilder ();
    bool caseFlag = false;
    bool tagFlag = false;
    for (int i = 0; i < input.Length; i ++) {
        char c = input [i];
        if (tagFlag) {
            if (c == '-') {
                caseFlag = true;
            } else if (caseFlag) {
                sb.Append (char.ToUpper (c));
                caseFlag = false;
            } else {
                sb.Append (char.ToLower (c));
            }
        } else {
            sb.Append (c);
        }
        if (c == '>' || c == '<') {
            tagFlag = (c == '<');
        }
    }
    return sb.ToString ();
}

