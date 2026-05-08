/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:29528648
*  Stack Overflow answer #:29531372
*  And Stack Overflow answer#:49517832
*/
public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    var token = JToken.Load (reader);
    var typeToken = token ["Type"];
    if (typeToken == null)
        throw new InvalidOperationException ("invalid object");
    var actualType = SubTypeClassBase.GetType (typeToken.ToObject < SubType > (serializer));
    if (existingValue == null || existingValue.GetType () != actualType) {
        var contract = serializer.ContractResolver.ResolveContract (actualType);
        existingValue = contract.DefaultCreator ();
    }
    using (var subReader = token.CreateReader ())
    {
        serializer.Populate (subReader, existingValue);
    } return existingValue;
}

public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    JObject item = JObject.Load (reader);
    var type = item ["type"].Value < string > ();
    if (type == "SubClass1") {
        return item.ToObject < SubClass1 > ();
    } else if (type == "SubClass2") {
        return item.ToObject < SubClass2 > ();
    } else {
        return null;
    }
}

