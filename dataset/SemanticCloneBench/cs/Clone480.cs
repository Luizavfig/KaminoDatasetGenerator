/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:19681374
*  Stack Overflow answer #:19757023
*  And Stack Overflow answer#:19748560
*/
private static void Main (string [] args) {
    var registrationBuilder = new RegistrationBuilder ();
    registrationBuilder.ForTypesMatching < IClass > (t = > FilterOnMetadata (t, MyClassType.TypeOne)).ExportInterfaces ();
    var assemblyCatalog = new AssemblyCatalog (typeof (MyClassType).Assembly, registrationBuilder);
    var compositionContainer = new CompositionContainer (assemblyCatalog);
    var ic = new TestImportContainer ();
    compositionContainer.ComposeParts (ic);
    var count = ic.ImportedParts.Count ();
}

static void Main () {
    var catalog = new AssemblyCatalog (typeof (Program).Assembly);
    var filteredCatalog = catalog.Filter (p = > {
        var type = ReflectionModelServices.GetPartType (p).Value;
        return typeof (IClass).IsAssignableFrom (type) && Attribute.IsDefined (type, typeof (ExportMetadataAttribute)) && type.GetCustomAttributes (typeof (ExportMetadataAttribute), true).Any (ca = > {
            var ema = (ExportMetadataAttribute) ca;
            return ema.Name == "Type" && (MyClassType) ema.Value == MyClassType.TypeA;
        });
    });
    var container = new CompositionContainer (filteredCatalog);
    MyClassConsumer mcc = new MyClassConsumer ();
    container.ComposeParts (mcc);
    Console.WriteLine ("Imported property's type: {0}", mcc.MyClass.GetType ());
    Console.ReadLine ();
}

