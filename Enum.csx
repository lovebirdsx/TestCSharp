enum Foo {
    Bar1,
    Bar2,
    Bar3
}

Console.WriteLine(Enum.GetName(typeof(Foo), Foo.Bar1));