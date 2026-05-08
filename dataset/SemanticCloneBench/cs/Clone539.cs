/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2503645
*  Stack Overflow answer #:2518196
*  And Stack Overflow answer#:2518196
*/
public static void Dispose (this ILGenerator ilGen) {
    if (ilGen == null)
        return;
    Type ilGenType = typeof (ILGenerator);
    FieldInfo ilSigHelp = ilGenType.GetField ("m_localSignature", BindingFlags.Instance | BindingFlags.NonPublic);
    SignatureHelper sigTemp = ilSigHelp.GetValue (ilGen) as SignatureHelper;
    sigTemp.Dispose ();
    ilSigHelp.SetValue (ilGen, null);
}

public static void Dispose (this ModuleBuilder modBuild) {
    if (modBuild == null)
        return;
    Type modBuildType = typeof (ModuleBuilder);
    FieldInfo modBuildModData = modBuildType.GetField ("m__moduleData", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
    FieldInfo modTypeBuildList = modBuildType.GetField ("m__TypeBuilderList", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
    ArrayList modTypeList = modTypeBuildList.GetValue (modBuild) as ArrayList;
    if (modTypeList != null) {
        for (int i = 0; i < modTypeList.Count; i ++) {
            TypeBuilder tb = modTypeList [i] as TypeBuilder;
            tb.Dispose ();
            modTypeList = null;
        }
        modTypeBuildList.SetValue (modBuild, null);
    }
    modBuildModData.SetValue (modBuild, null);
}

