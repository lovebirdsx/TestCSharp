using System.Text.RegularExpressions;

public static bool IsOkLuaKeyStr(string key) {
    key = key.Trim();
    var match = Regex.Match(key, @"^[a-zA-Z_$][a-zA-Z_$0-9]*$");
    return match.Success;
}

public static bool IsOkLuaValueStr(string value) {
    value = value.Trim();
    if (value.Length <= 0) {
        return false;
    }

    // 字符串
    if (value[0] == '\'') {
        var match1 = Regex.Match(value, @"^\'\w+\'$");
        return match1.Success;
    }

    // bool
    if (value == "true" || value == "false") {
        return true;
    }

    // number
    var match2 = Regex.Match(value, @"^(\-|\+)?\d+(\.\d+)?$");
    return match2.Success;
}

// 检测形如 a=1, b='1bc', _c=1.0 的lua参数字符串
public static bool IsOkLuaParams(string s) {
    var tokens = s.Split(',');
    foreach (var token in tokens) {
        var kvs = token.Split('=');
        if (kvs.Length != 2) {
            return false;
        }

        if (!IsOkLuaKeyStr(kvs[0])) {
            return false;
        }

        if (!IsOkLuaValueStr(kvs[1])) {
            return false;
        }
    }

    return true;
}

void Assert(bool value, bool desire, string msg) {
    if (value != desire) {
        Console.WriteLine($"Assert failed: [{msg}] result != {desire}");
    } else {
        Console.WriteLine($"Passed: [{msg}] result == {desire}");
    }
}

string[] successParamsList = {
    "k1 = 123",
    "k1=123, k2 = 234",
    "k1='123', k2 = 234",
    "buff=1234, k2 = '234'",
    "k1=1001, k2='test'",
    "a=1, b='1bc', _c=1.0",
};

string[] failParamsList = {
    "'k1=123",
    "'k1=123, k",
    "'k1=123; k",
};

foreach (var p in successParamsList) {
    Assert(IsOkLuaParams(p), true, p);
}

foreach (var p in failParamsList) {
    Assert(IsOkLuaParams(p), false, p);
}
