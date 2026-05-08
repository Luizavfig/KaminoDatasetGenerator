/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1933126
*  Stack Overflow answer #:1933371
*  And Stack Overflow answer#:1934609
*/
static void Main () {
    using (var invoker = new RunspaceInvoke ())
    {
        string command = @"Get-WmiObject -list -namespace root\cimv2" + " | Foreach {$_.Name}";
        Collection < PSObject > results = invoker.Invoke (command);
        var classNames = results.Select (ps = > (string) ps.BaseObject);
        foreach (var name in classNames) {
            Console.WriteLine (name);
        }
    }}

static void Main (string [] args) {
    var script = @" 
                Get-WmiObject -list -namespace root\cimv2 | Foreach {$_.Name}
            ";
    var powerShell = PowerShell.Create ();
    powerShell.AddScript (script);
    foreach (var className in powerShell.Invoke ()) {
        Console.WriteLine (className);
    }
}

