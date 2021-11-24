float time = 60*6 + 45 + 0.01f * 33;

struct CountDownTime {
    int miniute;
    int seconds;
    int hSecond;

    public static CountDownTime Parse(float t) {
        int t100 = (int)(t * 100);
        int miniute = t100 / 6000;
        int seconds = (t100 - miniute * 6000) / 100;
        int hSecond = t100 % 100;
        return new CountDownTime { miniute = miniute, seconds = seconds, hSecond = hSecond };
    }

    public override string ToString() {
        return string.Format("{0:D2}:{1:D2}:{2:D2}", miniute, seconds, hSecond);
    }
}

Console.WriteLine(CountDownTime.Parse(time));
