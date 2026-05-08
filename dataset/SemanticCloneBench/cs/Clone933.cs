/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15551718
*  Stack Overflow answer #:15551808
*  And Stack Overflow answer#:15552626
*/
[Test] public void test () {
    List < int > test = new List < int > ();
    for (int i = 0; i < 10; i ++) {
        test.Add (MyMath.Random (100));
    }
    Console.WriteLine ("result:");
    foreach (int i in test) {
        Console.WriteLine ();
    }
}

public int ComeOnItsKindaRandom (int minValue, int maxValue) {
    var query = "http://www.random.org/integers/?num=1&min={0}&max={1}&col=1&base=10&format=plain&rnd=new";
    var request = WebRequest.Create (string.Format (query, minValue, maxValue));
    var response = request.GetResponse ();
    using (var sr = new StreamReader (response.GetResponseStream ()))
    {
        var body = sr.ReadToEnd ().Trim ();
        return int.Parse (body);
    }}

