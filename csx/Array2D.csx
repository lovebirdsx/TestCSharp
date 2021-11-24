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

var b = new int[4][];
b[0] = new int [4] {1, 2, 3, 4};
b[1] = new int [4] {5, 6, 7, 8};
b[2] = new int [4] {4, 3, 2, 1};
b[3] = new int [4] {8, 7, 6, 5};

for (int i = 0; i < b.Length; i++) {
    var arr = b[i];
    for (int j = 0; j < arr.Length; j++) {
        Console.WriteLine(arr[j]);
    }
}