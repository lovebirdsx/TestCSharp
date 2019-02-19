class Foo {
    public string FieldA { get ; private set; }

    public Foo(string a) {
        FieldA = a;
    }
}

var foo = new Foo("Hello");
Console.WriteLine(foo.FieldA);

abstract class Base {
    public virtual int Id { get; protected set; }
}

class Implement : Base {
    public override int Id { get { return 0; } }
}

