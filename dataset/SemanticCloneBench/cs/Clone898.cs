/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:37930700
*  Stack Overflow answer #:37931265
*  And Stack Overflow answer#:38067372
*/
public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    JObject obj = JObject.Load (reader);
    LinksResult result = new LinksResult ();
    result.Count = (int) obj ["count"];
    result.ErrorCode = (int) obj ["errorCode"];
    result.ErrorMessage = (string) obj ["errorMessage"];
    result.Links = new List < LinkData > ();
    for (int i = 1; i <= result.Count; i ++) {
        string index = i.ToString ();
        LinkData link = new LinkData ();
        link.LinkType = (string) obj ["LinkType" + index];
        link.LinkUrl = (string) obj ["LinkUrl" + index];
        link.LinkShow = (int) obj ["LinkShow" + index] == 1;
        result.Links.Add (link);
    }
    return result;
}

public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
    var obj = serializer.Deserialize < JObject > (reader);
    var page = new TPage ();
    serializer.Populate (obj.CreateReader (), page);
    page.PageItems = new List < TItem > ();
    for (int i = 1; i <= page.Count; i ++) {
        string index = i.ToString ();
        var jsonItem = new JObject ();
        foreach (var prop in obj.Properties ().Where (p = > _numberPostfixRegex.Match (p.Name).Value == index)) {
            jsonItem [_numberPostfixRegex.Replace (prop.Name, "")] = prop.Value;
        }
        TItem item = jsonItem.ToObject < TItem > (serializer);
        page.PageItems.Add (item);
    }
    return page;
}

