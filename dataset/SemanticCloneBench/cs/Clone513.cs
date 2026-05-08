/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3578648
*  Stack Overflow answer #:3578759
*  And Stack Overflow answer#:3578759
*/
public static Person CreatePerson (Type type) {
    if (type == typeof (Person))
        return CreatePerson ();
    else if (type == typeof (Employee))
        return CreateEmployee ();
    else if (type == typeof (Pilot))
        return CreatePilot ();
    else
        throw new ArgumentOutOfRangeException (string.Format (CultureInfo.InvariantCulture, "Unrecognized type [{0}]", type.FullName), "type");
}

public static Person CreatePerson (string typeOfPerson) {
    switch (typeOfPerson) {
        case "Employee" :
            return CreateEmployee ();
        case "Pilot" :
            return CreatePilot ();
        default :
            return CreateEmployee ();
    }
}

