/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13539869
*  Stack Overflow answer #:13540355
*  And Stack Overflow answer#:13540168
*/
private static void Main () {
    _serialPortBytes = Encoding.ASCII.GetBytes ("Mimic a bunch of bytes from the serial port");
    _streamOfBytesFromPort = new MemoryStream (_serialPortBytes);
    _streamOfBytesFromPort.Position = 0;
    _cancelTaskSignalSource = new CancellationTokenSource ();
    _cancelTaskSignal = _cancelTaskSignalSource.Token;
    var readFromSerialPort = Task.Factory.StartNew (ReadStream, _cancelTaskSignal);
    readFromSerialPort.Wait (3000);
    Console.WriteLine ("Press enter to cancel the task");
    _cancelTaskSignalSource.Cancel ();
    Console.ReadLine ();
}

static void Main (string [] args) {
    int buff;
    SerialPort port = new SerialPort ("COM4", 9600, Parity.None, 8, StopBits.One);
    port.Open ();
    for (int i = 0; i < 2000; i ++) {
        Console.ReadLine ();
        buff = port.ReadByte ();
        Console.WriteLine (buff);
    }
}

