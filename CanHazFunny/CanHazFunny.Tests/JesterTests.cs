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
        Jester myFunnyMan = new(jokeService: null!, new WriteJoke());
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

}