/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16820731
*  Stack Overflow answer #:16823932
*  And Stack Overflow answer#:16823932
*/
public override bool IsValid (DateTime value) {
    DateTime today = DateTime.Today;
    int age = today.Year - value.Year;
    if (value > today.AddYears (- age))
        age --;
    if (age < 18) {
        return false;
    }
    return true;
}

public override bool IsValid (string value) {
    string format = "dd/MM/yyyy HH:mm:ss";
    DateTime dt;
    if (DateTime.TryParseExact ((String) value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) {
        return IsValid (dt);
    } else {
        return false;
    }
}

