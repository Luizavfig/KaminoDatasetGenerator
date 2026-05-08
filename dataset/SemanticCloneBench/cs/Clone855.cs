/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:10927523
*  Stack Overflow answer #:10927632
*  And Stack Overflow answer#:10927800
*/
public bool IsValidIP (string addr) {
    string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.
([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
    Regex check = new Regex (pattern);
    bool valid = false;
    if (addr == "") {
        valid = false;
    } else {
        valid = check.IsMatch (addr, 0);
    }
    return valid;
}

bool IsTextAValidIPAddress (string text) {
    bool result = true;
    string [] values = text.Split (new [] {"."}, StringSplitOptions.None);
    result &= values.Length == 4;
    if (result)
        for (int i = 0; i < 4; i ++)
            result &= byte.TryParse (values [i], out temp);
    return result;
}

