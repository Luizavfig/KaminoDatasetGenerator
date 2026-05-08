/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:45043266
*  Stack Overflow answer #:45153942
*  And Stack Overflow answer#:45153942
*/
static void Main (string [] args) {
    ConventionPack cp = new ConventionPack ();
    cp.Add (new StringObjectIdIdGeneratorConventionThatWorks ());
    ConventionRegistry.Register ("TreatAllStringIdsProperly", cp, _ = > true);
    var collection = new MongoClient ().GetDatabase ("test").GetCollection < Person > ("persons");
    Person person = new Person ();
    person.Name = "Name";
    collection.InsertOne (person);
    Console.ReadLine ();
}

public void PostProcess (BsonClassMap classMap) {
    var idMemberMap = classMap.IdMemberMap;
    if (idMemberMap == null || idMemberMap.IdGenerator != null)
        return;
    if (idMemberMap.MemberType == typeof (string)) {
        idMemberMap.SetIdGenerator (StringObjectIdGenerator.Instance).SetSerializer (new StringSerializer (BsonType.ObjectId));
    }
}

