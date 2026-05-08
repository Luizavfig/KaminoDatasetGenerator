/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:45798486
*  Stack Overflow answer #:47378309
*  And Stack Overflow answer#:45880146
*/
string ReturnType (Method objMethod) {
    if (objMethod.Type.Name == "IActionResult") {
        if ((objMethod.Parameters.Where (x = > ! x.Type.IsPrimitive).FirstOrDefault () != null)) {
            return objMethod.Parameters.Where (x = > ! x.Type.IsPrimitive).FirstOrDefault ().Name;
        } else {
            return "void";
        }
    } else {
        return objMethod.Type.Name;
    }
}

string ReturnType (Method m) {
    if (m.Type.Name == "IActionResult") {
        foreach (var a in m.Attributes) {
            if (a.name == "returnType") {
                string type = string.Empty;
                bool isArray = a.Value.Contains ("<");
                string formattedType = a.Value.Replace ("<", "").Replace ("><![CDATA[", "").Replace ("typeof(", "").Replace (")", "");
                string [] ar;
                ar = formattedType.Split ('.');
                type = ar [ar.Length - 1];
                if (isArray) {
                    type += "[]";
                }
                if (type == "bool") {
                    type = "boolean";
                }
                return type;
            }
        }
        return "void";
    }
    return m.Type.Name;
}

