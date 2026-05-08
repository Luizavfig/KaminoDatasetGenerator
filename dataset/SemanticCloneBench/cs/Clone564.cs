/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:25498791
*  Stack Overflow answer #:25522584
*  And Stack Overflow answer#:25511313
*/
[Fact] public void Test () {
    var fixture = new Fixture ();
    fixture.Register < CarId, Car > (id = > {
        var resource = new Car {Id = id};
        return resource;
    });
    fixture.Register < PlaneId, Plane > (id = > {
        var resource = new Plane {Id = id};
        return resource;
    });
    Assert.NotSame (fixture.Create < Car > ().Id, fixture.Create < Car > ().Id);
    Assert.NotSame (fixture.Create < Plane > ().Id, fixture.Create < Plane > ().Id);
}

[Fact] public void Test () {
    var fixture = new Fixture ();
    fixture.Customize < Plane > (c = > c.With (x = > x.Id, fixture.Create < PlaneId > ()));
    fixture.Customize < Car > (c = > c.With (x = > x.Id, fixture.Create < CarId > ()));
    var plane = fixture.Create < Plane > ();
    var car = fixture.Create < Car > ();
    Assert.IsType < PlaneId > (plane.Id);
    Assert.IsType < CarId > (car.Id);
}

