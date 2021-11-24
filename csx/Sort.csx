List<int> foo = new List<int>{3,4,1,2,10,9};
foo.Sort((a, b) => a - b);
Console.WriteLine(string.Join(",", foo));