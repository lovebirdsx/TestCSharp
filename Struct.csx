struct Vector3 {
    public float x;
    public float y;
    public float z;

    public override string ToString() {
        return String.Format("({0}, {1}, {2})", x, y, z);
    }
}

Vector3 a;
a.z = 1;
Console.WriteLine(a);

Vector3 b;
b = a;
Console.WriteLine(b);

a.x = 1;
b.y = 1;
Console.WriteLine(a);
Console.WriteLine(b);

Vector3[] poses = new Vector3[2];
foreach (var pos in poses) {
    Console.WriteLine(pos);
}

// 注意此处是拷贝赋值,改变pos并不会改变poses中的值
Vector3 pos = poses[1];
pos.x = 100;
pos.y = 100;

foreach (var pos in poses) {
    Console.WriteLine(pos);
}