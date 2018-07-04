delegate void PrintDelegate(int num);

void Foo(int num) {
    Console.WriteLine("Foo({0}) = {1}", num, num);
}

void Bar(int num) {
    Console.WriteLine("Bar({0}) = {1}", num, num * num);
}

PrintDelegate print = Foo;
print(2);
print = Bar;
print(2);

PrintDelegate print2 = Foo;
print2 += Bar;
print2(2);
print2 -= Bar;
print2(2);