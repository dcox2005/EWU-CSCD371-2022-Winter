using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

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
        string nextValue = "string";
        Node<string> myNode2 = new(nextValue);
        Assert.IsNotNull(myNode2);
        Node<double> node3 = new(23.43);
        Assert.IsNotNull(node3);
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
        string value = "Some Value";
        Node<string> myNode = new(value);
        Assert.AreEqual(value, myNode.ToString());
    }

    [TestMethod]
    public void ToString_ValueIsNullShouldReturnNull_Succes()
    {
        Node<string?> myNode = new(null);
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
        Node<string> myNode = new("Value");
        Assert.AreEqual(myNode, myNode.Next);
    }

    [TestMethod]
    public void Append_AddsANewNodeToTheList_Success()
    {
        Node<string> myNode = new("Value");
        myNode.Append("Second Value");
        Assert.AreEqual("Second Value", myNode.Next.ToString());
    }

    [TestMethod]
    public void Append_MultipleNewNodesCreated_Success()
    {
        Node<string> myNode = new("Value");
        myNode.Append("Second Value");
        Assert.AreEqual("Second Value", myNode.Next.ToString());

        myNode.Append("Third Value");
        Assert.AreEqual("Third Value", myNode.Next.ToString());
        Assert.AreEqual("Second Value", myNode.Next.Next.ToString());
    }

    [TestMethod]
    public void Append_MultipleNewNodesCreatedUsingNextProperty_Success()
    {
        Node<string> myNode = CreateNodeList();
        Assert.AreEqual("Second Value", myNode.Next.ToString());
        Assert.AreEqual("Third Value", myNode.Next.Next.ToString());
        Assert.AreEqual("Fourth Value", myNode.Next.Next.Next.ToString());
    }

    [TestMethod]
    public void Append_MultipleNewNodesLoopAroundWorks_Success()
    {
        Node<string> myNode = CreateNodeList();
        Assert.AreEqual("Value", myNode.Next.Next.Next.Next.ToString());
        Assert.AreEqual(myNode, myNode.Next.Next.Next.Next);

    }

    [TestMethod]
    public void Clear_RemovesAllButTheNodeUsedToStart_Success()
    {
        Node<string> myNode = CreateNodeList();
        myNode = myNode.Clear();

        Assert.AreEqual(myNode, myNode.Next);
    }

    [TestMethod]
    public void Clear_CheckThatGarbageCollectionRemovedOld_Success()
    {
        Node<string> myNode = CreateNodeList();
        long fullListMemory = GC.GetTotalMemory(false);
        
        _ = myNode.Clear();

        GC.Collect();
        GC.WaitForPendingFinalizers();

        long clearedListMemory = GC.GetTotalMemory(false);
        //Console.WriteLine(fullListMemory);
        //Console.WriteLine(clearedListMemory);
        Assert.AreNotEqual(clearedListMemory, fullListMemory);
        Assert.IsTrue(clearedListMemory < fullListMemory);
    }

    [TestMethod]
    public void Exists_DoesValueExist_Success()
    {
        Node<string> myNode = CreateNodeList();
        myNode.Append(null!);
        Assert.IsTrue(myNode.Exists("Value"));
        Assert.IsTrue(myNode.Exists("Second Value"));
        Assert.IsTrue(myNode.Exists("Third Value"));
        Assert.IsTrue(myNode.Exists("Fourth Value"));
        Assert.IsTrue(myNode.Exists(null!));
    }

    [TestMethod]
    public void Exists_DoesValueNotExist_Success()
    {
        Node<string> myNode = CreateNodeList();
        Assert.IsFalse(myNode.Exists(null!));
        Assert.IsFalse(myNode.Exists("Fifth Value"));
        Assert.IsFalse(myNode.Exists("Sixth Value"));
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Append_ThrowsExceptionForAddingSameValueTwice_ThrowsException()
    {
        Node<string> myNode = CreateNodeList();
        myNode.Append("Value");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Append_ThrowsExceptionForAddingSameValueTwiceDifferentValue_ThrowsException()
    {
        Node<string> myNode = CreateNodeList();
        myNode.Append("Third Value");
    }

    private static Node<string> CreateNodeList()
    {
        Node<string> myNode = new("Value");
        myNode.Append("Second Value");
        myNode.Next.Append("Third Value");
        myNode.Next.Next.Append("Fourth Value");

        return myNode;
    }

}
