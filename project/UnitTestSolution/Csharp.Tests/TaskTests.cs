namespace Csharp.Tests;

public class TaskTests : IDisposable
{
    readonly string _tempDir;
    readonly FileSystemWatcher _watcher;

    public TaskTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_tempDir);

        _watcher = new FileSystemWatcher(_tempDir, "*.txt")
        {
            EnableRaisingEvents = true,
            NotifyFilter = NotifyFilters.LastWrite
        };
    }

    public void Dispose()
    {
        _watcher.Dispose();
        if (Directory.Exists(_tempDir))
        {
            Directory.Delete(_tempDir, recursive: true);
        }
    }

    string WriteFile(string fileName, string content)
    {
        string filePath = Path.Combine(_tempDir, fileName);
        File.WriteAllText(filePath, content);
        return filePath;
    }

    [Fact]
    public void WriteFile_Ok_ReadFile()
    {
        string filePath = WriteFile("test.txt", "Hello, World!");
        string content = File.ReadAllText(filePath);
        Assert.Equal("Hello, World!", content);
    }

    [Fact]
    public async Task FileChanged_Ok_IsNotified()
    {
        WriteFile("test.txt", "hello");
        
        int threadId = Environment.CurrentManagedThreadId;
        int threadId2 = -1;

        var tcs = new TaskCompletionSource<string>();
        void handler(object sender, FileSystemEventArgs e)
        {
            tcs.SetResult(e.FullPath);
            _watcher.Changed -= handler;

            threadId2 = Environment.CurrentManagedThreadId;
        }

        _watcher.Changed += handler;

        WriteFile("test.txt", "hello world");

        var completedTask = await Task.WhenAny(tcs.Task, Task.Delay(1000));

        Assert.True(tcs.Task.IsCompleted, "Changed事件未被触发");

        // 文件处理的回调是在另一个线程上执行的
        Assert.NotEqual(threadId, threadId2);
    }
}