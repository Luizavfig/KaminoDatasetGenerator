/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:45779
*  Stack Overflow answer #:45901
*  And Stack Overflow answer#:45901
*/
public static void Main () {
    var raiser = new EventRaiser ();
    var handler = new Handler ();
    string eventName = "SomethingHappened";
    var eventinfo = raiser.GetType ().GetEvent (eventName);
    eventinfo.AddEventHandler (raiser, EventProxy.Create (eventinfo, handler.HandleEvent));
    string eventName2 = "SomethingHappenedWithArg";
    var eventInfo2 = raiser.GetType ().GetEvent (eventName2);
    eventInfo2.AddEventHandler (raiser, EventProxy.Create < int > (eventInfo2, handler.HandleEventWithArg));
    eventinfo.AddEventHandler (raiser, EventProxy.Create (eventinfo, () = > Console.WriteLine ("!")));
    eventInfo2.AddEventHandler (raiser, EventProxy.Create < int > (eventInfo2, i = > Console.WriteLine (i + "!")));
    raiser.RaiseEvents ();
}

static public Delegate Create < T > (EventInfo evt, Action < T > d) {
    var handlerType = evt.EventHandlerType;
    var eventParams = handlerType.GetMethod ("Invoke").GetParameters ();
    var parameters = eventParams.Select (p = > Expression.Parameter (p.ParameterType, "x")).ToArray ();
    var arg = getArgExpression (parameters [1], typeof (T));
    var body = Expression.Call (Expression.Constant (d), d.GetType ().GetMethod ("Invoke"), arg);
    var lambda = Expression.Lambda (body, parameters);
    return Delegate.CreateDelegate (handlerType, lambda.Compile (), "Invoke", false);
}

