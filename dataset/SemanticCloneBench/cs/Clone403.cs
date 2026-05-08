/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:41228754
*  Stack Overflow answer #:41229326
*  And Stack Overflow answer#:41229281
*/
public static long addLong (decimal value, decimal adder) {
    try {
        return value + adder;
    }
    catch (OverflowException e) {
        Debug.Log ("greater then max value");
        return decimal.MaxValue;
    }
}

public static long addLong (long value, long adder) {
    unchecked {
        if (value + adder < value && value + adder < adder) {
            Debug.Log ("greater then max value");
            return long.MaxValue;
        } else if (value + adder > value && value + adder > adder) {
            Debug.Log ("less then min value");
            return long.MinValue;
        } else {
            Debug.Log ("within the [min..max] range");
            return value + adder;
        }
    }
}

