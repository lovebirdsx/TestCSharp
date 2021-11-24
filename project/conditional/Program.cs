#define CONDITION1
#define CONDITION2
using System;
using System.Diagnostics;

class Test
{
    static void Main()
    {
        Console.WriteLine("Calling Method1");
        Method1(3);
        Console.WriteLine("Calling Method2");
        Method2();
        Console.WriteLine("Calling Method3");
        Method3();
    }

    [Conditional("CONDITION1")]
    public static void Method1(int x)
    {
        Console.WriteLine("CONDITION1 is defined");
    }

    [Conditional("CONDITION1"), Conditional("CONDITION2")]
    public static void Method2()
    {
        Console.WriteLine("CONDITION1 or CONDITION2 is defined");
    }

    [Conditional("CONDITION2")]
    public static void Method3()
    {
        Console.WriteLine("CONDITION2 is defined");
    }
}