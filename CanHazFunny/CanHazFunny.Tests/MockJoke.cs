namespace CanHazFunny.Tests;

public class MockJoke : IJokeService, IWriteLine
{
    public string GetJoke()
    {
        return "I have a funny knock knock joke for you";
    }

    public void WriteLine(string message)
    {
        throw new System.NotImplementedException();
    }
}
