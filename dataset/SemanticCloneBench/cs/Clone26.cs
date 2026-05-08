/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15743192
*  Stack Overflow answer #:22708260
*  And Stack Overflow answer#:15743231
*/
static void Main (string [] args) {
    Console.Write ("Enter a number: ");
    int theNum = int.Parse (Console.ReadLine ());
    if (theNum < 3) {
        if (theNum == 2) {
            Console.WriteLine ("{0} is a prime!", theNum);
        } else {
            Console.WriteLine ("{0} is not a prime", theNum);
        }
    } else {
        if (theNum % 2 == 0) {
            Console.WriteLine ("{0} is not a prime", theNum);
        } else {
            int div;
            for (div = 3; theNum % div != 0; div += 2)
                ;
            if (div == theNum) {
                Console.WriteLine ("{0} is a prime!", theNum);
            } else {
                Console.WriteLine ("{0} is not a prime", theNum);
            }
        }
    }
    Console.ReadLine ();
}

static void Main () {
    Console.WriteLine ("--- Primes between 0 and 100 ---");
    for (int i = 0; i < 100; i ++) {
        bool prime = PrimeTool.IsPrime (i);
        if (prime) {
            Console.Write ("Prime: ");
            Console.WriteLine (i);
        }
    }
    Console.WriteLine ("--- Primes between 10000 and 10100 ---");
    for (int i = 10000; i < 10100; i ++) {
        if (PrimeTool.IsPrime (i)) {
            Console.Write ("Prime: ");
            Console.WriteLine (i);
        }
    }
}

