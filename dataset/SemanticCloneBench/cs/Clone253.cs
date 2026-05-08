/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:13524426
*  Stack Overflow answer #:13524487
*  And Stack Overflow answer#:37842298
*/
[STAThread] static void Main () {
    Application.EnableVisualStyles ();
    FooConverter.AddProperty ("Time", typeof (DateTime));
    FooConverter.AddProperty ("Age", typeof (int));
    using (var grid = new PropertyGrid {Dock = DockStyle.Fill, SelectedObject = new Foo ()})
    using (var form = new Form {Controls = {grid}})
    {
        Application.Run (form);
    }}

public static void Main () {
    object [] ctorParams = new object [2];
    Console.Write ("Enter a integer value for X: ");
    string myX = Console.ReadLine ();
    Console.Write ("Enter a integer value for Y: ");
    string myY = Console.ReadLine ();
    Console.WriteLine ("---");
    ctorParams [0] = Convert.ToInt32 (myX);
    ctorParams [1] = Convert.ToInt32 (myY);
    Type ptType = CreateDynamicType ();
    object ptInstance = Activator.CreateInstance (ptType, ctorParams);
    ptType.InvokeMember ("WritePoint", BindingFlags.InvokeMethod, null, ptInstance, new object [0]);
}

