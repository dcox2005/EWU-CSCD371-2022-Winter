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
    public void NodeCostructor_CreatingANode_Success()
    {
        Node myNode = new();
    }
}
