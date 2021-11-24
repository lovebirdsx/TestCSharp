public static class Assert {
    public static void IsTrue(bool expression) {
        if (!expression) {
            Console.WriteLine("Faild IsTrue");
        }
    }

    public static void IsFalse(bool expression) {
        if (expression) {
            Console.WriteLine("Faild IsFalse");
        }
    }
}

public struct Vector2 {
    public float x;
    public float y;
}

public static class Mathf {
    public static int RoundToInt(float value) {
        return Convert.ToInt32(value);
    }

    public static int Max(int a, int b) {
        return a > b ? a : b;
    }

    public static int Min(int a, int b) {
        return a < b ? a : b;
    }
}

struct GridRect {
    int minX;
    int minY;
    int maxX;
    int maxY;

    public GridRect(int cx, int cy, int width, int height) {
        Assert.IsTrue(width % 2 == 0);
        Assert.IsTrue(height % 2 == 0);

        minX = cx - width / 2;
        minY = cy - height / 2;
        maxX = cx + width / 2;
        maxY = cy + height / 2;
    }

    public GridRect(Vector2 center, Vector2 size) {
        int cx = Mathf.RoundToInt(center.x);
        int cy = Mathf.RoundToInt(center.y);
        int width = Mathf.RoundToInt(size.x);
        int height = Mathf.RoundToInt(size.y);

        Assert.IsTrue(width % 2 == 0);
        Assert.IsTrue(height % 2 == 0);

        minX = cx - width / 2;
        minY = cy - height / 2;
        maxX = cx + width / 2;
        maxY = cy + height / 2;
    }

    public bool Contains(GridRect r) {
        return minX <= r.minX && minY <= r.minY && r.maxX <= maxX && r.maxY <= maxY;
    }

    public bool HasIntersection(GridRect r) {
        int minXI = Mathf.Max(minX, r.minX);
        int minYI = Mathf.Max(minY, r.minY);
        int maxXI = Mathf.Min(maxX, r.maxX);
        int maxYI = Mathf.Min(maxY, r.maxY);
        
        return minXI < maxXI && minYI < maxYI;
    }
}

public static class Test {
    public static void TestContains() {
        var r1 = new GridRect(0, 0, 4, 4);
        var r2 = new GridRect(0, 0, 2, 2);
        var r3 = new GridRect(0, 0, 6, 2);
        Assert.IsTrue(r1.Contains(r2));
        Assert.IsFalse(r1.Contains(r3));
        Assert.IsFalse(r3.Contains(r1));
        Assert.IsTrue(r1.Contains(r1));
    }

    public static void TestIntersection() {
        var r1 = new GridRect(0, 0, 4, 4);
        var r2 = new GridRect(0, 0, 2, 2);
        var r3 = new GridRect(0, 0, 2, 2);
        var r4 = new GridRect(2, 0, 2, 2);
        Assert.IsTrue(r1.HasIntersection(r2));
        Assert.IsTrue(r2.HasIntersection(r1));
        Assert.IsTrue(r2.HasIntersection(r3));
        Assert.IsTrue(r3.HasIntersection(r2));
        Assert.IsFalse(r3.HasIntersection(r4));
        Assert.IsFalse(r4.HasIntersection(r3));
    }

    public static void TestAll() {
        TestContains();
        TestIntersection();
        Console.WriteLine("Done");        
    }
}

Test.TestAll();
