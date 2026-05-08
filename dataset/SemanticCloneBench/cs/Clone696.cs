/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13773339
*  Stack Overflow answer #:13775880
*  And Stack Overflow answer#:13775562
*/
static IEnumerable < Category > GetById (IEnumerable < Category > categories, string id) {
    if (categories == null || ! categories.Any ())
        yield break;
    Category result = categories.FirstOrDefault (c = > c.Id == id);
    if (result != null) {
        yield return result;
        yield break;
    }
    foreach (var category in categories) {
        var subCategories = GetById (category.Categories, id);
        if (subCategories.Any ()) {
            yield return category;
            foreach (var subCategory in subCategories)
                yield return subCategory;
            yield break;
        }
    }
}

public static IEnumerable < Category > Flatten (this Category category) {
    if (category.Categories != null) {
        foreach (var sub in category.Categories) {
            foreach (var subSub in sub.Flatten ())
                yield return subSub;
        }
    }
    yield return category;
}

