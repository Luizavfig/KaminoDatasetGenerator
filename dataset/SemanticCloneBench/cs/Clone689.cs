/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6488034
*  Stack Overflow answer #:6488314
*  And Stack Overflow answer#:6586805
*/
public bool ApplyRules (List < Rule > rules, User user) {
    foreach (var rule in rules) {
        IComparable value = null;
        object limit = null;
        if (rule.objectProperty == "age") {
            value = user.age;
            limit = Convert.ToInt32 (rule.TargetValue);
        } else if (rule.objectProperty == "username") {
            value = user.username;
            limit = rule.TargetValue;
        } else
            throw new InvalidOperationException ("invalid property");
        int result = value.CompareTo (limit);
        if (rule.ComparisonOperator == "equal") {
            if (! (result == 0))
                return false;
        } else if (rule.ComparisonOperator == "greater_than") {
            if (! (result > 0))
                return false;
        } else
            throw new InvalidOperationException ("invalid operator");
    }
    return true;
}

private static void Compile (CodeDom.CodeDomProvider provider, string source) {
    var param = new CodeDom.CompilerParameters () {GenerateExecutable = false, IncludeDebugInformation = false, GenerateInMemory = true};
    var path = System.Reflection.Assembly.GetExecutingAssembly ().Location;
    var root_Dir = System.IO.Path.Combine (System.AppDomain.CurrentDomain.BaseDirectory, "Bin");
    param.ReferencedAssemblies.Add (path);
    var dependencies = new string [] {"yyyyyy.dll", "xxxxxx.dll", "NHibernate.dll", "ABC.Helper.Rules.dll"};
    foreach (var dependency in dependencies) {
        var assemblypath = System.IO.Path.Combine (root_Dir, dependency);
        param.ReferencedAssemblies.Add (assemblypath);
    }
    param.ReferencedAssemblies.Add (@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.dll");
    param.ReferencedAssemblies.Add (@"C:\Program Files\Reference Assemblies\Microsoft\Framework\v3.5\System.Core.dll");
    var compileResults = provider.CompileAssemblyFromSource (param, source);
    var output = compileResults.Output;
    if (compileResults.Errors.Count != 0) {
        CodeDom.CompilerErrorCollection es = compileResults.Errors;
        var edList = new List < DataRuleLoadExceptionDetails > ();
        foreach (CodeDom.CompilerError s in es)
            edList.Add (new DataRuleLoadExceptionDetails () {Message = s.ErrorText, LineNumber = s.Line});
        var rde = new RuleDefinitionException (source, edList.ToArray ());
        throw rde;
    }
}

