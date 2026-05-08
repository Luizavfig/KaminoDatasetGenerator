/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:2503645
*  Stack Overflow answer #:2518196
*  And Stack Overflow answer#:2518196
*/
public static void Dispose (this TypeBuilder tb) {
    if (tb == null)
        return;
    Type tbType = typeof (TypeBuilder);
    FieldInfo tbMbList = tbType.GetField ("m_listMethods", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo tbDecType = tbType.GetField ("m_DeclaringType", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo tbGenType = tbType.GetField ("m_genTypeDef", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo tbDeclMeth = tbType.GetField ("m_declMeth", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo tbMbCurMeth = tbType.GetField ("m_currentMethod", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo tbMod = tbType.GetField ("m_module", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo tbGenTypeParArr = tbType.GetField ("m_inst", BindingFlags.Instance | BindingFlags.NonPublic);
    TypeBuilder tempDecType = tbDecType.GetValue (tb) as TypeBuilder;
    tempDecType.Dispose ();
    tbDecType.SetValue (tb, null);
    tempDecType = tbGenType.GetValue (tb) as TypeBuilder;
    tempDecType.Dispose ();
    tbDecType.SetValue (tb, null);
    MethodBuilder tempMeth = tbDeclMeth.GetValue (tb) as MethodBuilder;
    tempMeth.Dispose ();
    tbDeclMeth.SetValue (tb, null);
    tempMeth = tbMbCurMeth.GetValue (tb) as MethodBuilder;
    tempMeth.Dispose ();
    tbMbCurMeth.SetValue (tb, null);
    ArrayList mbList = tbMbList.GetValue (tb) as ArrayList;
    for (int i = 0; i < mbList.Count; i ++) {
        tempMeth = mbList [i] as MethodBuilder;
        tempMeth.Dispose ();
        mbList [i] = null;
    }
    tbMbList.SetValue (tb, null);
    ModuleBuilder tempMod = tbMod.GetValue (tb) as ModuleBuilder;
    tempMod.Dispose ();
    tbMod.SetValue (tb, null);
    tbGenTypeParArr.SetValue (tb, null);
}

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

