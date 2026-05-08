/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:5122737
*  Stack Overflow answer #:52959211
*  And Stack Overflow answer#:43968202
*/
public static void Main () {
    List < bool > mouseStates = new List < bool > {false, false, false, false, true, true, true, false, true, false, false, true};
    mouseStates.Zip (mouseStates.Skip (1), (oldMouseState, newMouseState) = > {
        if (oldMouseState) {
            if (newMouseState)
                return MouseEvent.Held;
            else
                return MouseEvent.Released;
        } else {
            if (newMouseState)
                return MouseEvent.Clicked;
            else
                return MouseEvent.NotPressed;
        }
    }).ToList ().ForEach (mouseEvent = > Console.WriteLine (mouseEvent));
}

static void Main (string [] args) {
    var letters = new string [] {"A", "B", "C", "D", "E"};
    var numbers = new int [] {1, 2, 3};
    var q = letters.Zip (numbers, (l, n) = > l + n.ToString ()).ToArray ();
    var qDef = ZipDefault (letters, numbers);
    Array.Resize (ref q, qDef.Count ());
    foreach (var s in q.Zip (qDef, (a, b) = > string.Format ("{0, 2} {1, 2}", a, b)))
        Console.WriteLine (s);
}

