/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:12169443
*  Stack Overflow answer #:21003143
*  And Stack Overflow answer#:23145792
*/
static String findFirstKeyByValue (Dictionary < string, string > Data_Array, String value) {
    if (Data_Array.ContainsValue (value)) {
        foreach (String key in Data_Array.Keys) {
            if (Data_Array [key].Equals (value))
                return key;
        }
    }
    return null;
}

public static string GetSpecialCookieKeyVal (string _CookieName, string _key) {
    Dictionary < string, string > dictCookie = JsonConvert.DeserializeObject < Dictionary < string, string > > (MyCookinator.Get (_CookieName));
    string value;
    if (dictCookie.TryGetValue (_key, out value)) {
        return value;
    } else {
        return "0";
    }
}

