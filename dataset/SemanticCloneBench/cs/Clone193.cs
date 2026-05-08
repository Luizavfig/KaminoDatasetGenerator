/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:683073
*  Stack Overflow answer #:683081
*  And Stack Overflow answer#:683179
*/
private Update BuildMetaData (MetaData [] nvPairs) {
    Update update = new Update ();
    var ip = new List < InputProperty > ();
    foreach (var nvPair in nvPairs) {
        if (nvPair == null)
            break;
        var inputProp = new InputProperty {Name = "udf:" + nvPair.Name, Val = nvPair.Value};
        ip.Add (inputProp);
    }
    update.Items = ip.ToArray ();
    return update;
}

private Update BuildMetaData (MetaData [] nvPairs) {
    Update update = new Update ();
    InputProperty [] ip = new InputProperty [20];
    int i;
    for (i = 0; i < nvPairs.Length; i ++) {
        if (nvPairs [i] == null)
            break;
        ip [i] = new InputProperty ();
        ip [i].Name = "udf:" + nvPairs [i].Name;
        ip [i].Val = nvPairs [i].Value;
    }
    if (i < nvPairs.Length) {
        update.Items = new InputProperty [i];
        Array.Copy (ip, update.Items, i);
    } else {
        update.Items = ip;
    }
    return update;
}

