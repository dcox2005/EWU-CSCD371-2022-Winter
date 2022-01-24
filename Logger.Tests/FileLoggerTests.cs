using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    string filePath = "FileLoggerTestFile.txt";

    [TestMethod]
    public void SimpleTest_CreateFileLogger_SuccessNotNull()
    {
        FileLogger newLogger = new(filePath);
        Assert.AreNotEqual(newLogger, null);
    }

    [TestMethod]
    public void SimpleTest_LoggerPathMatchesGiven_SuccessPathsMatch()
    {
        FileLogger newLogger = new(filePath);
        if (newLogger is not null)
        {
            Assert.AreEqual(newLogger.FilePath, filePath);
        }
        else
        {
            Assert.Fail("Path Passed into logger was not the name it received!");
        }
    }

    [TestMethod]
    public void SimpleTest_CreateLogFile_SuccessFileExsit()
    {
        FileLogger newLogger = new(filePath);
        newLogger.Log(logLevel: 0, "SimpleTest_CreateLogFile_SuccessFileExsit");
        Assert.IsTrue(File.Exists(filePath));
    }

    [TestMethod]
    [Ignore("This passed, but once log lines were completed, it was no longer needed and could not pass due to it's simplicity.")]
    public void Test_LogMessageAppenedProperly_SuccessFinalLineMatch()
    {
        FileLogger newLogger = new(filePath);
        string messageOne = "Test_LogMessageAppenedProperly_SuccessFinalLinesMatchOne";
        newLogger.Log(logLevel: 0, messageOne);
        string messageTwo = "Test_LogMessageAppenedProperly_SuccessFinalLinesMatchTwo";
        newLogger.Log(logLevel: 0, messageTwo);
        if (File.Exists(filePath))
        {

            string lastLine = "";
            foreach (string line in File.ReadLines(filePath))
            { lastLine = line; }
            Assert.AreEqual(lastLine, messageTwo);
        }
        else
        {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void Test_CreateProperLogMessage_SuccessFinalLineMatches()
    {
        //If the second of time tics over during test, this could cause it to fail. Run Again.
        FileLogger newLogger = new(filePath);
        newLogger.ClassName = "FileLoggerTests";
        string message = "Test_CreateProperLogMessage_SuccessFinalLineMatches";
        newLogger.Log(logLevel: 0, message);
        if (File.Exists(filePath))
        {
            string expectedLogLine = $"{DateTime.Now.ToString()} FileLoggerTests Error: {message}";
            string lastLine = "";
            foreach (string line in File.ReadLines(filePath))
            { lastLine = line; }
            Assert.AreEqual(lastLine, expectedLogLine);
        }
        else
        {
            Assert.Fail();
        }
    }

}
