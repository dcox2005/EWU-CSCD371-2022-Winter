
public class Program
{
        static int iterationCount = 0;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        Task<int> task = Task.Run(
        () => Display('.', cancellationTokenSource.Token)
        );


        iterationCount--;
        Console.WriteLine("ENTER to exit");
        Console.ReadLine();
        Console.WriteLine("Thanks for letting me done writing boring periods.... sheesh.. give me some real work.");
        cancellationTokenSource.Cancel();
        iterationCount = task.Result;
        Console.WriteLine($"IterationCount = {iterationCount}");
        Console.WriteLine("Exiting!!!");
    }
    static int Display(char character, CancellationToken cancellationToken)
    {
        iterationCount = 0;
        Thread.CurrentThread.Name = "";
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
            iterationCount++;
        }
        return iterationCount;
    }
}

