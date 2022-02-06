using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Costructor_CreatingANode_Success()
    {
        int value = 42;
        Node<int> myNode = new(value);
        Assert.IsNotNull(myNode);
    }

    [TestMethod]
    public void Constructor_AcceptingNullValue_Success()
    {
        Node<string> myNode = new(null!);
        Assert.IsNotNull(myNode);
    }

    [TestMethod]
    public void ToString_ValueShouldBeReturned_Success()
    {
        string value = "some value";
        Node<string> myNode = new(value);
        Assert.AreEqual(value, myNode.ToString());
    }

    [TestMethod]
    public void ToString_ValueIsNullShouldReturnNull_Succes()
    {
        Node<string?> myNode = new(null!);
        Assert.AreEqual(null, myNode.ToString());
    }

    [TestMethod]
    public void ToString_ValueIsNotOfStringTypeReturnsAsString_Success()
    {
        int value = 42;
        Node<int> myNode = new(value);
        Assert.AreEqual("42", myNode.ToString());
    }

    [TestMethod]
    public void Constructor_SettingNextNodeToEqualTheNodeCreated_Succes()
    {
        Node<string> myNode = new("value");
        Assert.AreEqual(myNode, myNode.Next);
    }



}
