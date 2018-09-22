float GetDpi(int width, int height, int dpi) {
    float len = (float)Math.Sqrt(width * width + height * height);
    return len / dpi;
}

Console.WriteLine(GetDpi(2436, 1125, 458));