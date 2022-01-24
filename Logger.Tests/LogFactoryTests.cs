using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    LogFactory factory = new();
    string classCreating = "LogFactoryTest";
    //factory.configureFileLogger("FileLoggerTestFile.txt");

    [TestMethod]
    public void SimpleTest_CreateLogFactoryWithClassName_SuccessNotNull()
    {
        Assert.AreNotEqual(factory, null);
    }

    [TestMethod]
    public void SimpleTest_FactoryCreatesFileLogger_SuccessLoggerNotNull()
    {
        factory.configureFileLogger("FileLoggerTestFile.txt");
        BaseLogger? logger = factory.CreateLogger(classCreating);
        Assert.AreNotEqual(logger, null);
    }

    [TestMethod]
    public void SimpleTest_LoggerCreatedWithClassName_SuccessNameMatches()
    {
        factory.configureFileLogger("FileLoggerTestFile.txt");
        BaseLogger? logger = factory.CreateLogger(classCreating);
        if (logger is not null)
        {
            Assert.AreEqual(classCreating, logger.ClassName);
        }
        else
        {
            Assert.Fail("Name Passed into logger was not the name it received!");
        }
    }

    [TestMethod]
    public void SimpleTest_ConfigureFileLogger_SuccessFileUpdated()
    {
        string updatedFilePath = "NewFilePath.txt";
        factory.configureFileLogger(updatedFilePath);
        Assert.AreEqual(updatedFilePath, factory.FilePath);
    }

    [TestMethod]
    public void NullTest_FactoryUsedBeforeFilePathSet_SuccessReturnsNull()
    {
        LogFactory factory = new();
        BaseLogger? logger = factory.CreateLogger(classCreating);
        Assert.AreEqual(logger, null);
    }

}
