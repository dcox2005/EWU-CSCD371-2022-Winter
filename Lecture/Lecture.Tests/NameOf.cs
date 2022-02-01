namespace Lecture.Tests;

[TestClass]
public class NameOfTests
{
    [TestMethod]
    public void NameOf_GivenMethodName()
    {
        Assert.AreEqual<string>(
            $"ThingStudent",
            nameof(NameOfTests) + nameof(Student));
    }
}
