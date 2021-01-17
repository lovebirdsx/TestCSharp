struct Vector2Int {
    public int x;
    public int y;

    public Vector2Int(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public override string ToString() {
        return $"({x}, {y})";
    }
}

Vector2Int GetGridPos(int id, int maxCol) {
    var count = id + 1;
    var colLeft = count % maxCol;
    var col = (colLeft == 0) ? maxCol : colLeft;
    var row = (int) (id / maxCol) + 1;
    return new Vector2Int(col - 1, row - 1);
}

for (int i = 0; i < 10; i++) {
    Console.WriteLine($"i {i} result {GetGridPos(i, 4)}");
}