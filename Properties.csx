class Foo {
    public string FieldA { get ; private set; }

    public Foo(string a) {
        FieldA = a;
    }
}

var foo = new Foo("Hello");
Console.WriteLine(foo.FieldA);