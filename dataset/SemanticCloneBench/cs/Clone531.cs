/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1096568
*  Stack Overflow answer #:28428894
*  And Stack Overflow answer#:28428894
*/
private void GatherTypesFrom (Type t) {
    EnsureType (t.BaseType);
    foreach (var intf in t.GetInterfaces ()) {
        EnsureType (intf);
    }
    foreach (var nested in t.GetNestedTypes ()) {
        EnsureType (nested);
    }
    var all = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
    foreach (var field in t.GetFields (all)) {
        EnsureType (field.FieldType);
    }
    foreach (var property in t.GetProperties (all)) {
        EnsureType (property.PropertyType);
    }
    foreach (var evt in t.GetEvents (all)) {
        EnsureType (evt.EventHandlerType);
    }
    foreach (var ctor in t.GetConstructors (all)) {
        foreach (var par in ctor.GetParameters ()) {
            EnsureType (par.ParameterType);
        }
        GatherTypesFrom (ctor);
    }
    foreach (var method in t.GetMethods (all)) {
        if (method.ReturnType != typeof (void)) {
            EnsureType (method.ReturnType);
        }
        foreach (var par in method.GetParameters ()) {
            EnsureType (par.ParameterType);
        }
        GatherTypesFrom (method);
    }
}

private void GatherTypesFrom (MethodBase method) {
    if (this.assemblies.Contains (method.DeclaringType.Assembly)) {
        MethodBody methodBody = method.GetMethodBody ();
        if (methodBody != null) {
            foreach (var local in methodBody.LocalVariables) {
                EnsureType (local.LocalType);
            }
            var il = methodBody.GetILAsByteArray ();
            if (il != null) {
                foreach (var oper in ILDecompiler.Decompile (method, il)) {
                    if (oper.Operand is MemberInfo) {
                        foreach (var type in HandleMember ((MemberInfo) oper.Operand)) {
                            EnsureType (type);
                        }
                    }
                }
            }
        }
    }
}

