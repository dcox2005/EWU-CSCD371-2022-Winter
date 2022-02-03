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
        MockJokeWriter writer = new();
        MockJoke myJoke = new ();
        Jester myFunnyMan = new(myJoke, writer);

        myFunnyMan.TellJoke();

        Assert.AreEqual(writer.Output, myJoke.GetJoke());
    }

}
