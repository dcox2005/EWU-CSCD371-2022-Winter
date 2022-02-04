using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_JokerServicePassedInIsNull_ArgumentNullException()
    {
        Jester myFunnyMan = new(null!, new WriteJoke());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_WriteJokePassedInIsNull_ArgumentNullException()
    {
        Jester myFunnyMan = new(new JokeService(), null!);
    }

    [TestMethod]
    public void Constructor_ReturnsANotNullObject_Success()
    {
        Jester myFunnyMan = new(new JokeService(), new WriteJoke());
        Assert.IsNotNull(myFunnyMan);
    }

    [TestMethod]
    public void TellJoke_RetrievesJoke_Success()
    {
        IJokeService jokeService = new JokeService();

        string res = "";
        do
        {
            res = jokeService.GetJoke();
        } while (res.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase) || res.Contains("ChuckNorris", StringComparison.OrdinalIgnoreCase));

        Assert.IsFalse(res.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase) || res.Contains("ChuckNorris", StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void TellJoke_RetrievesJokeProperly_Success()
    {
        MockJokeWriter writer = new();
        MockJoke myJoke = new();
        Jester myFunnyMan = new(myJoke, writer);

        myFunnyMan.TellJoke();

        Assert.AreEqual(writer.Output, myJoke.GetJoke());
    }

    [TestMethod]
    public void TellJoke_ChuckNorrisNotAllowed_Success()
    {
        MockJokeWriter writer = new();
        MockJoke myJoke = new();
        Jester myFunnyMan = new(myJoke, writer);

        StringWriter sw = new();
        Console.SetOut(sw);

        myFunnyMan.TellJoke();

        Assert.IsFalse(sw.ToString().Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase) || sw.ToString().Contains("ChuckNorris", StringComparison.OrdinalIgnoreCase));
    }

}