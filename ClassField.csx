class Foo {
    public string name = "foo";
}

class Bar {
    public Foo foo = new Foo();
}

Bar bar = new Bar();
Console.WriteLine(bar.foo.name);