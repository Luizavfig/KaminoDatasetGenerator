/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:624466
*  Stack Overflow answer #:6229373
*  And Stack Overflow answer#:6229373
*/
public void Add (Type type) {
    if (! type.IsVisible) {
        return;
    }
    var members = type.GetMembers (BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
    foreach (var member in members) {
        Add (type, member);
    }
}

private void Add (Type type, MemberInfo member) {
    Type nestedType = null;
    sb.Length = 0;
    switch (member.MemberType) {
        case MemberTypes.Constructor :
            sb.Append ("M:");
            AppendConstructor (sb, (ConstructorInfo) member);
            break;
        case MemberTypes.Event :
            sb.Append ("E:");
            AppendEvent (sb, (EventInfo) member);
            break;
        case MemberTypes.Field :
            sb.Append ("F:");
            AppendField (sb, (FieldInfo) member);
            break;
        case MemberTypes.Method :
            sb.Append ("M:");
            AppendMethod (sb, (MethodInfo) member);
            break;
        case MemberTypes.NestedType :
            nestedType = (Type) member;
            if (IsVisible (nestedType)) {
                sb.Append ("T:");
                AppendNestedType (sb, (Type) member);
            }
            break;
        case MemberTypes.Property :
            sb.Append ("P:");
            AppendProperty (sb, (PropertyInfo) member);
            break;
    }
    if (sb.Length > 0) {
        stringSet.Add (sb.ToString ());
    }
    if (nestedType != null) {
        Add (nestedType);
    }
}

