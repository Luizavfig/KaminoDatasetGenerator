/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29417204
*  Stack Overflow answer #:29417345
*  And Stack Overflow answer#:29417391
*/
static void Main (string [] args) {
    int integerSum = 0;
    int count = 0;
    while (true) {
        Console.WriteLine ("Please enter Integer {0} now.", (count + 1));
        string rawInput = Console.ReadLine ();
        int integerInput;
        bool isInteger = int.TryParse (rawInput, out integerInput);
        if (isInteger == false) {
            Console.WriteLine ("This is not a valid integer. Please enter a valid integer now:");
        } else {
            integerSum += integerInput;
            count ++;
        }
        if (count >= 5) {
            break;
        }
    }
    Console.WriteLine ("sum = " + integerSum);
}

static void Main () {
    int sum = 0, value = 0;
    for (int i = 1; i <= 5; i ++) {
        Console.WriteLine ("Please enter Integer {0} now.", i);
        while (! int.TryParse (Console.ReadLine (), out value)) {
            Console.WriteLine ("This is not a valid integer. Please enter a valid integer {0} now:", i);
        }
        sum += value;
    }
    Console.WriteLine (sum);
}

