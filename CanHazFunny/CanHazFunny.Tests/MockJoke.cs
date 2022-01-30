namespace CanHazFunny.Tests;

public class MockJoke : IJokeService, IWriteJoke
{
    public string GetJoke()
    {
        return "I have a funny knock knock joke for you";
    }

    public void WriteJoke(string message)
    {
        throw new System.NotImplementedException();
    }
}
