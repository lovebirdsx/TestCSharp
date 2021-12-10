public class Foo : IDisposable {
    public void Dispose() {
        Console.WriteLine("Foo.Dispose()");
    }

    public void Bar() {
        Console.WriteLine("Foo.Bar()");
    }
}

using (var foo = new Foo()) {
    foo.Bar();
    throw new Exception();
}