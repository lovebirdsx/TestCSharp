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