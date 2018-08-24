List<string> list = new List<string>();
list.Add("Hello");
list.Add("World");
list.Add("Hello");
list.Add("Lovebird");

Console.WriteLine(string.Join(",", list));
Console.WriteLine(list.Aggregate((y, x) => y + "(" + x + ")"));
