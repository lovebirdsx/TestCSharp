abstract class Base {
    public abstract string Name();
}

class Foo : Base {
    public override string Name() {
        return "Foo";
    }
}

class Bar : Base {
    public override string Name() {
        return "Bar";
    }
}

Foo foo = new Foo();
Bar bar = new Bar();

Base b1 = foo;
Base b2 = bar;

Console.WriteLine("b1 == b2 {0}", b1 == b2);
Console.WriteLine("foo == b1 {0}", foo == b1);
Console.WriteLine("bar == b2 {0}", bar == b2);