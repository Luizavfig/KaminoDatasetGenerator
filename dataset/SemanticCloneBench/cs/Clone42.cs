/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:627463
*  Stack Overflow answer #:627487
*  And Stack Overflow answer#:33704827
*/
private static long IsPrime (long input) {
    if ((input % 2) == 0) {
        return 2;
    } else if ((input == 1)) {
        return 1;
    } else {
        long threshold = (Convert.ToInt64 (Math.Sqrt (input)));
        long tryDivide = 3;
        while (tryDivide < threshold) {
            if ((input % tryDivide) == 0) {
                Console.WriteLine ("Found a factor: " + tryDivide);
                return tryDivide;
            }
            tryDivide += 2;
        }
        Console.WriteLine ("Found a factor: " + input);
        return - 1;
    }
}

bool IsPrime (int input) {
    if (input == 2 || input == 3)
        return true;
    else if (input % 2 == 0 || input % 3 == 0)
        return false;
    else {
        for (int i = 5; i * i <= input; i += 6) {
            if (input % i == 0 || input % (i + 2) == 0)
                return false;
        }
        return true;
    }
}

