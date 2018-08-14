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