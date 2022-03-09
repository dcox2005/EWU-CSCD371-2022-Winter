
public class Program
{
    static int iterationCount = 0;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        CancellationTokenSource cancellationTokenSource = 
            new CancellationTokenSource();

        Task<int> task = Task.Run(
            () => Display('.', cancellationTokenSource.Token)                
            );
        
        iterationCount--;
        Console.WriteLine("ENTER to exit");
        Console.ReadLine();
        cancellationTokenSource.Cancel();
        iterationCount = task.Result;
        Console.WriteLine($"IterationCount = {iterationCount}");
        Console.WriteLine("Exiting!!!");
    }
    static int Display(char character, CancellationToken cancellationToken)
    {
        iterationCount = 0;
        Thread.CurrentThread.Name = "DisplayThread";
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
            iterationCount++;
        }
        return iterationCount;
    }
}

