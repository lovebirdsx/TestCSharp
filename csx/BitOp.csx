int x = 1 << 4;
int y = (1 << 5) + x;
Console.WriteLine("x + y = {0}, x | y = {1}", x + y, x | y);

int foo = 1;
foo |= 8;
Console.WriteLine("{0}", foo);

Console.WriteLine(7 & ~4);
Console.WriteLine(3 & ~1);

// 设定和取消设定位
byte bit = 1 << 4;
byte state = 0xff;
Console.WriteLine("Before set: {0}", Convert.ToString(state, 2).PadLeft(8, '0'));
state &= (byte)~bit;
Console.WriteLine(" unset bit: {0}", Convert.ToString(state, 2).PadLeft(8, '0'));
state &= (byte)~bit;
Console.WriteLine(" unset bit: {0}", Convert.ToString(state, 2).PadLeft(8, '0'));
state |= bit;
Console.WriteLine("   set bit: {0}", Convert.ToString(state, 2).PadLeft(8, '0'));
state |= bit;
Console.WriteLine("   set bit: {0}", Convert.ToString(state, 2).PadLeft(8, '0'));