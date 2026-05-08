/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:27820197
*  Stack Overflow answer #:32072714
*  And Stack Overflow answer#:27841157
*/
public int RegisterMember (string memberName, string emailAddress, string memberPassword, string memberTypeAlias, string memberGroupName) {
    int umbracoMemberId = - 1;
    if (! MemberExists (emailAddress)) {
        IMember newMember = ApplicationContext.Current.Services.MemberService.CreateMember (emailAddress, emailAddress, memberName, memberTypeAlias);
        try {
            ApplicationContext.Current.Services.MemberService.Save (newMember);
            ApplicationContext.Current.Services.MemberService.SavePassword (newMember, memberPassword);
            ApplicationContext.Current.Services.MemberService.AssignRole (newMember.Id, memberGroupName);
            umbracoMemberId = newMember.Id;
        }
        catch (Exception ex) {
            throw new Exception ("Unable to create new member " + ex.Message);
        }
    }
    return umbracoMemberId;
}

public ActionResult SignUp (MemberModel model) {
    if (! ModelState.IsValid)
        return CurrentUmbracoPage ();
    var memberService = Services.MemberService;
    if (memberService.GetByEmail (model.Email) != null) {
        ModelState.AddModelError ("", "Member already exists");
        return CurrentUmbracoPage ();
    }
    var member = memberService.CreateMemberWithIdentity (model.Email, model.Email, model.Name, "MyMemberType");
    memberService.Save (member);
    memberService.SavePassword (member, model.Password);
    Members.Login (model.Email, model.Password);
    return Redirect ("/");
}

