/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9790749
*  Stack Overflow answer #:45035908
*  And Stack Overflow answer#:24816588
*/
private void CheckIfPalindrome (string str) {
    char [] array = str.ToCharArray ();
    int length = array.Length - 1;
    Boolean palindrome = true;
    for (int i = 0; i <= length; i ++) {
        if (array [i] != array [length]) {
            MessageBox.Show ("not");
            palindrome = false;
            break;
        } else {
            length --;
        }
    }
    if (palindrome)
        MessageBox.Show ("Palindrome");
}

public static bool IsPalindrome (string value) {
    int i = 0;
    int j = value.Length - 1;
    while (true) {
        if (i > j) {
            return true;
        }
        char a = value [i];
        char b = value [j];
        if (char.ToLower (a) != char.ToLower (b)) {
            return false;
        }
        i ++;
        j --;
    }
}

