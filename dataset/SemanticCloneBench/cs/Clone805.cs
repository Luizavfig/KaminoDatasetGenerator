/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11412956
*  Stack Overflow answer #:29942932
*  And Stack Overflow answer#:11412991
*/
public Boolean CheckIPValid (String strIP) {
    string [] arrOctets = strIP.Split ('.');
    if (arrOctets.Length != 4)
        return false;
    byte obyte = 0;
    foreach (string strOctet in arrOctets)
        if (! byte.TryParse (strOctet, out obyte))
            return false;
    return true;
}

public bool ValidateIPv4 (string ipString) {
    if (String.IsNullOrWhiteSpace (ipString)) {
        return false;
    }
    string [] splitValues = ipString.Split ('.');
    if (splitValues.Length != 4) {
        return false;
    }
    byte tempForParsing;
    return splitValues.All (r = > byte.TryParse (r, out tempForParsing));
}

