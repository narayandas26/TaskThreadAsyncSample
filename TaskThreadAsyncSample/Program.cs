internal class Program
{
    private static void Main(string[] args)
    {
        //SynchronousSampleWithFrozenConsole();

        //AsyncSampleWithUsableConsole();

        //TaskSampleWithParallelExecution();

        ThreadSampleWithConcurrentExecution();

        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Hello " + name);
        Console.Read();
    }

    private static void SynchronousSampleWithFrozenConsole()
    {
        DownloadFile1();

        DownloadFile2();
    }

    private static void AsyncSampleWithUsableConsole()
    {
        DownloadFile1Async();

        DownloadFile2Async();
    }

    private static void TaskSampleWithParallelExecution()
    {
        //Task.Run(() => { DownloadFile1(); });
        //Task.Run(() => { DownloadFile2(); });

        Task.Run(() => { DownloadFile1Async(); });        
        Task.Run(() => { DownloadFile2Async(); });
    }

    private static void ThreadSampleWithConcurrentExecution()
    {
        Thread thread1 = new Thread(() => { Thread.Sleep(10000); Console.WriteLine("File1 downloaded"); });
        Thread thread2 = new Thread(() => { Thread.Sleep(10000); Console.WriteLine("File2 downloaded"); });
        thread1.Start();
        thread2.Start();
    }

    private static void DownloadFile2()
    {
        Task.Delay(10000).Wait();
        Console.WriteLine("File2 downloaded");
    }

    private static void DownloadFile1()
    {
        Task.Delay(10000).Wait();
        Console.WriteLine("File1 downloaded");
    }

    private static async void DownloadFile2Async()
    {
        await Task.Delay(10000);
        Console.WriteLine("File2 downloaded");
    }

    private static async void DownloadFile1Async()
    {
        await Task.Delay(10000);
        Console.WriteLine("File1 downloaded");
    }
}