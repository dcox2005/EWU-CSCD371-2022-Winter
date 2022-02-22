using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Costructor_CreatingANode_Success()
    {
        int value = 42;
        Node<int> myNode = new(value);
        string nextValue = "string";
        Node<string> myNode2 = new(nextValue);
        Node<double> myNode3 = new(23.43);
        Node<long> myNode4 = new(9223372036854775);
        Node<bool> myNode5 = new(true);
        Node<char> myNode6 = new('H');
        Node<float> myNode7 = new(3.14f);

        Assert.IsNotNull(myNode);
        Assert.IsNotNull(myNode2);
        Assert.IsNotNull(myNode3);
        Assert.IsNotNull(myNode4);
        Assert.IsNotNull(myNode5);
        Assert.IsNotNull(myNode6);
        Assert.IsNotNull(myNode7);
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
    public void ToString_ValueIsNullShouldReturnNull_Success()
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

        bool val = false;
        Node<bool> myNode2 = new(val);
        Assert.AreEqual("False", myNode2.ToString());
    }

    [TestMethod]
    public void Constructor_SettingNextNodeToEqualTheNodeCreated_Success()
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

    //helper method
    private static Node<string> CreateNodeList()
    {
        Node<string> myNode = new("Value");
        myNode.Append("Second Value");
        myNode.Next.Append("Third Value");
        myNode.Next.Next.Append("Fourth Value");

        return myNode;
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

    [TestMethod]
    public void Part7_ReturnAllItems()
    {
        Node<string> myNode = CreateNodeList();
        bool correct1 = false;
        bool correct2 = false;
        bool correct3 = false;
        bool correct4 = false;
        bool enteredLoop = false;

        int count = 0;
        foreach (Node<string> node in myNode)
        {
            string? value = node.ToString();
            count++;
            if (count == 1)
            {
                correct1 = (value!.Equals("Value"));
            }
            else if (count == 2)
            {
                correct2 = (value!.Equals("Second Value"));
            }
            else if (count == 3)
            {
                correct3 = (value!.Equals("Third Value"));
            }
            else if (count == 4)
            {
                correct4 = (value!.Equals("Fourth Value"));
            }
            enteredLoop = true;
        }

        Assert.IsTrue(enteredLoop);
        Assert.IsTrue(correct1);
        Assert.IsTrue(correct2);
        Assert.IsTrue(correct3);
        Assert.IsTrue(correct4);
    }
}