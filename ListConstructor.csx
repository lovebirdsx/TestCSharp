class Foo {
    public int bar;
}

List<Foo> foos = new List<Foo>(3);

Console.WriteLine(foos.Count);
foreach (var foo in foos) {
    Console.WriteLine(foo.bar);
}   