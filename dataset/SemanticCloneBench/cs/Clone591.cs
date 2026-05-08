/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13271880
*  Stack Overflow answer #:13272469
*  And Stack Overflow answer#:13272817
*/
public static Dictionary < Header, Detail > Ungroup (Dictionary < Header, Detail > input) {
    var output = new Dictionary < Header, Detail > ();
    foreach (var key in input.Keys) {
        var lookup = input [key].Parts.ToLookup (part = > part);
        bool done = false;
        for (int i = 0; ! done; i ++) {
            var parts = lookup.GetNthValues (i).ToList ();
            if (parts.Any ()) {
                output.Add (new Header (key.Value), new Detail {Parts = parts});
            } else {
                done = true;
            }
        }
    }
    return output;
}

public static IEnumerable < KeyValuePair < Header, Detail > > UngroupParts (this IEnumerable < KeyValuePair < Header, Detail > > data) {
    foreach (var kvp in data) {
        Header header = kvp.Key;
        List < string > parts = kvp.Value.Parts.ToList ();
        do
            {
                List < string > distinctParts = parts.Distinct ().ToList ();
                Detail detail = new Detail () {Parts = distinctParts};
                yield return new KeyValuePair < Header, Detail > (header, detail);
                foreach (var part in distinctParts)
                    parts.Remove (part);
            } while (parts.Any ());
    }
}

