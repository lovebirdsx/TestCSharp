byte a = 10;
enum Foo {
    Value1,
    Value2,
    Value3,
}

Foo f = Foo.Value1;
object b = f;

Console.WriteLine((byte)f);

// 将b强制转换成byte会报错
// Console.WriteLine((byte)b);