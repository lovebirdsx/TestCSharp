using System.Collections.Generic;
using System.Text.RegularExpressions;

class TalkText {

    const string NoColor = "none";
    const string InvisibleColor= "invisible";

    string content;
    List<ColorChar> chars = new List<ColorChar>();

    struct ColorChar {
        public char c;
        public string color;

        public ColorChar(char c, string color) {
            this.c = c;
            this.color = color;
        }
    }
    
    public int Length => chars.Count;

    public TalkText(string content) {
        this.content = content;
        var i = 0;
        var currentColor = NoColor;
        var colorCapsuled = false;
        while (i < content.Length) {
            var c = content[i];
            if (c == '<') {
                if (!colorCapsuled) {
                    i++;
                    while (i < content.Length && content[i] != '=') {
                        i++;
                    }
                    var colorIndex1 = i + 1;
                    while (i < content.Length && content[i] != '>') {
                        i++;
                    }
                    var colorIndex2 = i - 1;
                    currentColor = content.Substring(colorIndex1, colorIndex2 - colorIndex1 + 1);
                    i++;
                } else {
                    while (i < content.Length && content[i] != '>') {
                        i++;
                    }
                    i++;
                    currentColor = NoColor;
                }
                colorCapsuled = !colorCapsuled;
            } else {
                chars.Add(new ColorChar(c, currentColor));
                i++;
            }
        }
    }

    public string GetDisplayText(int len) {
        if (len >= Length) {
            return content;
        }

        var prevColor = NoColor;
        var sb = new StringBuilder(content.Length + 20);
        for (int i = 0; i < len; i++) {
            var c = chars[i];
            if (c.color != prevColor) {
                if (prevColor != NoColor) {
                    sb.Append("</color>");
                }

                if (c.color != NoColor) {
                    sb.Append($"<color={c.color}>");
                }
                prevColor = c.color;
            }

            sb.Append(c.c);

            if (i == len - 1) {
                if (c.color != NoColor) {
                    sb.Append("</color>");
                }
            }
        }

        if (len < Length) {
            sb.Append($"<color={InvisibleColor}>");
            for (int i = len; i < Length; i++) {
                var c = chars[i];
                sb.Append(c.c);
            }
            sb.Append("</color>");
        }

        return sb.ToString();
    }
}

void TestForContent(string content) {
    var tt = new TalkText(content);
    for (int i = 0; i < tt.Length; i++) {
        Console.WriteLine(tt.GetDisplayText(i + 1));
    }
}

void Test1() {
    TestForContent("<color=red>我</color>是<color=info>对话<color>");
    TestForContent("说点<color=red>什么</color>吧1");
    TestForContent("说点什么吧2");
}

Test1()