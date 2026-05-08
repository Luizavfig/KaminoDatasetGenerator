/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1132702
*  Stack Overflow answer #:6479119
*  And Stack Overflow answer#:6479119
*/
private static AssemblyName GetAssemblyName (string source, bool isFile) {
    AssemblyName asmName = null;
    try {
        if (isFile)
            asmName = GetAssemblyNameFromFile (source);
        else
            asmName = GetAssemblyNameFromQualifiedName (source);
    }
    catch (Exception err) {
        string ErrorFormatString = "Invalid Call to utility method 'GetAssemblyNameOrThrowException'\n" + "Arguments passed in:\n" + "=> Source:\n[{0}]\n" + "=> isFile = {1}\n" + "See inner exception(s) for more detail.";
        throw new InvalidOperationException (string.Format (ErrorFormatString, source, isFile), err);
    }
    if (asmName == null)
        throw new InvalidOperationException (asmName.Name + " Assembly Name object is null, but no other error was encountered!");
    return asmName;
}

public static Delegate Create (RuntimeDelegate link, Object linkObject) {
    AssemblyName ObjectAssemblyName = null;
    AssemblyName DelegateAssemblyName = null;
    Assembly ObjectAssembly = null;
    Assembly DelegateAssembly = null;
    Type ObjectType = null;
    Type DelegateType = null;
    MethodInfo TargetMethodInformation = null;
    ObjectAssemblyName = GetAssemblyName (link.ObjectSource);
    DelegateAssemblyName = GetAssemblyName (link.DelegateSource);
    ObjectAssembly = LoadAssembly (ObjectAssemblyName);
    DelegateAssembly = LoadAssembly (DelegateAssemblyName);
    ObjectType = GetTypeFromAssembly (link.ObjectFullName, ObjectAssembly);
    DelegateType = GetTypeFromAssembly (link.DelegateFullName, DelegateAssembly);
    TargetMethodInformation = ObjectType.GetMethod (link.ObjectMethodName, link.SuggestedBinding);
    return CreateDelegateFrom (linkObject, ObjectType, DelegateType, TargetMethodInformation);
}

