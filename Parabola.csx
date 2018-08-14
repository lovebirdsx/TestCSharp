float y0 = 1;
float y1 = 4;
float y2 = 0;
float t = 2;

void CalAccAndVec(float y0, float y1, float y2, float t, out float a, out float v) {
    float t1 = t / ((float)Math.Sqrt((y2 - y1) / (y0 - y1)) + 1);
    a = -(2 * (y1 - y0)) / (t1 * t1);
    v = -a * t1;
}

float a;
float v;
CalAccAndVec(y0, y1, y2, t, out a, out v);

for (int i = 0; i < 21; i++) {
    float dt = (t / 20) *i;
    Console.WriteLine(Math.Round(y0 + v * dt + 0.5 * a * dt * dt, 2));
}
