/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4217616
*  Stack Overflow answer #:38327957
*  And Stack Overflow answer#:4217747
*/
static void Main (string [] args) {
    try {
        try {
            try {
                CallAndThrow ();
            }
            catch (Exception ex) {
                var dispatchException = ExceptionDispatchInfo.Capture (ex);
                dispatchException.Throw ();
            }
        }
        catch (Exception ex) {
            var dispatchException = ExceptionDispatchInfo.Capture (ex);
            dispatchException.Throw ();
        }
    }
    catch (Exception ex) {
        Console.WriteLine (ex.Message);
        Console.WriteLine (ex.InnerException.Message);
        Console.WriteLine (ex.StackTrace);
    }
    Console.ReadLine ();
}

static void Main (string [] args) {
    try {
        Rethrower ();
    }
    catch (Exception ex) {
        Console.Write (ex.ToString ());
    }
    Console.ReadKey ();
}

