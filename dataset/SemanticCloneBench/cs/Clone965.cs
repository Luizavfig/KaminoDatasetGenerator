/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1675864
*  Stack Overflow answer #:14711227
*  And Stack Overflow answer#:15623974
*/
public string Read (string KeyName) {
    RegistryKey rk = baseRegistryKey;
    RegistryKey sk1 = rk.OpenSubKey (subKey);
    if (sk1 == null) {
        return null;
    } else {
        try {
            return (string) sk1.GetValue (KeyName.ToUpper ());
        }
        catch (Exception e) {
            ShowErrorMessage (e, "Reading registry " + KeyName.ToUpper ());
            return null;
        }
    }
}

static void Main () {
    const string dotNetFourPath = "Software\\Microsoft";
    using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey (dotNetFourPath))
    {
        Console.WriteLine (registryKey.SubKeyCount);
        foreach (var VARIABLE in registryKey.GetSubKeyNames ()) {
            Console.WriteLine (VARIABLE);
        }
    }}

