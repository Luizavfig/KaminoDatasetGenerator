/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:9259952
*  Stack Overflow answer #:9260015
*  And Stack Overflow answer#:9260088
*/
public static void Main (string [] args) {
    int result = 1;
    int numToCheck = 141234;
    boolean found = false;
    for (int i = 0; i < 15; i ++) {
        if (numToCheck == result) {
            found = true;
            break;
        }
        result *= 2;
    }
    if (found)
        Console.WriteLine ("Awesome");
}

public static void Main (string [] args) {
    int result = 0;
    int numToTest = 0;
    if (int.TryParse (args [0], out numToTest)) {
        result = ((from c in Convert.ToString (numToTest, 2)
            where c == '1'
            select c).Count () == 1) ? 1 : 0;
    }
    Console.WriteLine (result);
}

