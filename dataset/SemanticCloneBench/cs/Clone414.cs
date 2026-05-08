/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6330699
*  Stack Overflow answer #:6331453
*  And Stack Overflow answer#:6331620
*/
public override string ReadLine () {
    int c;
    c = Read ();
    if (c == - 1) {
        return null;
    }
    StringBuilder sb = new StringBuilder ();
    do
        {
            char ch = (char) c;
            if (ch == ',') {
                return sb.ToString ();
            } else {
                sb.Append (ch);
            }
        } while ((c = Read ()) != - 1);
    return sb.ToString ();
}

public override string ReadLine () {
    string result = string.Empty;
    int b = base.Read ();
    while ((b != (int) ',') && (b > 0)) {
        result += this.CurrentEncoding.GetString (new byte [] {(byte) b});
        b = base.Read ();
    }
    return result;
}

