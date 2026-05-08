/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:33646022
*  Stack Overflow answer #:33646308
*  And Stack Overflow answer#:33646286
*/
static void Main (string [] args) {
    memberLocation student, teacher, manager;
    student = new memberLocation ();
    teacher = new memberLocation ();
    manager = new memberLocation ();
    String filePath = "data.txt";
    StreamReader sr = new StreamReader (filePath);
    String fileData = sr.ReadToEnd ();
    student.start = fileData.IndexOf ("[Student]");
    teacher.start = fileData.IndexOf ("[Teacher]");
    manager.start = fileData.IndexOf ("[Manager]");
    student.end = fileData.IndexOf (']', student.start + 9) - 9;
    teacher.end = fileData.IndexOf (']', teacher.start + 9) - 9;
    manager.end = fileData.IndexOf (']', manager.start + 9) - 9;
    String studentStr, teacherStr, managerStr;
    if (student.end > 0)
        studentStr = fileData.Substring (student.start, student.end - student.start);
    else
        studentStr = fileData.Substring (student.start);
    if (teacher.end > 0)
        teacherStr = fileData.Substring (teacher.start, teacher.end - teacher.start);
    else
        teacherStr = fileData.Substring (teacher.start);
    if (manager.end > 0)
        managerStr = fileData.Substring (manager.start, manager.end - manager.start);
    else
        managerStr = fileData.Substring (manager.start);
}

public static Profile readFile (string filename) {
    var profile = new Profile ();
    var properties = typeof (Profile).GetProperties ().ToDictionary (q = > q.Name, q = > q);
    using (StreamReader sr = new StreamReader (filename))
    {
        String mode = "";
        while (! sr.EndOfStream) {
            String line = sr.ReadLine ();
            if (line == "[Student]") {
                mode = "student";
            } else if (line == "[Teacher]") {
                mode = "teacher";
            } else if (! string.IsNullOrEmpty (line)) {
                var nameValues = line.Split (new char [] {'='}, 2);
                if (nameValues.Length < 2)
                    continue;
                var key = mode + nameValues [0];
                if (properties.ContainsKey (key)) {
                    var value = nameValues [1];
                    properties [key].SetValue (profile, value);
                }
            }
        }
    } return profile;
}

