/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:248989
*  Stack Overflow answer #:249042
*  And Stack Overflow answer#:4370949
*/
[TestMethod] public void Test_ThatMyEventIsRaised () {
    List < string > receivedEvents = new List < string > ();
    MyClass myClass = new MyClass ();
    myClass.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e) {
        receivedEvents.Add (e.PropertyName);
    };
    myClass.MyProperty = "testing";
    Assert.AreEqual (2, receivedEvents.Count);
    Assert.AreEqual ("MyProperty", receivedEvents [0]);
    Assert.AreEqual ("MyOtherProperty", receivedEvents [1]);
}

[TestMethod] public void Test_ThatMyEventIsRaised () {
    Dictionary < string, int > receivedEvents = new Dictionary < string, int > ();
    MyClass myClass = new MyClass ();
    myClass.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e) {
        if (receivedEvents.ContainsKey (e.PropertyName))
            receivedEvents [e.PropertyName] ++;
        else
            receivedEvents.Add (e.PropertyName, 1);
    };
    myClass.MyProperty = "testing";
    Assert.IsTrue (receivedEvents.ContainsKey ("MyProperty"));
    Assert.AreEqual (1, receivedEvents ["MyProperty"]);
    Assert.IsTrue (receivedEvents.ContainsKey ("MyOtherProperty"));
    Assert.AreEqual (1, receivedEvents ["MyOtherProperty"]);
}

