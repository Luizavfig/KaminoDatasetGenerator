/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:248989
*  Stack Overflow answer #:4370949
*  And Stack Overflow answer#:34786740
*/
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

public static bool Verify < T > (T inputClass) where T : INotifyPropertyChanged {
    var properties = inputClass.GetType ().GetProperties ().Where (x = > x.CanWrite);
    var index = 0;
    var matchedName = 0;
    inputClass.PropertyChanged += (o, e) = > {
        if (properties.ElementAt (index).Name == e.PropertyName) {
            matchedName ++;
        }
        index ++;
    };
    foreach (var item in properties) {
        item.SetValue (inputClass, GetPropertyValue (inputClass, item.Name));
    }
    return matchedName == properties.Count ();
}

