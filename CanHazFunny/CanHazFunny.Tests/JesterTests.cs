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
        Mock<IJokeService> service = new Mock<IJokeService>();
        Mock<IWriteJoke> writer = new Mock<IWriteJoke>();

        // Jester myFunnyMan = new Jester(service, writer);
        Mock<Jester> myFunnyMan = new(new Mock<IJokeService>(), new Mock<IWriteJoke>());

        //using (StringWriter stringWriter = new StringWriter())
        //{         
        //    Console.SetOut(stringWriter);
        //    Mock<Jester> mock = new();
        //    mock.SetupSequence(funny => funny.TellJoke());
        //    var joke = "Who's There?";
        //    //IWriteJoke mock = new MockJoke();
        //    //mock.JokeWriter(joke);
        //    Assert.AreEqual<string>(joke + "\r\n", stringWriter.ToString());
        //}
    }

}
