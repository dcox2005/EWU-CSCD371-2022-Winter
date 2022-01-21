using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lecture.Tests;

[TestClass]
public class ISavableTests
{
    [TestMethod]
    public void SimpleSave_GivenPerson_PersonString()
    {
        ISavable person = new Person("Inigo");
        Assert.AreEqual<string>("Name: Inigo; DateOfBirth: 1/1/0001", person.ToText());
    }

    [TestMethod]
    public void SimpleSave_GivenAThing_ThingString()
    {
        ISavable thing = new Thing("Thing 1");
        Assert.AreEqual<string>("Name: Thing 1", thing.ToText());
    }

    [TestMethod]
    public void SimpleSave_GivenADocument_DocumentString()
    {
        Document thing = new Document("Document 1");
        Assert.AreEqual<string>("Name: Thing 1", ((ISavable)thing).ToText());
    }
}

