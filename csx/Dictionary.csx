struct Vector2 {
    public int x;
    public int y;
}

Dictionary<Vector2, bool> foo = new Dictionary<Vector2, bool>();
Vector2 v1 = new Vector2 {x = 1, y = 1};

// 以struct作为key,判断对应的key是否存在,是按照值比较来判定的
Console.WriteLine(foo.ContainsKey(v1));
Console.WriteLine(foo.ContainsKey(new Vector2 {x= 1, y = 1}));
foo[v1] = true;
Console.WriteLine(foo.ContainsKey(v1));
Console.WriteLine(foo.ContainsKey(new Vector2 {x= 1, y = 1}));
