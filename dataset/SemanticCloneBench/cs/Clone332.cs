/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11140164
*  Stack Overflow answer #:43741761
*  And Stack Overflow answer#:12058856
*/
private static void Main (string [] args) {
    var connection = new HubConnection ("http://127.0.0.1:8088/");
    var myHub = connection.CreateHubProxy ("MyHub");
    Console.WriteLine ("Enter your name");
    string name = Console.ReadLine ();
    connection.Start ().ContinueWith (task = > {
        if (task.IsFaulted) {
            Console.WriteLine ("There was an error opening the connection:{0}", task.Exception.GetBaseException ());
        } else {
            Console.WriteLine ("Connected");
            myHub.On < string, string > ("addMessage", (s1, s2) = > {
                Console.WriteLine (s1 + ": " + s2);
            });
            while (true) {
                string message = Console.ReadLine ();
                if (string.IsNullOrEmpty (message)) {
                    break;
                }
                myHub.Invoke < string > ("Send", name, message).ContinueWith (task1 = > {
                    if (task1.IsFaulted) {
                        Console.WriteLine ("There was an error calling send: {0}", task1.Exception.GetBaseException ());
                    } else {
                        Console.WriteLine (task1.Result);
                    }
                });
            }
        }
    }).Wait ();
    Console.Read ();
    connection.Stop ();
}

private static void Main (string [] args) {
    var connection = new HubConnection ("http://127.0.0.1:8088/");
    var myHub = connection.CreateHubProxy ("CustomHub");
    connection.Start ().ContinueWith (task = > {
        if (task.IsFaulted) {
            Console.WriteLine ("There was an error opening the connection:{0}", task.Exception.GetBaseException ());
        } else {
            Console.WriteLine ("Connected");
        }
    }).Wait ();
    myHub.Invoke < string > ("Send", "HELLO World ").ContinueWith (task = > {
        if (task.IsFaulted) {
            Console.WriteLine ("There was an error calling send: {0}", task.Exception.GetBaseException ());
        } else {
            Console.WriteLine (task.Result);
        }
    });
    myHub.On < string > ("addMessage", param = > {
        Console.WriteLine (param);
    });
    myHub.Invoke < string > ("DoSomething", "I'm doing something!!!").Wait ();
    Console.Read ();
    connection.Stop ();
}

