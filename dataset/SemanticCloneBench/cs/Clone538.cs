/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2503645
*  Stack Overflow answer #:2518196
*  And Stack Overflow answer#:2518196
*/
public static void Dispose (this MethodBuilder mb) {
    if (mb == null)
        return;
    Type mbType = typeof (MethodBuilder);
    FieldInfo mbILGen = mbType.GetField ("m_ilGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo mbMod = mbType.GetField ("m_module", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo mbContType = mbType.GetField ("m_containingType", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo mbLocSigHelp = mbType.GetField ("m_localSignature", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo mbSigHelp = mbType.GetField ("m_signature", BindingFlags.Instance | BindingFlags.NonPublic);
    ILGenerator tempIlGen = mbILGen.GetValue (mb) as ILGenerator;
    tempIlGen.Dispose ();
    SignatureHelper tempmbSigHelp = mbLocSigHelp.GetValue (mb) as SignatureHelper;
    tempmbSigHelp.Dispose ();
    tempmbSigHelp = mbSigHelp.GetValue (mb) as SignatureHelper;
    tempmbSigHelp.Dispose ();
    ModuleBuilder tempMod = mbMod.GetValue (mb) as ModuleBuilder;
    tempMod.Dispose ();
    mbMod.SetValue (mb, null);
    mbILGen.SetValue (mb, null);
    mbContType.SetValue (mb, null);
    mbLocSigHelp.SetValue (mb, null);
    mbSigHelp.SetValue (mb, null);
    mbMod.SetValue (mb, null);
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

