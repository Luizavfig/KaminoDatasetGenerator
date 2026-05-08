/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:7974205
*  Stack Overflow answer #:9026385
*  And Stack Overflow answer#:7998564
*/
protected override HttpRequestMessage OnHandle (TResource model, HttpRequestMessage requestMessage) {
    var results = new List < ValidationResult > ();
    var context = new ValidationContext (model, null, null);
    Validator.TryValidateObject (model, context, results, true);
    if (results.Count == 0) {
        return requestMessage;
    }
    var errorMessages = results.Select (x = > x.ErrorMessage).ToArray ();
    var mediaType = requestMessage.Headers.Accept.FirstOrDefault ();
    var response = new RestValidationFailure (errorMessages);
    if (mediaType != null) {
        response.Content = new ObjectContent (typeof (string []), errorMessages, mediaType);
    }
    throw new HttpResponseException (response);
}

protected override object [] OnHandle (object [] input) {
    var model = input [0];
    var validationResults = new List < ValidationResult > ();
    var context = new ValidationContext (model, null, null);
    Validator.TryValidateObject (model, context, validationResults, true);
    if (validationResults.Count == 0) {
        return input;
    } else {
        var response = new HttpResponseMessage () {Content = new StringContent ("Model Error"), StatusCode = HttpStatusCode.BadRequest};
        throw new HttpResponseException (response);
    }
}

