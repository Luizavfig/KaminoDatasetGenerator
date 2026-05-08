/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3116606
*  Stack Overflow answer #:3116633
*  And Stack Overflow answer#:3116633
*/
private static void DetectCollisions (string file) {
    try {
        Assembly assembly = Assembly.LoadFrom (file);
        foreach (var method in FindExtensionMethods (assembly)) {
            DetectCollisions (method);
        }
    }
    catch (Exception e) {
        Console.WriteLine ("Error detecting collisions: {0}", e.Message);
    }
}

private static void DetectCollisions (MethodBase method) {
    Console.WriteLine ("  Testing {0}.{1}", method.DeclaringType.Name, method.Name);
    Type extendedType = method.GetParameters () [0].ParameterType;
    foreach (var type in GetTypeAndAncestors (extendedType).Distinct ()) {
        foreach (var collision in DetectCollidingMethods (method, type)) {
            Console.WriteLine ("    Possible collision in {0}: {1}", collision.DeclaringType.Name, collision);
        }
    }
}

