/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13283184
*  Stack Overflow answer #:13283467
*  And Stack Overflow answer#:15004833
*/
static void Main (string [] args) {
    List < string > names = new List < string > () {"Sam", "John", "Bob", "Adam", "Kelly", "Nolan", "Carl", "Tim", "Tom", "David"};
    for (int i = 0; i < names.Count; i ++) {
        if (i % 4 == 0 && i > 0)
            Console.WriteLine ();
        Console.Write (names [i] + "\t");
    }
    Console.ReadLine ();
}

public static void Main () {
    Tuple < string, DateTime, int, DateTime, int > [] cities = {Tuple.Create ("Los Angeles", new DateTime (1940, 1, 1), 1504277, new DateTime (1950, 1, 1), 1970358), Tuple.Create ("New York", new DateTime (1940, 1, 1), 7454995, new DateTime (1950, 1, 1), 7891957), Tuple.Create ("Chicago", new DateTime (1940, 1, 1), 3396808, new DateTime (1950, 1, 1), 3620962), Tuple.Create ("Detroit", new DateTime (1940, 1, 1), 1623452, new DateTime (1950, 1, 1), 1849568)};
    string header = String.Format ("{0,-12}{1,8}{2,12}{1,8}{2,12}{3,14}\n", "City", "Year", "Population", "Change (%)");
    Console.WriteLine (header);
    string output;
    foreach (var city in cities) {
        output = String.Format ("{0,-12}{1,8:yyyy}{2,12:N0}{3,8:yyyy}{4,12:N0}{5,14:P1}", city.Item1, city.Item2, city.Item3, city.Item4, city.Item5, (city.Item5 - city.Item3) / (double) city.Item3);
        Console.WriteLine (output);
    }
}

