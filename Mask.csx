public enum MaskType {
	Foo = 1,
	Bar = 2,
	Car = 3,
	Gee = 4,
	Zue = 5,
	Tue = 6,
}

[Serializable]
public struct MaskStrcut {
	int value;

	public static MaskStrcut NamesToMask(params string[] names) {
		int result = 0;
		foreach (var name in names) {
			result |= (1 << (int)Enum.Parse(typeof(MaskType), name));
		}

		return new MaskStrcut(result);
	}

	public MaskStrcut(int value) {
		this.value = value;
	}

    public override string ToString() {
        return value.ToString();
    }
}

MaskStrcut m = MaskStrcut.NamesToMask("Foo", "Bar");
Console.WriteLine(m);

MaskType m2 = (MaskType)8;
Console.WriteLine("{0}", m2);

public struct Mask {
    int value;

    public static int EnumsToMask(params int[] enums) {
        int result = 0;
		foreach (int e in enums) {
			result |= (1 << (int)e);
		}

		return result;
    }

    public static int NamesToMask(Type enumType, params string[] names) {
        int[] enums = new int[names.Length];
        for (int i = 0; i < names.Length; i++) {
            enums[i] = (int)Enum.Parse(enumType, names[i]);
        }

        return EnumsToMask(enums);
    }   
}

public string ToBitsString(int mask) {
	List<string> result = new List<string>();
	var values = Enum.GetValues(typeof(Bits));
	for (int i = 0; i < values.Length; i++) {
		int value = (int) values.GetValue(i);
		if ((mask & value) > 0) {
			result.Add(Enum.GetName(typeof(Bits), value));
		}
	}
	return string.Join(",", result.ToArray());
}

public enum Bits {
	Bit0 = 1 << 0,
	Bit1 = 1 << 1,
	Bit2 = 1 << 2,
	Bit3 = 1 << 3,
	Bit4 = 1 << 4,
	Bit5 = 1 << 5,
	Bit6 = 1 << 6,
}

int mask = 7;

Console.WriteLine(ToBitsString(mask));

public int ResetBit(int mask, Bits value) {
	int valueMask = Convert.ToInt32(value);
	mask = (mask & ~valueMask);
	return mask;
}

public static int SetBit(int mask, Bits value) {
	int valueMask = Convert.ToInt32(value);
	mask = (mask | valueMask);
	return mask;
}

public static bool BitAnd(int mask, Bits value) {
	int valueMask = Convert.ToInt32(value);
	return (mask & valueMask) > 0;
}

Console.WriteLine(ToBitsString(SetBit(mask, Bits.Bit6)));
Console.WriteLine(ToBitsString(ResetBit(mask, Bits.Bit1)));
