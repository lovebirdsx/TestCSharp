void CastSkill(Action<bool> cb) {
    System.Threading.Thread.Sleep(2000);
    if (cb != null) {
        cb(false);
    }
}

Console.WriteLine("Start Test");
CastSkill(ok => Console.WriteLine("Result is {0}", ok));
Console.WriteLine("End Test");