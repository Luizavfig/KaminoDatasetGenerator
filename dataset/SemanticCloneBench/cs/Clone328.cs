/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:15832646
*  Stack Overflow answer #:15833421
*  And Stack Overflow answer#:15833341
*/
private static void getDiscount (int [] items, int [] discount, ref int itemsbought, ref int discountItem) {
    for (int i = 0; itemsbought > items [i];) {
        discountItem = discount [i];
        i ++;
        if (i >= items.Length)
            break;
    }
}

private static void getDiscount (int [] items, int [] discount, int itemsbought, ref int discountItem) {
    for (int i = 0; i < items.Length; i ++) {
        if (itemsbought > items [i])
            discountItem = discount [i];
        else
            break;
    }
}

