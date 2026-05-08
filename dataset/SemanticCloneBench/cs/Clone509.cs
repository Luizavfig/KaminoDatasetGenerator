/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1914885
*  Stack Overflow answer #:34633405
*  And Stack Overflow answer#:7327551
*/
public static bool IsQueueAvailable (string queueName) {
    MessageQueue queue;
    try {
        queue = new MessageQueue (queueName);
        queue.Peek (new TimeSpan (0, 0, 5));
        return true;
    }
    catch (Exception ex) {
        if (ex is ArgumentException) {
            return false;
        } else if (ex is MessageQueueException) {
            return (((MessageQueueException) ex).MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout);
        }
        return false;
    }
}

public static bool IsQueueAvailable (string queueName) {
    var queue = new MessageQueue (queueName);
    try {
        queue.Peek (new TimeSpan (0, 0, 5));
        return true;
    }
    catch (MessageQueueException ex) {
        return ex.Message.StartsWith ("Timeout");
    }
}

