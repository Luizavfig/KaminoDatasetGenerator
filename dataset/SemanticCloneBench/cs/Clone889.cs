/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:36460089
*  Stack Overflow answer #:36460295
*  And Stack Overflow answer#:36460295
*/
public static int convertNum (String n1, String n2) {
    int num1 = 0;
    int num2 = 0;
    int result = 0;
    try {
        num1 = Int32.Parse (n1);
        num2 = Int32.Parse (n2);
        result = sum (num1, num2);
        return result;
    }
    catch (FormatException) {
        MessageBox.Show ("Input only numbers.");
        return result;
    }
}

private void btnSum_Click (object sender, RoutedEventArgs e) {
    String num1 = txtNum1.Text;
    String num2 = txtNum2.Text;
    if (validate (num1, num2) == false) {
        MessageBox.Show ("Empty fields");
    } else {
        var result = convertNum (num1, num2);
        MessageBox.Show ("The sum is: " + result);
    }
}

