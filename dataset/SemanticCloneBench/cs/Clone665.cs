/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:721441
*  Stack Overflow answer #:721761
*  And Stack Overflow answer#:721761
*/
[Test] public void TestShouldFindProperty () {
    MockClass mockObject = new MockClass ();
    Assert.IsTrue (mockObject.HasProperty ("Id"));
    Assert.IsTrue (mockObject.HasProperty ("Name"));
    Assert.IsTrue (mockObject.HasProperty ("GetOnly"));
    Assert.IsTrue (mockObject.HasProperty ("SetOnly"));
    Assert.IsTrue (mockObject.HasProperty ("Nested"));
    Assert.IsTrue (mockObject.HasProperty ("Nested.NestedId"));
    Assert.IsTrue (mockObject.HasProperty ("Nested.NestedName"));
    Assert.IsTrue (mockObject.HasProperty ("Nested.NestedGetOnly"));
    Assert.IsTrue (mockObject.HasProperty ("Nested.NestedSetOnly"));
}

[Test] public void TestShouldGetPropertyValue () {
    MockClass mockObject = new MockClass ();
    mockObject.Id = "1";
    mockObject.Name = "Name";
    mockObject.Nested.NestedId = "NestedId";
    mockObject.Nested.NestedName = "NestedName";
    Assert.AreEqual (mockObject.Id, mockObject.GetPropertyValue ("Id"));
    Assert.AreEqual (mockObject.Name, mockObject.GetPropertyValue ("Name"));
    Assert.AreEqual (mockObject.GetOnly, mockObject.GetPropertyValue ("GetOnly"));
    Assert.AreEqual (mockObject.Nested.NestedId, mockObject.GetPropertyValue ("Nested.NestedId"));
    Assert.AreEqual (mockObject.Nested.NestedName, mockObject.GetPropertyValue ("Nested.NestedName"));
}

