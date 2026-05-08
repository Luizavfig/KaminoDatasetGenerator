/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33057488
*  Stack Overflow answer #:33057552
*  And Stack Overflow answer#:33057579
*/
static void Main (string [] args) {
    authenticator auth = new authenticator ();
    string login = "hello";
    string pass = "12345";
    if (auth.CheckPassword (login, pass))
        Console.Write ("Access granted");
    else
        Console.Write ("Wrong login or password");
}

static void Main (string [] args) {
    Console.WriteLine ("Enter username : ");
    var username = Console.ReadLine ();
    Console.WriteLine ("Enter password : ");
    var password = Console.ReadLine ();
    var isvalid = auth.ValidateCredentials (username, password);
    Console.WriteLine ("Your are{0} authenticated!", isvalid ? string.Empty : " NOT");
    Console.ReadLine ();
}

