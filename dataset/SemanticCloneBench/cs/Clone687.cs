/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3453274
*  Stack Overflow answer #:28372263
*  And Stack Overflow answer#:3453340
*/
public static IEnumerable < T > TakeLast < T > (this IEnumerable < T > input, int count) {
    if (count <= 0)
        yield break;
    var inputList = input as IList < T >;
    if (inputList != null) {
        int last = inputList.Count;
        int first = last - count;
        if (first < 0)
            first = 0;
        for (int i = first; i < last; i ++)
            yield return inputList [i];
    } else {
        T [] buffer = new T [count];
        int index = 0;
        count = 0;
        foreach (T item in input) {
            buffer [index] = item;
            index = (index + 1) % buffer.Length;
            count ++;
        }
        if (count < buffer.Length)
            index = 0;
        else
            count = buffer.Length;
        while (count > 0) {
            yield return buffer [index];
            index = (index + 1) % buffer.Length;
            count --;
        }
    }
}

public static IEnumerable < T > TakeLast < T > (this IEnumerable < T > source, int takeCount) {
    if (source == null) {
        throw new ArgumentNullException ("source");
    }
    if (takeCount < 0) {
        throw new ArgumentOutOfRangeException ("takeCount", "must not be negative");
    }
    if (takeCount == 0) {
        yield break;
    }
    T [] result = new T [takeCount];
    int i = 0;
    int sourceCount = 0;
    foreach (T element in source) {
        result [i] = element;
        i = (i + 1) % takeCount;
        sourceCount ++;
    }
    if (sourceCount < takeCount) {
        takeCount = sourceCount;
        i = 0;
    }
    for (int j = 0; j < takeCount; ++ j) {
        yield return result [(i + j) % takeCount];
    }
}

