/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:14712916
*  Stack Overflow answer #:14731454
*  And Stack Overflow answer#:20099636
*/
static public bool AddUserToGroup (string user, UserGroup group) {
    var name = new StringBuilder (512);
    var nameSize = (uint) name.Capacity;
    var refDomainName = new StringBuilder (512);
    var refDomainNameSize = (uint) refDomainName.Capacity;
    var sid = new IntPtr ();
    switch (group) {
        case UserGroup.PerformanceMonitorUsers :
            ConvertStringSidToSid ("S-1-5-32-558", out sid);
            break;
        case UserGroup.Administrators :
            ConvertStringSidToSid ("S-1-5-32-544", out sid);
            break;
    }
    SID_NAME_USE sidType;
    if (! LookupAccountSid (null, sid, name, ref nameSize, refDomainName, ref refDomainNameSize, out sidType))
        return false;
    LOCALGROUP_MEMBERS_INFO_3 info;
    info.Domain = user;
    var val = NetLocalGroupAddMembers (null, name.ToString (), 3, ref info, 1);
    return val.Equals (SUCCESS) || val.Equals (ERROR_MEMBER_IN_ALIAS);
}

private static void Main (string [] args) {
    var user = new System.Security.Principal.NTAccount (@"IIS APPPOOL\10e6c294-9836-44a9-af54-207385846ebf");
    var sid = user.Translate (typeof (System.Security.Principal.SecurityIdentifier));
    var ctx = new PrincipalContext (ContextType.Machine);
    var appPoolIdentityGroupPrincipal = GroupPrincipal.FindByIdentity (ctx, IdentityType.Sid, sid.Value);
    Console.WriteLine (appPoolIdentityGroupPrincipal.Name);
    Console.WriteLine (appPoolIdentityGroupPrincipal.DisplayName);
    GroupPrincipal targetGroupPrincipal = GroupPrincipal.FindByIdentity (ctx, "Performance Monitor Users");
    targetGroupPrincipal.Members.Add (appPoolIdentityGroupPrincipal);
    targetGroupPrincipal.Save ();
    Console.WriteLine ("DONE!");
    Console.ReadKey ();
}

