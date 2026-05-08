/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:47045964
*  Stack Overflow answer #:47046191
*  And Stack Overflow answer#:47046034
*/
private static void RecurseDeserialize (Dictionary < string, object > result) {
    foreach (var keyValuePair in result.ToArray ()) {
        var jarray = keyValuePair.Value as JArray;
        if (jarray != null) {
            var dictionaries = JsonConvert.DeserializeObject < List < Dictionary < string, object > > > (jarray.ToString ());
            result [keyValuePair.Key] = dictionaries;
            foreach (var dictionary in dictionaries) {
                RecurseDeserialize (dictionary);
            }
        }
    }
}

Dictionary < string, object > RecursiveDeserialize (string json) {
    var result = JsonConvert.DeserializeObject < Dictionary < string, object > > (json);
    foreach (var pair in result.ToArray ()) {
        if (IsJson (pair.Value)) {
            result [pair.Key] = RecursiveDeserialize (pair.Value);
        }
    }
    return result;
}

