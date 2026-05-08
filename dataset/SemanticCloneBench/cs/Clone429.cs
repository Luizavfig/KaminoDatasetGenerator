/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5243237
*  Stack Overflow answer #:23390837
*  And Stack Overflow answer#:5243263
*/
private static char GetRandomCharacter () {
    var upperBound = PwdCharArray.GetUpperBound (0);
    if (ExcludeSymbols) {
        upperBound = UBoundDigit;
    }
    int randomCharPosition = GetCryptographicRandomNumber (PwdCharArray.GetLowerBound (0), upperBound);
    char randomChar = PwdCharArray [randomCharPosition];
    return randomChar;
}

protected char GetRandomCharacter () {
    int upperBound = pwdCharArray.GetUpperBound (0);
    if (true == this.ExcludeSymbols) {
        upperBound = PasswordGenerator.UBoundDigit;
    }
    int randomCharPosition = GetCryptographicRandomNumber (pwdCharArray.GetLowerBound (0), upperBound);
    char randomChar = pwdCharArray [randomCharPosition];
    return randomChar;
}

