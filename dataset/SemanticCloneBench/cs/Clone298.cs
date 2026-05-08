/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:25125329
*  Stack Overflow answer #:34470202
*  And Stack Overflow answer#:28386319
*/
public ActionResult Index (int ? page) {
    int pagenumber = (page ?? 1) - 1;
    OrderManagement orderMan = new OrderManagement (HttpContext.ApplicationInstance.Context);
    int totalCount = 0;
    List < Order > orders = orderMan.GetOrderPage (pagenumber, 5, out totalCount);
    List < OrderViewModel > orderViews = new List < OrderViewModel > ();
    foreach (Order order in orders) {
        orderViews.Add (orderMan.GenerateOrderViewModel (order));
    }
    IPagedList < OrderViewModel > pageOrders = new StaticPagedList < OrderViewModel > (orderViews, pagenumber + 1, 5, totalCount);
    return View (pageOrders);
}

public ActionResult Index (int ? id, int ? courseID, int ? InstructorPage, int ? CoursePage, int ? EnrollmentPage) {
    int instructPageNumber = (InstructorPage ?? 1);
    int CoursePageNumber = (CoursePage ?? 1);
    int EnrollmentPageNumber = (EnrollmentPage ?? 1);
    var viewModel = new InstructorIndexData ();
    viewModel.Instructors = db.Instructors.Include (i = > i.OfficeAssignment).Include (i = > i.Courses.Select (c = > c.Department)).OrderBy (i = > i.LastName).ToPagedList (instructPageNumber, 5);
    if (id != null) {
        ViewBag.InstructorID = id.Value;
        viewModel.Courses = viewModel.Instructors.Where (i = > i.ID == id.Value).Single ().Courses.ToPagedList (CoursePageNumber, 5);
    }
    if (courseID != null) {
        ViewBag.CourseID = courseID.Value;
        viewModel.Enrollments = viewModel.Courses.Where (x = > x.CourseID == courseID).Single ().Enrollments.ToPagedList (EnrollmentPageNumber, 5);
    }
    return View (viewModel);
}

