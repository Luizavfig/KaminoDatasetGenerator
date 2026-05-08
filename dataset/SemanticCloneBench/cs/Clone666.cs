/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:42644595
*  Stack Overflow answer #:42644912
*  And Stack Overflow answer#:42644912
*/
public void InputGrade () {
    int grade;
    string input;
    Console.WriteLine ("{0}\n{1}", "Enter the integer grades in the range 0-100", "Type <Ctrl> z and press Enter to terminate input:");
    counter ++;
    System.Console.Write ("score " + counter + ":");
    input = Console.ReadLine ();
    while (input != null) {
        grade = Convert.ToInt32 (input);
        total += grade;
        gradeCounter ++;
        IncrementLetterGradeCounter (grade);
        counter ++;
        System.Console.Write ("score " + counter + ":");
        input = Console.ReadLine ();
    }
}

private void IncrementLetterGradeCounter (int grade) {
    switch (grade / 10) {
        case 9 : case 10 :
            ++ aCount;
            break;
        case 8 :
            ++ bCount;
            break;
            case7 : ++ cCount;
            case6 : ++ dCount;
            break;
        default :
            ++ fCount;
            break;
    }
}

