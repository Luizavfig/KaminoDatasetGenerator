/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:8854137
*  Stack Overflow answer #:8857455
*  And Stack Overflow answer#:16977816
*/
public object AfterReceiveRequest (ref Message request, IClientChannel channel, InstanceContext instanceContext) {
    try {
        Guid tokenId = request.Headers.GetHeader < Guid > ("Token", "System");
        Console.WriteLine ("Token: {0}", tokenId);
    }
    catch (Exception e) {
        Console.WriteLine ("{0}: {1}", e.GetType ().FullName, e.Message);
    }
    return null;
}

public object AfterReceiveRequest (ref Message request, IClientChannel channel, InstanceContext instanceContext) {
    var i = request.Headers.FindHeader (TOKEN_HEADER_NAME, TOKEN_HEADER_NAMESPACE);
    string token;
    if (i >= 0) {
        token = request.Headers.GetHeader < string > (i);
    } else {
        token = Guid.NewGuid ().ToString ();
        request.Headers.Add (MessageHeader.CreateHeader (TOKEN_HEADER_NAME, TOKEN_HEADER_NAMESPACE, token));
    }
    return token;
}

