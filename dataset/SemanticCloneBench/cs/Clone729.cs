/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1784446
*  Stack Overflow answer #:1784555
*  And Stack Overflow answer#:1784555
*/
private static String [] SplitCodeArray (String codeToExecute) {
    List < String > items = new List < String > ();
    Int32 parenAndbracketCount = 0;
    String buffer = "";
    foreach (Char c in codeToExecute.ToCharArray ()) {
        if (c == '.') {
            if (buffer.Length > 0) {
                items.Add (buffer);
                buffer = "";
            }
            continue;
        } else if (c == '[') {
            parenAndbracketCount ++;
            if (buffer.Length > 0) {
                items.Add (buffer);
            }
            buffer = c.ToString ();
        } else if (c == ']' || c == ')') {
            parenAndbracketCount --;
            buffer += c;
            if (buffer.Length > 0) {
                items.Add (buffer);
                buffer = "";
            }
        } else if (Char.IsWhiteSpace (c) || Char.IsControl (c)) {
            if (parenAndbracketCount == 0) {
                continue;
            } else {
                buffer += c;
            }
        } else if (c == '(') {
            parenAndbracketCount ++;
            buffer += c;
        } else {
            buffer += c;
        }
    }
    if (buffer.Length > 0) {
        items.Add (buffer);
    }
    return items.ToArray ();
}

private static void ProcessArray (ReflectorResult result, String codeFragment, Boolean createIfNotExists) {
    Int32 failCount = 0;
    ArrayDefinition arrayDefinition = GetArrayDefinition (result.Value, codeFragment);
    if (arrayDefinition != null) {
        PropertyInfo propertyInfo = arrayDefinition.RetrieveMemberInfo as PropertyInfo;
        if (propertyInfo != null) {
            SetPropertyInfoValue : try {
                object value = propertyInfo.GetValue (result.Value, arrayDefinition.Parameters);
                result.SetResult (value, propertyInfo, arrayDefinition.Parameters);
            }
            catch (TargetInvocationException ex) {
                failCount ++;
                if (ex.InnerException is ArgumentOutOfRangeException && failCount == 1 && createIfNotExists) {
                    if (CreateArrayItem (result, arrayDefinition)) {
                        goto SetPropertyInfoValue;
                    }
                }
                result.Clear ();
                throw new InvalidCodeFragmentException (codeFragment);
            }
        } else {
            MethodInfo methodInfo = arrayDefinition.RetrieveMemberInfo as MethodInfo;
            if (methodInfo != null) {
                try {
                    object value = methodInfo.Invoke (result.Value, arrayDefinition.Parameters);
                    result.SetResult (value, methodInfo, arrayDefinition.Parameters);
                }
                catch (TargetInvocationException) {
                    result.Clear ();
                    throw new InvalidCodeFragmentException (codeFragment);
                }
            }
        }
    } else {
        result.Clear ();
        throw new InvalidCodeFragmentException (codeFragment);
    }
}

