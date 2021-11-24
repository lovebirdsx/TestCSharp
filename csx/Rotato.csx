struct Vector2 {
    public int x;
    public int y;

    public override string ToString() {
        return string.Format("({0}, {1})", x, y);
    }
}

const float GridSize = 1f;

struct MapObject {
    public int xGrid;
    public int yGrid;
    public int width;
    public int height;
}

class Mathf {
    public static float PI = (float)Math.PI;

    public static float Cos(float radius) {
        return (float)Math.Cos(radius);
    }

    public static float Sin(float radius) {
        return (float)Math.Sin(radius);
    }
}

// b.x = ( a.x - o.x)*cos(angle) - (a.y - o.y)*sin(angle) + o.x
// b.y = (a.x - o.x)*sin(angle) + (a.y - o.y)*cos(angle) + o.y
Vector2[] GetGrids(int xGrid, int yGrid, int width, int height, float rotationY) {
    Vector2[] result = new Vector2[width * height];

    // 顺时针旋转
    float cosA = Mathf.Cos(-rotationY);
    float sinA = Mathf.Sin(-rotationY);
    int xGridStart = -(width / 2);
    int yGridStart = -(height / 2);
    for (int y = 0; y < height; y++) {
        for (int x = 0; x < width; x++) {
            float ax = xGrid + xGridStart + x + GridSize / 2;
            float ay = yGrid + yGridStart + y + GridSize / 2;
            float bx = (ax - xGrid) * cosA - (ay - yGrid) * sinA + xGrid;
            float by = (ax - xGrid) * sinA + (ay - yGrid) * cosA + yGrid;
            result[y * width + x].x = (int)(bx - GridSize / 2);
            result[y * width + x].y = (int)(by - GridSize / 2);
        }
    }
    return result;
}

Vector2[] GetGrids(MapObject obj, float rotationY) {
    return GetGrids(obj.xGrid, obj.yGrid, obj.width, obj.height, rotationY);
}

void TestFor(int xGrid, int yGrid, int width, int height, float rotationY) {
    MapObject obj = new MapObject {xGrid = xGrid, yGrid = yGrid, width = width, height = height};
    Console.WriteLine(string.Join(", ", GetGrids(obj, rotationY)));
}

TestFor(0, 0, 2, 1, 0);
TestFor(0, 0, 2, 1, Mathf.PI / 2);
TestFor(0, 0, 2, 1, Mathf.PI);
TestFor(0, 0, 2, 1, Mathf.PI / 2 * 3);