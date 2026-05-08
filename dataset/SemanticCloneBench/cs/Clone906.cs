/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:16282838
*  Stack Overflow answer #:16283350
*  And Stack Overflow answer#:16283350
*/
public static Type CommonBaseClass (params Type [] types) {
    if (ReferenceEquals (types, null))
        return typeof (object);
    types = types.Where (x = > ! ReferenceEquals (x, null)).Distinct ().ToArray ();
    switch (types.Length) {
        case 0 :
            return typeof (object);
        case 1 :
            return types [0].IsInterface ? typeof (object) : types [0];
        default :
            IEnumerable < IEnumerable < Type > > hierarchies = types.Select (ClassHierarchy).OrderBy (x = > x.Count ());
            Queue < Type > smallest = new Queue < Type > (hierarchies.First ().Reverse ());
            hierarchies = hierarchies.Skip (1);
            do
                {
                    int maxPossible = smallest.Count;
                    hierarchies = hierarchies.Select (each = > each.Take (maxPossible));
                    Type candidate = smallest.Dequeue ();
                    if (hierarchies.All (each = > each.Last () == candidate))
                        return candidate;
                } while (smallest.Count > 1);
            return typeof (object);
    }
}

public static IEnumerable < Type > ClassHierarchy (this Type type) {
    if (type == null || type.IsInterface)
        type = typeof (object);
    var stack = new Stack < Type > ();
    do
        {
            stack.Push (type);
            type = type.BaseType;
        } while (type != null);
    return stack;
}

