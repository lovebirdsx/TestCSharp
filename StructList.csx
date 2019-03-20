struct Vector {
    public float x;
    public float y;
}

struct Record {
    public Vector pos;
    public float time;

    public Record(float x, float y) {
        pos.x = x;
        pos.y = y;
        time = 0;
    }

    public override string ToString() {
        return string.Format("({0}, {1})", pos.x, pos.y);
    }
}

List<Record> records = new List<Record>();
records.Add(new Record(1, 2));
records.Add(new Record(2, 3));

Console.WriteLine(records.Find(r => r.pos.x == 1 && r.pos.y == 2));
Console.WriteLine(records.Find(r => r.pos.x == 1 && r.pos.y == 2).Equals(default(Record)));
Console.WriteLine(records.Find(r => r.pos.x == 2 && r.pos.y == 2));
Console.WriteLine(records.Find(r => r.pos.x == 2 && r.pos.y == 2).Equals(default(Record)));
