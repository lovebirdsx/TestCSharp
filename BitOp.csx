int x = 1 << 4;
int y = (1 << 5) + x;
Console.WriteLine("x + y = {0}, x | y = {1}", x + y, x | y);

int foo = 1;
foo |= 8;
Console.WriteLine("{0}", foo);