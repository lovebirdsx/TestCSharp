class Mathf {
    public static int Floor(float value) {
        return (int)value;
    }

    public static int RoundToInt(float value) {
        int floor = Floor(value);
        float left = value - floor;
        return left > .5f ? floor + 1 : floor;
    }
}

string CovertTimeStr(float totalSeconds) {
    int minutes = Mathf.Floor(totalSeconds / 60);
    int seconds = Mathf.RoundToInt(totalSeconds % 60);

    return string.Format("{0:D}:{1:D2}", minutes, seconds);
}

Console.WriteLine(CovertTimeStr(90));
Console.WriteLine(CovertTimeStr(70));