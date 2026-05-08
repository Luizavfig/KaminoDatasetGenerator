/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:541954
*  Stack Overflow answer #:30519639
*  And Stack Overflow answer#:9646835
*/
public static int CountOccurrences (string original, string substring) {
    if (string.IsNullOrEmpty (substring))
        return 0;
    if (substring.Length == 1)
        return CountOccurrences (original, substring [0]);
    if (string.IsNullOrEmpty (original) || substring.Length > original.Length)
        return 0;
    int substringCount = 0;
    for (int charIndex = 0; charIndex < original.Length; charIndex ++) {
        for (int subCharIndex = 0, secondaryCharIndex = charIndex; subCharIndex < substring.Length && secondaryCharIndex < original.Length; subCharIndex ++, secondaryCharIndex ++) {
            if (substring [subCharIndex] != original [secondaryCharIndex])
                goto continueOuter;
        }
        if (charIndex + substring.Length > original.Length)
            break;
        charIndex += substring.Length - 1;
        substringCount ++;
        continueOuter :;}
    return substringCount;
}

public int getNumberOfOccurencies (String inputString, String checkString) {
    if (checkString.Length > inputString.Length || checkString.Equals ("")) {
        return 0;
    }
    int lengthDifference = inputString.Length - checkString.Length;
    int occurencies = 0;
    for (int i = 0; i < lengthDifference; i ++) {
        if (inputString.Substring (i, checkString.Length).Equals (checkString)) {
            occurencies ++;
            i += checkString.Length - 1;
        }
    }
    return occurencies;
}

