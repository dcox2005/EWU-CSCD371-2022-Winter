using Microsoft.VisualStudio.TestTools.UnitTesting;

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
}
