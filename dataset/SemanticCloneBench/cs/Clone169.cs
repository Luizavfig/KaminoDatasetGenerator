/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:3048650
*  Stack Overflow answer #:3057111
*  And Stack Overflow answer#:3049186
*/
static void Main () {
    using (MemoryStream ms = new MemoryStream ())
    {
        WriteNext (ms, 123);
        WriteNext (ms, new Person {Name = "Fred"});
        WriteNext (ms, "abc");
        ms.Position = 0;
        while (ReadNext (ms)) {
        }
    }}

static void Main (string [] args) {
    Person person = new Person {Id = 12345, Name = "Fred", Address = new Address {Line1 = "Flat 1", Line2 = "The Meadows"}};
    object value;
    using (Stream stream = new MemoryStream ())
    {
        Send < Person > (stream, person);
        stream.Position = 0;
        value = Read (stream);
        person = value as Person;
    }}

