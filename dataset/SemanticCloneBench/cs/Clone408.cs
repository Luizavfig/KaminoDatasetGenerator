/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30171878
*  Stack Overflow answer #:30188950
*  And Stack Overflow answer#:30188071
*/
public static void Main (string [] args) {
    using (var db = new BloggingContext ())
    {
        for (int i = 0; i < 10; ++ i) {
            var blog = new Blog () {};
            db.Blogs.Add (blog);
            db.SaveChanges ();
        }
        for (int i = 0; i < 10; ++ i) {
            var fkBlog = GetBlog (db);
            var post = new Post () {};
            db.Posts.Add (post);
            db.SaveChanges ();
        }
    }}

public static void Main (string [] args) {
    using (var db = new BloggingContext ())
    {
        for (int i = 0; i < 10; ++ i) {
            var blog = new Blog () {Name = i.ToString (), Description = "Desc", Url = String.Format ("http://{0}", i)};
            db.Blogs.Add (blog);
            db.SaveChanges ();
        }
    } using (var db = new BloggingContext ())
    {
        for (int i = 0; i < 10; ++ i) {
            var fkBlog = GetBlog ();
            db.Context.Attach (fkBlog);
            var post = new Post () {Blog = fkBlog, Content = String.Format ("Blog Content {0}", i), Title = String.Format ("Blog Title {0}", i)};
            db.Posts.Add (post);
            db.SaveChanges ();
        }
    }}

