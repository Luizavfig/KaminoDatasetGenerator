/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15745007
*  Stack Overflow answer #:15745054
*  And Stack Overflow answer#:15745121
*/
private static void GetUserData (string userName, UserSession user) {
    using (Entities ctx = CommonSERT.GetContext ())
    {
        var result = (from ur in ctx.datUserRoles
            where ur.AccountName.Equals (userName, StringComparison.CurrentCultureIgnoreCase)
            select new {Active = ur.active, ID = ur.ID,}).FirstOrDefault ();
        if (result != null)
            user.UserActive = result.Active;
        user.UserID = result.ID;
    }}

private static void GetUserData (string userName, UserSession userSession) {
    using (Entities ctx = CommonSERT.GetContext ())
    {
        var result = (from ur in ctx.datUserRoles
            where ur.AccountName.Equals (userName, StringComparison.CurrentCultureIgnoreCase)
            select new {UserActive = ur.active, UserROB = ur.ROB, UserID = ur.ID}).FirstOrDefault ();
    } if (result != null) {
        userSession.UserActive = result.UserActive;
        userSession.UserROB = result.UserROB;
        userSession.UserID = result.UserID;
    }
}

