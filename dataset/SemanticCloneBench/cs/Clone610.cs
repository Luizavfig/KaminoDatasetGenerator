/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:678178
*  Stack Overflow answer #:678228
*  And Stack Overflow answer#:31819426
*/
public static T [,] To2dArray (this List < List < T > > list) {
    if (list.Count == 0 || list [0].Count == 0)
        throw new ArgumentException ("The list must have non-zero dimensions.");
    var result = new T [list.Count, list [0].Count];
    for (int i = 0; i < list.Count; i ++) {
        for (int j = 0; j < list [i].Count; j ++) {
            if (list [i].Count != list [0].Count)
                throw new InvalidOperationException ("The list cannot contain elements (lists) of different sizes.");
            result [i, j] = list [i] [j];
        }
    }
    return result;
}

public static T [,] To2DArray < T > (this List < List < T > > lst) {
    if ((lst == null) || (lst.Any (subList = > subList.Any () == false)))
        throw new ArgumentException ("Input list is not properly formatted with valid data");
    int index = 0;
    int subindex;
    return lst.Aggregate (new T [lst.Count (), lst.Max (sub = > sub.Count ())], (array, subList) = > {
        subindex = 0;
        subList.ForEach (itm = > array [index, subindex ++] = itm);
        ++ index;
        return array;
    });
}

