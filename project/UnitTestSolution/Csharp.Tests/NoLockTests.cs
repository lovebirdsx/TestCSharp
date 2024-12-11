namespace Csharp.Tests;

public class NoLockTests
{
    [Fact]
    public async Task InterlockedIncrement_InManyTasks_IsThreadSafe()
    {
        int count = 0;
        int taskCount = 100;
        var tasks = new Task[taskCount];
        for (int i = 0; i < taskCount; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 100; j++)
                {
                    Interlocked.Increment(ref count);
                }
            });
        }

        await Task.WhenAll(tasks);
        Assert.Equal(100 * 100, count);
    }
}
