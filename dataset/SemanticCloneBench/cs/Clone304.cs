/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:38093972
*  Stack Overflow answer #:44425580
*  And Stack Overflow answer#:46363980
*/
public static void RedirectAssembly (BindingRedirect bindingRedirect) {
    ResolveEventHandler handler = null;
    handler = (sender, args) = > {
        var requestedAssembly = new AssemblyName (args.Name);
        if (requestedAssembly.Name != bindingRedirect.ShortName) {
            return null;
        }
        var targetPublicKeyToken = new AssemblyName ("x, PublicKeyToken=" + bindingRedirect.PublicKeyToken).GetPublicKeyToken ();
        requestedAssembly.Version = new Version (bindingRedirect.RedirectToVersion);
        requestedAssembly.SetPublicKeyToken (targetPublicKeyToken);
        requestedAssembly.CultureInfo = CultureInfo.InvariantCulture;
        AppDomain.CurrentDomain.AssemblyResolve -= handler;
        return Assembly.Load (requestedAssembly);
    };
    AppDomain.CurrentDomain.AssemblyResolve += handler;
}

public static void RedirectAssembly () {
    var list = AppDomain.CurrentDomain.GetAssemblies ().Select (a = > a.GetName ()).OrderByDescending (a = > a.Name).ThenByDescending (a = > a.Version).Select (a = > a.FullName).ToList ();
    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) = > {
        var requestedAssembly = new AssemblyName (args.Name);
        foreach (string asmName in list) {
            if (asmName.StartsWith (requestedAssembly.Name + ",")) {
                return Assembly.Load (asmName);
            }
        }
        return null;
    };
}

