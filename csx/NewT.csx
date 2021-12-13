public class Foo<T> where T: new() {
    public static T Create() {
        return new T();
    }
}

class Bar : Foo<Bar> {
    public string name;
    // 此处的构造函数必须为public,否则编译报错
    public Bar() {
        name = "Hello Bar!";
    }
    public override string ToString() {
        return name;
    }
}

class Cuz : Foo<Cuz> {
    public int id;
    public Cuz() {
        id = 100;
    }
    public override string ToString() {
        return id.ToString();
    }
}

var bar = Bar.Create();
Console.WriteLine(bar);
var cuz = Cuz.Create();
Console.WriteLine(cuz);
