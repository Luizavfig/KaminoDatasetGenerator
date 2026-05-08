/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:4823904
*  Stack Overflow answer #:5024858
*  And Stack Overflow answer#:5024276
*/
[HttpPost] public ActionResult Create (CreateOrderViewModel model) {
    try {
        var newOrder = new Order {OrderDate = DateTime.Now, OrderProduct = new OrderProduct {ProductId = SelectedProductId}};
        db.Orders.AddObject (newOrder);
        return RedirectToAction ("Index");
    }
    catch {
        return View ();
    }
}

[HttpPost] public ActionResult Create (FormCollection form) {
    MVC.Models.MVCOrder ord = Models.MVCOrder.Instance.CreateBlankOrder ();
    if (TryUpdateModel < MVC.Models.MVCOrder > (ord, form.ToValueProvider ())) {
        ord.Product = Models.MVCProduct.Instance.ProductList.Find (p = > p.Id == int.Parse (form.GetValue ("ProductList").AttemptedValue));
        ord.Attribute = Models.MVCAttribute.Instance.AttributeList.Find (a = > a.Id == int.Parse (form.GetValue ("attributeId").AttemptedValue));
        UpdateModel (ord);
        return RedirectToAction ("Index");
    } else {
        return View (ord);
    }
}

