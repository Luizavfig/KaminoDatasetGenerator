/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3822873
*  Stack Overflow answer #:11323028
*  And Stack Overflow answer#:23779297
*/
private HomeController GenerateController (object model) {
    HomeController controller = new HomeController () {RoleService = new MockRoleService (), MembershipService = new MockMembershipService ()};
    MvcMockHelpers.SetFakeAuthenticatedControllerContext (controller);
    var modelBinder = new ModelBindingContext () {ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType (() = > model, model.GetType ()), ValueProvider = new NameValueCollectionValueProvider (new NameValueCollection (), CultureInfo.InvariantCulture)};
    var binder = new DefaultModelBinder ().BindModel (new ControllerContext (), modelBinder);
    controller.ModelState.Clear ();
    controller.ModelState.Merge (modelBinder.ModelState);
    return controller;
}

private static ControllerContext SetUpControllerContext < TModel > (Controller controller, TModel viewModel) {
    var controllerContext = A.Fake < ControllerContext > ();
    controller.ControllerContext = controllerContext;
    var json = new JavaScriptSerializer ().Serialize (viewModel);
    A.CallTo (() = > controllerContext.Controller).Returns (controller);
    A.CallTo (() = > controllerContext.HttpContext.Request.InputStream).Returns (new MemoryStream (Encoding.UTF8.GetBytes (json)));
    A.CallTo (() = > controllerContext.HttpContext.Request.ContentType).Returns ("application/json");
    return controllerContext;
}

