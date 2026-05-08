/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30819153
*  Stack Overflow answer #:30830981
*  And Stack Overflow answer#:30830981
*/
public static void Main (string [] args) {
    var provider = new NativeApplicationClient (GoogleAuthenticationServer.Description);
    provider.ClientIdentifier = clientId;
    provider.ClientSecret = clientSecret;
    var auth = new OAuth2Authenticator < NativeApplicationClient > (provider, GetAuthorization);
    var service = new BigqueryService (auth);
    JobsResource j = service.Jobs;
    QueryRequest qr = new QueryRequest ();
    qr.Query = query;
    QueryResponse response = j.Query (qr, projectId).Fetch ();
    foreach (TableRow row in response.Rows) {
        List < string > list = new List < string > ();
        foreach (TableRow.FData field in row.F) {
            list.Add (field.V);
        }
        Console.WriteLine (String.Join ("\t", list));
    }
    Console.WriteLine ("\nPress enter to exit");
    Console.ReadLine ();
}

private static IAuthorizationState GetAuthorization (NativeApplicationClient arg) {
    IAuthorizationState state = new AuthorizationState (new [] {BigqueryService.Scopes.Bigquery.GetStringValue ()});
    state.Callback = new Uri (NativeApplicationClient.OutOfBandCallbackUrl);
    Uri authUri = arg.RequestUserAuthorization (state);
    Process.Start (authUri.ToString ());
    Console.Write ("  Authorization Code: ");
    string authCode = Console.ReadLine ();
    Console.WriteLine ();
    return arg.ProcessUserAuthorization (authCode, state);
}

