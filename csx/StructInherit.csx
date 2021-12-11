interface IFoo {
    void Bar();
}

struct FooStruct : IFoo {
    public int a;

    public void Bar() {
        Console.WriteLine("FooStruct:Bar()");
    }
}

class FooClass : IFoo {
    public void Bar() {        
        Console.WriteLine("FooClass:Bar()");
    }
}

// 结构不能被继承
// struct Bar : Foo {
//     public int b;
// }

var f1 = new FooStruct();
var f2 = new FooClass();
f1.Bar();
f2.Bar();
