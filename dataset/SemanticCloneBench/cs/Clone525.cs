/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4116242
*  Stack Overflow answer #:4116293
*  And Stack Overflow answer#:4116263
*/
static void Main (string [] args) {
    var sum = 0;
    foreach (var number in GetEvenFibonacciSeries ()) {
        if (sum + number > 4000000)
            break;
        sum += number;
    }
    Console.WriteLine (sum);
}

static void Main () {
    int sum = 0;
    int currentNumber = 1;
    int lastNumber = 0;
    while (currentNumber <= 500) {
        if (currentNumber % 2 == 0) {
            sum += currentNumber;
        }
        int nextNumber = lastNumber + currentNumber;
        lastNumber = currentNumber;
        currentNumber = nextNumber;
    }
    Console.WriteLine ("Project Euler - Question 2\n\nAnswer: " + sum);
    Console.ReadLine ();
}

