var str = "10001,1002,1";
var strs = str.Split(',');

foreach (var s in strs) {
    Console.WriteLine(s);
    Console.WriteLine(int.Parse(s));
}