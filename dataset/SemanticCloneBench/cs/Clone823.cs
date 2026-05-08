/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:46356865
*  Stack Overflow answer #:46356932
*  And Stack Overflow answer#:46356943
*/
public ApiResponse < IEnumerable < Customers > > getCustomersById (string id) {
    var retVal = new ApiResponse < IEnumerable < Customers > > ();
    var isAuthenticated = tokenAuthorization.validateToken (access_token);
    if (! isAuthenticated) {
        retVal.Message = "You are not authrized";
        return retVal;
    }
    try {
        var data = yourList;
        retVal.IsSuccess = true;
        retVal.Data = yourList;
    }
    catch (exception ex) {
        retVal.Message = yourmessage;
    }
    return retVal;
}

public IEnumerable < Customers > getCustomersById (string id) {
    var isAuthenticated = tokenAuthorization.validateToken (access_token);
    if (isAuthenticated) {
        List < Customers > customers = new List < Customers > ();
        Customers customer = null;
        customer = new Customers ();
        customer.kunnr = id;
        customer.name = "John Doe";
        customers.Add (customer);
        return customers;
    } else {
        throw new TokenInvalidException ("Not a valid Access Token");
    }
}

