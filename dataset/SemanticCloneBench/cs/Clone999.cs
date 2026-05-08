/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:450233
*  Stack Overflow answer #:28597288
*  And Stack Overflow answer#:11844293
*/
public static void Move < T > (this List < T > list, int oldIndex, int newIndex) {
    if ((oldIndex == newIndex) || (0 > oldIndex) || (oldIndex >= list.Count) || (0 > newIndex) || (newIndex >= list.Count))
        return;
    var i = 0;
    T tmp = list [oldIndex];
    if (oldIndex < newIndex) {
        for (i = oldIndex; i < newIndex; i ++) {
            list [i] = list [i + 1];
        }
    } else {
        for (i = oldIndex; i > newIndex; i --) {
            list [i] = list [i - 1];
        }
    }
    list [newIndex] = tmp;
}

public static void Move < T > (this List < T > list, Predicate < T > itemSelector, int newIndex) {
    Ensure.Argument.NotNull (list, "list");
    Ensure.Argument.NotNull (itemSelector, "itemSelector");
    Ensure.Argument.Is (newIndex >= 0, "New index must be greater than or equal to zero.");
    var currentIndex = list.FindIndex (itemSelector);
    Ensure.That < ArgumentException > (currentIndex >= 0, "No item was found that matches the specified selector.");
    var item = list [currentIndex];
    list.RemoveAt (currentIndex);
    list.Insert (newIndex, item);
}

