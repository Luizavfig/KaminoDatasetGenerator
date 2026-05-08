/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:35297344
*  Stack Overflow answer #:35331857
*  And Stack Overflow answer#:35331857
*/
public override void PreBuildUp (IBuilderContext context) {
    if (context.BuildKey.Type != typeof (Logger)) {
        var loggerPolicy = context.Policies.Get < ILoggerPolicy > (LoggerExtension.LoggerBuildKey);
        if (loggerPolicy == null) {
            loggerPolicy = new LoggerPolicy ();
            context.Policies.Set < ILoggerPolicy > (loggerPolicy, LoggerExtension.LoggerBuildKey);
        }
        loggerPolicy.Push (context.BuildKey.Type);
    }
}

public override void PreBuildUp (IBuilderContext context) {
    if (context.BuildKey.Type == typeof (Logger)) {
        var policy = context.Policies.Get < ILoggerPolicy > (LoggerExtension.LoggerBuildKey);
        Type type = policy.Peek ();
        if (type != null) {
            context.AddResolverOverrides (new ParameterOverride ("type", new InjectionParameter (typeof (Type), type)));
        }
    }
}

