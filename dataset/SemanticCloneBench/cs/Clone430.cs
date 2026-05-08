/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5243237
*  Stack Overflow answer #:23390837
*  And Stack Overflow answer#:5243263
*/
public static string Generate () {
    var pwdLength = GetCryptographicRandomNumber (Minimum, Maximum);
    var pwdBuffer = new StringBuilder {Capacity = Maximum};
    char lastCharacter = '\n';
    for (var i = 0; i < pwdLength; i ++) {
        var nextCharacter = GetRandomCharacter ();
        while (nextCharacter == lastCharacter) {
            nextCharacter = GetRandomCharacter ();
        }
        if (false == RepeatCharacters) {
            var temp = pwdBuffer.ToString ();
            var duplicateIndex = temp.IndexOf (nextCharacter);
            while (- 1 != duplicateIndex) {
                nextCharacter = GetRandomCharacter ();
                duplicateIndex = temp.IndexOf (nextCharacter);
            }
        }
        if ((null != Exclusions)) {
            while (- 1 != Exclusions.IndexOf (nextCharacter)) {
                nextCharacter = GetRandomCharacter ();
            }
        }
        pwdBuffer.Append (nextCharacter);
        lastCharacter = nextCharacter;
    }
    return pwdBuffer.ToString ();
}

public string Generate () {
    int pwdLength = GetCryptographicRandomNumber (this.Minimum, this.Maximum);
    StringBuilder pwdBuffer = new StringBuilder ();
    pwdBuffer.Capacity = this.Maximum;
    char lastCharacter, nextCharacter;
    lastCharacter = nextCharacter = '\n';
    for (int i = 0; i < pwdLength; i ++) {
        nextCharacter = GetRandomCharacter ();
        if (false == this.ConsecutiveCharacters) {
            while (lastCharacter == nextCharacter) {
                nextCharacter = GetRandomCharacter ();
            }
        }
        if (false == this.RepeatCharacters) {
            string temp = pwdBuffer.ToString ();
            int duplicateIndex = temp.IndexOf (nextCharacter);
            while (- 1 != duplicateIndex) {
                nextCharacter = GetRandomCharacter ();
                duplicateIndex = temp.IndexOf (nextCharacter);
            }
        }
        if ((null != this.Exclusions)) {
            while (- 1 != this.Exclusions.IndexOf (nextCharacter)) {
                nextCharacter = GetRandomCharacter ();
            }
        }
        pwdBuffer.Append (nextCharacter);
        lastCharacter = nextCharacter;
    }
    if (null != pwdBuffer) {
        return pwdBuffer.ToString ();
    } else {
        return String.Empty;
    }
}

