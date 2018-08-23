var a = new int[5, 4];
Console.WriteLine(a.Length);
Console.WriteLine(a.GetLength(0));
Console.WriteLine(a.GetLength(1));

for (int i = 0; i < a.GetLength(0); i++) {
    for (int j = 0; j < a.GetLength(1); j++) {
        a[i, j] = i + j;
    }
}

foreach (int i in a) {
    Console.WriteLine(i);
}
