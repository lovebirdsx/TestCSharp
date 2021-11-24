public struct Vector2 {
    public float x;
    public float y;

    public Vector2(float x, float y) {
        this.x = x;
        this.y = y;
    }

    public override string ToString() {
        return string.Format("({0}, {1})", x, y);
    }
}

public struct Rect {
    public Vector2 min;
    public Vector2 max;
    public float height;
    public float width;

    public Rect(float x, float y, float w, float h) {
        min.x = x;
        min.y = y;
        max.x = x + w;
        max.y = y + h;
        height = h;
        width = w;
    }
}

// 获得线段a,b和线段c,d的交点
public static bool GetLineIntersection(Vector2 a, Vector2 b, Vector2 c, Vector2 d, out Vector2 result) {
    result.x = 0;
    result.y = 0;

    // 解线性方程组,求线段交点,如果分母为0,则平行或共线
    var denominator = (b.y - a.y) * (d.x - c.x) - (a.x - b.x) * (c.y - d.y);
    if (denominator == 0) {
        return false;
    }
    
    // 判断交点是否在两条线段上
    var x = ((b.x - a.x) * (d.x - c.x) * (c.y - a.y)
            + (b.y - a.y) * (d.x - c.x) * a.x
            - (d.y - c.y) * (b.x - a.x) * c.x) / denominator;
    var y = -((b.y - a.y) * (d.y - c.y) * (c.x - a.x)
            + (b.x - a.x) * (d.y - c.y) * a.y
            - (d.x - c.x) * (b.y - a.y) * c.y) / denominator;

    if ( (x - a.x) * (x - b.x) <= 0 && (y - a.y) * (y - b.y) <= 0       // 交点在线段1上
            && (x - c.x) * (x - d.x) <= 0 && (y - c.y) * (y - d.y) <= 0    // 且交点也在线段2上  
        ) {
        result.x = x;
        result.y = y;
        return true;
    }
    
    return false;
}

// Returns 1 if the lines intersect, otherwise 0. In addition, if the lines 
// intersect the intersection point may be stored in the floats i_x and i_y.
public static bool GetLineIntersection2(Vector2 a, Vector2 b, Vector2 c, Vector2 d, out Vector2 result) {
    float p0_x = a.x;
    float p0_y = a.y;
    float p1_x = b.x;
    float p1_y = b.y;
    float p2_x = c.x;
    float p2_y = c.y;
    float p3_x = d.x;
    float p3_y = d.y;

    float s1_x, s1_y, s2_x, s2_y;
    s1_x = p1_x - p0_x;     
    s1_y = p1_y - p0_y;
    s2_x = p3_x - p2_x;     
    s2_y = p3_y - p2_y;

    float s, t;
    s = (-s1_y * (p0_x - p2_x) + s1_x * (p0_y - p2_y)) / (-s2_x * s1_y + s1_x * s2_y);
    t = ( s2_x * (p0_y - p2_y) - s2_y * (p0_x - p2_x)) / (-s2_x * s1_y + s1_x * s2_y);

    if (s >= 0 && s <= 1 && t >= 0 && t <= 1) {
        result.x = p0_x + (t * s1_x);
        result.y = p0_y + (t * s1_y);
        return true;
    }

    result.x = 0;
    result.y = 0;
    return false; // No collision
}

// 返回线段和矩形的一个交点
public static bool GetRectIntersection(Vector2 a, Vector2 b, Rect rect, out Vector2 result) {
    Vector2 r1 = rect.min;
    Vector2 r2 = rect.min; r2.y += rect.height;
    Vector2 r3 = rect.max;
    Vector2 r4 = rect.max; r4.y -= rect.height;

    Vector2[,] lines = new Vector2[4, 2] { { r1, r2 }, {r2, r3}, {r3, r4 }, {r4, r1} };
    for (int i = 0; i < 4; i++) {
        if (GetLineIntersection(a, b, lines[i, 0], lines[i, 1], out result)) {
            return true;
        }
    }

    result.x = 0;
    result.y = 0;
    return false;
}

void Test() {
    Vector2 a = new Vector2(0f, 0f);
    Vector2 b = new Vector2(1956.0f, 461.5f);
    Rect rect = new Rect(-480.10f, -270.0f, 960.2f, 540.0f);

    Vector2 result;
    var ok = GetRectIntersection(a, b, rect, out result);
    Console.WriteLine("{0} {1}", ok, result);
}

Test();