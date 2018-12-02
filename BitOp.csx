int x = 1 << 4;
int y = (1 << 5) + x;
Console.WriteLine("x + y = {0}, x | y = {1}", x + y, x | y);

int foo = 1;
foo |= 8;
Console.WriteLine("{0}", foo);

Console.WriteLine(7 & ~4);
Console.WriteLine(3 & ~1);
