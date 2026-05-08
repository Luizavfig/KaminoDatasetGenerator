/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1583050
*  Stack Overflow answer #:2679594
*  And Stack Overflow answer#:1583270
*/
static void Main () {
    object [] values = new object [Size];
    for (int i = 0; i < Size - 2; i += 3) {
        values [i] = null;
        values [i + 1] = "";
        values [i + 2] = 1;
    }
    FindSumWithCast (values);
    FindSumWithAsAndHas (values);
    FindSumWithAsAndIs (values);
    FindSumWithIsThenAs (values);
    FindSumWithIsThenConvert (values);
    FindSumWithLinq (values);
    Console.ReadLine ();
}

static void Main () {
    TestUnrestricted < int > (1, 5);
    TestUnrestricted < string > ("abc", 5);
    TestUnrestricted < int ? > (1, 5);
    TestNullable < int > (1, 5);
    const int LOOP = 100000000;
    Console.WriteLine (TestUnrestricted < int > (1, LOOP));
    Console.WriteLine (TestUnrestricted < string > ("abc", LOOP));
    Console.WriteLine (TestUnrestricted < int ? > (1, LOOP));
    Console.WriteLine (TestNullable < int > (1, LOOP));
}

