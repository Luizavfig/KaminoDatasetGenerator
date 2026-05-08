/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:174664
*  Stack Overflow answer #:176336
*  And Stack Overflow answer#:176336
*/
public override decimal Evaluate () {
    decimal result = decimal.Zero;
    switch (op) {
        case "+" :
            result = lhs.Evaluate () + rhs.Evaluate ();
            break;
        case "-" :
            result = lhs.Evaluate () - rhs.Evaluate ();
            break;
        case "*" :
            result = lhs.Evaluate () * rhs.Evaluate ();
            break;
        case "/" :
            result = lhs.Evaluate () / rhs.Evaluate ();
            break;
        case "%" :
            result = lhs.Evaluate () % rhs.Evaluate ();
            break;
        case "^" :
            double x = Convert.ToDouble (lhs.Evaluate ());
            double y = Convert.ToDouble (rhs.Evaluate ());
            result = Convert.ToDecimal (Math.Pow (x, y));
            break;
        case "!" :
            result = Factorial (lhs.Evaluate ());
            break;
    }
    return result;
}

public decimal Evaluate (string text) {
    decimal result = decimal.Zero;
    equation = text;
    EvalNode parsed;
    equation = equation.Replace (" ", "");
    parsed = Parse (equation, "qx");
    if (parsed != null)
        result = parsed.Evaluate ();
    return result;
}

