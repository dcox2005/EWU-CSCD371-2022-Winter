using System;

namespace CanHazFunny;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Would you like to hear a joke? (Y or Yes, anything else No)");
        string? response = Console.ReadLine();
        if (response is null)
        {
            Console.WriteLine("You choose no joke, good bye");
            return;
        }
        WriteJoke myJokeWriter = new();
        JokeService myJokeService = new();
        Jester funnyMan = new(myJokeService, myJokeWriter);
        while (!(response is null) && (response.Equals("y", StringComparison.OrdinalIgnoreCase) || response!.Equals("y", StringComparison.OrdinalIgnoreCase)))
        {
            funnyMan.TellJoke();
            Console.WriteLine("Would you like to hear another?");
            response = Console.ReadLine();
        }

        Console.WriteLine("You chose not to have any more fun. Good bye");
    }
}
