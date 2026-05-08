/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29716367
*  Stack Overflow answer #:29716441
*  And Stack Overflow answer#:29716524
*/
static void xn () {
    double r = 3.9;
    double [] xr_arr = new double [100];
    for (double x = 0; x <= 1; x += 0.01) {
        double xr = r * x * (1 - x);
        xr_arr [x] = xr;
        for (int y = 0; y < 23; y ++) {
            Console.WriteLine (xr_arr [y]);
        }
    }
}

static void xn () {
    double r = 3.9;
    var n = 0;
    var increment = 0.01d;
    var n_expected = 100;
    var x_arr = new double [n_expected];
    for (double x = 0; x <= 1; x += increment) {
        double xr = r * x * (1 - x);
        x_arr [n ++] = xr;
    }
    for (int y = 0; y < 23; y ++) {
        Console.WriteLine (xr_arr [y]);
    }
}

