/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7109624
*  Stack Overflow answer #:7110006
*  And Stack Overflow answer#:7111681
*/
public static string SummarizeMethodCall (MethodBase method, params object [] values) {
    var output = new StringBuilder (method.Name + " invoked: ");
    ParameterInfo [] parameters = method.GetParameters ();
    for (int i = 0; i < parameters.Length; i ++) {
        output.AppendFormat ("{0} = {1}", parameters [i].Name, i >= values.Length ? "<empty>" : values [i]);
        if (i < parameters.Length - 1)
            output.Append (", ");
    }
    return output.ToString ();
}

public override void OnException (MethodExecutionEventArgs eventArgs) {
    Console.WriteLine (eventArgs.Method.DeclaringType.Name);
    Console.WriteLine (eventArgs.Method.Name);
    Console.WriteLine (eventArgs.Exception.StackTrace);
    ParameterInfo [] parameterInfos = eventArgs.Method.GetParameters ();
    object [] paramValues = eventArgs.GetReadOnlyArgumentArray ();
    for (int i = 0; i < parameterInfos.Length; i ++) {
        Console.WriteLine (parameterInfos [i].Name + "=" + paramValues [i]);
    }
    eventArgs.FlowBehavior = FlowBehavior.Default;
}

