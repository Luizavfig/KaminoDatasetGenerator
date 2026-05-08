/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:760088
*  Stack Overflow answer #:760475
*  And Stack Overflow answer#:760475
*/
private static void Compile () {
    if (_assembly == null) {
        StringBuilder src = new StringBuilder (CodeStart);
        foreach (KeyValuePair < string, string > kvp in _conditionSnippet)
            src.AppendFormat (ConditionTemplate, DynamicConditionPrefix, kvp.Key, kvp.Value);
        foreach (KeyValuePair < string, string > kvp in _methodSnippet)
            src.AppendFormat (MethodTemplate, kvp.Key, kvp.Value);
        src.Append (CodeEnd);
        Trace.TraceError ("SOURCE\r\n{0}", src);
        _assembly = Compile (src.ToString ());
    }
}

private static Assembly Compile (string sourceCode) {
    CompilerParameters cp = new CompilerParameters ();
    cp.ReferencedAssemblies.AddRange (_references.ToArray ());
    cp.ReferencedAssemblies.Add (Assembly.GetExecutingAssembly ().ManifestModule.FullyQualifiedName);
    cp.CompilerOptions = "/target:library /optimize";
    cp.GenerateExecutable = false;
    cp.GenerateInMemory = true;
    CompilerResults cr = (new CSharpCodeProvider ()).CompileAssemblyFromSource (cp, sourceCode);
    if (cr.Errors.Count > 0)
        throw new CompilerException (cr.Errors);
    return cr.CompiledAssembly;
}

