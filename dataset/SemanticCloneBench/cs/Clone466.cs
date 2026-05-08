/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16463773
*  Stack Overflow answer #:17683133
*  And Stack Overflow answer#:25168857
*/
static void Main (string [] args) {
    Database.SetInitializer < MyContext > (new DropCreateDatabaseAlways < MyContext > ());
    using (var ctx = new MyContext ())
    {
        ctx.Database.Initialize (false);
        var parent = new MyEntity {Name = "Parent", Children = new List < MyEntity > ()};
        parent.Children.Add (new MyEntity {Name = "Child 1"});
        parent.Children.Add (new MyEntity {Name = "Child 2"});
        ctx.MyEntities.Add (parent);
        ctx.SaveChanges ();
    } using (var ctx = new MyContext ())
    {
        var parent = ctx.MyEntities.Include (e = > e.Children).FirstOrDefault ();
        foreach (var child in parent.Children.ToList ())
            ctx.MyEntities.Remove (child);
        ctx.MyEntities.Remove (parent);
        ctx.SaveChanges ();
    }}

static void Main (string [] args) {
    Database.SetInitializer < MyContext > (new DropCreateDatabaseAlways < MyContext > ());
    using (var ctx = new MyContext ())
    {
        ctx.Database.Initialize (false);
        ctx.MyEntities.Add (new TestObjectGraph ().RootEntity ());
        ctx.SaveChanges ();
    } using (var ctx = new MyContext ())
    {
        var parent = ctx.MyEntities.Include (e = > e.Children).FirstOrDefault ();
        var deleteme = parent.Children.First ();
        ctx.DeleteMyEntity (deleteme);
    } Console.WriteLine ("Completed....");
    Console.WriteLine ("Press any key to exit");
    Console.ReadKey ();
}

