/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4392193
*  Stack Overflow answer #:37978163
*  And Stack Overflow answer#:37978163
*/
[System.Security.Permissions.SecurityPermission (System.Security.Permissions.SecurityAction.Demand)] public override void Commit (IDictionary savedState) {
    base.Commit (savedState);
    string environmentVar = Environment.GetEnvironmentVariable ("PATH");
    string oldPath = (string) Registry.LocalMachine.CreateSubKey (environmentKey).GetValue ("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames);
    var index = oldPath.IndexOf (pathUrl);
    if (index < 0) {
        Registry.LocalMachine.CreateSubKey (environmentKey).SetValue ("Path", oldPath + ";" + pathUrl, RegistryValueKind.ExpandString);
    }
}

[System.Security.Permissions.SecurityPermission (System.Security.Permissions.SecurityAction.Demand)] public override void Uninstall (IDictionary savedState) {
    base.Uninstall (savedState);
    string oldPath = (string) Registry.LocalMachine.CreateSubKey (environmentKey).GetValue ("Path", "", RegistryValueOptions.DoNotExpandEnvironmentNames);
    string removeString = pathUrl + ";";
    var index = oldPath.IndexOf (removeString);
    if (index < 0) {
        removeString = pathUrl;
        index = oldPath.IndexOf (removeString);
    }
    if (index > - 1) {
        oldPath = oldPath.Remove (index, pathUrl.Length);
        Registry.LocalMachine.CreateSubKey (environmentKey).SetValue ("Path", oldPath, RegistryValueKind.ExpandString);
    }
}

