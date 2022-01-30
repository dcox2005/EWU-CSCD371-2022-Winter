using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests;

[TestClass]
public class IJokeServiceTests
{
    [TestMethod]
    public void SimpleJoke_TestingToSeeIfJokeIsImplemented_Success()
    {
        IJokeService mockJoke = new MockJoke();
        Assert.AreEqual<string>("I have a funny knock knock joke for you", mockJoke.GetJoke());
    }


    [TestMethod]
    public void MyTestMethod()
    {
        Mock<IJokeService> mock = new();
        mock.SetupSequence(funny => funny.GetJoke()).Returns("I have a funny joke for you");

        Assert.AreEqual<string>("I have a funny joke for you", mock.Object.GetJoke());
    }

}

