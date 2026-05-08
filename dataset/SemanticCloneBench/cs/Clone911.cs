/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16068887
*  Stack Overflow answer #:16069607
*  And Stack Overflow answer#:16087372
*/
static int Main (string [] args) {
    try {
        int testcase = (Int32.Parse (args [0]));
        RunTest (testcase);
    }
    catch (Exception x) {
        Console.WriteLine ("test failed: " + x.Message);
        return 1;
    }
    Console.WriteLine ("test passed.");
    return 0;
}

private void RunTestInCustomDomain (string methodName) {
    var testDll = @"..\..\..\UnitTests\bin\Debug\UnitTests.dll";
    Assert.IsTrue (File.Exists (testDll));
    var assemblyName = AssemblyName.GetAssemblyName (testDll).FullName;
    var domain = AppDomain.CreateDomain (methodName, null, new AppDomainSetup () {ApplicationBase = Path.GetDirectoryName (testDll)});
    var tests = domain.CreateInstanceAndUnwrap (assemblyName, typeof (UnitTest1).FullName) as UnitTest1;
    var type = tests.GetType ();
    var method = type.GetMethod (methodName);
    method.Invoke (tests, new object [] {});
    AppDomain.Unload (domain);
}

