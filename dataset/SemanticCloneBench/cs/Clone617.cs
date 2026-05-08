/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:11686690
*  Stack Overflow answer #:35448994
*  And Stack Overflow answer#:11686747
*/
public HttpResponseMessage CertificateUpload (employeeModel emp) {
    if (! ModelState.IsValid) {
        string errordetails = "";
        var errors = new List < string > ();
        foreach (var state in ModelState) {
            foreach (var error in state.Value.Errors) {
                string p = error.ErrorMessage;
                errordetails = errordetails + error.ErrorMessage;
            }
        }
        Dictionary < string, object > dict = new Dictionary < string, object > ();
        dict.Add ("error", errordetails);
        return Request.CreateResponse (HttpStatusCode.BadRequest, dict);
    } else {
    }
}

public HttpResponseMessage Post (Person person) {
    if (ModelState.IsValid) {
        PersonDB.Add (person);
        return Request.CreateResponse (HttpStatusCode.Created, person);
    } else {
        var errors = new List < string > ();
        foreach (var state in ModelState) {
            foreach (var error in state.Value.Errors) {
                errors.Add (error.ErrorMessage);
            }
        }
        return Request.CreateResponse (HttpStatusCode.Forbidden, errors);
    }
}

