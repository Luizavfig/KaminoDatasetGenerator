/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:23160426
*  Stack Overflow answer #:23224544
*  And Stack Overflow answer#:23224544
*/
void IServiceBehavior.ApplyDispatchBehavior (ServiceDescription description, ServiceHostBase serviceHostBase) {
    IErrorHandler errorHandler;
    try {
        errorHandler = (IErrorHandler) Activator.CreateInstance (errorHandlerType);
    }
    catch (MissingMethodException e) {
        throw new ArgumentException ("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must have a public empty constructor.", e);
    }
    catch (InvalidCastException e) {
        throw new ArgumentException ("The errorHandlerType specified in the ErrorBehaviorAttribute constructor must implement System.ServiceModel.Dispatcher.IErrorHandler.", e);
    }
    foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers) {
        ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
        channelDispatcher.ErrorHandlers.Add (errorHandler);
    }
}

public void ProvideFault (Exception error, MessageVersion version, ref Message fault) {
    if (error is FaultException)
        return;
    error = MyExceptionHandler.HandleError (error);
    var serviceDebug = OperationContext.Current.EndpointDispatcher.ChannelDispatcher.IncludeExceptionDetailInFaults;
    BusinessRuleFaultExceptionType f = new BusinessRuleFaultExceptionType {Code = - 100, Reason = "xxx"};
    FaultException < BusinessRuleFaultExceptionType > faultException = new FaultException < BusinessRuleFaultExceptionType > (f, error.Message);
    MessageFault faultMessage = faultException.CreateMessageFault ();
    fault = Message.CreateMessage (version, faultMessage, faultException.Action);
}

