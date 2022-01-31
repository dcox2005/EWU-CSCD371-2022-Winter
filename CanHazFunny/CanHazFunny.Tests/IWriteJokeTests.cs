using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        Assert.AreEqual("Knock Knock!\r\n", stringWriter.ToString());
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
            mock.WriteJoke(joke);
            Assert.AreEqual<string>(joke + "\r\n", stringWriter.ToString());
        }
    }
}
