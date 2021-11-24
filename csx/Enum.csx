enum Foo {
    Bar1,
    Bar2,
    Bar3
}

Console.WriteLine(Enum.GetName(typeof(Foo), Foo.Bar1));

enum Mask {
    Mask0 = 1 << 0,
    Mask1 = 1 << 1,
    Mask2 = 1 << 2,
    Mask3 = 1 << 3,
    Mask4 = 1 << 4,
}

public static int GetMask<T>(params T[] enums) {
    int result = 0;
    for (int i = 0; i < enums.Length; i++) {
        result |= Convert.ToInt32(enums[i]);
    }
    return result;
}

Mask[] masks = new Mask[2];
masks[0] = Mask.Mask0;
masks[1] = Mask.Mask4;

Console.WriteLine(GetMask(masks));
Console.WriteLine(GetMask(Mask.Mask0, Mask.Mask4));