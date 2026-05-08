/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:32102433
*  Stack Overflow answer #:32102596
*  And Stack Overflow answer#:32102711
*/
static void Main (string [] args) {
    Random rand = new Random ();
    int number = rand.Next (1, 1000);
    byte [] intBytes = BitConverter.GetBytes (number);
    string answer = "";
    for (int i = 0; i < intBytes.Length; i ++) {
        answer += intBytes [i] + @"\";
    }
    Console.WriteLine (answer);
    Console.WriteLine (number);
    Console.ReadKey ();
}

public static void Main () {
    Int32 value = 5152;
    byte [] bytes = new byte [4];
    for (int i = 0; i < 4; i ++) {
        bytes [i] = (byte) ((value > > i * 8) & 0xFF);
    }
    StringBuilder result = new StringBuilder ();
    for (int i = 0; i < 4; i ++) {
        result.Append ("\\" + bytes [i].ToString ("X2"));
    }
    Console.WriteLine (result);
}

