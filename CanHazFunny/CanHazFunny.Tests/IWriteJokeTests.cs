using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CanHazFunny.Tests;

[TestClass]
public class IWriteJokeTests
{
    //Extra Credit Part One attempted here
    [TestMethod]
    public void Console_DoesItWriteToConsole_Success()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        Console.WriteLine("Knock Knock!");
        Assert.AreEqual<string>("Knock Knock!\r\n", stringWriter.ToString());
        stringWriter.Dispose();
    }

    //Extra Credit Part One attempted here
    [TestMethod]
    public void WriteJoke_DoesConsoleWriteLineWriteTheJokeToConsole_Success()
    {
        using (StringWriter stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            var joke = "Who's There?";
            IWriteJoke mock = new MockJoke();
            mock.JokeWriter(joke);
            Assert.AreEqual<string>(joke + "\r\n", stringWriter.ToString());
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void JokeWriter_InputNull_ThrowsException()
    {
        WriteJoke writer = new();
        writer.JokeWriter(null!);
    }
}
