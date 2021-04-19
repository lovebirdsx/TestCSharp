using System.Text.RegularExpressions;

string GetSuffix(string name) {
    var match = Regex.Match(name, @"\(\d+\)");
    return match.ToString();
}

void Test1() {
    Console.WriteLine(GetSuffix("ResWall2X2 (1)"));
    Console.WriteLine(GetSuffix("ResWall2X2 (123)"));
}

string Replace(string color) {
    if (color == "grey") {
        return "0xff00ff00";
    }
    return color;
}

void Test2() {
    var str = @"攻击+100
角色血量回复速度+20%
每击杀一个普通怪物，攻击+20，当前共击杀5/20只
<color=blue>套装效果</color>
怀特的假腿 <color=grey>怀特的帽子</color> 怀特的手套 <color=grey>怀特的上衣</color> <color=grey>怀特的裤子</color>
2件套效果：攻击+50
<color=grey>3件套效果：防御+20</color>
<color=grey>4件套效果：血量+100</color>
<color=grey>5件套效果：回复+20</color>";

    var result = Regex.Replace(str, "<color=(\\w+)>", (s)=> "<color="+Replace(s.Groups[1].ToString())+">");
    Console.WriteLine(result);
}

void Test3() {
    var path = "Assets/Resources/Maps/map_test3.prefab";
    var match = Regex.Match(path, @"Assets/Resources/Maps/([\w\d]+).prefab");
    Console.WriteLine($"result is {match.Success}");
}

// 测试是否为合法的变量名
void Test4() {
    string[] names = {"a1", "_a", "a1_1", "1", "1a"};
    foreach (var name in names) {
        var match = Regex.Match(name, @"^[a-zA-Z_$][a-zA-Z_$0-9]*$");
        Console.WriteLine($"{name} {match.Success}");
    }
}

// 测试是否为合法的lua字符串
void Test5() {
    string[] names = {"'a1'", "'_a", "a1_1", "ab_action", "'1001'", "'123"};
    foreach (var name in names) {
        var match = Regex.Match(name, @"^\'\w+\'$");
        Console.WriteLine($"{name} {match.Success}");
    }
}

// 测试是否为合法的lua数字
void Test6() {
    string[] names = {"123", "1.1", "1.10", "1.34", "1001", "'123"};
    foreach (var name in names) {
        var match = Regex.Match(name, @"^(\-|\+)?\d+(\.\d+)?$");
        Console.WriteLine($"{name} {match.Success}");
    }
}

Test5();
