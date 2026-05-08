/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:47844124
*  Stack Overflow answer #:47847658
*  And Stack Overflow answer#:47844956
*/
static void Main (string [] args) {
    var list1 = new List < Property > {new Property {Name = "A"}, new Property {Name = "A"}, new Property {Name = "A"}, new Property {Name = "B"}};
    var list2 = new List < Property > {new Property {Name = "A"}, new Property {Name = "B"}, new Property {Name = "B"}};
    var result = list1.FullOuterJoin (list2, p1 = > p1.Name, p2 = > p2.Name, (p1, p2) = > new JoinedProperty {Name1 = p1, Name2 = p2}).ToList ();
    foreach (var res in result) {
        Console.WriteLine (res.ToString ());
    }
    Console.ReadLine ();
}

static void Main (string [] args) {
    var list1 = new List < Property > {new Property {Name = "A"}, new Property {Name = "A"}, new Property {Name = "A"}, new Property {Name = "B"}};
    var list2 = new List < Property > {new Property {Name = "A"}, new Property {Name = "B"}, new Property {Name = "B"}};
    var allLetters = list1.Union (list2).Distinct ().ToList ();
    var result = new List < JoinedProperty > ();
    foreach (var letter in allLetters) {
        var list1Count = list1.Count (l = > l.Name == letter.Name);
        var list2Count = list2.Count (l = > l.Name == letter.Name);
        var matchCount = Math.Min (list1Count, list2Count);
        addValuesToResult (result, letter, letter, matchCount);
        var difference = list1Count - list2Count;
        if (difference > 0) {
            addValuesToResult (result, letter, null, difference);
        } else {
            difference = difference * - 1;
            addValuesToResult (result, null, letter, difference);
        }
    }
    foreach (var res in result) {
        Console.WriteLine (res.ToString ());
    }
    Console.ReadLine ();
}

