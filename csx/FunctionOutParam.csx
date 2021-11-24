int Foo(out float f)
{
    f = 1.0f;
    return 3;
}

float a;
float b;

a = Foo(out b);

Console.WriteLine(a + " " + b);