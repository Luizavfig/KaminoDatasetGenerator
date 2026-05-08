/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33030807
*  Stack Overflow answer #:33053156
*  And Stack Overflow answer#:33030941
*/
public void Set (int index) {
    int handlerCount;
    Action [] handlerList;
    lock (syncLock)
    {
        if (entries [index].IsSet)
            throw new InvalidOperationException ();
        entries [index].IsSet = true;
        handlerCount = entries [index].HandlerCount;
        handlerList = entries [index].HandlerList;
    } for (int i = 0; i < handlerCount; i ++)
        handlerList [i] ();
}

public void Set (int i) {
    lock (this)
    {
        if (! set.Contains (i)) {
            set.Add (i);
            BlockingCollection < Action > toExecute;
            if (! actions.TryGetValue (i, out toExecute)) {
                actions [i] = toExecute = new BlockingCollection < Action > ();
            }
            ExecuteActions (toExecute);
        }
    }}

