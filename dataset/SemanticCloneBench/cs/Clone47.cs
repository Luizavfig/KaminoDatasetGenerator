/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5999177
*  Stack Overflow answer #:6006100
*  And Stack Overflow answer#:47744757
*/
private static void OneTimeSetup () {
    Type stackFrameHelperType = typeof (object).Assembly.GetType ("System.Diagnostics.StackFrameHelper");
    MethodInfo getStackFramesInternal = Type.GetType ("System.Diagnostics.StackTrace, mscorlib").GetMethod ("GetStackFramesInternal", BindingFlags.Static | BindingFlags.NonPublic);
    DynamicMethod dynamicMethod = new DynamicMethod ("GetStackFrameHelper", typeof (object), new Type [0], typeof (StackTrace), true);
    ILGenerator generator = dynamicMethod.GetILGenerator ();
    generator.DeclareLocal (stackFrameHelperType);
    generator.Emit (OpCodes.Ldc_I4_0);
    generator.Emit (OpCodes.Ldnull);
    generator.Emit (OpCodes.Newobj, stackFrameHelperType.GetConstructor (new Type [] {typeof (bool), typeof (Thread)}));
    generator.Emit (OpCodes.Stloc_0);
    generator.Emit (OpCodes.Ldloc_0);
    generator.Emit (OpCodes.Ldc_I4_0);
    generator.Emit (OpCodes.Ldnull);
    generator.Emit (OpCodes.Call, getStackFramesInternal);
    generator.Emit (OpCodes.Ldloc_0);
    generator.Emit (OpCodes.Ret);
    _getStackFrameHelper = (DGetStackFrameHelper) dynamicMethod.CreateDelegate (typeof (DGetStackFrameHelper));
    _frameCount = stackFrameHelperType.GetField ("iFrameCount", BindingFlags.NonPublic | BindingFlags.Instance);
}

private static void OneTimeSetup () {
    try {
        Type stackFrameHelperType = typeof (object).Assembly.GetType ("System.Diagnostics.StackFrameHelper");
        MethodInfo getStackFramesInternal = Type.GetType ("System.Diagnostics.StackTrace, mscorlib").GetMethod ("GetStackFramesInternal", BindingFlags.Static | BindingFlags.NonPublic);
        if (getStackFramesInternal == null)
            return;
        DynamicMethod dynamicMethod = new DynamicMethod ("GetStackFrameHelper", typeof (object), new Type [0], typeof (StackTrace), true);
        ILGenerator generator = dynamicMethod.GetILGenerator ();
        generator.DeclareLocal (stackFrameHelperType);
        bool newDotNet = false;
        ConstructorInfo constructorInfo = stackFrameHelperType.GetConstructor (new Type [] {typeof (bool), typeof (Thread)});
        if (constructorInfo != null)
            generator.Emit (OpCodes.Ldc_I4_0);
        else {
            constructorInfo = stackFrameHelperType.GetConstructor (new Type [] {typeof (Thread)});
            if (constructorInfo == null)
                return;
            newDotNet = true;
        }
        generator.Emit (OpCodes.Ldnull);
        generator.Emit (OpCodes.Newobj, constructorInfo);
        generator.Emit (OpCodes.Stloc_0);
        generator.Emit (OpCodes.Ldloc_0);
        generator.Emit (OpCodes.Ldc_I4_0);
        if (newDotNet)
            generator.Emit (OpCodes.Ldc_I4_0);
        generator.Emit (OpCodes.Ldnull);
        generator.Emit (OpCodes.Call, getStackFramesInternal);
        generator.Emit (OpCodes.Ldloc_0);
        generator.Emit (OpCodes.Ret);
        _getStackFrameHelper = (DGetStackFrameHelper) dynamicMethod.CreateDelegate (typeof (DGetStackFrameHelper));
        _frameCount = stackFrameHelperType.GetField ("iFrameCount", BindingFlags.NonPublic | BindingFlags.Instance);
    }
    catch {
    }
}

