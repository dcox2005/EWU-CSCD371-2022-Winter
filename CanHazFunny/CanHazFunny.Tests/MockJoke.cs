using System;

namespace CanHazFunny.Tests;

public class MockJoke : IJokeService, IWriteJoke
{
    public string GetJoke()
    {
        return "I have a funny knock knock joke for you";
    }

    public void JokeWriter(string message)
    {
        Console.WriteLine(message);
    }
}
