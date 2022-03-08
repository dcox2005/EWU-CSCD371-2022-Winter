
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        CancellationTokenSource cancellationTokenSource = 
            new CancellationTokenSource();
        Task task = Task.Run(
            () => Display('.', cancellationTokenSource.Token)
            );

        Console.WriteLine("ENTER to exit");
        Console.ReadLine();
        Console.WriteLine("Thanks for letting me done writing boring periods.... sheesh.. give me some real work.");
        cancellationTokenSource.Cancel();
        Console.WriteLine("Exiting!!!");
    }
    static void Display(char character, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
        }
    }
}

