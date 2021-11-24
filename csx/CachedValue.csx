class Time {
    public static float time { get; set; }
}

class CachedValue<T> {
    T value;
    Func<T> calFun;
    float nextCalTime;
    float updateInterval;

    public CachedValue(Func<T> calFun, float updateInterval = .1f) {
        this.calFun = calFun;
        this.updateInterval = updateInterval;
    }

    public T Value {
        get {
            if (Time.time >= nextCalTime) {
                value = calFun();
                nextCalTime = Time.time + updateInterval;
            }
            return value;
        }
    }
}

struct Vector3 {
    public float x;
    public float y;
    public float z;

    public override string ToString() {
        return string.Format("({0}, {1}, {2})", x, y, z);
    }
}

int callTimes = 0;
Vector3 GetPosition() {
    callTimes++;
    return new Vector3 {x = callTimes, y = callTimes, z = callTimes};
}

CachedValue<Vector3> cv = new CachedValue<Vector3>(GetPosition);
CachedValue<Vector3> cv2 = new CachedValue<Vector3>(() => {return GetPosition();});

Console.WriteLine(cv2.Value);
Time.time = .05f;
Console.WriteLine(cv2.Value);
Time.time = .1f;
Console.WriteLine(cv2.Value);
Time.time = .2f;
Console.WriteLine(cv2.Value);
