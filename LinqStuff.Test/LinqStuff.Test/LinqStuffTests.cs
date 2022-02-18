using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LinqStuff.Test;

[TestClass]
public class LinqStuffTests
{
    [TestMethod]
    public MemberInfo[] getEnumerableMembers()
    {
        MemberInfo[] members = typeof(Enumerable).GetMembers();
        int count = members.Count();
        Console.WriteLine(count);
        Assert.AreEqual<int>(count, members.Length);
        return members;
    }

    [TestMethod]
    public void GetAllTheMemberNames()
    {
        MemberInfo[] members = getEnumerableMembers();
        IEnumerable<string> memberNames = members.Select(member => member.Name);
        Assert.IsTrue(memberNames.Any(name => name == "Contains"));
        Assert.IsTrue(memberNames.Any(name => name == "Aggregate"));
        Assert.IsFalse(memberNames.Any(name => name == "Map"));
        //Assert.IsTrue(memberNames.Contains("Contains"));
        //Assert.IsTrue(memberNames.Contains("Aggregate"));
        //Assert.IsFalse(memberNames.Contains("Map"));

        memberNames.Where(name => name == "Contains" || name == "Aggregate");

    }
    [TestMethod]
    public void DeferredExecution()
    {
        int count = 0;
        IEnumerable<MemberInfo> memberInfos = getEnumerableMembers().Where(item => item.Name[0] == 'C');
        IEnumerable<string> memberNames =
            memberInfos.Select(item => 
            { 
                count++; 
                return item.Name; 
            });

        Assert.AreEqual<int>(0, count);
        Assert.AreEqual<int>(7,memberNames.Count());
        Assert.AreEqual<int>(7, count);
        int temp = memberNames.Count();
        Assert.AreEqual<int>(14, count);

    }
}
