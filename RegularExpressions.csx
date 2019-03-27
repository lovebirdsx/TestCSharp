using System.Text.RegularExpressions;

string GetSuffix(string name) {
    var match = Regex.Match(name, @"\(\d+\)");
    return match.ToString();
}

Console.WriteLine(GetSuffix("ResWall2X2 (1)"));
Console.WriteLine(GetSuffix("ResWall2X2 (123)"));