using System.Collections.Generic;
using System;

public class Vector2 {
    public float x;
    public float y;

    public static float Distance(Vector2 a, Vector2 b) {
        return (float)Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
    }

    public static Vector2 FindNearest(List<Vector2> list, Vector2 pos) {
        float minDistance = float.MaxValue;
        Vector2 result = null;

        foreach (var item in list) {
            float distance = Vector2.Distance(pos, item);
            if (distance < minDistance) {
                minDistance = distance;
                result = item;
            }
        }

        return result;
    }

    public Vector2(float x, float y) {
        this.x = x;
        this.y = y;
    }
}

var random = new Random();
var list = new List<Vector2>();
for (int i = 0; i < 5; i++) {
    list.Add(new Vector2((float)random.Next(0, 100), (float)random.Next(0, 100)));
}

var pos = new Vector2(50, 50);
var nearestPos = Vector2.FindNearest(list, pos);

foreach (var pos in list) {
    Console.WriteLine("({0}, {1})", pos.x, pos.y);
}

Console.WriteLine("pos = ({0}, {1}) nearest = ({2}, {3})", pos.x, pos.y, nearestPos.x, nearestPos.y);