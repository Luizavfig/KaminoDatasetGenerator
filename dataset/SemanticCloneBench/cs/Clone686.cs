/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:6156692
*  Stack Overflow answer #:46556176
*  And Stack Overflow answer#:6156822
*/
static Type CreateEmailType () {
    var assemblyName = new AssemblyName ("DynamicAssembly");
    var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly (assemblyName, AssemblyBuilderAccess.Run);
    var moduleBuilder = assemblyBuilder.DefineDynamicModule (assemblyName.Name);
    var typeBuilder = moduleBuilder.DefineType ("Email", (TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.SequentialLayout | TypeAttributes.Serializable), typeof (ValueType));
    typeBuilder.DefineField ("From", typeof (string), FieldAttributes.Public);
    typeBuilder.DefineField ("To", typeof (string), FieldAttributes.Public);
    typeBuilder.DefineField ("Subject", typeof (string), FieldAttributes.Public);
    typeBuilder.DefineField ("Body", typeof (string), FieldAttributes.Public);
    return typeBuilder.CreateType ();
}

static void Main (string [] args) {
    Address address = new Address ();
    address.Street = "One Microsoft Way";
    address.City = "Redmond";
    address.Zip = 98053;
    Order order = new Order ();
    order.BillTo = address;
    order.ShipTo = address;
    XmlSerializer xmlSerializer = GetSerializer (typeof (Order));
    xmlSerializer.Serialize (Console.Out, order);
}

