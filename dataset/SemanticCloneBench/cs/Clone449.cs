/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2288498
*  Stack Overflow answer #:25510241
*  And Stack Overflow answer#:21676524
*/
public static String Rainbow (Int32 numOfSteps, Int32 step) {
    var r = 0.0;
    var g = 0.0;
    var b = 0.0;
    var h = (Double) step / numOfSteps;
    var i = (Int32) (h * 6);
    var f = h * 6.0 - i;
    var q = 1 - f;
    switch (i % 6) {
        case 0 :
            r = 1;
            g = f;
            b = 0;
            break;
        case 1 :
            r = q;
            g = 1;
            b = 0;
            break;
        case 2 :
            r = 0;
            g = 1;
            b = f;
            break;
        case 3 :
            r = 0;
            g = q;
            b = 1;
            break;
        case 4 :
            r = f;
            g = 0;
            b = 1;
            break;
        case 5 :
            r = 1;
            g = 0;
            b = q;
            break;
    }
    return "#" + ((Int32) (r * 255)).ToString ("X2") + ((Int32) (g * 255)).ToString ("X2") + ((Int32) (b * 255)).ToString ("X2");
}

public static Color Rainbow (float progress) {
    float div = (Math.Abs (progress % 1) * 6);
    int ascending = (int) ((div % 1) * 255);
    int descending = 255 - ascending;
    switch ((int) div) {
        case 0 :
            return Color.FromArgb (255, 255, ascending, 0);
        case 1 :
            return Color.FromArgb (255, descending, 255, 0);
        case 2 :
            return Color.FromArgb (255, 0, 255, ascending);
        case 3 :
            return Color.FromArgb (255, 0, descending, 255);
        case 4 :
            return Color.FromArgb (255, ascending, 0, 255);
        default :
            return Color.FromArgb (255, 255, 0, descending);
    }
}

