int a = 102;

Console.WriteLine(string.Format("+{0:D}", a));

string[] strs = new string[] {"foo", "bar", "car"};
Console.WriteLine(string.Format("{0} {1}", strs));
Console.WriteLine(string.Format("{0}", String.Join(" ", strs)));