/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:44260594
*  Stack Overflow answer #:44260634
*  And Stack Overflow answer#:44260735
*/
private long GetStakeholderId () {
    string currentUserId = _userManager.GetUserId (User);
    long stakeholderId;
    var users = _userManager.Users;
    foreach (var user in users) {
        if (user.Email == currentUserId) {
            var idForStakeholder = user.Id;
            var stakeholders = _context.Stakeholders;
            foreach (var stakeholder in stakeholders) {
                if (stakeholder.IdentityId == idForStakeholder) {
                    stakeholderId = stakeholder.StakeholderId;
                    return stakeholderId;
                } else {
                    return 0;
                }
            }
        }
    }
    return 0;
}

private long GetStakeholderId () {
    string currentUserId = _userManager.GetUserId (User);
    long stakeholderId;
    var user = _userManager.Users.Where (u = > u.Email == currentUserId).FirstOrDefault ();
    if (user == null) {
        return 0;
    }
    var stakeholder = _context.Stakeholders.Where (s = > s.StakeholderId == user.IdentityId).FirstOrDefault ();
    return stakeholder == null ? 0 : stakeholder.StakeholderId;
}

