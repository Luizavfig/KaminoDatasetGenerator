/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:317759
*  Stack Overflow answer #:6895916
*  And Stack Overflow answer#:4124031
*/
object IReflect.InvokeMember (string name, BindingFlags invokeAttr, Binder binder, object target, object [] args, ParameterModifier [] modifiers, System.Globalization.CultureInfo culture, string [] namedParameters) {
    try {
        if (name != "Item" && (invokeAttr & BindingFlags.GetProperty) == BindingFlags.GetProperty && args.Length > 0 && this.GetType ().GetProperty (name) != null) {
            object IndexedProperty = this.GetType ().InvokeMember (name, invokeAttr, binder, target, null, modifiers, culture, namedParameters);
            return IndexedProperty.GetType ().InvokeMember ("Item", invokeAttr, binder, IndexedProperty, args, modifiers, culture, namedParameters);
        }
        if (name != "Item" && (invokeAttr & BindingFlags.PutDispProperty) == BindingFlags.PutDispProperty && (args.Length == 2) && this.GetType ().GetProperty (name) != null) {
            BindingFlags invokeAttr2 = BindingFlags.GetProperty;
            object IndexedProperty = this.GetType ().InvokeMember (name, invokeAttr2, binder, target, null, modifiers, culture, namedParameters);
            return IndexedProperty.GetType ().InvokeMember ("Item", invokeAttr, binder, IndexedProperty, args, modifiers, culture, namedParameters);
        }
        return this.GetType ().InvokeMember (name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
    }
    catch (MissingMemberException ex) {
        const int DISP_E_MEMBERNOTFOUND = unchecked ((int) 0x80020003);
        throw new COMException (ex.Message, DISP_E_MEMBERNOTFOUND);
    }
}

object IReflect.InvokeMember (string name, BindingFlags invokeAttr, Binder binder, object target, object [] args, ParameterModifier [] modifiers, System.Globalization.CultureInfo culture, string [] namedParameters) {
    try {
        if (name != "Item" && (invokeAttr & BindingFlags.GetProperty) == BindingFlags.GetProperty && args.Length > 0 && this.GetType ().GetProperty (name) != null) {
            object IndexedProperty = this.GetType ().InvokeMember (name, invokeAttr, binder, target, null, modifiers, culture, namedParameters);
            return IndexedProperty.GetType ().InvokeMember ("Item", invokeAttr, binder, IndexedProperty, args, modifiers, culture, namedParameters);
        }
        return this.GetType ().InvokeMember (name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
    }
    catch (MissingMemberException ex) {
        const int DISP_E_MEMBERNOTFOUND = unchecked ((int) 0x80020003);
        throw new COMException (ex.Message, DISP_E_MEMBERNOTFOUND);
    }
}

