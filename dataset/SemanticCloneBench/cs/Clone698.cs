/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:1952153
*  Stack Overflow answer #:18193038
*  And Stack Overflow answer#:38191082
*/
public IEnumerable < int [] > GetIntPermutations (int [] index, int offset, int len) {
    switch (len) {
        case 1 :
            yield return index;
            break;
        case 2 :
            yield return index;
            Swap (index, offset, offset + 1);
            yield return index;
            Swap (index, offset, offset + 1);
            break;
        default :
            foreach (var result in GetIntPermutations (index, offset + 1, len - 1)) {
                yield return result;
            }
            for (var i = 1; i < len; i ++) {
                Swap (index, offset, offset + i);
                foreach (var result in GetIntPermutations (index, offset + 1, len - 1)) {
                    yield return result;
                }
                Swap (index, offset, offset + i);
            }
            break;
    }
}

public static string [] FindPermutationsSet (string word) {
    if (word.Length == 2) {
        var c = word.ToCharArray ();
        var s = new string (new char [] {c [1], c [0]});
        return new string [] {word, s};
    }
    var result = new List < string > ();
    var subsetPermutations = (string []) FindPermutationsSet (word.Substring (1));
    var firstChar = word [0];
    foreach (var temp in subsetPermutations.Select (s = > firstChar.ToString () + s).Where (temp = > temp != null).Where (temp = > temp != null)) {
        result.Add (temp);
        var chars = temp.ToCharArray ();
        for (var i = 0; i < temp.Length - 1; i ++) {
            var t = chars [i];
            chars [i] = chars [i + 1];
            chars [i + 1] = t;
            var s2 = new string (chars);
            result.Add (s2);
        }
    }
    return result.ToArray ();
}

