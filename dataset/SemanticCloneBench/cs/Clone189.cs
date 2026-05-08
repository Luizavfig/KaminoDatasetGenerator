/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:30959835
*  Stack Overflow answer #:30959962
*  And Stack Overflow answer#:30959997
*/
public ActionResult Index (string searchBy, string orderBy, string orderDir) {
    var query = fca.GetResultsByFilter (searchBy);
    if (orderBy == "Campus") {
        query = (orderDir == "Asc") ? query.OrderBy (s = > s.Campus).ThenBy (s = > s.Student_Name) : query.OrderByDescending (s = > s.Campus);
    } else if (orderBy == "Student Name") {
        query = (orderDir == "Asc") ? query.OrderBy (s = > s.Student_Name) : query.OrderByDescending (s = > s.Student_Name);
    } else if (orderBy == "Course Count") {
        query = (orderDir == "Asc") ? query.OrderBy (s = > s.Student_Name) : query.OrderByDescending (s = > s.Course_Count);
    }
}

public ActionResult Index (string searchBy, string orderBy, string orderDir) {
    var query = fca.GetResultsByFilter (searchBy);
    switch (orderBy) {
        case "Campus" :
            query = query.OrderByWithDirection (s = > s.Campus, orderDir);
            break;
        case "Student Name" :
            query = query.OrderByWithDirection (s = > s.Student_Name, orderDir);
            break;
        case "Course Count" :
            query = query.OrderByWithDirection (s = > s.Course_Count, orderDir);
            break;
    }
    if (orderBy == "Campus" && orderDir == "Asc") {
        query = query.ThenBy (s = > s.Student_Name);
    }
}

