/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3180685
*  Stack Overflow answer #:3180764
*  And Stack Overflow answer#:3180764
*/
public string CreateCacheKey (MethodBase method, params object [] inputs) {
    try {
        var sb = new StringBuilder ();
        if (method.DeclaringType != null) {
            sb.Append (method.DeclaringType.FullName);
        }
        sb.Append (':');
        sb.Append (method.Name);
        TextWriter writer = new StringWriter (sb);
        if (inputs != null) {
            foreach (var input in inputs) {
                sb.Append (':');
                if (input != null) {
                    var inputDateTime = input as DateTime ?;
                    if (inputDateTime.HasValue) {
                        sb.Append (inputDateTime.Value.Ticks);
                    } else {
                        serializer.Serialize (writer, input);
                    }
                }
            }
        }
        return sb.ToString ();
    }
    catch {
        return null;
    }
}

private IMethodReturn loadUsingCache () {
    lock (input.MethodBase)
    {
        if (TargetMethodReturnsVoid (input) || HttpContext.Current == null) {
            return getNext () (input, getNext);
        }
        var inputs = new object [input.Inputs.Count];
        for (int i = 0; i < inputs.Length; ++ i) {
            inputs [i] = input.Inputs [i];
        }
        string cacheKey = keyGenerator.CreateCacheKey (input.MethodBase, inputs);
        object cachedResult = getCachedResult (cacheKey);
        if (cachedResult == null) {
            var stopWatch = Stopwatch.StartNew ();
            var realReturn = getNext () (input, getNext);
            stopWatch.Stop ();
            if (realReturn.Exception == null && realReturn.ReturnValue != null) {
                AddToCache (cacheKey, realReturn.ReturnValue);
            }
            return realReturn;
        }
        var cachedReturn = input.CreateMethodReturn (cachedResult, input.Arguments);
        return cachedReturn;
    }}

