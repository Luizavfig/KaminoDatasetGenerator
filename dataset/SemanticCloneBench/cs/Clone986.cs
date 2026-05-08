/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:22362257
*  Stack Overflow answer #:22362873
*  And Stack Overflow answer#:22362681
*/
public void DrawSquare (int sideLength) {
    for (int row = 1; row <= sideLength; row ++) {
        for (int col = 1; col <= sideLength; col ++) {
            if (col <= row)
                Console.Write ('*');
            else
                Console.Write ('#');
        }
        Console.WriteLine ();
    }
}

public void Draw (int width) {
    int w_counter = 1;
    for (int l = 0; l < 6; l ++) {
        var asterisk = new String ('*', w_counter);
        var hash = new String ('#', width - w_counter);
        Console.WrilteLine (asterisk + hash);
        w_counter ++;
    }
}

