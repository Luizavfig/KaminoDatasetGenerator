/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:25383780
*  Stack Overflow answer #:25419837
*  And Stack Overflow answer#:25384783
*/
[TestMethod] public void Should_Add_User () {
    var mockSet = new Mock < DbSet < User > > ();
    var mockContext = new Mock < DTContext > ();
    mockContext.Setup (m = > m.Users).Returns (mockSet.Object);
    var usrCRUD = new UserCRUD (mockContext.Object);
    var usr = new User ();
    usr.Login = "Login_Name";
    usr.Email = "loginName@test.com";
    usr.Password = "***";
    usr.InvalidLogins = 0;
    usr.RememberID = 0;
    usrCRUD.AddUser (usr);
    mockSet.Verify (m = > m.Add (It.Is < User > (arg = > arg.Login == "Login_Name")));
    mockContext.Verify (m = > m.SaveChanges (), Times.Once ());
}

public static void IncrementInvalidLoginColumn (string login) {
    User user;
    try {
        user = _context.Users.Where (u = > u.Login.CompareTo (login) == 0).FirstOrDefault ();
        if (user.InvalidLogins < 3) {
            user.InvalidLogins = user.InvalidLogins + 1;
        }
        _context.SaveChanges ();
    }
    catch {
    }
}

