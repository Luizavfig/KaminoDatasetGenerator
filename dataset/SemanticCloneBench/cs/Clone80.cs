/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:547634
*  Stack Overflow answer #:6318951
*  And Stack Overflow answer#:547663
*/
public static string HtmlEncode (string s) {
    s = HttpUtility.HtmlEncode (s);
    int num = IndexOfHighChar (s, 0);
    if (num == - 1)
        return s;
    int old_num = 0;
    StringBuilder sb = new StringBuilder ();
    do
        {
            sb.Append (s, old_num, num - old_num);
            sb.Append ("&#");
            sb.Append (((int) s [num]).ToString (NumberFormatInfo.InvariantInfo));
            sb.Append (';');
            old_num = num + 1;
            num = IndexOfHighChar (s, old_num);
        } while (num != - 1);
    sb.Append (s, old_num, s.Length - old_num);
    return sb.ToString ();
}

public static string HtmlEncode (string text) {
    if (text == null)
        return null;
    StringBuilder sb = new StringBuilder (text.Length);
    int len = text.Length;
    for (int i = 0; i < len; i ++) {
        switch (text [i]) {
            case '<' :
                sb.Append ("&lt;");
                break;
            case '>' :
                sb.Append ("&gt;");
                break;
            case '"' :
                sb.Append ("&quot;");
                break;
            case '&' :
                sb.Append ("&amp;");
                break;
            default :
                if (text [i] > 159) {
                    sb.Append ("&#");
                    sb.Append (((int) text [i]).ToString (CultureInfo.InvariantCulture));
                    sb.Append (";");
                } else
                    sb.Append (text [i]);
                break;
        }
    }
    return sb.ToString ();
}

