int[] a = { 1, 2, 3, 4, 5 };
int[] b = { 1, 2, 3 };
var c = a.Concat(b).ToArray();

Console.WriteLine(String.Join(", ", c));

class Foo
{
    public string name = "foo";
}

Foo[] foos = new Foo[3];
foos[0] = new Foo();
foos[1] = new Foo();
foos[2] = new Foo();

foreach (Foo foo in foos)
{
    Console.WriteLine(foo.name);
}

Console.WriteLine(a.GetType());
Console.WriteLine(c.GetType());
Console.WriteLine(foos.GetType());
