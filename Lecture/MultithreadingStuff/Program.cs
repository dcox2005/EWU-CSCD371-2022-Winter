
public class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        Task task = Task.Run(
            () => Display('.', cancellationTokenSource.Token)
            );

        Console.WriteLine("ENTER to exit");
        Console.ReadLine();
        cancellationTokenSource.Cancel();
        task.Wait();
        Console.WriteLine("Exiting!!!");

    }
    static void Display(char character, CancellationToken cancellationToken)
    {
        while(!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
        }
    }

}