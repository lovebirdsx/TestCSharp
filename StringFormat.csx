int a = 102;

Console.WriteLine($"{a:D8}");
Console.WriteLine(string.Format("+{0:D}", a));

string[] strs = new string[] {"foo", "bar", "car"};
Console.WriteLine(string.Format("{0} {1}", strs));
Console.WriteLine(string.Format("{0}", String.Join(" ", strs)));

float b = 11.10001f;
Console.WriteLine($"b = {b:0.##}s");