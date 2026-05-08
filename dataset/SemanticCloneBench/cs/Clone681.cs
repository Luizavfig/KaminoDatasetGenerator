/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:24104789
*  Stack Overflow answer #:24106451
*  And Stack Overflow answer#:24106451
*/
private void ReaderWorker (object data) {
    ProcessOutputReaderWorkerThreadArguments args;
    try {
        args = (ProcessOutputReaderWorkerThreadArguments) data;
    }
    catch {
        return;
    }
    try {
        char [] readBuffer = new char [args.ReadBufferSize];
        while (! args.Exit) {
            if (args.Process == null) {
                return;
            }
            if (args.Process.HasExited) {
                return;
            }
            if (args.Process.StandardOutput.EndOfStream) {
                return;
            }
            int readBytes = this.Process.StandardOutput.Read (readBuffer, 0, readBuffer.Length);
            args.IntermediateDataStore.Append (readBuffer, 0, readBytes);
            this.FireOnDataRead (new String (readBuffer, 0, readBytes));
        }
    }
    catch (ThreadAbortException) {
        if (! args.Process.HasExited) {
            args.Process.Kill ();
        }
    }
}

public void StartReading () {
    if (this.ReaderThread != null) {
        if (this.ReaderThread.IsAlive) {
            return;
        }
    }
    this.ReaderThread = new Thread (new ParameterizedThreadStart (ReaderWorker));
    this.threadArguments.Exit = false;
    this.ReaderThread.Start (this.threadArguments);
}

